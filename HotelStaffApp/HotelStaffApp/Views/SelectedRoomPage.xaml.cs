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
	public partial class SelectedRoomPage : ContentPage
	{
        Room ThisRoom;
		public SelectedRoomPage (Room room)
		{
			InitializeComponent ();

            ThisRoom = room;
            BindingContext = room;
		}

        private void SolvedButton_Clicked(object sender, EventArgs e)
        {
            HotelRestService.Instance.SolveProblem(ThisRoom.RoomID);
            ThisRoom.IsAvailable = true;
        }
    }
}