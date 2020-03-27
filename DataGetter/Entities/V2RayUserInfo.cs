using System;
using System.Collections.Generic;
using System.Text;

namespace DataGetter.Entities
{
    /// <summary>
    /// V2Ray 用户信息
    /// </summary>
    public class V2RayUserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 额外ID
        /// </summary>
        public uint AlterId { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public uint Level { get; set; }

        /// <summary>
        /// 接口标记
        /// </summary>
        public string InBoundTag { get; set; }
    }
}
