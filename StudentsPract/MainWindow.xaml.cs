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

            this.MaxHeight = SystemParameters.WorkArea.Height + (SystemParameters.MaximizedPrimaryScreenHeight - SystemParameters.WorkArea.Height); // Setting maximum height of window aplication (Solve: Maximized window was under taskbar)
            //this.MaxWidth = SystemParameters.WorkArea.Width;

            TopMenu.SelectedIndex = 0; // Set home screen page is activated after startup application and initialize components

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

        private void TopListView_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (((ListView)sender).SelectedIndex != -1) // Kostil for a listview selected items
            {
                //int index = -1;
                string name = ((ListView)sender).Name;

                int index = ((ListView)sender).SelectedIndex;

                if (name.Equals("BottomMenu"))
                {
                    index = 6;
                }

                if (ContentView.IsInitialized)
                {
                    switch (index)
                    {
                        case 0: // Главная страница
                            ContentView.Children.Clear();
                            ContentView.Children.Add(new Home());
                            break;
                        case 1: // Список групп
                            ContentView.Children.Clear();
                            ContentView.Children.Add(new Groups());
                            break;                        
                        case 2: // Список студентов
                            ContentView.Children.Clear();
                            ContentView.Children.Add(new Students());
                            break;
                        case 3: // Реестр баз практики
                            ContentView.Children.Clear();
                            //ContentView.Children.Add(new Practises());
                            break;
                        case 4: // Документы
                            ContentView.Children.Clear();
                            //ContentView.Children.Add(new Documents());
                            break;
                        case 5: // Уведомления
                            ContentView.Children.Clear();
                            //ContentView.Children.Add(new Reminders());
                            break;
                        case 6: // Параметры
                            ContentView.Children.Clear();
                            ContentView.Children.Add(new Preferences());
                            break;
                        default: break;
                    }
                }

                if (name.Equals("TopMenu"))
                {
                    BottomMenu.SelectedIndex = -1; // Unselect BOTTOM ListViewItem
                }
                else if (name.Equals("BottomMenu"))
                {
                    TopMenu.SelectedIndex = -1; // Unselect TOP ListViewItem
                }
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
