using Microsoft.EntityFrameworkCore;
using NetCoreKit.Infrastructure.EfCore.Db;

namespace TodoWebApi.Infrastructure.Db
{
	public class TodoDbContext : ApplicationDbContext
	{
		public TodoDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}