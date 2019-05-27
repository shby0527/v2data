using System;
using Org.BouncyCastle.Crypto.Parameters;

namespace SecretLib.Mac
{
    /// <summary>
    /// Mac算法
    /// </summary>
    public interface IMac
    {
        /// <summary>
        /// 算法名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 计算消息码
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] MessageCode(byte[] message, KeyParameter key);
    }
}