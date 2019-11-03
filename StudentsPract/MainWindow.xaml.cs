using StudentsPract.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsPract
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool hamburger_menu_open = true;

        public MainWindow()
        {
            InitializeComponent();

            TopMenu.SelectedIndex = 0; // Set home screen page is activated after initialize components
        }

        private void hamburger_Click(object sender, RoutedEventArgs e)
        {
            if(hamburger_menu_open == true) {
                hamburger_menu.Width = new GridLength(59);
            } else {
                hamburger_menu.Width = new GridLength(1, GridUnitType.Star);
            }
            hamburger_menu_open = !hamburger_menu_open;
        }

        // TopMenu hide selection
        private void BottomListView_Selected(object sender, RoutedEventArgs e)
        {
            //((ListView)sender).Name
            if (TopMenu.SelectedIndex != -1 || !TopMenu.SelectedIndex.Equals("")) {
                TopMenu.SelectedIndex = -1;
            }
        }

        // BottomMenu hide selection
        private void TopListView_Selected(object sender, SelectionChangedEventArgs e)
        {
            int index = TopMenu.SelectedIndex;

            if (ContentView.IsInitialized)
            {
                switch (index)
                {
                    case 0: // Главное меню
                        ContentView.Children.Clear();
                        ContentView.Children.Add(new Home());
                        break;
                    case 1: //
                        ContentView.Children.Clear();
                        break;
                    case 2: //
                        ContentView.Children.Clear();
                        break;
                    case 3: //
                        ContentView.Children.Clear();
                        break;
                    case 4: // 
                        ContentView.Children.Clear();
                        break;
                    case 5: // Уведомления
                        ContentView.Children.Clear();
                        break;
                    case 6: // Параметры
                        ContentView.Children.Clear();
                        break;
                    default: break;
                }
            }

            if (BottomMenu.SelectedIndex != -1 || !BottomMenu.SelectedIndex.Equals("")) { 
                BottomMenu.SelectedIndex = -1;
            }
        }
    }
}
