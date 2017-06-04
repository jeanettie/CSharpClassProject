using Contacto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Contacto.Repositories;

namespace Contacto.Controllers
{
    public class HomeController : Controller
    {

        
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

        public ActionResult CreateContact()
        {
            return View("AddContact");
        }

        public ActionResult AddContact(Contact contact)
        {
            using (var repo = new ContactRepository())
            {
                repo.AddContact(contact);
                return View("SingleContact", contact);
            }
        }


        public ActionResult ViewContacts()
        {
            using (var repo = new ContactRepository())
            {
                return View("ContactList", repo.Contacts.ToList());
            }
        }

        public ActionResult EditContact(int id)
        {
            using (var repo = new ContactRepository())
            {
                return View("EditContact", repo.GetContact(id));
            }
        }

        public ActionResult ChangeContact(Contact contact)
        {
            using (var repo = new ContactRepository())
            {
                repo.EditContact(contact);
                return View("ContactList", repo.Contacts.ToList());
            }
        }
    }

   
}