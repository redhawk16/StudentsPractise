using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

/*            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal principal = (WindowsPrincipal)Thread.CurrentPrincipal;
            WindowsIdentity identity = (WindowsIdentity)principal.Identity;*/

            TextBlock_Username.Text = "Вы вошли под именем: " + Environment.UserName;
        }

        private void ItemCard_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            switch (button.Name)
            {
                case "AddStudent":
                    mainWindow.TopMenu.SelectedIndex = 2;
                    new Windows.Student_add().ShowDialog();
                    break;
                case "AddGroup":
                    mainWindow.TopMenu.SelectedIndex = 1;
                    break;
                case "AddOrder":
                    break;
                case "AddContract":
                    mainWindow.TopMenu.SelectedIndex = 4;
                    new Windows.Contracts().ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}
