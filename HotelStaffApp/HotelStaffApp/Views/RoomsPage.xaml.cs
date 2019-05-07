using HotelClassLibrary;
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
	public partial class RoomsPage : ContentPage
	{
		RoomViewModel rm;
		public RoomsPage ()
		{
			InitializeComponent ();
			rm = new RoomViewModel();
			BindingContext = rm;
		}

		private void RoomsSearch_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private async void LoadRoomPage(Room r)
		{
			await Navigation.PushAsync(new NavigationPage(new RoomTabbedPage(r)));
		}

		private void RoomListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			LoadRoomPage((Room)e.Item);
		}

		private void RefreshButton_Clicked(object sender, EventArgs e)
		{
			RefreshButton.IsVisible = false;
			RefreshActivity.IsVisible = true;
			RefreshActivity.IsRunning = true;
			rm.RefreshRooms();
			RefreshButton.IsVisible = true;
			RefreshActivity.IsVisible = false;
			RefreshActivity.IsRunning = false;

		}
	}
}