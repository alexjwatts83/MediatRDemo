using MediatRDemo.Functions.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

[assembly: FunctionsStartup(typeof(MediatRDemo.Functions.Startup))]
namespace MediatRDemo.Functions
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			//var configuration = new ConfigurationBuilder()
			//	.AddUserSecrets(Assembly.GetExecutingAssembly(), false)
			//	.AddEnvironmentVariables()
			//	.Build();

			//builder
			//	.Services
			//	.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), configuration))
			//	.AddTransient<IYouTubeApiService, YouTubeApiService>();
			var services = builder.Services;
			services.AddScoped<IYouTubeApiService, YouTubeApiService>();
		}

		public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
		{
			var config = builder.ConfigurationBuilder.Build();
			var context = builder.GetContext();

			builder.ConfigurationBuilder
				.SetBasePath(context.ApplicationRootPath)
				.AddJsonFile("local.settings.json", optional: true, reloadOnChange: false)
				.AddUserSecrets(Assembly.GetExecutingAssembly(), true)
				.AddEnvironmentVariables();
		}
	}
}
