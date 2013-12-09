using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wander
{
    class DataController
    {
        private DataController instance;

        public DataController getInstance()
        {
            if (instance == null)
                instance = new DataController();
            return instance;
        }
    }
}
