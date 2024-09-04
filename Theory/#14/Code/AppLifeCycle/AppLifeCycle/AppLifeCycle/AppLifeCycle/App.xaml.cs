using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLifeCycle
{
    public partial class App : Application
    {
        private DateTime _lastActivityTime;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());

        }

        protected override void OnStart()
        {
            _lastActivityTime = Preferences.Get("LastActivityTime", DateTime.MinValue);
        }

        protected override void OnSleep()
        {
            Preferences.Set("LastActivityTime", DateTime.Now.ToUniversalTime());
        }

        protected override void OnResume()
        {
            _lastActivityTime = Preferences.Get("LastActivityTime", DateTime.MinValue);
        }
    }
}
