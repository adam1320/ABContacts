using System;
using ABContacts.Models;

namespace ABContacts.Models
{
    public class Contact
    {
        public Contact()
        { }
        public int PersonID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ContactType { get; set; }


    }
}
