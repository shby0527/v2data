using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataWeb.DbContents;
using DataWeb.DbEntities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using SecretLib.Asymmetric;
using SecretLib.Sign;
using SecretLib.Symmetric;
using SecretLib.Utils;

namespace DataWeb.Controllers
{
    [EnableCors]
    [Route("api/v2data")]
    public class QueryController : Controller
    {
        private readonly V2RayDbContent db;

        private readonly ISign sign;

        private readonly IAsymmetric asymmetric;
        private readonly ISymmetric symmetric;

        private readonly AsymmetricKeyParameter privateKey;

        public QueryController(
            V2RayDbContent db,
            IConfiguration configuration,
            ISign sign,
            IAsymmetric asymmetric,
            ISymmetric symmetric)
        {
            this.db = db;
            this.sign = sign;
            this.asymmetric = asymmetric;
            this.symmetric = symmetric;
            string key = configuration.GetValue<string>("KeyFile");
            privateKey = PEMReaderUtils.ReadAsymmetricKey(key);
        }

        [HttpGet]
        public IEnumerable<DataEntity> Query([FromQuery]string name, [FromQuery] DateTimeOffset? start, [FromQuery] DateTimeOffset? end, [FromQuery]string tag)
        {
            IQueryable<DataEntity> data = db.DataEntity.AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(p => p.User == name);
            }
            if (start != null)
            {
                data = data.Where(p => p.CreateTime >= start);
            }
            if (end != null)
            {
                data = data.Where(p => p.CreateTime <= end);
            }
            if (!string.IsNullOrEmpty(tag))
            {
                data = data.Where(p => p.Tags == tag);
            }

            return data.ToArray();
        }

        [HttpGet("users")]
        public string GetServerUsers([FromQuery]uint serverId, [FromQuery]string code, [FromQuery]string keycode)
        {
            var servers = (from p in db.ServerInfos
                         .Include(e => e.ServerUsers)
                         .AsNoTracking()
                           where p.Id == serverId
                           select p).ToArray();
            var server = servers.FirstOrDefault();
            if (server == null) return string.Empty;
            // 读取code, 并读取keycode （对 code 的签名）,校验通过后表示合法服务器请求，可放行
            byte[] origin = Convert.FromBase64String(code);
            byte[] sign = Convert.FromBase64String(keycode);
            var key = PEMReaderUtils.ReadAsymmetricKey(server.PublicKey);
            // 签名验证不通过
            if (!this.sign.Verify(origin, sign, key)) return string.Empty;
            byte[] aesKey = new byte[32];
            using RandomNumberGenerator numberGenerator = RandomNumberGenerator.Create();
            numberGenerator.GetBytes(aesKey);
            KeyParameter aes = new KeyParameter(aesKey);
            string dataJson = JsonConvert.SerializeObject(server.ServerUsers);
            byte[] resultOrigin = Encoding.UTF8.GetBytes(dataJson);
            byte[] cryptedData = symmetric.Encrypto(resultOrigin, aes);
            byte[] cryptedKey = asymmetric.Encrypto(aesKey, key);
            byte[] resultSign = this.sign.Sign(cryptedData, privateKey);
            return $"{Convert.ToBase64String(cryptedKey)},{Convert.ToBase64String(cryptedData)},{Convert.ToBase64String(resultSign)}";
        }
    }
}
