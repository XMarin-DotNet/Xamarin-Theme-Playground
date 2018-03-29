﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvPrismTabNavigation.ViewModels;
using AdvPrismTabNavigation.Views;
using Prism;
using Prism.Common;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Unity;
using Xamarin.Forms;

namespace AdvPrismTabNavigation.xUnitTest
{
    public partial class TestApp : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public TestApp() : this(null) { }

        public TestApp(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            Container.GetContainer().RegisterInstance<INavigationService>(NavigationService);

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<MyTabbedPage>();
            containerRegistry.RegisterForNavigation<TabChild1Page>();
            containerRegistry.RegisterForNavigation<TabChild2Page>();
            containerRegistry.RegisterForNavigation<TabChild3Page>();
            containerRegistry.RegisterForNavigation<DetailPage>();
            
            containerRegistry.Register<HomePageViewModel>();
            containerRegistry.Register<MyTabbedPageViewModel>();
            containerRegistry.Register<TabChild1PageViewModel>();
            containerRegistry.Register<TabChild2PageViewModel>();
            containerRegistry.Register<TabChild3PageViewModel>();
            containerRegistry.Register<DetailPageViewModel>();
        }
    }
}
