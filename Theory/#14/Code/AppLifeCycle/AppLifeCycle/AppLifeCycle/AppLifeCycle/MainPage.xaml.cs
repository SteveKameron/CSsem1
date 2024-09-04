using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLifeCycle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<EventPage>(this, "Something happened!", async (sender) =>
            {
                await DisplayAlert("Information", "Something just happened on EventPage", "Jot it");
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventPage());
        }
    }
}
