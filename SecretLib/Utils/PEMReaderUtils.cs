using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecretLib.Utils
{
    public static class PEMReaderUtils
    {
        public static AsymmetricKeyParameter ReadAsymmetricKey(string pem)
        {
            using StringReader reader = new StringReader(pem);
            PemReader pr = new PemReader(reader);
            return pr.ReadObject() as AsymmetricKeyParameter;
        }
    }
}
