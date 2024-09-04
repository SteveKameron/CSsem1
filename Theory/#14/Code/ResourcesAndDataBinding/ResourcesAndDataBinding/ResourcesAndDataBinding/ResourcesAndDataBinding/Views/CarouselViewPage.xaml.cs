using ResourcesAndDataBinding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselViewPage : ContentPage
    {
        private ContactViewModel Contacts { get; set; }
        public CarouselViewPage()
        {
            InitializeComponent();
            Contacts = new ContactViewModel();
            BindingContext = Contacts;
        }

        private void PeopleList_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {

            var currentItem = e.CurrentItem;
            var previousItem = e.PreviousItem;
        }

        private void PeopleList_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            int currentPosition = e.CurrentPosition;
            int previousPosition = e.PreviousPosition;
        }
    }
}