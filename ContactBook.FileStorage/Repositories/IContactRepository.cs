using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Models;

namespace ContactBook.FileStorage.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContacts();

        Task AddContact(Contact newContact);
        Task UpdateAllContacts(IEnumerable<Contact> contacts);
    }
}
