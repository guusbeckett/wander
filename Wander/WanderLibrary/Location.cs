using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        
        public Location(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

    }
}
