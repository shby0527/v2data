using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DataWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHost(web => web.UseStartup<Startup>().UseKestrel());
    }
}
