using ContactBook.DomainModel.Models;
using ContactBook.FileStorage.FileManagers;

namespace ContactBook.FileStorage.Tests.FileManagers
{
    public class Tests
    {
        private const string _oneElementSaveXMLFilePath = "Input/oneElementFileSave.xml";
        private const string _oneElementLoadXMLFilePath = "Input/oneElementFileLoad.xml";

        private readonly Contact _firstContactToSave = new Contact()
        {
            FirstName = "Sylwia", LastName = "Kop", StreetName="GwiaŸdzista", HouseNumber="14", ApartmentNumber="2", PostalCode="60-600", Town="Poznañ", PhoneNumber="666 777 999", DateOfBirth=new DateTime(2022,12,28)
        };

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_oneElementSaveXMLFilePath))
            {
                File.Delete(_oneElementSaveXMLFilePath);
            }    
        }

        [Test]
        public void LoadOneElementFileTest()
        {
            XMLFileManager xMLFileManager = new XMLFileManager("Input", "oneElementFileLoad.xml");
            var contacts = xMLFileManager.GetAllContacts();
            Contact contact = contacts.Result.FirstOrDefault();

            Assert.AreEqual(_firstContactToSave.FirstName, contact.FirstName);
            Assert.AreEqual(_firstContactToSave.LastName, contact.LastName);
            Assert.AreEqual(_firstContactToSave.StreetName, contact.StreetName);
            Assert.AreEqual(_firstContactToSave.HouseNumber, contact.HouseNumber);
            Assert.AreEqual(_firstContactToSave.ApartmentNumber, contact.ApartmentNumber);
            Assert.AreEqual(_firstContactToSave.PostalCode, contact.PostalCode);
            Assert.AreEqual(_firstContactToSave.Town, contact.Town);
            Assert.AreEqual(_firstContactToSave.PhoneNumber, contact.PhoneNumber);
            Assert.AreEqual(_firstContactToSave.DateOfBirth.Year, contact.DateOfBirth.Year);
            Assert.AreEqual(_firstContactToSave.DateOfBirth.Month, contact.DateOfBirth.Month);
            Assert.AreEqual(_firstContactToSave.DateOfBirth.Day, contact.DateOfBirth.Day);

            Assert.AreEqual(contacts.Result.Count(), 1);

        }

        [Test]
        public void SaveOneElementFileTest()
        {
            XMLFileManager xMLFileManager = new XMLFileManager("Input", "oneElementFileLoad.xml");
            xMLFileManager.StoreAllContacts(new List<Contact>() { _firstContactToSave });

            Assert.IsTrue(File.Exists(_oneElementSaveXMLFilePath));
            


        }
    }
}