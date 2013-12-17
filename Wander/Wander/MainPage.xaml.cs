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
        DataController datacontroller;
        ViewSettings settings;
        MapShapeLayer polygonLayer;
        Help help;

        public MainPage()
        {
            this.InitializeComponent();
            GeofenceMonitor.Current.Geofences.Clear();
            GeofenceMonitor.Current.GeofenceStateChanged += Current_GeofenceStateChanged;
            polygonLayer = new MapShapeLayer();
            bingMap.ShapeLayers.Add(polygonLayer);
            datacontroller = DataController.getInstance();
            sightList.ItemsSource = datacontroller.giveStringsOfLoadedSights();
            datacontroller.setSightsWithGeofences(bingMap);
            drawRoute();
            setPinListeners();
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

        public void setHelp()
        {
            help = new Help(this);
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
                        if (geofence.Id.EndsWith("_20m"))
                        {
                            var message = new MessageDialog(((String)geofence.Id).Split('_').First(), "U bent in de buurt van de volgende locatie;");
                            await message.ShowAsync();
                        }
                        else if (geofence.Id.EndsWith("_5m"))
                        {
                            foreach(Pushpin pin in bingMap.Children)
                            {
                                if(pin.Text == ((String)geofence.Id).Split('_').First())
                                {
                                    pin.Background = new SolidColorBrush(Colors.Black);
                                }
                            }
                        }
                        
                    }
                }
            });
        }

        private void drawWalkedRoute()
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Color = Windows.UI.Colors.Blue;
            polyline.Width = 3;

            polyline.Locations = new LocationCollection();
            List<Bing.Maps.Location> locations = null;

            foreach (Bing.Maps.Location location in locations)
            {
                polyline.Locations.Add(location);
            }


            polyline.Visible = true;


            polygonLayer.Shapes.Add(polyline);
        }

        private void drawRoute()
        {
            MapPolyline polyline = new MapPolyline(); 
            polyline.Color = Windows.UI.Colors.Red;
            polyline.Width = 3;

            polyline.Locations = new LocationCollection();
            List<Location> locations = datacontroller.getWaypointLocations();

            foreach (Location location in locations)
            {
                polyline.Locations.Add(location);
            }


            polyline.Visible = true;


            polygonLayer.Shapes.Add(polyline);
        }

    }
}
