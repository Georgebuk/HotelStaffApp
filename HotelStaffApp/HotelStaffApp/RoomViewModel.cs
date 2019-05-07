using HotelClassLibrary;
using HotelStaffApp.Web_Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelStaffApp
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Room> unfilteredRooms = new ObservableCollection<Room>();
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();

        //When is refreshing is true the refresh animation continues to trigger
        //When isRefreshing is false the animation stops
        private bool _isRefreshing = false;

        private bool _noHotels_IsVisible;
        private bool _search_IsVisible;
        private bool _filterLabel_IsVisible;

        public ObservableCollection<Room> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                if (value.Count > 0)
                {
                    NoHotels_IsVisible = false;
                    Search_IsVisible = true;
                    FilterLabel_IsVisible = false;
                }
                else
                {
                    if (unfilteredRooms.Count == 0)
                    {
                        NoHotels_IsVisible = true;
                        Search_IsVisible = false;
                        FilterLabel_IsVisible = false;
                    }
                    else
                    {
                        NoHotels_IsVisible = false;
                        Search_IsVisible = true;
                        FilterLabel_IsVisible = true;
                    }
                }
                OnPropertyChanged(nameof(Rooms));
            }
        }
        public bool NoHotels_IsVisible
        {
            get
            {
                return _noHotels_IsVisible;
            }
            set
            {
                _noHotels_IsVisible = value;
                OnPropertyChanged(nameof(NoHotels_IsVisible));
            }
        }

        public bool Search_IsVisible
        {
            get
            {
                return _search_IsVisible;
            }
            set
            {
                _search_IsVisible = value;
                OnPropertyChanged(nameof(Search_IsVisible));
            }
        }

        public bool FilterLabel_IsVisible
        {
            get
            {
                return _filterLabel_IsVisible;
            }
            set
            {
                _filterLabel_IsVisible = value;
                OnPropertyChanged(nameof(FilterLabel_IsVisible));
            }
        }

        //Notifies the view when a property is updated
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            GetRooms();
        }

        private async void GetRooms()
        {
            HotelRestService service = HotelRestService.Instance;
            Rooms.Clear();
            var rooms = await service.GetRoomsForHotel(UserHandler.LoggedInUser.Location.HotelID);
            ObservableCollection<Room> rm = new ObservableCollection<Room>();
            foreach (Room r in rooms)
                rm.Add(r);
            unfilteredRooms = rm;
            Rooms = rm;
        }

        public void FilterRooms(string filter)
        {
            
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true; //Start refreshing animation

                    GetRooms(); //Get bookings for user

                    IsRefreshing = false; //Stop refreshing animation
                });
            }
        }

        public void RefreshRooms()
        {
            GetRooms();
        }
    }

}
