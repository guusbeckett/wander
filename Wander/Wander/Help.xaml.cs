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
    public sealed partial class Help : UserControl
    {
        private string HelpMessage = "Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar, Bonjour ik spreek geen frans maar ik ken wel een frans duits. Haha, loljimlol, dit is een test voor scrollbar";
        MainPage page;
        public Help(MainPage page)
        {
            this.InitializeComponent();
            HelpGrid.DataContext = HelpMessage;
            this.page = page;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            page.removeHelp(this);
        }

    }
}
