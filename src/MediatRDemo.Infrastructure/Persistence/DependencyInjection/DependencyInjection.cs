using MediatRDemo.Application.Common.Interfaces;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Infrastructure.Persistence.Configurations;
using MediatRDemo.Infrastructure.Persistence.Repositories;
using MediatRDemo.Infrastructure.Persistence.RepositoryScripts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRDemo.Infrastructure.Persistence.DependencyInjection
{
	public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringSettings>(configuration.GetSection(ConnectionStringSettings.Section));
            services.AddTransient<IGoalTasksGenericCrudRepositoryScripts, GoalTasksGenericCrudRepositoryScripts>();
			services.AddTransient<IGoalGenericCrudRepositoryScripts, GoalGenericCrudRepositoryScripts>();
			services.AddTransient<ITwelveWeekYearGenericCrudRepositoryScripts, TwelveWeekYearGenericCrudRepositoryScripts>();
			services.AddScoped(typeof(IGenericCrudRepository<,>), typeof(GenericCrudRepository<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
