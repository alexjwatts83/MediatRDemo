using MediatRDemo.Application.Interfaces;
using MediatRDemo.Infrastructure.Persistence.Configurations;
using MediatRDemo.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRDemo.Infrastructure.Persistence.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringSettings>(configuration.GetSection(ConnectionStringSettings.Section));
            //services.AddTransient<ILocationGenericCrudRepositoryScripts, LocationGenericCrudRepositoryScripts>();
            //services.AddTransient<IMoviesGenericCrudRepositoryScripts, MoviesGenericCrudRepositoryScripts>();
            //services.AddTransient<ITagsGenericCrudRepositoryScripts, TagsGenericCrudRepositoryScripts>();
            services.AddScoped(typeof(IGenericCrudRepository<,>), typeof(GenericCrudRepository<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
