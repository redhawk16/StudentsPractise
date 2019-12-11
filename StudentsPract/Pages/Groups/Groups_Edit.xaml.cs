using StudentsPract.Adapters;
using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Groups_Edit.xaml
    /// </summary>
    public partial class Groups_Edit : Window
    {
        private Group group;
        private List<Control> controls = new List<Control>();
        private List<Practise_Type> practise_Types = new List<Practise_Type>();

        public Groups_Edit(Group group)
        {
            InitializeComponent();

            this.group = group;

            controls = new List<Control>() { groupe, direction, form_study, enroll, end };

            form_study.ItemsSource = new List<string>() { "Очная", "Заочная" };
            foreach (List<string> groups in SQLiteAdapter.GetValue("directions", "name"))
            {
                if (!direction.Items.Contains(groups[0])) direction.Items.Add(groups[0]);
            }

            groupe.Text = group.groupe;
            direction.SelectedItem = group.direction;
            form_study.SelectedItem = group.form_study;
            enroll.Text = group.enroll_year;
            end.Text = group.end_year;

            List<List<string>> LGroups = SQLiteAdapter.GetValue($"pract_types INNER JOIN groups ON groups.id=pract_types.id_groupe WHERE groupe='{group.groupe}'", "pract_types.type_name");
            if(LGroups.Count > 0)
            {
                foreach(List<string> tmp in LGroups)
                {
                    practise_Types.Add(new Practise_Type { type_name=tmp[0] });
                    //if(!typePract.Items.Contains(tmp[0])) typePract.Items.Add(tmp[0]);
                }
            }
            typePract.ItemsSource = practise_Types;

            // EventHandler's
            groupe.TextChanged += Controls_Listener;
            direction.SelectionChanged += Controls_Listener;
            form_study.SelectionChanged += Controls_Listener;
            enroll.TextChanged += Controls_Listener;
            end.TextChanged += Controls_Listener;
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
                    string sel_direction = direction.SelectedItem.ToString().Trim();
                    string direction_id = SQLiteAdapter.GetValue($"directions WHERE name = '{sel_direction}'", "id")[0][0];

                    string new_value = "groupe = '" + groupe.Text.Trim() + "', " +
                                        "direction = '" + direction_id.Trim() + "', " +
                                        "form_study = '" + form_study.SelectedItem.ToString().Trim() + "', " +
                                        "enroll_year = '" + enroll.Text.Trim() + "', " +
                                        "end_year = '" + end.Text.Trim() + "'";
                    SQLiteAdapter.ChangeValueById("groups", group.id, new_value);
                    Helper.RefreshOCollection();

                    SQLiteAdapter.DeleteRowById("pract_types", $"[id_groupe]='{group.id}'");

                    for(int i = 0; i < practise_Types.Count; i++)
                    {
                        if(practise_Types[i].type_name.ToString().Trim().Length > 0)
                            SQLiteAdapter.SetValue("pract_types", group.id, practise_Types[i].type_name.ToString().Trim());
                    }
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
