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
	public partial class LoggedInTabbedPage : TabbedPage
	{
		public LoggedInTabbedPage ()
		{
			InitializeComponent ();
		}
	}
}