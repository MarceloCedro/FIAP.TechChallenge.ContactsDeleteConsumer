using FIAP.TechChallenge.ContactsDeleteConsumer.Application.Applications;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Applications;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Application
{
    public static class ApplicationDependency
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection service)
        {
            service.AddScoped<IContactApplication, ContactApplication>();

            return service;
        }
    }
}
