using MediatRDemo.WebApi.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRDemo.WebApi.StartupExtensions
{
	public static class HealthCheckStartup
	{
		public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHealthChecks().AddCheck<DbHealthCheck>("Database");
			services.AddSingleton<DbHealthCheck>();

			return services;
		}
	}
}
