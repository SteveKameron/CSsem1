using StackLayoutExamples.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StackLayoutExamples
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StackLayoutPage), typeof(StackLayoutPage));
            Routing.RegisterRoute(nameof(FlexLayoutPage), typeof(FlexLayoutPage));
            Routing.RegisterRoute(nameof(GridPage), typeof(GridPage));
            Routing.RegisterRoute(nameof(AbsoluteLayoutPage), typeof(AbsoluteLayoutPage));
            Routing.RegisterRoute(nameof(RelativeLayoutPage), typeof(RelativeLayoutPage));
            Routing.RegisterRoute(nameof(ScrollViewPage), typeof(ScrollViewPage));
            Routing.RegisterRoute(nameof(FramePage), typeof(FramePage));
            Routing.RegisterRoute(nameof(ButtonPage), typeof(ButtonPage));
            Routing.RegisterRoute(nameof(LabelEntryEditorPage), typeof(LabelEntryEditorPage));
            Routing.RegisterRoute(nameof(DateTimePickerPage), typeof(DateTimePickerPage));
            Routing.RegisterRoute(nameof(SwitchSliderStepperPage), typeof(SwitchSliderStepperPage));
            Routing.RegisterRoute(nameof(ImagePage), typeof(ImagePage));
            Routing.RegisterRoute(nameof(MediaPage), typeof(MediaPage));
            Routing.RegisterRoute(nameof(AlertsPage), typeof(AlertsPage));
            
        }
    }
}
