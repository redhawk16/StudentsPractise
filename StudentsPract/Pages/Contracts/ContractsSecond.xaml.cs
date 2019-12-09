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

namespace StudentsPract.Pages.Contracts
{
    /// <summary>
    /// Логика взаимодействия для ContractsSecond.xaml
    /// </summary>
    public partial class ContractsSecond : Page
    {
        public ContractsSecond()
        {
            InitializeComponent();
            
            formPract.ItemsSource = new List<string> { "Учебная", "Производственная" }; // Вид практики

            /* TODO:
             * Получаем на вход данные из ContractsFirst 
             * В type_pract исходя из полученных данных, получить обьедененные типы практики из таблиц => занести необходимые группы в TreeView 
             */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "btnClose":
                    Window parentWindow = Window.GetWindow(this);
                    parentWindow.Close();
                    break;
                case "btnCreate":
                    MessageBox.Show("Договор сформирован", "Формирование договора", MessageBoxButton.OK);
                    break;
                default:
                    break;
            }
        }
    }
}
