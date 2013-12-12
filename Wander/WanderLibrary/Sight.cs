using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    public class Sight : Waypoint
    {
        public Dictionary<Media.Media.Type, Media.Media> media { get; set; }
        public string name { get; set; }
        public Boolean isVisited;

        public Sight(Dictionary<Media.Media.Type, Media.Media> media, string name, string information, Location location):base(information, location)
        {
            this.media = media;
            this.name = name;
            this.information = information;
            this.location = location;
            isVisited = false;
        }
        public Sight(Dictionary<Media.Media.Type, Media.Media> media, string name, string information, Location location, Boolean isVisited):base(information,location)
        {
            this.media = media;
            this.name = name;
            this.information = information;
            this.location = location;
            this.isVisited = isVisited;
        }
        
        public void setToVisited()
        {
            isVisited = true;
        }

    }
}
