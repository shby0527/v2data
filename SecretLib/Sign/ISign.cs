using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Crypto;
using SecretLib.Hash;

namespace SecretLib.Sign
{
    /// <summary>
    /// 数字签名
    /// </summary>
    public interface ISign
    {
        /// <summary>
        /// 签名算法
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 签名Hash
        /// </summary>
        IHash Hash { get; }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ppk"></param>
        /// <returns></returns>
        byte[] Sign(byte[] data, AsymmetricKeyParameter ppk);

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="sign">签名数据</param>
        /// <param name="pk"></param>
        /// <returns></returns>
        bool Verify(byte[] data, byte[] sign, AsymmetricKeyParameter pk);
    }
}
