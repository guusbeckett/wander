using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Wander
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string number;
        public MainPage()
        {
            this.InitializeComponent();
            fillGrid();
        }

        private void fillGrid()
        {
            List<String> list = new List<String>();

            for (int i = 0; i < 40; i++ )
            {
                number = i.ToString();
                list.Add("Bezienswaardigheid"+i.ToString());
            }
            lijstje.ItemsSource = list;  
        }
    }
}
