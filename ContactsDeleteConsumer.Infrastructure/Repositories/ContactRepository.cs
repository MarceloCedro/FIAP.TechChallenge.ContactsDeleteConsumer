using FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure.Data;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Entities;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FIAP.TechChallenge.ContactsDeleteConsumer.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository

    {
        private readonly ContactsDbContext _context;

        public ContactRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}