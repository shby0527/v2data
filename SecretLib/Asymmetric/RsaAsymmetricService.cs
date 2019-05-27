using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;

namespace SecretLib.Asymmetric
{
    public class RsaAsymmetricService : IAsymmetric
    {
        public string Name => "RSA/PKCS1";

        public byte[] Decrypto(byte[] data, AsymmetricKeyParameter ppk)
        {
            BufferedAsymmetricBlockCipher rsa = new BufferedAsymmetricBlockCipher(new Pkcs1Encoding(new RsaEngine()));
            rsa.Init(false, ppk);
            return rsa.DoFinal(data);
        }

        public byte[] Encrypto(byte[] data, AsymmetricKeyParameter pk)
        {
            BufferedAsymmetricBlockCipher rsa = new BufferedAsymmetricBlockCipher(new Pkcs1Encoding(new RsaEngine()));
            rsa.Init(true, pk);

            return rsa.DoFinal(data);
        }
    }
}
