using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelStaffApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountPage : ContentPage
	{
		public AccountPage ()
		{
			InitializeComponent ();

            accountLabel.Text = "Logged in as: " + UserHandler.LoggedInUser.Username;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (UserHandler.LoggedInUser != null)
            {
                UserHandler.LoggedInUser = null;
                Application.Current.MainPage = new LoginRegisterTabbedPage();
            }
        }
    }
}