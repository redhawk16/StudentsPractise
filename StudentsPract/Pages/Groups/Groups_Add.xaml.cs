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

namespace StudentsPract.Pages.Groups
{
    /// <summary>
    /// Логика взаимодействия для Groups_Add.xaml
    /// </summary>
    public partial class Groups_Add : Window
    {
        private List<Control> controls = new List<Control>();

        public Groups_Add()
        {
            InitializeComponent();

            controls = new List<Control>() { groupe, direction, form_study, enroll, end };

            form_study.ItemsSource = new List<string>() { "Очная", "Заочная" };

            foreach (List<string> groups in SQLiteAdapter.GetValue("directions", "name"))
            {
                if (!direction.Items.Contains(groups[0])) direction.Items.Add(groups[0]);
            }

            // EventHandler's
            groupe.TextChanged += Controls_Listener;
            direction.SelectionChanged += Controls_Listener;
            form_study.SelectionChanged += Controls_Listener;
            enroll.TextChanged += Controls_Listener;
            end.TextChanged += Controls_Listener;
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
                    string[] sel_direction = direction.SelectedItem.ToString().Trim().Split();
                    string direction_id = SQLiteAdapter.GetValue($"directions WHERE name = '{sel_direction[0]}'", "id")[0][0];

                    SQLiteAdapter.SetValue("groups",
                            groupe.Text.Trim(),
                            direction_id.Trim(),
                            form_study.SelectedItem.ToString().Trim(),
                            enroll.Text.Trim(),
                            end.Text.Trim()
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
