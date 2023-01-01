using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Commands;
using ContactBook.App.Helpers;
using ContactBook.App.Stores;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.ViewModels
{
    public class AddContactViewModel : ObservableObject
    {
        public Contact NewContact { get; set; }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        private string _errorMsg;
        public string ErrorMessage
        {
            get { return _errorMsg; }
            set
            {
                _errorMsg = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(IsErrorPresent));
            }
        }

        public bool IsErrorPresent => !string.IsNullOrEmpty(_errorMsg);

        public bool CanAdd => true;

        public AddContactViewModel(ModalNavigationStore modalNavigationStore, ContactStore contactStore)
        {
            NewContact = new Contact();
            AddCommand = new SaveAddContactCommand(this, modalNavigationStore, contactStore);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
