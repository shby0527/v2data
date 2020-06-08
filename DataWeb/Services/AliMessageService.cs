using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto.Parameters;
using SecretLib.Mac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataWeb.Services
{
    public class AliMessageService
    {
        public const string SMS_BASE = @"https://dysmsapi.aliyuncs.com/";
        private readonly HttpClient http;
        private readonly IMac passwordService;
        private readonly ILogger logger;
        private readonly string code;
        private readonly string sign;
        private readonly string accessKey;
        private readonly string accessSecret;

        public AliMessageService(
            IHttpClientFactory http,
            IConfiguration configuration,
            ILogger<AliMessageService> logger,
            IMac passwordService)
        {
            this.http = http.CreateClient();
            this.passwordService = passwordService;
            this.logger = logger;
            IConfigurationSection section = configuration.GetSection("AliSms");
            code = section.GetValue<string>("Code");
            sign = section.GetValue<string>("Sign");
            accessKey = section.GetValue<string>("AccessKey");
            accessSecret = section.GetValue<string>("AccessSecret");
        }

        public async Task<bool> SendMessage(string recipient, string title, string context)
        {
            IDictionary<string, string> args = new SortedDictionary<string, string>(StringComparer.Ordinal)
            {
                { "SignatureMethod", "HMAC-SHA1" },
                { "SignatureNonce", Guid.NewGuid().ToString() },
                { "AccessKeyId", accessKey },
                { "SignatureVersion", "1.0" },
                { "Action", "SendSms" },
                { "Format", "json" },
                { "RegionId", "cn-hangzhou" },
                { "Timestamp", DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") },
                { "Version", "2017-05-25" },
                { "PhoneNumbers", recipient },
                { "SignName", sign },
                { "TemplateCode", code },
                { "TemplateParam", $"{{\"code\":\"{context}\"}}" }
            };
            StringBuilder sb = new StringBuilder();
            foreach (var item in args)
            {
                sb.Append(UrlEncoder(item.Key))
                    .Append("=")
                    .Append(UrlEncoder(item.Value))
                    .Append("&");
            }
            sb.Remove(sb.Length - 1, 1);
            string querystring = sb.ToString();
            logger.LogDebug("现在的查询字符串是：{}", querystring);
            string finalString = $@"GET&{UrlEncoder("/")}&{UrlEncoder(querystring)}";
            logger.LogDebug("待签名字符串：{}", finalString);
            KeyParameter keyParameter = new KeyParameter(Encoding.UTF8.GetBytes($"{accessSecret}&"));
            string signedString = UrlEncoder(Convert.ToBase64String(passwordService.MessageCode(Encoding.UTF8.GetBytes(finalString), keyParameter)));
            logger.LogDebug("签名后内容：{}", signedString);
            string url = $@"{SMS_BASE}?Signature={signedString}&{querystring}";
            logger.LogDebug("请求地址：{}", url);
            var result = await http.GetAsync(url);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                JToken jobj = JsonConvert.DeserializeObject<JToken>(await result.Content.ReadAsStringAsync());
                if ("OK".Equals((string)jobj["Code"], StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private string UrlEncoder(string url)
        {
            return WebUtility.UrlEncode(url)
                        .Replace("+", "%20")
                        .Replace("*", "%2A")
                        .Replace("%7E", "~");
        }
    }
}
