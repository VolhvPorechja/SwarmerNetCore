using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swarmer.Common.Logging;
using Swarmer.TM.DAL;
using Swashbuckle.Swagger.Model;

namespace Swarmer.TM.Service
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
            TournamentsDAL.Init();

            services.AddSingleton(Configuration);
			services.AddSingleton(provider => new LogMessagesManager("TM"));


            // Add framework services.
            services.AddMvc();
            services.ConfigureSwaggerGen(opts =>
            {
                opts.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Tournaments management service",
                });
                opts.IncludeXmlComments(Configuration["Swagger:xmldocpath"]);
                opts.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
