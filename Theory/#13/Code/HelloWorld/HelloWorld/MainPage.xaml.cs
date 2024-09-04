using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        int counter = 0;
        private void counterBtn_Clicked(object sender, EventArgs e)
        {
            counterLbl.Text = $"Tapped {counter++} times!";
        }
    }
}
