using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatRDemo.Application;
using MediatRDemo.WebApi.Services;
using MediatRDemo.Application.Interfaces;
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
			services.AddApplicationServices(_configuration);
			services.AddPersistenceServices(_configuration);
			services.AddTransient<INotifierMediatorService, NotifierMediatorService>();
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
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
