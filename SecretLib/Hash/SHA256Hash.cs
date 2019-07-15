using System;
using Org.BouncyCastle.Crypto.Digests;

namespace SecretLib.Hash
{
    public class SHA256Hash : IHash
    {
        public string Name => "SHA-256";

        public byte[] HashCompute(byte[] message)
        {
            Sha256Digest sha256 = new Sha256Digest();
            byte[] output = new byte[sha256.GetDigestSize()];
            sha256.BlockUpdate(output, 0, message.Length);
            sha256.DoFinal(output, 0);
            return output;
        }
    }
}
