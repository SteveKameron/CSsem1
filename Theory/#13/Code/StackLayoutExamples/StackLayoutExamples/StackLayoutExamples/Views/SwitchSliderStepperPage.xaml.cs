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
    public partial class SwitchSliderStepperPage : ContentPage
    {
        public SwitchSliderStepperPage()
        {
            InitializeComponent();
        }

        private void Switch1_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void Slider1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            StepperValue.Text = e.NewValue.ToString();
        }

        private void Stepper1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            StepperValue.Text = e.NewValue.ToString();

        }
    }
}