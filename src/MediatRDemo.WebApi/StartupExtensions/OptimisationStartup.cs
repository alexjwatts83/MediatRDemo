using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.IO.Compression;

namespace MediatRDemo.WebApi.StartupExtensions
{
	public static class OptimisationStartup
	{
		public static void AddCustomOptimisation(this IServiceCollection services)
		{
			services.AddResponseCaching();

			services.AddResponseCompression();

			services.Configure<GzipCompressionProviderOptions>(options =>
			{
				options.Level = CompressionLevel.Fastest;
			});
		}

		public static void UseCustomOptimisation(this IApplicationBuilder app)
		{
			app.UseResponseCaching();

			app.UseResponseCompression();

			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = (context) =>
				{
					var headers = context.Context.Response.GetTypedHeaders();

					headers.CacheControl = new CacheControlHeaderValue
					{
						Public = true,
						MaxAge = TimeSpan.FromDays(8)
					};
				}
			});
		}
	}
}
