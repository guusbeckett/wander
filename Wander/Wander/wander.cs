using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wander
{
    class wander
    {
        //private List<Object> languages { get; } //TODO fix zodra library er is
        private GPS GPS; //FIXME zodra GUIController er is
        private List<object> routes; //HINT fix dit zodra library er is
        public MapController mapcontroller; //TASK fix dit zodra MapController er is

        public wander()
        {
            GPS = new GPS();
            mapcontroller = new MapController();
        }
    }
}
