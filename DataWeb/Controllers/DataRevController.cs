using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Asn1;
using SecretLib.Asymmetric;
using SecretLib.Symmetric;
using Org.BouncyCastle.OpenSsl;
using System.IO;
using Org.BouncyCastle.Crypto.Parameters;
using System.Text;
using DataWeb.Entities;
using Newtonsoft.Json;
using DataWeb.DbContents;
using DataWeb.DbEntities;

namespace DataWeb.Controllers
{
    [Route("api")]
    public class DataRevController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IAsymmetric asymmetric;
        private readonly ISymmetric symmetric;
        private readonly AsymmetricKeyParameter key;
        private readonly V2RayDbContent db;

        public DataRevController(
            IConfiguration configuration,
            IAsymmetric asymmetric,
            ISymmetric symmetric,
            V2RayDbContent db)
        {
            this.configuration = configuration;
            this.symmetric = symmetric;
            this.asymmetric = asymmetric;
            this.db = db;
            string key = configuration.GetValue<string>("KeyFile");
            using (TextReader reader = System.IO.File.OpenText(key))
            {
                PemReader pem = new PemReader(reader);
                AsymmetricCipherKeyPair pair = (AsymmetricCipherKeyPair)pem.ReadObject();
                this.key = pair.Private;
            }
        }

        [HttpGet("test")]
        public string Test()
        {
            return "OK Worked";
        }


        [HttpPost("data")]
        public string RevecData([FromForm(Name = "data")]IFormFile data, [FromForm(Name = "key")]IFormFile key, [FromForm(Name = "tag")]string tag)
        {
            using (Stream sdata = data.OpenReadStream())
            using (Stream skey = key.OpenReadStream())
            {
                byte[] ekeyData = new byte[key.Length];
                skey.Read(ekeyData, 0, ekeyData.Length);
                byte[] keyData = asymmetric.Decrypto(ekeyData, this.key);
                KeyParameter aesKey = new KeyParameter(keyData);
                byte[] edata = new byte[data.Length];
                sdata.Read(edata, 0, edata.Length);
                byte[] odata = symmetric.Decrypto(edata, aesKey);
                string jsonStr = Encoding.UTF8.GetString(odata);
                IEnumerable<V2RayEntity> entities = JsonConvert.DeserializeObject<IEnumerable<V2RayEntity>>(jsonStr);
                var db = entities
                    .Where(e => e.DataSize > 0)
                    .Select(s => new DataEntity()
                    {
                        LinkType = s.LinkType,
                        Size = Convert.ToUInt64(s.DataSize),
                        User = s.User,
                        Utype = s.UserType,
                        CreateTime = DateTimeOffset.Now,
                        Tags = tag
                    });
                this.db.DataEntity.AddRange(db);
                this.db.SaveChanges();
            }
            return "OK";
        }
    }
}
