using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRDemo.WebApi.StartupExtensions
{
	public static class WebApiStartup
	{
		public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
		{
			return services;
		}
	}
}
