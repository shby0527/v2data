using DataWeb.DbContents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecretLib.Asymmetric;
using SecretLib.Hash;
using SecretLib.Sign;
using SecretLib.Symmetric;

namespace DataWeb
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddHealthChecks();

            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson()
                .AddControllersAsServices();
            services.AddDbContextPool<V2RayDbContent>((provider, builder) =>
            {
                ILoggerFactory factory = provider.GetRequiredService<ILoggerFactory>();
                string connection = configuration.GetConnectionString("MySQL");
                builder.UseMySql(connection)
                .UseLoggerFactory(factory);
            });
            services.AddSingleton<ISymmetric, AesCBCService>();
            services.AddSingleton<IAsymmetric, RsaAsymmetricService>();
            services.AddSingleton<IHash, SHA256Hash>();
            services.AddSingleton<ISign, RSASha1Sign>();
            services.AddCors(p =>
            {
                p.DefaultPolicyName = "default";
                p.AddDefaultPolicy(x =>
                {
                    x.AllowAnyHeader();
                    x.AllowAnyMethod();
                    x.WithOrigins("https://v2.umiblog.cn", "http://localhost:8080");
                    x.AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapHealthChecks("/health");
                endpoint.MapDefaultControllerRoute();
            });
        }
    }
}
