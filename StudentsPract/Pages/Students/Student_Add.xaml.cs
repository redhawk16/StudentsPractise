using StudentsPract.Adapters;
using StudentsPract.Classes;
using StudentsPract.Pages;
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

namespace StudentsPract.Pages.Students
{
    /// <summary>
    /// Логика взаимодействия для Student_add.xaml
    /// </summary>
    public partial class Student_Add : Window
    {
        List<Control> controls = new List<Control>();
        Helper helper = new Helper();

        public Student_Add()
        {
            InitializeComponent();

            controls = new List<Control>() { surname, name, patronymic, group, formStudy, email, phone };

            formStudy.ItemsSource = new List<string>() { "Бюджет", "Внебюджет" };

            foreach(List<string> groups in SQLiteAdapter.GetValue("groups", "groupe"))
            {
                if(!group.Items.Contains(groups[0])) group.Items.Add(groups[0]);
            }

            // EventHandler's
            surname.TextChanged += Controls_Listener;
            name.TextChanged += Controls_Listener;
            patronymic.TextChanged += Controls_Listener;
            group.SelectionChanged += Controls_Listener;
            formStudy.SelectionChanged += Controls_Listener;
            email.TextChanged += Controls_Listener;
            phone.TextChanged += Controls_Listener;
        }

        protected void Controls_Listener(object sender, EventArgs e)
        {
            AddStudent.IsEnabled = Helper.Controls_Listener(controls);
        }

        private void Button_Listener(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "FormClose":
                    this.Close();
                    break;
                case "AddStudent":
                    string sel_group = group.SelectedItem.ToString().Trim();
                    string group_id = SQLiteAdapter.GetValue($"groups WHERE groupe = '{sel_group}'", "id")[0][0];

                    SQLiteAdapter.SetValue("students",
                            surname.Text.Trim(), 
                            name.Text.Trim(),
                            patronymic.Text.Trim(),
                            group_id.Trim(),
                            formStudy.SelectedItem.ToString().Trim(),
                            email.Text.Trim(),
                            phone.Text.Trim()
                    );
                    Helper.RefreshOCollection();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
