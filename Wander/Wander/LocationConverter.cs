using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wander
{
    public class LocationConverter
    {
        public Bing.Maps.Location convertToBingLocation(WanderLib.Location wanderLocation)
        {
            Bing.Maps.Location bingLocation = new Bing.Maps.Location();
            string longitude = wanderLocation.longitude.Remove(wanderLocation.longitude.Length - 1);
            string latitude = wanderLocation.latitude.Remove(wanderLocation.latitude.Length - 1);
            if (DataController.getInstance().session.settings.language.name == "Nederlands")
            {
                bingLocation.Longitude = Convert.ToDouble(longitude.Replace(".", ","));
                bingLocation.Latitude = Convert.ToDouble(latitude.Replace(".", ","));
            }
            else
            {
                bingLocation.Longitude = Convert.ToDouble(longitude);
                bingLocation.Latitude = Convert.ToDouble(latitude);
            }
            return bingLocation;
        }

        public WanderLib.Location convertToWanderLocation(Bing.Maps.Location bingLocation)
        {
            WanderLib.Location wanderLocation = null;
            wanderLocation.longitude = bingLocation.Longitude.ToString() + "E";
            wanderLocation.latitude = bingLocation.Latitude.ToString() + "N";
            return wanderLocation;
        }
    }
}
