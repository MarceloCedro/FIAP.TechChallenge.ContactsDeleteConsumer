using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Entities;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Applications;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Services;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.DTOs.EntityDTOs;
using Microsoft.Extensions.Logging;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Application.Applications
{
    public class ContactApplication(IContactService contactService,
                                    ILogger<ContactApplication> logger) : IContactApplication
    {
        private readonly IContactService _contactService = contactService;
        private readonly ILogger<ContactApplication> _logger = logger;

        public async Task DeleteContactAsync(ContactDto contactDto)
        {
            try
            {
                var contact = new Contact
                {
                    Id = contactDto.Id,
                    Name = contactDto.Name,
                    Email = contactDto.Email,
                    AreaCode = contactDto.AreaCode,
                    Phone = contactDto.Phone
                };

                await _contactService.DeleteAsync(contact);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}