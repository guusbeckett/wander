using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        
        public Location(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

    }
}
