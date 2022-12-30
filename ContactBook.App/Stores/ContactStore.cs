using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.App.Commands;
using ContactBook.DomainModel.Commands;
using ContactBook.DomainModel.Models;
using ContactBook.DomainModel.Queries;

namespace ContactBook.App.Stores
{
    public class ContactStore
    {
        private readonly IGetAllContactsQuery _getAllContactsQuery;
        private readonly IUpdateContactsCommand _updateContactsCommand;
        private readonly IAddContactCommand _addContactCommand;

        public event Action<Contact> ContactAdded;
        public event Action<Contact> ContactDeleted;
        public event Action<Contact> ContactUpdated;
        public event Action ContactsGot;
        public event Action ContactsUpdated;
        public event Action ChangesToContactsCancelled;

        public List<Contact> Contacts { get; set; }

        public ContactStore(IGetAllContactsQuery getAllContactsQuery, IUpdateContactsCommand updateContactsCommand, IAddContactCommand addContactCommand)
        {
            _getAllContactsQuery = getAllContactsQuery;
            _updateContactsCommand = updateContactsCommand;
            _addContactCommand = addContactCommand;
            Contacts = new List<Contact>();
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            IEnumerable<Contact> contacts = await _getAllContactsQuery.Execute();
            Contacts.Clear();
            Contacts.AddRange(contacts);

            ContactsGot.Invoke();
            return contacts;
        }
        

        public async Task Add(Contact newContact)
        {
            await _addContactCommand.Execute(newContact);
            Contacts.Add(newContact);
            ContactAdded?.Invoke(newContact);
        }

        

        public async Task Delete(Contact contactToDelete)
        {
            Contact ctd = Contacts.First(c => c.Id == contactToDelete.Id);
            Contacts.Remove(ctd);

            ContactDeleted?.Invoke(contactToDelete);
        }

        public async Task Update(Contact contactToUpdate)
        {
            
            ContactUpdated?.Invoke(contactToUpdate);
        }

        public async Task UpdateContacts(IEnumerable<Contact> contacts)
        {
            await _updateContactsCommand.Execute(contacts);

            ContactsUpdated?.Invoke();
        }

        public async Task<IEnumerable<Contact>> CancelChanges()
        {
            IEnumerable<Contact> contacts = await _getAllContactsQuery.Execute();
            Contacts.Clear();
            Contacts.AddRange(contacts);

            ChangesToContactsCancelled.Invoke();

            return contacts;

        }
    }
}
