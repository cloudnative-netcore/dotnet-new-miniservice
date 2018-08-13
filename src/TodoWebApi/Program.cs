using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NetCoreKit.Infrastructure.EfCore.Extensions;
using TodoWebApi.Infrastructure.Db;

namespace TodoWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var webHost = CreateWebHostBuilder(args).Build();
			if ((webHost.Services.GetService(typeof(IHostingEnvironment)) as IHostingEnvironment).IsDevelopment())
			{
				// webHost = webHost.RegisterDbContext<TodoDbContext>();
			}

			webHost.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
