using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactBook.App.Stores
{
    public class ModalNavigationStore
    {
        private ObservableObject _currentViewModel;


        public ObservableObject CurrentViewModel
        {
            get { return _currentViewModel; }   
            set 
            { 
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        public bool IsCurrentViewModelOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }

    
}
