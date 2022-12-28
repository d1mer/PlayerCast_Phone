using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlayerCast.Views.Phone
{
    public partial class TabbedPagePhone : Xamarin.Forms.TabbedPage
    {
        public TabbedPagePhone()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }
    }
}
