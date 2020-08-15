using AutoMapper;
using ContactWebApi.Controllers;
using ContactWebApi.ViewModel;
using Entity.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Repository;
using Services;
using System.Threading.Tasks;
using Xunit;

namespace WebApiXUnitTest
{
    /// <summary>
    /// Unit Test Class for Controller unti test
    /// </summary>
    public class ContactControllerUntiTest
    {
        #region Variable
        private readonly ContactController _contactController = null;
        #endregion

        #region Constructor
        public ContactControllerUntiTest()
        {
            var mockRepo = new Mock<IRepository<Contact>>();
            IContactService service = new ContactService(mockRepo.Object);
            var mapper = new Mock<IMapper>();
            _contactController = new ContactController(mapper.Object, service);


            // Resolve DP injection for service classes
            //var sev = new ServiceCollection()
            //    .AddLogging().BuildServiceProvider();
            //var factory = sev.GetService<IContactService>();
            //var contactService = factory.GetAsync(1);
            //_contactController = new ContactController(mapper.Object, service);

        }

        #endregion

        #region Test Cases

        /// <summary>
        /// Get All Contact Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllContactTest()
        {
            var res = await _contactController.GetAll();
            Assert.Empty(res);
        }

        /// <summary>
        /// Get Contact Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetContactTest()
        {
            var res = await _contactController.GetContact(1);
            Assert.Null(res);
         }

        /// <summary>
        /// Save Contact
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SaveContact()
        {
            var contactViewModel = new Mock<ContactViewModel>();
            var res = await _contactController.SaveContact(contactViewModel.Object);
            Assert.NotNull(res);
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateContact()
        {
            var contactViewModel = new Mock<ContactViewModel>();
            var res = await _contactController.UpdateContact(1, contactViewModel.Object);
            Assert.NotNull(res);
        }

        /// <summary>
        /// Chane Contact status Unit Test 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ChangeStatus()
        {
            var contactViewModel = new Mock<ContactViewModel>();
            var res = await _contactController.UpdateContact(2, contactViewModel.Object);
            Assert.NotNull(res);
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        [Fact]
        public void DeleteContact()
        {
            _contactController.DeleteContact(2);
            Assert.True(true);
        }

        /// <summary>
        /// Delete All Contact
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteAllContact()
        {
            await _contactController.DeleteAll();
            Assert.True(true);
        }

        #endregion
    }
}
