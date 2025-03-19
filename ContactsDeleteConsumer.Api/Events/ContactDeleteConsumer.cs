using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Applications;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.DTOs.EntityDTOs;
using MassTransit;

namespace ContactsDeleteConsumer.Api.Events
{
    public class ContactDeleteConsumer : IConsumer<ContactDto>
    {
        private readonly IContactApplication _contactApplication;
        private Timer _timer;

        public ContactDeleteConsumer(IContactApplication contactApplication)
        {
            _contactApplication = contactApplication;
        }

        public Task Consume(ConsumeContext<ContactDto> context)
        {
            try
            {
                if (context.Message != null)
                {
                    return _contactApplication.DeleteContactAsync(context.Message);
                }
                else
                    throw new Exception("Message cannot be null or empty.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
