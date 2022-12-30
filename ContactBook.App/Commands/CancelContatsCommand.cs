using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.Commands
{
    public class CancelContactsCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ContactStore _contactStore;
    
        public CancelContactsCommand( ContactStore contactStore)
        {
            _contactStore = contactStore;
            
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await _contactStore.CancelChanges();
        }
    }
}
