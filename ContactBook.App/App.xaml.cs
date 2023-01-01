using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AddContactCommand = ContactBook.FileStorage.Commands.AddContactCommand;

namespace ContactBook.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      
        private const string _folderWithStoredContactsName = @"ContactsApp";
        private const string _fileWithStoredContactsName = @"mycontacts.xml";

        

        private readonly IHost _host;
        public App()
        {
            string pathToFileWithStoredContacts = string.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _folderWithStoredContactsName); ;

            _host = Host.CreateDefaultBuilder().
                ConfigureServices((services) =>
                {
                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<IContactRepository, XMLFileContactRepository>((s) =>
                    new XMLFileContactRepository(pathToFileWithStoredContacts, _fileWithStoredContactsName));

                    services.AddSingleton<IGetAllContactsQuery, GetAllContactsQuery>();
                    services.AddSingleton<IUpdateContactsCommand, UpdateContactsCommand>();
                    services.AddSingleton<IAddContactCommand, AddContactCommand>();
                    
                    services.AddSingleton<ContactStore>();

                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>(se => new MainWindow()
                    {
                        DataContext = se.GetRequiredService<MainViewModel>()
                    });

                }
                ).Build();
    
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

     
            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
