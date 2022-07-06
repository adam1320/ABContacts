using ABContacts.Models;
using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Data;
using Dapper;

namespace ABContacts
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _conn;
        public ContactRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void DeleteContact(Contact contact)
        {
            
            _conn.Execute("DELETE FROM people WHERE PersonID = @id;",
                                     new { id = contact.PersonID });

        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _conn.Query<Contact>("Select * from people;");
            
        }

        public Contact GetContact(int id)
        {
            

            return _conn.QuerySingle<Contact>("SELECT * FROM PEOPLE WHERE PersonID = @id;",
               new { id = id });

        }

        public IEnumerable<Contact> GetSearchResults(string search)
        {
            return _conn.Query<Contact>("SELECT * FROM PEOPLE WHERE FName like '%" + @search + "%' or LName like '%" + @search + "%' or Phone like '%" + @search + "%' or Email like '%" + @search + "%' or Address like '%" + @search + "%' or City like '%" + @search + "%' or State like '%" + @search + "%' or Zip like '%" + @search + "%' or ContactType like '%" + @search +"%' ;") ;




        }

        public void InsertContact(Contact contact)
        {
            _conn.Execute("INSERT INTO people (FName, LName, Phone, Email, Address, City, State, Zip, ContactType) VALUES (@FirstName, @LastName, @Phone, @Email, @Address, @City, @State, @Zip, @ContactType);",
               new { firstName = contact.FName, lastname = contact.LName, phone = contact.Phone, email = contact.Email, address = contact.Address, city = contact.City, state = contact.State, zip = contact.Zip, contacttype = contact.ContactType, id = contact.PersonID });

        }

        public void UpdateContact(Contact contact)
        {
            
           _conn.Execute("UPDATE people SET FName = @FirstName, LName = @lastname, Phone = @phone, Email = @email, Address = @address, City = @city, State = @state, Zip = @zip, ContactType = @contacttype WHERE PersonID = @id",
               new { FirstName = contact.FName, lastname = contact.LName, phone = contact.Phone, email = contact.Email, address = contact.Address, city = contact.City, state = contact.State, zip = contact.Zip, contacttype = contact.ContactType, id = contact.PersonID });

        }
        
        


    }
}
