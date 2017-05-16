using ContactMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactMVC.Controllers
{
    public class ContactController : Controller
    {
        static ContactRepository _contactRepository = new ContactRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
            return View("SingleContact", contact);
            
        }

        public ActionResult ShowContacts()
        {
            return View("ContactList", _contactRepository.Contacts);
        }
    }

    public class ContactRepository
    {
        private List<Contact> _contacts = new List<Contact>();

        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }



    }


}