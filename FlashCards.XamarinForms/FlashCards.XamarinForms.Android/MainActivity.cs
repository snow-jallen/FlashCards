using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Toasts;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

namespace FlashCards.XamarinForms.Droid
{
    [Activity(Label = "FlashCards.XamarinForms", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            DependencyService.Register<ToastNotification>();
            ToastNotification.Init(this);
            
            LoadApplication(new App(new AndroidNavigation()));
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                System.Diagnostics.Debug.WriteLine("Android back button: there are some pages in the popup stack");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Android back button: there are not any pages in the popup stack");
            }
        }
    }

    public class AndroidNavigation : INavigationService
    {
        public async Task<string> ShowPopupAsync(string prompt)
        {
            await PopupNavigation.Instance.PushAsync(new PopupPage());
            return null;
        }
    }
}