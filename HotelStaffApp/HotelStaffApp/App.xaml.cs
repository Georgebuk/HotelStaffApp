using HotelStaffApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HotelStaffApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if(UserHandler.LoggedInUser != null)
                MainPage = new LoggedInTabbedPage();
            else
                MainPage = new LoginRegisterTabbedPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
