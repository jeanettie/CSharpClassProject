using Contacto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Contacto.Repositories
{
    public class ContactRepository : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }

        public ContactRepository() : base("ContactRepository")
        {
            Debug.Write(Database.Connection.ConnectionString);
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
            this.SaveChanges();
        }

        public Contact GetContact(int id)
        {
            //This is a LINQ query that returns the contact
            //  where the id matches and to pull the first one
            //  NOTE if you pass an id that doesn't exist this will error
            return (from x in Contacts
             where x.ID == id
             select x).First();
        }

        public void EditContact(Contact contact)
        {
            //This tells the DbContext to associate contact with a database record 
            //  and mark it as modified so that when save changes is called to update the database
            this.Entry(contact).State = EntityState.Modified;
            this.SaveChanges();
        }
    }
}