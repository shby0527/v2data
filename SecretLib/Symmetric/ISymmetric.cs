

using Org.BouncyCastle.Crypto.Parameters;

namespace SecretLib.Symmetric
{
    /// <summary>
    /// 对称加密算法的通用接口
    /// </summary>
    public interface ISymmetric
    {
        /// <summary>
        /// 加密算法
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] Encrypto(byte[] data, KeyParameter key);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] Decrypto(byte[] data, KeyParameter key);
    }
}