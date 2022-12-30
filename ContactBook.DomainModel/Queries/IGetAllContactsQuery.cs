using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Models;

namespace ContactBook.DomainModel.Queries
{
    public interface IGetAllContactsQuery
    {
        public Task<IEnumerable<Contact>> Execute();
    }
}
