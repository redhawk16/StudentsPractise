using StudentsPract.Adapters;
using StudentsPract.Classes;
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
using System.Windows.Shapes;

namespace StudentsPract.Pages.Employees
{
    /// <summary>
    /// Логика взаимодействия для Employee_Add.xaml
    /// </summary>
    public partial class Employee_Add : Window
    {
        private List<Control> controls = new List<Control>();

        public Employee_Add()
        {
            InitializeComponent();

            controls = new List<Control>() { surname, name, patronymic, phone, email, login, lvl };

            lvl.ItemsSource = Helper.levels;

            // EventHandler's
            surname.TextChanged += Controls_Listener;
            name.TextChanged += Controls_Listener;
            patronymic.TextChanged += Controls_Listener;
            phone.TextChanged += Controls_Listener;
            email.TextChanged += Controls_Listener;
            login.TextChanged += Controls_Listener;
            lvl.SelectionChanged += Controls_Listener;
        }

        protected void Controls_Listener(object sender, EventArgs e)
        {
            btnAdd.IsEnabled = Helper.Controls_Listener(controls);
        }

        private void Button_Listener(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "FormClose":
                    this.Close();
                    break;
                case "btnAdd":
                    Helper.Level level = (Helper.Level)Enum.Parse(typeof(Helper.Level), lvl.SelectedItem.ToString().Trim()); // Convert string (Selected Level) to enum

                    SQLiteAdapter.SetValue("employees",
                            surname.Text.Trim(),
                            name.Text.Trim(),
                            patronymic.Text.Trim(),
                            phone.Text.Trim(),
                            email.Text.Trim(),
                            login.Text.Trim(),
                            level.GetHashCode().ToString()
                    );
                    // Refresh ObservableCollection for update dataGrids
                    Helper.RefreshOCollection();
                    /*Helper.OEmployees.Add(new Employee
                    {
                        id = (Helper.OEmployees.Count() + 1).ToString(),
                        surname = surname.Text.Trim(),
                        name = name.Text.Trim(),
                        patronymic = patronymic.Text.Trim(),
                        phone = phone.Text.Trim(),
                        email = email.Text.Trim(),
                        login = login.Text.Trim(),
                        lvl = level.GetHashCode().ToString()
                    });*/
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
