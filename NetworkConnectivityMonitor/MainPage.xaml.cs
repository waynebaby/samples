//    THIS SAMPLE CODE IS PROVIDED FOR THE PURPOSE OF ILLUSTRATION ONLY
//    AND IS NOT INTENDED TO BE USED IN A PRODUCTION ENVIRONMENT.

//    THIS SAMPLE CODE AND ANY RELATED INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY
//    OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NetworkConnectivityMonitor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            bool isConnected = (
                (connectionProfile != null) &&
                (connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                );

            DataContext = new MainViewModel();
            UpdateConnectivityUI(isConnected);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            // don't forget to unregistrer notifications
            NetworkInformation.NetworkStatusChanged -= OnConnectivityChanged;

            base.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // register notification about connectivity changes
            NetworkInformation.NetworkStatusChanged += OnConnectivityChanged;
        }

        private void UpdateConnectivityUI(bool isConnected)
        {
            MainViewModel mvm = DataContext as MainViewModel;
            mvm.IsConnected = isConnected;
            mvm.ConnectivityStatus = isConnected ? "Connected" : "Offline";
        }

        async private void OnConnectivityChanged(object sender)
        {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            bool isConnected = (
                (connectionProfile != null) &&
                (connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                );

            // need to come back to the main thread to update the UI
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                UpdateConnectivityUI(isConnected);
            });

        }

    }
}
