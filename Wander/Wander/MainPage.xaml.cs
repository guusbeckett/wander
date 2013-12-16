using Bing.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Wander
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        string number;
        DataController datacontroller;
        ViewSettings settings;
        Help help;

        public MainPage()
        {
            this.InitializeComponent();

            GeofenceMonitor.Current.GeofenceStateChanged += Current_GeofenceStateChanged;
            datacontroller = DataController.getInstance();
            sightList.ItemsSource = datacontroller.giveStringsOfLoadedSights();
            datacontroller.setSightsWithGeofences(bingMap);
            calculateRoute();
            setPinListeners();
        }


        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (settings == null)
            {
                settings = new ViewSettings(this);
                GridRoot.Children.Add(settings);
            }
        }

        public void setHelp()
        {
            help = new Help(this);
            GridRoot.Children.Add(help);
            removeSettings(settings);
        }

        public void removeSettings(ViewSettings vs)
        {
            GridRoot.Children.Remove(vs);
            settings = null;
        }

        public void removeHelp(Help h)
        {
            GridRoot.Children.Remove(h);
            help = null;
        }

        public async void showErrorMessage(string title, string content)
        {
            var dialog = new MessageDialog(content, title);
            await dialog.ShowAsync();
        }

        private void setPinListeners()
        {
            foreach(Pushpin pin in bingMap.Children)
            {

                pin.Tapped += Current_location_pushpin_tapped;

            }
        }

        void Current_location_pushpin_tapped(object sender, TappedRoutedEventArgs e)
        {
            var selectedItem = ((Pushpin)sender).Text;
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(Message), selectedItem);
            }
        }

        private async void sightList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(Message), selectedItem);
            }
        }

        async void Current_GeofenceStateChanged(GeofenceMonitor sender, object args)
        {
            var reports = sender.ReadReports();

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {

                foreach (GeofenceStateChangeReport report in reports)
                {
                    GeofenceState state = report.NewState;

                    Geofence geofence = report.Geofence;

                    if (state == GeofenceState.Entered)
                    {
                        var message = new MessageDialog(geofence.Id, "Het werkt!");
                        await message.ShowAsync();
                    }
                }
            });
        }

        private async void calculateRoute()
        {
            datacontroller.calculateRoute(bingMap);
        }

    }
}
