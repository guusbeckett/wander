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
        private int selectedIndex = 0;
        MainPage page;
        private DataController datacontroller;
        public ViewSettings(MainPage page)
        {
            this.InitializeComponent();
            GridSetting.DataContext = language;
            datacontroller = DataController.getInstance();
            LanguageComboBox.ItemsSource = datacontroller.giveAllLanguages();
            LanguageComboBox.SelectedIndex = selectedIndex;
            this.page = page;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            page.setHelp();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            page.removeChild(this);
        }

        public List<string> ListLanguages { get; set; }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];
            selectedIndex = LanguageComboBox.SelectedIndex;
            
        }
    }
}
