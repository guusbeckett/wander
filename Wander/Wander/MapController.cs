using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wander
{
    class MapController
    {
        private MapController instance;
        private List<Bing.Maps.Location> previouspoints;

        public void addPointToListIfDistanceToPreviousIsGreatEnough(Bing.Maps.Location location)
        {
            if (previouspoints == null)
            {
                previouspoints = new List<Bing.Maps.Location>();
                previouspoints.Add(location);
                return;
            }
            Bing.Maps.Location prevlocation = previouspoints[previouspoints.Count-1];
            double latdif = prevlocation.Latitude - location.Latitude;
            double longdif = prevlocation.Longitude - location.Longitude;
            if (latdif < 0)
                latdif = latdif + (latdif + latdif);
            if (longdif < 0)
                longdif = longdif + (longdif + longdif);
            if (latdif >= 0.001 || longdif >= 0.001)
            {
                previouspoints.Add(location);
            }
            System.Diagnostics.Debug.WriteLine("difference in latitudes is: {0}", latdif);
            System.Diagnostics.Debug.WriteLine("difference in longitudes is: {0}", longdif);
            //if ((prevlocation.Latitude - location.Latitude))
        }

        public List<Bing.Maps.Location> locations()
        {
            return previouspoints;
        }

        public MapController getInstance()
        {
            if (instance == null)
                instance = new MapController();
            return instance;
        }
    }
}
