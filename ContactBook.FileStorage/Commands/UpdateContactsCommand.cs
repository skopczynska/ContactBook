using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Commands;
using ContactBook.DomainModel.Models;
using ContactBook.FileStorage.Repositories;

namespace ContactBook.FileStorage.Commands
{
    public class UpdateContactsCommand : IUpdateContactsCommand
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactsCommand(IContactRepository repository)
        {
            _contactRepository = repository;
        }
        public async Task Execute(IEnumerable<Contact> contacts)
        {
            await _contactRepository.UpdateAllContacts(contacts);
        }
    }
}
