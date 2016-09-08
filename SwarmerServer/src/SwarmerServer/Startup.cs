using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SwarmerServer.Repositories;
using Swashbuckle.Swagger.Model;

namespace SwarmerServer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var pathToDoc = Configuration["Swagger:path"];

            // Add framework services.
            services.AddMvc();
            services.AddSingleton<UsersRepository>();
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(opts =>
            {
                opts.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Accounts Management Module",
                });
                opts.IncludeXmlComments(pathToDoc);
                opts.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            app.UseMvc();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
