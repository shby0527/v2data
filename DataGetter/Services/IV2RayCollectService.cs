using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataGetter.Entities;

namespace DataGetter.Services
{
    /// <summary>
    /// v2ray收集系统
    /// </summary>
    public interface IV2RayCollectService
    {
        Task<IEnumerable<V2RayEntity>> QueryV2RayDataAsync(CancellationToken token);
    }
}
