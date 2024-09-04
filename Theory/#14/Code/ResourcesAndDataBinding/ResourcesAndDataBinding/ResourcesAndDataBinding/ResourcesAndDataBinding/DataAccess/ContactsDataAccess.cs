using ResourcesAndDataBinding.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourcesAndDataBinding.DataAccess
{
    public class ContactsDataAccess
    {
        public static SQLiteConnection Database;
        private static object collisionLock = new object();

        public ContactsDataAccess()
        {
            Database = new SQLiteConnection(DataAccessHelper.DatabasePath);
            Database.CreateTable<Contact>();
        }

        public List<Contact> GetFamilyMembers()
        {
            lock (collisionLock)
            {
                var contacts = Database.Table<Contact>();
                var result = contacts.Where(c => c.IsFamilyMember).ToList();
                return result;
            }
        }

        public void AddContact(Contact contact)
        {
            lock (collisionLock)
            {
                Database.Insert(contact);
            }
        }

        public void DeleteContact(Contact contact)
        {
            lock (collisionLock)
            {
                Database.Delete(contact);
            }
        }

        public void EditContact(Contact contact)
        {
            lock (collisionLock)
            {
                Database.Update(contact);
            }
        }

        public void SaveAll(IEnumerable<Contact> contacts)
        {
            lock (collisionLock)
            {
                var existingContacts = contacts.Where(c => c.ID != 0);
                var newContacts = contacts.Where(c => c.ID == 0);

                Database.UpdateAll(existingContacts);
                Database.InsertAll(newContacts);
            }
        }
    }
}
