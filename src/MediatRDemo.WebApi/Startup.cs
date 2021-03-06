using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatRDemo.Application;
using MediatRDemo.WebApi.StartupExtensions;
using MediatRDemo.Infrastructure.Persistence.DependencyInjection;

namespace MediatRDemo.WebApi
{
	public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
			services.AddSwaggerDocumentation();
			services.AddCustomHealthChecks(_configuration);
			services.AddApplicationServices(_configuration);
			services.AddPersistenceServices(_configuration);
			services.AddWebApiServices(_configuration);
			services.AddCustomRouting();
			services.AddCustomOptimisation();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			app.UseSwaggerDocumentation();
			app.UseHttpsRedirection();
			app.UseCustomRouting();
			app.UseCustomOptimisation();
			app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
				endpoints.MapCustomHealthChecks();
				endpoints.MapControllers();
            });
        }
    }
}
