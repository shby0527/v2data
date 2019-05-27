using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Modes;

namespace SecretLib.Symmetric
{
    public class AesCBCService : ISymmetric
    {
        public string Name => "AES/CBC/PKCS7";

        public byte[] Decrypto(byte[] data, KeyParameter key)
        {
            PaddedBufferedBlockCipher aes = new PaddedBufferedBlockCipher(new CbcBlockCipher(new AesEngine()), new Pkcs7Padding());
            aes.Init(false, key);
            return aes.DoFinal(data);
        }

        public byte[] Encrypto(byte[] data, KeyParameter key)
        {
            PaddedBufferedBlockCipher aes = new PaddedBufferedBlockCipher(new CbcBlockCipher(new AesEngine()), new Pkcs7Padding());
            aes.Init(true, key);
            return aes.DoFinal(data);
        }
    }
}
