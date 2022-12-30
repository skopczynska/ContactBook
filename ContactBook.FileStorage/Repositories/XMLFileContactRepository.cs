using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Models;
using ContactBook.FileStorage.FileManagers;


namespace ContactBook.FileStorage.Repositories
{
    public class XMLFileContactRepository : IContactRepository
    {
        private XMLFileManager _fileManager;
        private IEnumerable<Contact> _contacts;

        public XMLFileContactRepository(string pathToXmlFile, string fileName)
        {
            _fileManager = new XMLFileManager(pathToXmlFile, fileName);
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            _contacts = await _fileManager.GetAllContacts();

            AddContactIds();

            return _contacts;

        }

        private void AddContactIds()
        {
            int idNum = 0;
            foreach (var contact in _contacts)
            {
                contact.Id = idNum++;
            }

        }

        public async Task UpdateAllContacts(IEnumerable<Contact> contacts)
        {
             _fileManager.StoreAllContacts(contacts);
        }


        public async Task AddContact(Contact newContact)
        {
            if (_contacts.Any())
            {
                newContact.Id = _contacts.Max(c => c.Id) + 1;
            }
            else
            {
                newContact.Id = 0;
            }    
           
        }
    }
}
