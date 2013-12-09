using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    class GPS
    {
        public Boolean isConnected { get; set; }
        private Location location;
        
        public Location getLocation()
        {
            //TODO add location calculation, but it may be better to handle this in control.
            return location;
        }
    }
}
