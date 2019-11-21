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

namespace StudentsPract.Pages
{
    /// <summary>
    /// Логика взаимодействия для Preferences.xaml
    /// </summary>
    public partial class Preferences : UserControl
    {

        public Preferences()
        {
            InitializeComponent();

            List<string> Themes = new List<string> { "Dark", "Light" };
            themeSwitcher.ItemsSource = Themes;
            themeSwitcher.SelectedIndex = 0;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string selectedTheme = themeSwitcher.SelectedItem as string;
            Uri uri = new Uri("Themes/" + selectedTheme + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            /*TODO: save theme and load from setting file*/
        }
    }
}
