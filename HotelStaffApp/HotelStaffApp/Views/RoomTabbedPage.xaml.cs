using HotelClassLibrary;
using HotelStaffApp.Views;
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
    public partial class RoomTabbedPage : TabbedPage
    {
        public RoomTabbedPage (Room r)
        {
            InitializeComponent();

            var infoPage = new NavigationPage(new SelectedRoomPage(r));
            infoPage.Title = "Room";
            infoPage.Icon = "info.png";

            var errorPage = new NavigationPage(new ReportRoomErrorPage(r));
            errorPage.Title = "Report Error";
            errorPage.Icon = "error_black.png";

            Children.Add(infoPage);
            Children.Add(errorPage);
        }
    }
}