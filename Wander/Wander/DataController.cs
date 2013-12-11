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
        private List<WanderLib.Sight> loadedSights { get; set; }
        


        public static DataController getInstance()
        {

            if (instance == null)
                instance = new DataController();
            return instance;
        }

        public List<string> giveStringsOfLoadedSights()
        {
            if (loadedSights == null)
                loadedSights = giveAllSightsOnRoute();
            List<string> strings = new List<string>();
            foreach(WanderLib.Sight sight in loadedSights)
            {
               strings.Add(sight.name);
            }
            return strings;
        }

        public List<WanderLib.Sight> giveAllSightsOnRoute(string Route="")
        {
            //TODO vervang stub
            List<WanderLib.Sight> list = new List<WanderLib.Sight>();
            string lorips = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur at rhoncus sem. Etiam placerat aliquet dapibus. Nulla nisi massa, iaculis sed nibh non, consequat semper orci. Donec id magna turpis. Aliquam consequat lorem a sapien consequat vulputate. Duis id nulla ultricies, mollis justo id, posuere sem. Donec gravida felis at felis malesuada pretium. Sed lorem purus, eleifend commodo tellus non, vulputate imperdiet mauris. Pellentesque vel sapien a nunc lacinia molestie non ac risus. Duis sit amet mi et massa dignissim tristique. Ut id posuere quam, a ornare felis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc feugiat augue diam, at pulvinar dui mattis et. Donec scelerisque blandit tellus, luctus hendrerit arcu volutpat quis. Suspendisse nec interdum est. Curabitur risus metus, tincidunt eu dolor ut, consequat imperdiet nulla.\n\nVestibulum vehicula at odio a dapibus. Donec sodales purus ligula, a varius nunc bibendum quis. Vestibulum at velit consequat, volutpat metus nec, suscipit lacus. Suspendisse venenatis magna ac cursus auctor. Praesent a nisl nisi. Nunc non purus pulvinar, mollis eros vel, posuere nisi. In eu sapien vitae metus lobortis hendrerit id id augue. Nullam mauris ligula, volutpat vel interdum ac, viverra at nunc. Donec imperdiet vestibulum urna, sed dignissim enim tincidunt a. Nam tempus pellentesque est ut tempus.\n\nSuspendisse potenti. Pellentesque felis dolor, faucibus at volutpat id, ullamcorper in purus. Quisque urna nulla, dignissim quis molestie quis, egestas sed purus. Integer in urna ut nisi eleifend interdum non sed metus. Aliquam nulla nunc, mollis at consequat at, ultricies quis nulla. Donec auctor lacus nisi, nec congue libero cursus at. Suspendisse potenti. In eleifend neque ut sollicitudin porta. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.\n\nSed a magna in lacus bibendum laoreet. Interdum et malesuada fames ac ante ipsum primis in faucibus. Maecenas non mollis libero. Vestibulum porta ultricies libero, quis malesuada nisi scelerisque vitae. Morbi ut laoreet tortor, sed vehicula nisl. Phasellus aliquet arcu id orci ultricies, tristique lacinia arcu ultrices. Vestibulum iaculis tortor interdum, hendrerit est sit amet, varius felis. Suspendisse a orci vel ante placerat volutpat quis vitae nisl. Vestibulum et placerat magna.\n\nSed pulvinar at arcu in consequat. Ut eleifend fermentum arcu a imperdiet. Curabitur tempus pulvinar elit. Phasellus euismod, justo in tincidunt scelerisque, lorem turpis ornare elit, sit amet congue odio mi sit amet nisi. Fusce at justo enim. Donec aliquam vel velit at faucibus. Sed imperdiet iaculis orci sit amet sollicitudin. Ut rutrum magna orci.";
            list.Add(new WanderLib.Sight(null, "VVV Breda", lorips, new WanderLib.Location("51.59380N", "4.77963E")));
            list.Add(new WanderLib.Sight(null, "Liefdeszuster", lorips, new WanderLib.Location("51.59307N", "4.77969E")));
            list.Add(new WanderLib.Sight(null, "Kasteel van Breda", lorips, new WanderLib.Location("51.59061N", "4.77624E")));
            list.Add(new WanderLib.Sight(null, "Grote Kerk", lorips, new WanderLib.Location("51.58878N", "4.77549E")));
            list.Add(new WanderLib.Sight(null, "Bevrijdingsmonument", lorips, new WanderLib.Location("51.58797N", "4.77638E")));
            return list;
        }
    }
}
