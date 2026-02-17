namespace TrainingManagementSystemAPI.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddValidatorsFromAssemblies(this IServiceCollection services)
        {
            return services;
        }
    }
}