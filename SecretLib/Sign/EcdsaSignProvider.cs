using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using SecretLib.Hash;

namespace SecretLib.Sign
{
    /// <summary>
    ///  Ecdsa 签名程序
    /// </summary>
    public class EcdsaSignProvider : ISign
    {
        private IHash _hash;

        public EcdsaSignProvider(IHash hash)
        {
            _hash = hash;
        }

        public string Name => $"{Hash.Name}/ECDSA";

        public IHash Hash => _hash;

        public byte[] Sign(byte[] data, AsymmetricKeyParameter ppk)
        {
            ECDsaSigner dsa = new ECDsaSigner();
            DsaDigestSigner signer = new DsaDigestSigner(dsa, DigestUtilities.GetDigest(_hash.Name));
            signer.Init(true, ppk);
            signer.BlockUpdate(data, 0, data.Length);
            return signer.GenerateSignature();

        }

        public bool Verify(byte[] data, byte[] sign, AsymmetricKeyParameter pk)
        {
            ECDsaSigner dsa = new ECDsaSigner();
            DsaDigestSigner signer = new DsaDigestSigner(dsa, DigestUtilities.GetDigest(_hash.Name));
            signer.Init(false, pk);
            signer.BlockUpdate(data, 0, data.Length);
            return signer.VerifySignature(sign);
        }
    }
}
