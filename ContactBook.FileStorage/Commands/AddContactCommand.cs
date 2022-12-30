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
    public class AddContactCommand : IAddContactCommand
    {
        private readonly IContactRepository _contactRepository;

        public AddContactCommand(IContactRepository repository)
        {
            _contactRepository = repository;
        }
        public async Task Execute(Contact newContact)
        {
            await _contactRepository.AddContact(newContact);
        }
    }
}
