using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using DataGetter.Entities;
using V2Ray.Core.App.Stats.Command;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace DataGetter.Services.Impl
{
    public class V2RayCollectService : IV2RayCollectService
    {
        private readonly StatsService.StatsServiceClient client;
        private readonly ILogger logger;

        public V2RayCollectService(StatsService.StatsServiceClient client, ILogger<V2RayCollectService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<IEnumerable<V2RayEntity>> QueryV2RayDataAsync(CancellationToken token)
        {
            QueryStatsRequest request = new QueryStatsRequest()
            {
                Reset = true,
                Pattern = ""
            };
            QueryStatsResponse response = await client.QueryStatsAsync(request, deadline: DateTime.UtcNow.AddMinutes(1), cancellationToken: token);
            return response.Stat.Select(stat =>
            {

                string[] keys = stat.Name.Split(">>>");
                logger.LogInformation("name: {0}, v: {1}, keys : {2}", stat.Name, stat.Value, keys);
                return new V2RayEntity()
                {
                    UserType = keys[0],
                    User = keys[1],
                    LinkType = keys[3],
                    DataSize = stat.Value
                };
            });
        }
    }
}
