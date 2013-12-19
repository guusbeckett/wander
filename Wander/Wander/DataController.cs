using Bing.Maps;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;

namespace Wander
{
    class DataController
    {
        private static DataController instance;
        public List<WanderLib.Waypoint> loadedSights { get; set; }
        private List<WanderLib.Sight> sightsonly { get; set; }
        public WanderLib.Session session { get; set; }
        public int selectedLanguage { get; set; }
        public Boolean firstTimeStart = true;
        public Double distance { get; set; }



        public static DataController getInstance()
        {
            if (instance == null)
                instance = new DataController();
            return instance;
        }

        public void setFirstTime(Boolean boolean)
        {
            this.firstTimeStart = boolean;
		}
		
        public DataController()
        {
            session = new WanderLib.Session();
            session.settings = new WanderLib.Settings();
            session.settings.language = new WanderLib.Language("Nederlands");
            session.route = new WanderLib.Route("historische kilometer", giveAllWaypointsOnRoute(), 20);
            //session.routeWalked = null;
        }





        public List<string> giveStringsOfLoadedSights()
        {
            if (loadedSights == null)
                loadedSights = giveAllWaypointsOnRoute();
            List<string> strings = new List<string>();
            sightsonly = new List<WanderLib.Sight>();
            foreach(WanderLib.Waypoint sight in loadedSights)
            {
                if (sight.GetType() == (typeof(WanderLib.Sight)))
                {
                    strings.Add(((WanderLib.Sight)sight).name);
                    sightsonly.Add((WanderLib.Sight)sight);
                }
            }
            return strings;
        }

        public List<WanderLib.Route> giveAllRoutes()
        {
            List<WanderLib.Route> routes = new List<WanderLib.Route>();
            routes.Add(new WanderLib.Route("historische kilometer" ,giveAllWaypointsOnRoute(), 20));
            return routes;
		}
        public void setSightSeenTrue(String geofence)
        {
            foreach(WanderLib.Waypoint sight in loadedSights)
            {
                if (sight.GetType() == (typeof(WanderLib.Sight)))
                {
                    WanderLib.Sight convertedSight = ((WanderLib.Sight)sight);
                    if (convertedSight.name == geofence)
                    {
                        convertedSight.isVisited = true;
                        break;
                    }
                }
            }
        }

        public List<WanderLib.Language> giveAllLanguages()
        {
            List<WanderLib.Language> languages = new List<WanderLib.Language>();
            languages.Add(new WanderLib.Language("Nederlands"));
            languages.Add(new WanderLib.Language("English"));
            languages.Add(new WanderLib.Language("日本人"));
            return languages;
        }

        public List<WanderLib.Waypoint> giveAllWaypointsOnRoute(string Route="")
        {
            System.Xml.Linq.XDocument GPSpoints = System.Xml.Linq.XDocument.Load("Assets/GPS2.xml");
            var data = from item in GPSpoints.Descendants("waypoint")
                       select new
                       {
                           Lat = item.Element("Latitude").Value,
                           Long = item.Element("Longitude").Value,
                           name = item.Element("Site").Value,
                           fotos = item.Element("Fotos").Value
                       };
            string informationfile = "";
            switch(session.settings.language.name)
            {
                case "English":
                    informationfile = "Languages/en/information.xml";
                    break;
                case "Nederlands":
                    informationfile = "Languages/nl/information.xml";
                    break;
                default:
                    informationfile = "Languages/nl/information.xml";
                    break;

            }
            System.Xml.Linq.XDocument informations = System.Xml.Linq.XDocument.Load(informationfile);
            var data2 = from item in informations.Descendants("item")
                       select new
                       {
                           Name = item.Element("Name").Value,
                           Text = item.Element("Text").Value,

                       };
            List<WanderLib.Waypoint> list = new List<WanderLib.Waypoint>();
            foreach(var dat in data)
            {
                string text = "";
                foreach(var dat2 in data2)
                {
                    if (dat.name.ToLower() == dat2.Name.ToLower())
                        text = dat2.Text;
                }
                Dictionary<WanderLib.Media.Media, WanderLib.Media.Media.Type> media = new Dictionary<WanderLib.Media.Media, WanderLib.Media.Media.Type>();
                if (dat.fotos!="")
                {
                    if (dat.fotos.Contains(":"))
                    {
                        foreach(string medium in dat.fotos.Split(':'))
                        {
                            media.Add(new WanderLib.Media.Media(WanderLib.Media.Media.Type.PHOTO, "ms-appx:///Assets/photos/" + medium + ".jpg"), WanderLib.Media.Media.Type.PHOTO);
                        }
                    }
                    else
                    {
                        media.Add(new WanderLib.Media.Media(WanderLib.Media.Media.Type.PHOTO, "ms-appx:///Assets/photos/" + dat.fotos + ".jpg"), WanderLib.Media.Media.Type.PHOTO);
                    }
                }
                if (dat.name!="")
                    list.Add(new WanderLib.Sight(media, dat.name, text, new WanderLib.Location(dat.Lat, dat.Long)) as WanderLib.Waypoint);
                else
                    list.Add(new WanderLib.Waypoint(text, new WanderLib.Location(dat.Lat, dat.Long)));
            }
            //TODO vervang stub
            return list;
        }

        public void setSightsWithGeofences(Map bingMap)
        {

            foreach(WanderLib.Waypoint s in loadedSights)
            {
                    if (s.GetType() == (typeof(WanderLib.Sight)))
                    {
                        WanderLib.Sight sight = (WanderLib.Sight)s;

                        LocationConverter converter = new LocationConverter();
                        Location location = converter.convertToBingLocation(s.location);

                        Pushpin pin = new Pushpin();

                        Geofence geofence = new Geofence(sight.name+"_20m", new Geocircle(
                        new BasicGeoposition
                        {
                            Altitude = 0.0,
                            Latitude = location.Latitude,
                            Longitude = location.Longitude
                        },
                        20), MonitoredGeofenceStates.Entered, true, new TimeSpan(5));

                        GeofenceMonitor.Current.Geofences.Add(geofence);

                        geofence = new Geofence(sight.name + "_5m", new Geocircle(
                        new BasicGeoposition
                        {
                            Altitude = 0.0,
                            Latitude = location.Latitude,
                            Longitude = location.Longitude
                        },
                        20), MonitoredGeofenceStates.Entered, true, new TimeSpan(5));
                        GeofenceMonitor.Current.Geofences.Add(geofence);

                        pin.Text = sight.name;
                        MapLayer.SetPosition(pin, location);
                        bingMap.Children.Add(pin);
                } 
            }
        }

        public async void saveSession()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                using (Stream xmlstreamAwait = await folder.OpenStreamForWriteAsync("session.xml", CreationCollisionOption.ReplaceExisting))
                    Serializer.SerializeWithLengthPrefix<WanderLib.Session>(xmlstreamAwait, session, PrefixStyle.Base128);
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.Message); }
            
        }

        public async void openSession()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                using (Stream xmlstreamAwait = await folder.OpenStreamForWriteAsync("session.xml", CreationCollisionOption.ReplaceExisting))
                    DataController.instance.session = Serializer.Deserialize<WanderLib.Session>(xmlstreamAwait);
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.Message); }
        }


        public async void removeSession()
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                await folder.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.Message); }
        }


        public async Task calculateToNextPoint(Map bingMap, String geolocation)
        {
            LocationConverter converter = new LocationConverter();
            Bing.Maps.Directions.WaypointCollection waypoints = new Bing.Maps.Directions.WaypointCollection();
            Bing.Maps.Directions.DirectionsManager directionsManager = bingMap.DirectionsManager;


            foreach (WanderLib.Sight s in sightsonly)
            {
                if (geolocation == s.name)
                {
                    int i = sightsonly.IndexOf(s);

                    if (i+1 < sightsonly.Count())
                    {
                        waypoints.Add(new Bing.Maps.Directions.Waypoint(converter.convertToBingLocation(s.location)));
                        waypoints.Add(new Bing.Maps.Directions.Waypoint(converter.convertToBingLocation(sightsonly[i + 1].location)));

                        directionsManager.RequestOptions.RouteMode = Bing.Maps.Directions.RouteModeOption.Walking;
                        directionsManager.Waypoints = waypoints;

                        Bing.Maps.Directions.RouteResponse response = await directionsManager.CalculateDirectionsAsync();

                        distance = response.Routes[0].TravelDistance * 1000;

                        break;
                    }
                }    
            }
        }

        public async void calculateRoute(Map bingMap)
        {
            Bing.Maps.Directions.WaypointCollection waypoints = new Bing.Maps.Directions.WaypointCollection();
            Bing.Maps.Directions.DirectionsManager directionsManager = bingMap.DirectionsManager;

            LocationConverter converter = new LocationConverter();
            List<WanderLib.Waypoint> waypointsOnRoute = giveAllWaypointsOnRoute();

            foreach (WanderLib.Waypoint s in loadedSights)
            {
                if (s.GetType() == (typeof(WanderLib.Sight)))
                {

                    Location location = converter.convertToBingLocation(s.location);

                    Bing.Maps.Directions.Waypoint waypoint = new Bing.Maps.Directions.Waypoint(location);


                    waypoints.Add(waypoint);
                }


            }

            directionsManager.RequestOptions.RouteMode = Bing.Maps.Directions.RouteModeOption.Walking;
            //directionsManager.RenderOptions.WaypointPushpinOptions.
            //directionsManager.RenderOptions.WaypointPushpinOptions.Visible = false;
            directionsManager.Waypoints = waypoints;

            // Calculate route directions
            Bing.Maps.Directions.RouteResponse response = await directionsManager.CalculateDirectionsAsync();
        }



        public List<Location> getWaypointLocations()
        {
            List<WanderLib.Waypoint> waypointsOnRoute = giveAllWaypointsOnRoute();
            LocationConverter converter = new LocationConverter();
            List<Location> locations = new List<Location>(); ;

            foreach (WanderLib.Waypoint w in waypointsOnRoute)
            {
                Location location = converter.convertToBingLocation(w.location);

                locations.Add(location);
            }

            return locations;
        }

        internal Boolean getFirstTime()
        {
            return firstTimeStart;
        }

        public List<WanderLib.Location> getWalkedRouteConvertedToWanderLocation()
        {
            MapController mapController = MapController.getInstance();
            LocationConverter converter = new LocationConverter();

            List<Bing.Maps.Location> previouspoints = mapController.locations();

            List<WanderLib.Location> locations = new List<WanderLib.Location>();
            if (previouspoints != null && previouspoints.Count > 0)
            {
                foreach (Bing.Maps.Location location in previouspoints)
                {
                    locations.Add(converter.convertToWanderLocation(location));
                }
            }

            return locations;
        }
    }
}
