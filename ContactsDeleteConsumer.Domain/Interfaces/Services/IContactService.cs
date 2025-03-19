using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Entities;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Services
{
    public interface IContactService
    {
        Task DeleteAsync(Contact contact);
    }
}