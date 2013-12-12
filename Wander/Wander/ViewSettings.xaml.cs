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
    public sealed partial class ViewSettings : UserControl
    {
        private string language = "Talen";
        MainPage page;
        public ViewSettings(MainPage page)
        {
            this.InitializeComponent();
            GridSetting.DataContext = language;
            LanguageComboBox.ItemsSource = ListLanguages;
            this.page = page;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            page.setHelp();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            page.removeSettings(this);
        }

        public List<string> ListLanguages { get; set; }
    }
}
