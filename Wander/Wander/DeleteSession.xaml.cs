using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
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
    public sealed partial class DeleteSession : UserControl
    {
        private MainPage main;
        public DeleteSession(MainPage main)
        {
            this.InitializeComponent();
            this.main = main;
            updateStringWithCurrentLanguage();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DataController.getInstance().removeSession();
            main.removeChild(this);
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            main.removeChild(this);
        }

        private void updateStringWithCurrentLanguage()
        {
            ResourceLoader rl = new ResourceLoader();
            deleteSession.DataContext = rl.GetString("deleteSessionQuestion");
            Button_Yes.DataContext = rl.GetString("yesButton");
            Button_No.DataContext = rl.GetString("noButton");
        }

    }
}
