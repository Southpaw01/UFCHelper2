using System;
using UFCHelper.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UFCHelper
{
    public partial class App : Application
    {
        public INavigation navigation { get; set; }

        public App()
        {

            InitializeComponent();
 
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
