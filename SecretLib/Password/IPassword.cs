using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretLib.Password
{
    /// <summary>
    /// 密码存储计算
    /// </summary>
    public interface IPassword
    {
        /// <summary>
        /// 计算密码
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="salt"></param>
        /// <param name="key"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        byte[] GetEncodedPassword(byte[] origin, byte[] salt, KeyParameter key, params object[] others);
    }
}
