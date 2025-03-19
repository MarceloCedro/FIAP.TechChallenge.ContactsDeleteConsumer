using FIAP.TechChallenge.ContactsDeleteProducer.Domain.DTOs.EntityDTOs;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Applications
{
    public interface IContactApplication
    {
        Task DeleteContactAsync(ContactDto contactDto);
    }
}