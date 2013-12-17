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
            System.Diagnostics.Debug.WriteLine("difference in latitudes is: {1}", (prevlocation.Latitude - location.Latitude));
            System.Diagnostics.Debug.WriteLine("difference in longitudes is: {1}", (prevlocation.Longitude - location.Longitude));
            //if ((prevlocation.Latitude - location.Latitude))
        }

        public MapController getInstance()
        {
            if (instance == null)
                instance = new MapController();
            return instance;
        }
    }
}
