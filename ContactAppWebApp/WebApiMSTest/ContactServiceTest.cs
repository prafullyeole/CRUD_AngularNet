using AutoMapper;
using ContactWebApi.Controllers;
using Entity.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository;
using Services;
using System.Threading.Tasks;

namespace WebApiMSTest
{
    [TestClass]
    public class ContactServiceTest
    {
        private readonly ContactController _contactController = null;

        public ContactServiceTest() {
            var mockRepo = new Mock<IRepository<Contact>>();
            IContactService service = new ContactService(mockRepo.Object);
            var mapper = new Mock<IMapper>();
            _contactController = new ContactController(mapper.Object, service);
        }

        [TestMethod]
        public async Task GetAllContactTest()
        {
            var res = await _contactController.GetContact(1);
            Assert.IsNull(res);
        }
    }
}
