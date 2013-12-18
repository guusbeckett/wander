using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wander
{
    class wander
    {
        private GPS GPS;
        private List<object> routes;
        public MapController mapcontroller;

        public wander()
        {
            GPS = new GPS();
            mapcontroller = new MapController();
        }
    }
}
