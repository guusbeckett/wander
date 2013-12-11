using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    class Sight
    {
        private Dictionary<Media.Media.Type, Media.Media> media { get; set; }
        private string name { get; set; }
        private string information { get; set; }
        private Location location { get; set; }
        private Boolean isVisited;

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
        private void setToVisited()
        {
            isVisited = true;
        }

    }
}
