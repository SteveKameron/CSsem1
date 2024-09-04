using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{
    

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactView : ContentPage
    {
        private Contact NewContact { get; set; }
        public ContactView()
        {
            InitializeComponent();
            NewContact = new Contact
            {
                FirstName = "John",
                LastName = "McClane",
                DateOfBirth = new DateTime(1956, 05, 10),
                IsFamilyMember = false
            };

            BindingContext = NewContact;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Contact saved", $"{NewContact.LastName} " +
                $"{Environment.NewLine} {NewContact.FirstName} " +
                $"{Environment.NewLine} {NewContact.DateOfBirth}", "Ok");
        }
    }
}