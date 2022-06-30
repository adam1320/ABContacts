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
            //dapper.contrib.extensions
           // _conn.Delete(contact);
            _conn.Execute("DELETE FROM people WHERE PersonID = @id;",
                                     new { id = contact.PersonID });

        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _conn.Query<Contact>("Select * from people;");
            //dapper.contrib.extensions
            //return _conn.GetAll<Contact>();
        }

        public Contact GetContact(int id)
        {
            //dapper.contrib.extensions
            //return _conn.Get<Contact>(ID);

            return _conn.QuerySingle<Contact>("SELECT * FROM PEOPLE WHERE PersonID = @id",
                new { id = id });

        }

        public void InsertContact(Contact contact)
        {
            _conn.Execute("INSERT INTO people (FName, LName, Phone, Email, Address, City, State, Zip, ContactType) VALUES (@FirstName, @LastName, @Phone, @Email, @Address, @City, @State, @Zip, @ContactType);",
               new { FirstName = contact.FName, lastname = contact.LName, phone = contact.Phone, email = contact.Email, address = contact.Address, city = contact.City, state = contact.State, zip = contact.Zip, contacttype = contact.ContactType, id = contact.PersonID });

        }

        public void UpdateContact(Contact contact)
        {
            //Dapper.contrib.extensions
             //_conn.Update(contact);

           //without dapper.contrib
           _conn.Execute("UPDATE people SET FName = @FirstName, LName = @lastname, Phone = @phone, Email = @email, Address = @address, City = @city, State = @state, Zip = @zip, ContactType = @contacttype WHERE PersonID = @id",
               new { FirstName = contact.FName, lastname = contact.LName, phone = contact.Phone, email = contact.Email, address = contact.Address, city = contact.City, state = contact.State, zip = contact.Zip, contacttype = contact.ContactType, id = contact.PersonID });

        }
    }
}
