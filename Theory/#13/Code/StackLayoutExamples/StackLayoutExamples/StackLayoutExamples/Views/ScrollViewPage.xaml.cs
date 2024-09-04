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
    public partial class ScrollViewPage : ContentPage
    {
        public ScrollViewPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            //ScrollToPosition.Center
            //ScrollToPosition.Start
            //ScrollToPosition.End
            //ScrollToPosition.MakeVisible

            Scroll1.ScrollToAsync(Label1, ScrollToPosition.Start, true);
            
        }
    }
}