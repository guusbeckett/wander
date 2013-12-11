using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    public class Language
    {
        public string name { get; set; }

        public Language(string name)
        {
            this.name = name;
        }

        public string getLanguage()
        {
            return name;
        }
    }
}
