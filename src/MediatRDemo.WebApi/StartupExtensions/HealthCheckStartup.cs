using HealthChecks.UI.Client;
using MediatRDemo.WebApi.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
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

		public static void MapCustomHealthChecks(this IEndpointRouteBuilder endpoints)
		{
			endpoints.MapHealthChecks("/health", new HealthCheckOptions()
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
		}
	}
}
