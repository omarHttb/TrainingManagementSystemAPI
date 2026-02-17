using Application;
using Application.RepositoryInterfaces;
using Infastructure;
using Infastructure.Repositories;

namespace TrainingManagementSystemAPI.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddValidatorsFromAssemblies(this IServiceCollection services)
        {
            return services;
        }
    }
}