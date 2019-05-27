using System;

namespace SecretLib.Hash
{
    /// <summary>
    /// 散列函数
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// 算法名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 计算散列
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        byte[] HashCompute(byte[] message);
    }
}