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
        public Startup(IConfiguration configuration, ILoggerFactory factory)
        {
            Configuration = configuration;
            this.factory = factory;
        }

        private readonly ILoggerFactory factory;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddControllersAsServices();
            services.AddDbContextPool<V2RayDbContent>(builder =>
            {
                string connection = Configuration.GetConnectionString("MySQL");
                builder.UseMySql(connection)
                .UseLoggerFactory(factory);
            });
            services.AddSingleton<ISymmetric, AesCBCService>();
            services.AddSingleton<IAsymmetric, RsaAsymmetricService>();
            services.AddSingleton<IHash, SHA256Hash>();
            services.AddSingleton<ISign, EcdsaSignProvider>();
            services.AddCors(p =>
            {
                p.DefaultPolicyName = "default";
                p.AddDefaultPolicy(x =>
                {
                    x.AllowAnyHeader();
                    x.AllowAnyMethod();
                    x.AllowAnyOrigin();
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
