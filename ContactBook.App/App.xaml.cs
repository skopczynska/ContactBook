using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ContactBook.App.DataRepositories;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;

namespace ContactBook.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ContactRepository _contactRepository;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _contactRepository = new ContactRepository();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, _contactRepository)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
