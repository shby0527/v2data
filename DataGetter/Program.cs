using System;
using Microsoft.Extensions.Hosting;

namespace DataGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
        
            builder.Build().Run();
        }
    }
}
