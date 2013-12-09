using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wander
{
    class MapController
    {
        private MapController instance;

        public MapController getInstance()
        {
            if (instance == null)
                instance = new MapController();
            return instance;
        }
    }
}
