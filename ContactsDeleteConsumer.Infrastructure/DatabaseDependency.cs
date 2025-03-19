using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Repositories;
using FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure.Data;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure
{
    public static class DatabaseDependency
    {
        public static IServiceCollection AddRepositoriesDependency(this IServiceCollection service)
        {
            service.AddScoped<IContactRepository, ContactRepository>();

            return service;
        }

        public static IServiceCollection AddDbContextDependency(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ContactsDbContext>(options => options.UseMySql(connectionString,
                                                               new MySqlServerVersion(new Version(8, 0, 21)),
                                                               mySqlOptions => mySqlOptions.MigrationsAssembly("FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure")));

            return service;
        }
    }
}
