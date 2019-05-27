using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SecretLib.Asymmetric;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using System.Text;
using SecretLib.Symmetric;
using Org.BouncyCastle.Crypto.Parameters;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DataGetter.Services.Impl
{
    public class TimeBasedService : BackgroundService
    {
        private readonly IV2RayCollectService v2rayService;
        private readonly HttpClient http;
        private readonly IAsymmetric asymmetric;
        private readonly ISymmetric symmetric;
        private readonly AsymmetricKeyParameter parameter;

        public TimeBasedService(
            IV2RayCollectService v2ray,
            IAsymmetric asymmetric,
            ISymmetric symmetric,
            IHttpClientFactory factory,
            IConfiguration configuration)
        {
            this.v2rayService = v2ray;
            this.http = factory.CreateClient();
            this.asymmetric = asymmetric;
            this.symmetric = symmetric;
            string path = configuration.GetValue<string>("PublicKey");
            using (TextReader reader = File.OpenText(path))
            {
                PemReader pem = new PemReader(reader);
                var pemObject = pem.ReadObject();
                this.parameter = pemObject as AsymmetricKeyParameter;
            }
            http.BaseAddress = new Uri(configuration.GetConnectionString("DataServer"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                if (stoppingToken.IsCancellationRequested)
                    return;
                try
                {
                    var data = await v2rayService.QueryV2RayDataAsync();
                    string json = JsonConvert.SerializeObject(data);
                    byte[] bytes = Encoding.UTF8.GetBytes(json);
                    RandomNumberGenerator numberGenerator = RandomNumberGenerator.Create();
                    byte[] keyData = new byte[32];
                    numberGenerator.GetBytes(keyData);
                    KeyParameter key = new KeyParameter(keyData);
                    byte[] encrytpo = symmetric.Encrypto(bytes, key);
                    byte[] keyEncrypto = asymmetric.Encrypto(key.GetKey(), parameter);
                    using (MultipartFormDataContent content = new MultipartFormDataContent())
                    using (ByteArrayContent sdata = new ByteArrayContent(encrytpo))
                    using (ByteArrayContent skeyData = new ByteArrayContent(keyEncrypto))
                    {
                        sdata.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        skeyData.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        sdata.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            FileName = "encodedData",
                            Name = "data",
                        };
                        skeyData.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            FileName = "dekey",
                            Name = "key"
                        };
                        content.Add(sdata);
                        content.Add(skeyData);
                        await http.PostAsync("/api/data", content);
                    }

                }
                catch { }
                Thread.Sleep(600000); // 10分钟
            }
        }



        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }
    }
}
