using AutoMapper;
using ContactWebApi.ViewModel;
using Entity.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebApi.Controllers
{
    /// <summary>
    /// Contact controll to perform CRUD operation 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EVOLCore")]
    public class ContactController : ControllerBase
    {
        // public List<Contact> contacts = new List<Contact>();
        private readonly IContactService _contactService;
        private ResultViewModel _resultViewModel;
        private readonly IMapper _mapper;

        /// <summary>
        /// Param Costructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="contactService"></param>
        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }
        #region Post Methods    
        /// <summary>
        /// Save Contact
        /// </summary>
        /// <param name="contactViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveContact")]
        public async Task<IActionResult> SaveContact([FromBody] ContactViewModel contactViewModel)
        {
            Contact contact = _mapper.Map<Contact>(contactViewModel);
            _resultViewModel = new ResultViewModel();
            _resultViewModel.Data = await _contactService.SaveAsync(contact);
            _resultViewModel.IsSuccess = true;
            return new OkObjectResult(_resultViewModel);
        }
        #endregion

        #region Get Methods
        /// <summary>
        /// Get All Contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Contact>> GetAll()
        {
            var result = await _contactService.GetAllAsync();
            return result.OrderBy(c=>c.FirstName);
        }

        /// <summary>
        /// Get contact details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("GetContact")]
        public async Task<Contact> GetContact(int id)
        {
            var result = await _contactService.GetAsync(id);
            return result;
        }

        /// <summary>
        /// Search contact
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchContact")]
        public async Task<IEnumerable<Contact>> SearchContact(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                var result = await _contactService.GetAllAsync();
                return result.Where(c => c.FirstName.ToLower().Contains(name) || c.LastName.ToLower().Contains(name) || c.PhoneNumber.Contains(name) || c.Email.ToLower().Contains(name));
            }

            return await _contactService.GetAllAsync();


        }
        #endregion

        #region Put Methods
        /// <summary>
        /// Update Contact Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactViewModel"></param>
        [HttpPut("{id}")]
        [Route("UpdateContact")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactViewModel contactViewModel)
        {
            Contact contact = _mapper.Map<Contact>(contactViewModel);
            _resultViewModel = new ResultViewModel();

            if (contact != null && contact.FirstName != null && contact.LastName != null)
            {
                _resultViewModel.Data = await _contactService.SaveAsync(contact);
            }
            else
            {
                var contactStatusChange = await _contactService.GetAsync(id);
                if (contactStatusChange != null)
                {
                    contactStatusChange.Status = contactViewModel.Status;
                    _resultViewModel.Data = await _contactService.SaveAsync(contactStatusChange);
                }
            }
            _resultViewModel.IsSuccess = true;
            return new OkObjectResult(_resultViewModel);
        }


        #endregion

        #region Delete Methods
        /// <summary>
        /// Delete contact from list
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Route("DeleteContact")]
        public void DeleteContact(int id)
        {
            _contactService.DeleteAsync(id);
        }

        /// <summary>
        /// Remove all contacts
        /// </summary>
        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<bool> DeleteAll()
        {
            var allrecord = await _contactService.GetAllAsync();
            foreach (var item in allrecord)
            {
                _contactService.DeleteAsync(item.Id);
            }

            return true;
        }
        #endregion

        #region Private Functions

        #endregion

    }
}
