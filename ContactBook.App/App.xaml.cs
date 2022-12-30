using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ContactBook.App.Commands;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;
using ContactBook.DomainModel.Commands;
using ContactBook.DomainModel.Queries;
using ContactBook.FileStorage.Commands;
using ContactBook.FileStorage.Queries;
using ContactBook.FileStorage.Repositories;
using AddContactCommand = ContactBook.FileStorage.Commands.AddContactCommand;

namespace ContactBook.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ContactStore _contactStore;
        private readonly IContactRepository _contactReposotory;
        private const string _folderWithStoredContactsName = @"ContactsApp";
        private const string _fileWithStoredContactsName = @"mycontacts.xml";

        private readonly IGetAllContactsQuery _getAllContactsQuery;
        private readonly IUpdateContactsCommand _updateContactsCommand;
        private readonly IAddContactCommand _addContactCommand;

        public App()
        {
            string pathToFileWithStoredContacts = string.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _folderWithStoredContactsName); ;
            
            _modalNavigationStore = new ModalNavigationStore();
            
            _contactReposotory = new XMLFileContactRepository(pathToFileWithStoredContacts, _fileWithStoredContactsName);
            
            _getAllContactsQuery = new GetAllContactsQuery(_contactReposotory);
            
            _updateContactsCommand = new UpdateContactsCommand(_contactReposotory);
            _addContactCommand = new AddContactCommand(_contactReposotory);

            _contactStore = new ContactStore(_getAllContactsQuery, _updateContactsCommand, _addContactCommand);

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, _contactStore)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
