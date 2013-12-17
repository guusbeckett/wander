using Bing.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
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
        ResumeSession resume;
        Help help;
        Geolocator geo = null;
        Location currentLocation;
        Pushpin location = new Pushpin();

        public MainPage()
        {
            this.InitializeComponent();
            datacontroller = DataController.getInstance();
            sightList.ItemsSource = datacontroller.giveStringsOfLoadedSights();
            geo = new Geolocator();
            geo.DesiredAccuracy = PositionAccuracy.High;
            geo.PositionChanged += geolocator_PositionChanged;
            Map.Children.Add(location);
            resume = new ResumeSession();
            GridRoot.Children.Add(resume);
        }


        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (settings == null)
                settings = new ViewSettings(this);
            if(!GridRoot.Children.Contains(settings))
            {
                GridRoot.Children.Add(settings);
            }
            
        }

        public void setHelp(Boolean refresh)
        {
            help = new Help(this, refresh);
            GridRoot.Children.Add(help);
            removeChild(settings);
        }

        public void removeChild(UIElement e)
        {
            GridRoot.Children.Remove(e);
        }

        public async void showErrorMessage(string title, string content)
        {
            var dialog = new MessageDialog(content, title);
            await dialog.ShowAsync();
        }

        private async void sightList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(Message), selectedItem);
            }
        }

        private async void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(
            () =>
            {
                if(currentLocation == null)
                {
                    currentLocation = new Location(args.Position.Coordinate.Latitude, args.Position.Coordinate.Longitude);
                    Map.SetView(currentLocation, 16);
                }
                MapLayer.SetPosition(location, currentLocation);
            }));
        }

    }
}
