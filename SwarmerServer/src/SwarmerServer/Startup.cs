﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Swarmer.AM.Contracts.Providers;
using Swarmer.AM.Contracts.Repositories;
using Swarmer.AM.Core;
using Swarmer.AM.DAL;
using Swarmer.Common.Logging;
using SwarmerServer.Stubs;
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

            AccountsDal.Init();
			services.AddSingleton<RepositoriesManagerContract>(provider => new RepositoriesManager(Configuration["db:connections:main"]));
		    services.AddSingleton<SignUpActivationProviderContract>(provider => new StubSignUpProvider());

			services.AddSingleton(provider => new AccountsManagementCore
			{
                AuthenticationApi = new AuthenticationApi(provider.GetService<RepositoriesManagerContract>()),
				UsersApi = new UsersApi(provider.GetService<RepositoriesManagerContract>()),
				TeamsApi = new TeamsApi(provider.GetService<RepositoriesManagerContract>())
			});

			services.AddSingleton(provider => new LogMessagesManager("AM"));
		    services.AddSingleton(Configuration);

			// Configure swagger
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
