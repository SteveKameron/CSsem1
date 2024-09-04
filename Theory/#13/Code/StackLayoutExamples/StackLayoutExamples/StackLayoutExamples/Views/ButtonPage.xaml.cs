using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackLayoutExamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonPage : ContentPage
    {
        public ButtonPage()
        {
            InitializeComponent();
        }

        private void ThirdButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Message", "Ok");
        }
    }
}