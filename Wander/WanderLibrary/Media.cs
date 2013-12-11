using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib.Media
{
    public class Media
    {
        public string fileLocation { get; set; }
        
        public Media(Type type, string fileLocation)
        {
            fileLocation = "";
        }

        public enum Type
        {
            AUDIO,
            VIDEO,
            PHOTO
        }
    }
} 