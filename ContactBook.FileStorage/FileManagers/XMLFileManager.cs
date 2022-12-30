using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactBook.DomainModel.Models;

namespace ContactBook.FileStorage.FileManagers
{
    public class XMLFileManager
    {
        private string _pathToFile;
        private string _fileName;
        private string _fullPathToFile;

        public XMLFileManager(string pathToFile, string fileName)
        {
            _pathToFile = pathToFile;
            _fileName = fileName;
            _fullPathToFile = string.Format(@"{0}\{1}", _pathToFile, _fileName);
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            if (File.Exists(_fullPathToFile))
            {
                return LoadAllContacts();
            }
            return new List<Contact>();
        }

        private IEnumerable<Contact> LoadAllContacts()
        {
            int idIterator = 0;
            var storedContacts = new List<Contact>();

            XDocument root = XDocument.Load(_fullPathToFile);
            

                foreach (var xmlElement in root.Root.Elements())
                {
                    Contact contactReadFromFile = GetContactFromXMLElement(xmlElement);
                    //contactReadFromFile.Id= idIterator++;
                    storedContacts.Add(contactReadFromFile);
                }
           
            
            return storedContacts;
        }

        private Contact GetContactFromXMLElement(XElement item)
        {
            return XMLElementContactConverter.GetContact(item);

        }

        public async Task StoreAllContacts(IEnumerable<Contact> contacts)
        {
            XElement rootElement = GetMainElementWithContatcElements(contacts);

            if (!File.Exists(_fullPathToFile))
                CreateDirectoryToStoreContacts();
            
            XDocument document = new XDocument();
            document.Add(rootElement);
            document.Save(_fullPathToFile);
        }

        private void CreateDirectoryToStoreContacts()
        {
            DirectoryInfo contactFileDirectory = new DirectoryInfo(_pathToFile);
            if (!contactFileDirectory.Exists)
                contactFileDirectory.Create();
        }

        private XElement GetMainElementWithContatcElements(IEnumerable<Contact> contacts)
        {
            XElement rootElement = new XElement(XMLElementContactConverter.GetRootXElName());


            foreach (var contact in contacts)
            {
                XElement el = GetXlmElementFromContact(contact);
                rootElement.Add(el);
            }

            return rootElement;
        }

        private XElement GetXlmElementFromContact(Contact contact)
        {
            return XMLElementContactConverter.GetXElement(contact);
        }
    }
}
