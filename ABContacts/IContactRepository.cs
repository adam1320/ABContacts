using System;
using System.Collections.Generic;
using ABContacts.Models;

namespace ABContacts
{
    public interface IContactRepository
    {
        public IEnumerable<Contact> GetAllContacts();

        public Contact GetContact(int ID);
        public void UpdateContact(Contact contact);
        public void InsertContact(Contact contact);
        public void DeleteContact(Contact contact);
        public IEnumerable<Contact> GetSearchResults(string search);
    }

    
    
}
