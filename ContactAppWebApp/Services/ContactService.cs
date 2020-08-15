using Entity.Models;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Contat Service for CRUD operation
    /// </summary>
    public class ContactService : IContactService
    {

        #region Variable        
        private readonly IRepository<Contact> _contactRepository;
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contactRepository"></param>
        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Delete Contact by Id
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool DeleteAsync(int contactId)
        {
            var contactToRemove = _contactRepository.GetAsync(contactId).Result;            
            _contactRepository.RemoveAsync(contactToRemove);
            return true;
        }

        /// <summary>
        /// Get All Contact
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            return _contactRepository.GetAllAsync();
        }

        /// <summary>
        /// Get contact by Id
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public Task<Contact> GetAsync(int contactId)
        {
            return _contactRepository.GetAsync(contactId);
        }

        /// <summary>
        /// Add/Update contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public Task<Contact> SaveAsync(Contact contact)
        {
            return contact != null && contact.Id <= 0 ? _contactRepository.AddAsync(contact) : _contactRepository.UpdateAsync(contact);
        }
        

        #endregion
    }
}
