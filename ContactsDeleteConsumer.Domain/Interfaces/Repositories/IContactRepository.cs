using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Entities;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task DeleteAsync(Contact contact);
    }
}
