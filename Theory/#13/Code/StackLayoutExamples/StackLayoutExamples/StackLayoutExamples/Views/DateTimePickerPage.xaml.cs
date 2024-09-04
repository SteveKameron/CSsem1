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
    public partial class DateTimePickerPage : ContentPage
    {

        public DateTimePickerPage()
        {
            InitializeComponent();
        }

        private void DatePicker1_DateSelected(object sender, DateChangedEventArgs e)
        {
        }

        private void TimePicker1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }
    }
}