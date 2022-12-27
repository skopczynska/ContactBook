using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Commands;
using ContactBook.DomainModel.Models;
using ContactBook.App.Stores;

namespace ContactBook.App.ViewModels
{
    public class ContactListItemViewModel : ObservableObject
    {
        public Contact Contact { get; set; }
    
   
        
        public ICommand DeleteCommand { get; }

        public ContactListItemViewModel(Contact contact, ContactRepository contactRepository)
        {
            Contact = contact;
            DeleteCommand = new DeleteContactCommand(this, contactRepository);
         
        }
    }
}
