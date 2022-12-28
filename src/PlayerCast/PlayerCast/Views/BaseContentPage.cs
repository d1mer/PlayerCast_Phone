using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Page = Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page;

namespace PlayerCast.Views
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Page.SetUseSafeArea(On<iOS>(), true);
        }
    }
}

