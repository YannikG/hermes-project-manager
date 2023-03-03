using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Core.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Services;
using Microsoft.AspNetCore.Builder;

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

			// Register serivces
			services.AddScoped<ProjectService>();
			services.AddScoped<TimelineGroupService>();
			services.AddScoped<TimelineItemService>();

			return services;
		}

		public static void CoreInitDatabase(this IApplicationBuilder app)
		{
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
			{
				scope.ServiceProvider.GetRequiredService<ProjectContext>().Database.Migrate();
			}
        }
    }
}

