
using Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IContactService
    {
        Task<Contact> SaveAsync(Contact project);
        bool DeleteAsync(int contactId);
        Task<Contact> GetAsync(int contactId);       
        Task<IEnumerable<Contact>> GetAllAsync();
    }
}
