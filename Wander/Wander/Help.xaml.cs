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
    public sealed partial class Help : UserControl
    {
        private MainPage page;
        private DataController datacontroller;
        private Boolean refresh = false;
        public Help(MainPage page, Boolean refresh)
        {
            this.InitializeComponent();
            this.page = page;
            datacontroller = DataController.getInstance();
            this.refresh = refresh;
            updateStringWithCurrentLanguage();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            page.removeChild(this);
        }

        private void updateStringWithCurrentLanguage()
        {
            ResourceLoader rl = new ResourceLoader();
            helpBox.DataContext = rl.GetString("helpBox");
            needHelp.DataContext = rl.GetString("NeedHelp");
        }

    }
}
