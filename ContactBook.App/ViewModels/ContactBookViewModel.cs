using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactBook.App.ViewModels
{
    public class ContactBookViewModel : ObservableObject
    {
        public ContactListViewModel ContactListViewModel { get; }
        public ICommand AddContact { get; }
        public ICommand CancelChanges { get; }

        public ICommand SaveChanges { get; }

        public ContactBookViewModel()
        {
            ContactListViewModel = new ContactListViewModel();
        }
    }
}
