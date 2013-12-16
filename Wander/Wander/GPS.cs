using Bing.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Wander
{
    class GPS
    {
        private Location location;
        Geolocator geo = null;

        public Location getLocation()
        {
            calculateLocation();
            return location;
        }

        private async void calculateLocation()
        {
            if (geo == null)
            {
                geo = new Geolocator();
            } 

            Geoposition pos = await geo.GetGeopositionAsync();
            location.Latitude = pos.Coordinate.Latitude;
            location.Longitude = pos.Coordinate.Longitude;
        }
        
        
    }
}
