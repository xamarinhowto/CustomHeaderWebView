using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHowToCustomHeaders.Views;

namespace XamarinHowToCustomHeaders
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WebViewPage();
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
