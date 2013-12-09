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

        private void setToVisited()
        {
            isVisited = true;
        }

    }
}
