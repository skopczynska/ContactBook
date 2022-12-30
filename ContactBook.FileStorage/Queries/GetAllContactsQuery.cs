using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Models;
using ContactBook.DomainModel.Queries;
using ContactBook.FileStorage.Repositories;

namespace ContactBook.FileStorage.Queries
{
    public class GetAllContactsQuery : IGetAllContactsQuery
    {
        private readonly IContactRepository _contactRepository;
        public GetAllContactsQuery(IContactRepository repository)
        {
            _contactRepository = repository;
        }
        public async Task<IEnumerable<Contact>> Execute()
        {
            return await _contactRepository.GetAllContacts();
        }
    }
}
