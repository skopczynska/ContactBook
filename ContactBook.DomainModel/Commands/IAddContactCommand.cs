using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Models;

namespace ContactBook.DomainModel.Commands
{
    public interface IAddContactCommand
    {
        public Task Execute(Contact contacts);
    }
}
