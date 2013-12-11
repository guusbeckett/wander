using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    public class Route
    {
        public List<Sight> sights { get; set; }
        public double totalDistance { get; set; }
        public double distanceLeft { get; set; }
        public Location lastLocation { get; set; }
        
        public Route(List<Sight> sights, double totalDistance)
        {
            this.totalDistance = totalDistance;
            this.sights = sights;
        }

        public double routeLeft()
        {
            return distanceLeft;
        }

        public double routeWalked()
        {
            return totalDistance - distanceLeft;
        }


    }
}
