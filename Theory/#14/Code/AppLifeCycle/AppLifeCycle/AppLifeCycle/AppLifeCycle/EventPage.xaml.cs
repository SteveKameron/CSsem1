using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLifeCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();

            
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Something happened!");
        }
    }
}