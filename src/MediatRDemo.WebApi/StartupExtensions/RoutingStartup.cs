using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRDemo.WebApi.StartupExtensions
{
	public static class RoutingStartup
	{
		public static void AddCustomRouting(this IServiceCollection services)
		{
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
			});
		}

		public static void UseCustomRouting(this IApplicationBuilder app)
		{
			app.UseRouting();
		}
	}
}
