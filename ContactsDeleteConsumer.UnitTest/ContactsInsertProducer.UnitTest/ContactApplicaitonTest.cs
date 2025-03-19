using FIAP.TechChallenge.ContactsDeleteConsumer.Application.Applications;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Entities;
using FIAP.TechChallenge.ContactsDeleteConsumer.Domain.Interfaces.Services;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.DTOs.EntityDTOs;
using Microsoft.Extensions.Logging;
using Moq;

namespace ContactsInsertProducer.UnitTest
{
    public class ContactApplicaitonTest
    {
        private readonly Mock<IContactService> _contactServiceMock;
        private readonly Mock<ILogger<ContactApplication>> _loggerMock;
        private readonly ContactApplication contactApplication;

        public ContactApplicaitonTest()
        {
            _contactServiceMock = new Mock<IContactService>();
            _loggerMock = new Mock<ILogger<ContactApplication>>();

            contactApplication = new ContactApplication(_contactServiceMock.Object,
                                                        _loggerMock.Object);
        }
        
        private ContactDto GetMockedContactDto()
            => new ()
            {
                Id = 1,
                Name = "Marcelo Cedro",
                Email = "marcel1234ocedro@gmail.com",
                AreaCode = "11",
                Phone = "982840611"
            };

        private async Task SetupDomainServiceAsync(bool exception)
        {
            if (exception)
                _contactServiceMock.Setup(u => u.DeleteAsync(It.IsAny<Contact>())).ThrowsAsync(new Exception("Simulated Error"));
            else
                _contactServiceMock.Setup(u => u.DeleteAsync(It.IsAny<Contact>()));
        }

        [Fact]
        public async Task UpdateContactAsyncException()
        {
            await SetupDomainServiceAsync(true);
            var expectedPostContact = GetMockedContactDto();

            Action testCode = () => { };

            var exception = Assert.ThrowsAsync<Exception>(() => contactApplication.DeleteContactAsync(expectedPostContact));

            Assert.Equal("Simulated Error", exception.Result.Message);
        }

        [Fact]
        public async Task UpdateContactAsyncSuccess()
        {
            await SetupDomainServiceAsync(false);
            var expectedPostContact = GetMockedContactDto();

            await contactApplication.DeleteContactAsync(expectedPostContact);

            await VerifyUpdateContactAsync(Times.Once());
        }
       
        private async Task VerifyUpdateContactAsync(Times times)
        {
            _contactServiceMock.Verify(u => u.DeleteAsync(It.IsAny<Contact>()), times);
        }
    }
}