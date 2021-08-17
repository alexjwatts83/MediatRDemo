using System.Reflection;
using FluentValidation;
using MediatR;
using MediatRDemo.Application.Common.Behaviours;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRDemo.Application
{
	public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddTransient(typeof(IPipelineBehavior<,>),	typeof(ValidationBehavior<,>));

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			return services;
        }
    }
}
