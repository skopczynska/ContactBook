using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;

namespace ContactBook.App.Commands
{
    public class GetAllContactsCommand : ICommand
    {
        private ContactStore _contactStore;
        private ContactListViewModel _contactListViewModel;

        public event EventHandler? CanExecuteChanged;



        public GetAllContactsCommand(ViewModels.ContactListViewModel contactListViewModel, ContactStore contactStore)
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
                await _contactStore.GetAllContacts();
            }
            catch (Exception)
            {
                _contactListViewModel.ErrorMessage = "Error while loading contacts has appered. Contact administrator.";
            }
        }
    }
}
