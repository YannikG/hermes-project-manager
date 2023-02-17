using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Core.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Core
{
	public static class CoreExtensions
    {
		public static IServiceCollection ConfigureCore(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetValue<string>("ConnectionString")!;

			services.AddDbContext<ProjectContext>(o =>
				o.UseSqlite(connectionString, c => c.MigrationsAssembly("ProjectManager.Web"))
			);

			return services;
		}
	}
}

