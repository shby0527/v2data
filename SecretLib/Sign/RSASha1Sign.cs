using Org.BouncyCastle.Crypto;
using SecretLib.Hash;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretLib.Sign
{
    public class RSASha1Sign : ISign
    {
        public string Name => "RSA1Sign";

        public byte[] Sign(byte[] data, AsymmetricKeyParameter ppk)
        {
            throw new NotImplementedException();
        }

        public bool Verify(byte[] data, byte[] sign, AsymmetricKeyParameter pk)
        {
            throw new NotImplementedException();
        }
    }
}
