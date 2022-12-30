using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Stores;

namespace ContactBook.App.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ObservableObject CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsCurrentModalOpen => _modalNavigationStore.IsCurrentViewModelOpen;

        public ContactBookViewModel ContactBookViewModel { get; }


        public MainViewModel(ModalNavigationStore modalNavigationStore, ContactStore contactStore)
        {
            _modalNavigationStore = modalNavigationStore;
            ContactBookViewModel = new ContactBookViewModel(_modalNavigationStore, contactStore);

            _modalNavigationStore.CurrentViewModelChanged += _modalNavigationStore_CurrentViewModelChanged;

            
        }

        protected void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= _modalNavigationStore_CurrentViewModelChanged;
        }

        private void _modalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsCurrentModalOpen));
        }
    }
}
