using DataGetter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataGetter.Services
{
    /// <summary>
    /// V2Ray 用户操作服务
    /// </summary>
    public interface IUserOperatorService
    {
        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <param name="users">用户列表</param>
        /// <returns>成功添加的用户</returns>
        int InitUsers(IEnumerable<V2RayUserInfo> users);

        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>是否成功</returns>
        bool AddUser(V2RayUserInfo user);

        /// <summary>
        /// 移除一个用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>是否成功</returns>
        bool RemoveUser(V2RayUserInfo user);
    }
}
