using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HotelStaffApp.Droid
{
    [Activity(Label = "HotelGo Staff", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                LoadApplication(new App());
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }
    }
}