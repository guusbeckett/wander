using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Wander
{
    public sealed partial class ResumeSession : UserControl
    {
        private MainPage main;
        private DataController datacontroller;
        private RouteSelection routes;
        public ResumeSession(MainPage main)
        {
            this.InitializeComponent();
            this.main = main;
            datacontroller = DataController.getInstance();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            datacontroller.setFirstTime(false);
            main.removeChild(this);
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            datacontroller.setFirstTime(false);
            if (routes == null)
                routes = new RouteSelection(main);
            main.setGrid(routes);
            main.removeChild(this);
        }
    }
}
