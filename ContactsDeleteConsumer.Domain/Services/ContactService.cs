using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Entities;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Repositories;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Services
{
    public class ContactService(IContactRepository contactRepository, ILogger<ContactService> logger) : IContactService
    {
        private readonly IContactRepository _contactRepository = contactRepository;
        private readonly ILogger<ContactService> _logger = logger;

        public async Task DeleteAsync(Contact contact)
        {
            try
            {
                await _contactRepository.DeleteAsync(contact);
            }
            catch (Exception)
            {
                var message = "Some error occour when trying to delete a Contact.";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}