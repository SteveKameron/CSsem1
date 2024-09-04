using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HWApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int counter = 0;
        private void counterBtnClick(object sender, EventArgs e)
        {
            lblCounter.Text = $"You have tapped {counter++} times";
        }
    }
}
