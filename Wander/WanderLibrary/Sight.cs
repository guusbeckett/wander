using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    public class Sight
    {
        public Dictionary<Media.Media.Type, Media.Media> media { get; set; }
        public string name { get; set; }
        public string information { get; set; }
        public Location location { get; set; }
        public Boolean isVisited;

        public Sight(Dictionary<Media.Media.Type, Media.Media> media, string name, string information, Location location)
        {
            this.media = media;
            this.name = name;
            this.information = information;
            this.location = location;
            isVisited = false;
        }
        public Sight(Dictionary<Media.Media.Type, Media.Media> media, string name, string information, Location location, Boolean isVisited)
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
