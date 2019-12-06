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
    /// Логика взаимодействия для Employee_Edit.xaml
    /// </summary>
    public partial class Employee_Edit : Window
    {
        private Employee employee;
        private List<Control> controls = new List<Control>();

        public Employee_Edit(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;

            controls = new List<Control>() { surname, name, patronymic, phone, email, login, lvl };

            lvl.ItemsSource = Helper.levels;

            surname.Text = employee.surname;
            name.Text = employee.name;
            patronymic.Text = employee.patronymic;
            phone.Text = employee.phone;
            email.Text = employee.email;
            login.Text = employee.login;
            Helper.Level level = (Helper.Level)Enum.Parse(typeof(Helper.Level), employee.lvl.Trim()); // Convert string (Selected Level) to enum
            lvl.SelectedItem = level;

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
            btnChange.IsEnabled = Helper.Controls_Listener(controls);
        }

        private void Button_Listener(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "FormClose":
                    this.Close();
                    break;
                case "btnChange":
                    Helper.Level level = (Helper.Level)Enum.Parse(typeof(Helper.Level), lvl.SelectedItem.ToString().Trim()); // Convert string (Selected Level) to enum

                    string new_value = "surname = '" + surname.Text.Trim() + "', " +
                                        "name = '" + name.Text.Trim() + "', " +
                                        "patronymic = '" + patronymic.Text.Trim() + "', " +
                                        "phone = '" + phone.Text.Trim() + "', " +
                                        "email = '" + email.Text.Trim() + "', " +
                                        "account = '" + login.Text.Trim() + "', " +
                                        "lvl = '" + level.GetHashCode().ToString() + "'";
                    SQLiteAdapter.ChangeValueById("employees", employee.id, new_value);

                    Helper.RefreshOCollection();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
