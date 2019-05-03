using HotelClassLibrary;
using HotelStaffApp.Web_Service;
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
	public partial class ReportRoomErrorPage : ContentPage
	{
        Room r;
		public ReportRoomErrorPage (Room r)
		{
			InitializeComponent ();

            this.r = r;
        }
        private async void ReportButton_Clicked(object sender, EventArgs e)
        {
            string report = ErrorReport.Text.Trim();
            bool answer = await DisplayAlert("Report Room?", "This will make the room unavailable to customers. " +
                "Are you sure you wish to do this?", "Continue", "Cancel");

            if (answer)
            {
                HotelRestService.Instance.BookDownRoom(report, r.RoomID);
            }
        }
    }
}