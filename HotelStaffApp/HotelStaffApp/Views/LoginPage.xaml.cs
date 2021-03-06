﻿using HotelClassLibrary;
using HotelStaffApp.Views;
using HotelStaffApp.Web_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelStaffApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            //Notify the user that the application is loading something
            loadingActivity.IsVisible = true;
            loadingActivity.IsRunning = true;
            LoginButton.IsVisible = false;

            //Reset error labels
            errorLabelNoConnection.IsVisible = false;
            errorLabelNoUser.IsVisible = false;
            errorLabelNoEntry.IsVisible = false;

            string email = EntryEmail.Text;
            string password = EntryPassword.Text;
            //Check if user has entered data
            if (email == null || password == null)
            {
                //If no input display arror message
                errorLabelNoEntry.IsVisible = true;
            }
            else
            {
                //Look for user in web service
                Staff s = await StaffRestService.Instance.GetStaffMember(email, password);
                //If user exists
                if (s == null)
                {
                    errorLabelNoConnection.IsVisible = true;
                }
                else if (s.StaffID != 0)
                {
                    //Set the logged in user
                    UserHandler.LoggedInUser = s;
                    //Redirect to a new main page
                    Application.Current.MainPage = new LoggedInTabbedPage();
                }
                else
                {
                    //USer is not found. Display not found error
                    errorLabelNoUser.IsVisible = true;
                }
            }

            //Disable loading notification
            loadingActivity.IsVisible = false;
            loadingActivity.IsRunning = false;
            LoginButton.IsVisible = true;
        }
    }
}