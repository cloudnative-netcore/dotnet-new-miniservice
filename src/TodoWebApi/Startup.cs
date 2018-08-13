using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NetCoreKit.Infrastructure.AspNetCore.Miniservice;
using NetCoreKit.Infrastructure.EfCore.SqlServer;
using System.Collections.Generic;
using System.Reflection;
using TodoWebApi.Infrastructure.Db;

namespace TodoWebApi
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			var assemblies = new HashSet<Assembly>
			{
				typeof(Startup).GetTypeInfo().Assembly,
				typeof(MiniServiceExtensions).GetTypeInfo().Assembly
			};

			var serviceParams = new ServiceParams
			{
				{"assemblies", assemblies}
			};

			services.AddScoped(sp => serviceParams);
			services.AddEfCoreSqlServer();
			services.AddMiniService<TodoDbContext>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseMiniService();
		}
	}
}
