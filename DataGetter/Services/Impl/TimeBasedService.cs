using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace DataGetter.Services.Impl
{
    public class TimeBasedService : BackgroundService
    {
        private readonly IV2RayCollectService v2rayService;
        private readonly HttpClient http;
        public TimeBasedService(IV2RayCollectService v2ray, IHttpClientFactory factory, IConfiguration configuration)
        {
            this.v2rayService = v2ray;
            this.http = factory.CreateClient();
            http.BaseAddress = new Uri(configuration.GetConnectionString("DataServer"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                if (stoppingToken.IsCancellationRequested)
                    return;
                try
                {
                    var data = await v2rayService.QueryV2RayDataAsync();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(data));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "UTF-8" };
                    await http.PostAsync("/api/data", content);
                }
                catch { }
                Thread.Sleep(600000); // 10分钟
            }
        }



        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }
    }
}
