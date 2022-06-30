using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ABContacts.Models;

namespace ABContacts.Controllers
    
{


    public class ContactController : Controller
    {
        private readonly IContactRepository repo;
        public ContactController(IContactRepository repo)
        {
            this.repo = repo;

        }

        public IActionResult Index()
        {
            var contacts = repo.GetAllContacts();

            return View(contacts);

        }
        public IActionResult ViewContact(int id)
        {
            var Contact = repo.GetContact(id);
            return View(Contact);

        }
        public IActionResult UpdateContact(int id)
        {
            Contact contact = repo.GetContact(id);
            if (contact == null)
            {
                return View("ContactNotFound");
            }

            return View(contact);
        }


        public IActionResult UpdateContactToDatabase(Contact contact)
        {
            repo.UpdateContact(contact);

            return RedirectToAction("ViewContact", new { id = contact.PersonID });
        }

        public IActionResult InsertContact()
        {
           // var contact = repo.GetAllContacts();
            return View();
        }
        public IActionResult InsertContactToDatabase(Contact contact)
        {
            repo.InsertContact(contact);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteContact(Contact contact)
        {
            repo.DeleteContact(contact);

            return RedirectToAction("Index");
        }



    }
}
