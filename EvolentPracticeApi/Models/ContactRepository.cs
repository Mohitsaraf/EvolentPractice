using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolentPracticeApi.Models
{
    public class ContactRepository : IContactRepository
    {
        public static List<Contact> _contactsList { get; private set; }
        private int _nextId = 5;

        public ContactRepository()
        {
            if (_contactsList == null || _contactsList.Count == 0)
            {
                SampleData();
            }
        }

        private void SampleData()
        {
            _contactsList = new List<Contact>();

            _contactsList.Add(new Contact()
            {
                FirstName = "Mohit",
                LastName = "Edge",
                EmailId = "Sarafmohit1@gmail.com",
                Mobile="9784567878",
                Status= "Inactive"
            });

            _contactsList.Add(new Contact()
            {
                FirstName = "Ronaldo",
                LastName = "real",
                EmailId = "llio1@gmail.com",
                Mobile = "3784567878",
                Status = "Active"
            });

            _contactsList.Add(new Contact()
            {
                FirstName = "Messi",
                LastName = "Arg",
                EmailId = "argin@gmail.com",
                Mobile = "4784567878",
                Status = "Active"
            });

            _contactsList.Add(new Contact()
            {
                FirstName = "Ramos",
                LastName = "Madrid",
                EmailId = "spain@gmail.com",
                Mobile = "5784567878",
                Status = "Active"
            });
        }

        public Contact AddContact(Contact contact)
        {
            if (_contactsList.Find(n => n.EmailId.Equals(contact.EmailId)) == null && _contactsList.Find(n => n.Mobile.Equals(contact.Mobile)) == null)
                _contactsList.Add(contact);
            else
                throw new Exception();


            return contact;
        }

        public Contact GetContact(string emailId)
        {
            Contact result = _contactsList.Single(p => p.EmailId.Equals(emailId));


            return result;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactsList;
        }

        public void RemoveContact(string emailId)
        {
            _contactsList.RemoveAll(p => p.EmailId.Equals(emailId)); ;
        }

        public bool UpdateContact(string emailId, Contact item)
        {
            int index= _contactsList.FindIndex(n => n.EmailId.Equals(emailId));

            if (index == -1 )
                return false;
            else
            {
                _contactsList[index]=item;
                return true;
            }

            
        }

        public IEnumerable<Contact> GetAllActiveContact()
        {
            return _contactsList.Where(n=>n.Status=="Active"||n.Status=="ACTIVE").Select(n=>n).ToList();
        }

        public IEnumerable<Contact> GetAllInActiveContact()
        {
            return _contactsList.Where(n => n.Status == "Inactive" || n.Status == "INACTIVE").Select(n => n).ToList();
        }
    }
}