using HotelClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HotelStaffApp
{
    public class UserHandler
    {
        public static Staff LoggedInUser
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("loggedInStaff"))
                    return JsonConvert.DeserializeObject<Staff>(Application.Current.Properties["loggedInStaff"].ToString());
                else
                    return null;
            }
            set
            {
                if (value == null)
                    Application.Current.Properties.Remove("loggedInStaff");
                else
                    Application.Current.Properties["loggedInStaff"] = JsonConvert.SerializeObject(value);
            }
        }
    }
}
