using System;
using Org.BouncyCastle.Crypto;

namespace SecretLib.Asymmetric
{
    public interface IAsymmetric
    {
        /// <summary>
        /// 签名算法
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        byte[] Encrypto(byte[] data, AsymmetricKeyParameter pk);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ppk"></param>
        /// <returns></returns>
        byte[] Decrypto(byte[] data, AsymmetricKeyParameter ppk);
    }
}