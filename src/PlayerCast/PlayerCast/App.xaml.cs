using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Ioc;
using Prism;
using PlayerCast.Views.Phone;
using PlayerCast.Views.Tablet;
using PlayerCast.ViewModels;
using PlayerCast.Services.Rest;

namespace PlayerCast
{
    public partial class App : PrismApplication
    {
        public App (IPlatformInitializer platformInitializer = null)
            : base(platformInitializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Phone)
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(TabbedPagePhone)}");
            }
            else
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(TabbedPageTablet)}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region -- Services --

            containerRegistry.RegisterInstance<IRestService>(Container.Resolve<RestService>());

            #endregion

            #region -- Navigation --

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedPagePhone>();
            containerRegistry.RegisterForNavigation<TabbedPageTablet>();
            containerRegistry.RegisterForNavigation<DiscoverPage, DiscoverPageViewModel>();
            containerRegistry.RegisterForNavigation<DiscoverPageTablet, DiscoverPageViewModel>();
            containerRegistry.RegisterForNavigation<LibraryPage, LibraryPageViewModel>();
            containerRegistry.RegisterForNavigation<LibraryPageTablet, LibraryPageViewModel>();
            containerRegistry.RegisterForNavigation<PersonalPage, PersonalPageViewModel>();
            containerRegistry.RegisterForNavigation<PersonalPageTablet, PersonalPageViewModel>();

            #endregion
        }
    }
}

