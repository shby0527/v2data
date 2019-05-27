using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace SecretLib.Hash
{
    public class MD5Hash : IHash
    {
        public string Name => "MD5";

        public byte[] HashCompute(byte[] message)
        {
            IDigest digest = new MD5Digest();
            byte[] output = new byte[digest.GetDigestSize()];
            digest.BlockUpdate(message, 0, message.Length);
            digest.DoFinal(output, 0);
            return output;
        }
    }
}
