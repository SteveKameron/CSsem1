using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsListView : ContentPage
    {
        private ObservableCollection<Contact> Contacts { get; set; }
        public ContactsListView()
        {
            InitializeComponent();
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
            BindingContext = Contacts;
        }

        private void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            if (contact != null)
            {
                DisplayAlert("Edit", "Here we can edit selected element", "Ok");
            }
        }
    }
}