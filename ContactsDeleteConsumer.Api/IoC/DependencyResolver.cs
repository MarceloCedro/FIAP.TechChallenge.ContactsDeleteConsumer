using FIAP.TechChallenge.ContactsDeleteConsumer.Application;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain;
using FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure;

namespace ContactsDeleteConsumer.Api.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services, string connectionString)
        {
            services.AddRepositoriesDependency();
            services.AddDbContextDependency(connectionString);
            services.AddServicesDependency();
            services.AddApplicationDependency();
        }
    }
}
