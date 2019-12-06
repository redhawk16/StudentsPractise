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

namespace StudentsPract.Pages.Cathedras
{
    /// <summary>
    /// Логика взаимодействия для Cathedras_Edit.xaml
    /// </summary>
    public partial class Cathedras_Edit : Window
    {
        private Cathedra cathedra; 
        private List<Control> controls = new List<Control>();

        public Cathedras_Edit(Cathedra cathedra)
        {
            InitializeComponent();
            this.cathedra = cathedra;

            controls = new List<Control>() { number, name, phone, decan };

            foreach (List<string> value in SQLiteAdapter.GetValue("employees WHERE employees.id NOT IN(SELECT cathedras.id_decan FROM cathedras)", "employees.surname, employees.name, employees.patronymic"))
            {
                string decan_name = value[0].Trim() + " " + value[1].Trim() + " " + value[2].Trim();
                if (!decan.Items.Contains(decan_name)) decan.Items.Add(decan_name);
            }
            decan.Items.Add(cathedra.surname.Trim() + " " + cathedra.name.Trim() + " " + cathedra.patronymic.Trim());

            number.Text = cathedra.number;
            name.Text = cathedra.cathedra;
            phone.Text = cathedra.phone;
            decan.SelectedItem = cathedra.surname.Trim() + " " + cathedra.name.Trim() + " " + cathedra.patronymic.Trim();

            // EventHandler's
            number.TextChanged += Controls_Listener;
            name.TextChanged += Controls_Listener;
            phone.TextChanged += Controls_Listener;
            decan.SelectionChanged += Controls_Listener;
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
                    string[] decan_name = decan.SelectedItem.ToString().Trim().Split();
                    string decan_id = SQLiteAdapter.GetValue($"employees WHERE surname = '{decan_name[0]}' AND name = '{decan_name[1]}' AND patronymic = '{decan_name[2]}'", "id")[0][0];

                    string new_value = "number = '" + number.Text.Trim() + "', " +
                                        "cathedra = '" + name.Text.Trim() + "', " +
                                        "phone = '" + phone.Text.Trim() + "', " +
                                        "id_decan = '" + decan_id + "'";
                    SQLiteAdapter.ChangeValueById("cathedras", cathedra.id, new_value);

                    Helper.RefreshOCollection();

                    /*Helper.OCathedras[Helper.OCathedras.IndexOf(cathedra)] = new Cathedra
                    {
                        id = cathedra.id,
                        number = number.Text.Trim(),
                        name = name.Text.Trim(),
                        phone = phone.Text.Trim(),
                        id_decan = decan.SelectedItem.ToString().Trim()
                    }; */// Replace OCathedras with new values


                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
