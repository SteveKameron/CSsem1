using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ResourcesAndDataBinding.ViewModels
{
    public class ContactViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact SelectedContact { get; set; }

        public ContactViewModel()
        {
            this.Contacts = new ObservableCollection<Contact>();
            Contacts = new ObservableCollection<Contact>();
            Contact contact1 = new Contact
            {
                FirstName = "John",
                LastName = "McClane",
                DateOfBirth = new DateTime(1977, 05, 10),
                IsFamilyMember = false
            };
            Contact contact2 = new Contact
            {
                FirstName = "Walter",
                LastName = "White",
                DateOfBirth = new DateTime(1970, 02, 03),
                IsFamilyMember = true
            };
            Contact contact3 = new Contact
            {
                FirstName = "Rocky",
                LastName = "Balboa",
                DateOfBirth = new DateTime(1982, 09, 01),
                IsFamilyMember = true
            };

            Contacts.Add(contact1);
            Contacts.Add(contact2);
            Contacts.Add(contact3);
        }
    }
}
