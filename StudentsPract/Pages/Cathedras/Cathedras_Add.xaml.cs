using StudentsPract.Adapters;
using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentsPract.Pages.Cathedras
{
    /// <summary>
    /// Логика взаимодействия для Cathedras_Add.xaml
    /// </summary>
    public partial class Cathedras_Add : Window
    {
        private List<Control> controls = new List<Control>();

        public Cathedras_Add()
        {
            InitializeComponent();

            controls = new List<Control>() { number, name, phone, decan };

            foreach (List<string> value in SQLiteAdapter.GetValue("employees WHERE employees.id NOT IN(SELECT cathedras.id_decan FROM cathedras)", "employees.surname, employees.name, employees.patronymic"))
            {
                string decan_name = value[0] + " " + value[1] + " " + value[2];
                if (!decan.Items.Contains(decan_name)) decan.Items.Add(decan_name);
            }

            // EventHandler's
            number.TextChanged += Controls_Listener;
            name.TextChanged += Controls_Listener;
            phone.TextChanged += Controls_Listener;
            decan.SelectionChanged += Controls_Listener;
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
                    // Get id decan name from Employees table for adding to Cathedras table
                    string[] decan_name = decan.SelectedItem.ToString().Trim().Split();
                    string decan_id = SQLiteAdapter.GetValue($"employees WHERE surname = '{decan_name[0]}' AND name = '{decan_name[1]}' AND patronymic = '{decan_name[2]}'", "id")[0][0];

                    SQLiteAdapter.SetValue("cathedras",
                            number.Text.Trim(),
                            name.Text.Trim(),
                            phone.Text.Trim(),
                            decan_id
                    );
                    // TODO: добавить проверку на добавление в БД
                    Helper.RefreshOCollection();
                    /*Helper.OCathedras.Add(new Cathedra {
                            id = (Helper.OCathedras.Count()+1).ToString(),
                            number = number.Text.Trim(),
                            name = name.Text.Trim(),
                            phone = phone.Text.Trim(),
                            id_decan = decan_id });*/
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
