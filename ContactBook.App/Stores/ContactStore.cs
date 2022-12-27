using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.Stores
{
    public class ContactRepository
    {
        public event Action<Contact> ContactAdded;

        public async Task Add(Contact newContact)
        {
            ContactAdded?.Invoke(newContact);
        }

        public event Action<Contact> ContactDeleted;

        public async Task Delete(Contact contactToDelete)
        {
            ContactDeleted?.Invoke(contactToDelete);
        }
    }
}
