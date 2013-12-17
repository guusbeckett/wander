using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanderLib
{
    public class Waypoint
    {
        public string information { get; set; }
        public Location location { get; set; }

        public Waypoint(string information, Location location)
        {
            this.information = information;
            this.location = location;
        }

        
    }
}
