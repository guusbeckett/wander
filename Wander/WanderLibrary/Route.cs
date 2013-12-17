using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    public class Route
    {
        public string name { get; set; }
        public List<Waypoint> waypoints { get; set; }
        public double totalDistance { get; set; }
        public double distanceLeft { get; set; }
        public Location lastLocation { get; set; }
        
        public Route(string name, List<Waypoint> waypoints, double totalDistance)
        {
            this.name = name;
            this.totalDistance = totalDistance;
            this.waypoints = waypoints;
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
