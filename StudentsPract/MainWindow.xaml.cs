using StudentsPract.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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

            TopMenu.SelectedIndex = 0; // Set home screen page is activated after startup application and initialize components

            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        private void hamburger_Click(object sender, RoutedEventArgs e)
        {
            if(hamburger_menu_open == true) {
                hamburger_menu.Width = new GridLength(59); // Sidebar length
                hamburger.ToolTip = "Открыть область навигации";
            } else {
                hamburger_menu.Width = new GridLength(1, GridUnitType.Star); // Sidebar length sets to autosize
                hamburger.ToolTip = "Закрыть область навигации";
            }
            hamburger_menu_open = !hamburger_menu_open;
        }

        private void BottomListView_Selected(object sender, RoutedEventArgs e)
        {
            //((ListView)sender).Name

            // TopMenu hide selection
            if (TopMenu.SelectedIndex != -1 || !TopMenu.SelectedIndex.Equals("")) {
                TopMenu.SelectedIndex = -1;
            }
        }

        private void TopListView_Selected(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(((ListView)sender).Name);
            int index = TopMenu.SelectedIndex;
            //int f = (ListView)this.[Name];

            if ( ((ListView)sender).Name.Equals("BottomMenu") ) { index = 5; }

            if (ContentView.IsInitialized)
            {
                switch (index)
                {
                    case 0: // Главная страница
                        ContentView.Children.Clear();
                        ContentView.Children.Add(new Home());
                        break;
                    case 1: // Список студентов
                        ContentView.Children.Clear();
                        ContentView.Children.Add(new Students());
                        break;
                    case 2: // Реестр баз практики
                        ContentView.Children.Clear();
                        break;
                    case 3: // Договора на практику
                        ContentView.Children.Clear();
                        break;
                    case 4: // Уведомления
                        ContentView.Children.Clear();
                        break;
                    case 5: // Параметры
                        ContentView.Children.Clear();
                        break;
                    default: break;
                }
            }

            // BottomMenu hide selection
            if (BottomMenu.SelectedIndex != -1 || !BottomMenu.SelectedIndex.Equals("")) { 
                BottomMenu.SelectedIndex = -1;
            }
        }

        #region windowsButtons

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }        
        private void ButtonMax_Click(object sender, RoutedEventArgs e)
        {
            window.WindowState ^= WindowState.Maximized;
        }       
        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        #endregion
    }
}
