using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Storage;

namespace Wander
{
    class DataController
    {
        private static DataController instance;

        


        public static DataController getInstance()
        {

            if (instance == null)
                instance = new DataController();
            return instance;
        }

        //public List<>giveAllSightsOnRoute
    }
}
