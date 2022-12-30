using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.Stores;

namespace ContactBook.App.Commands
{
    public class GetAllContactsCommand : ICommand
    {
        private ContactStore _contactStore;

        public event EventHandler? CanExecuteChanged;


        public GetAllContactsCommand(ContactStore contactStore)
        {
            _contactStore = contactStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await _contactStore.GetAllContacts();
        }
    }
}
