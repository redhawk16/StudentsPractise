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

namespace StudentsPract.Pages.Students
{
    /// <summary>
    /// Логика взаимодействия для Student_Edit.xaml
    /// </summary>
    public partial class Student_Edit : Window
    {
        private Student student;
        private List<Control> controls = new List<Control>();

        public Student_Edit(Student student)
        {
            InitializeComponent();

            this.student = student;

            controls = new List<Control>() { surname, name, patronymic, group, formStudy, email, phone };

            formStudy.ItemsSource = new List<string>() { "Бюджет", "Внебюджет" };
            foreach (List<string> groups in SQLiteAdapter.GetValue("groups", "groupe"))
            {
                if (!group.Items.Contains(groups[0])) group.Items.Add(groups[0]);
            }

            surname.Text = student.surname;
            name.Text = student.name;
            patronymic.Text = student.patronymic;
            group.SelectedItem = student.groupe;
            formStudy.SelectedItem = student.free_study;
            email.Text = student.email;
            phone.Text = student.phone;

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
                    string sel_group = group.SelectedItem.ToString().Trim();
                    string group_id = SQLiteAdapter.GetValue($"groups WHERE groupe = '{sel_group}'", "id")[0][0];

                    string new_value = "surname = '" + surname.Text.Trim() + "', " +
                                        "name = '" + name.Text.Trim() + "', " +
                                        "patronymic = '" + patronymic.Text.Trim() + "', " +
                                        "groupe = '" + group_id.Trim() + "', " +
                                        "free_study = '" + formStudy.SelectedItem.ToString().Trim() + "', " +
                                        "email = '" + email.Text.Trim() + "', " +
                                        "phone = '" + phone.Text.Trim() + "'";
                    SQLiteAdapter.ChangeValueById("students", student.id, new_value);
                    Helper.RefreshOCollection();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
