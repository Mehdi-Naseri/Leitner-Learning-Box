using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LearningBox.Pages;

namespace LearningBox
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MenuItemBoxes_OnClick(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Boxes());
        }

        private void MenuItemCards_OnClick(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Cards());
        }

        private void MenuItemRead_OnClick(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Read());
        }


        private void MenuItemDictionary_OnClick(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Dictionary());
        }

        private void MenuItemAbout_OnClick(object sender, RoutedEventArgs e)
        {
            //Switcher.Switch(new About());
            MessageBox.Show("Mehdi@Naseri.net\n09177393373", "Contact Us");
        }

    }
}
