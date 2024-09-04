using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigationGeneral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondaryPage : ContentPage
    {
        bool _modal;
        public SecondaryPage(bool modal)
        {
            InitializeComponent();
            _modal = modal;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(_modal)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await Navigation.PopAsync();
            }
            
        }
    }
}