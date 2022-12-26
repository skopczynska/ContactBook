using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Commands;
using ContactBook.App.DataRepositories;
using ContactBook.App.Helpers;
using ContactBook.App.Models;
using ContactBook.App.Stores;

namespace ContactBook.App.ViewModels
{
    public class AddContactViewModel : ObservableObject
    {
        public Contact NewContact { get; set; }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public bool CanAdd => true;

        public AddContactViewModel(ModalNavigationStore modalNavigationStore, ContactRepository contactRepository)
        {
            NewContact = new Contact();
            AddCommand = new SaveAddContactCommand(this, modalNavigationStore, contactRepository);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
