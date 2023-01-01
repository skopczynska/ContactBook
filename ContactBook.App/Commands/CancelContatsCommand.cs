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
        private ContactListViewModel _contactListViewModel;
    
        public CancelContactsCommand(ContactListViewModel contactListViewModel, ContactStore contactStore)
        {
            _contactStore = contactStore;
            _contactListViewModel = contactListViewModel;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                await _contactStore.CancelChanges();
            }
            catch
            {
                _contactListViewModel.ErrorMessage = "Error while cancelling changes. Contact your admin."
            }
        }
    }
}
