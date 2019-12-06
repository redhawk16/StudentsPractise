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

namespace StudentsPract.Pages.Directions
{
    /// <summary>
    /// Логика взаимодействия для Direction_Edit.xaml
    /// </summary>
    public partial class Direction_Edit : Window
    {
        private List<Control> controls = new List<Control>();
        private Direction direction; 

        public Direction_Edit(Direction direction)
        {
            InitializeComponent();

            this.direction = direction;

            controls = new List<Control>() { name, code, id_cathedra };

            foreach (List<string> value in SQLiteAdapter.GetValue("cathedras WHERE cathedras.id NOT IN(SELECT directions.id_cathedra FROM directions)", "cathedra"))
            {
                if (!id_cathedra.Items.Contains(value[0])) id_cathedra.Items.Add(value[0]);
            }
            id_cathedra.Items.Add(direction.id_cathedra);

            code.Text = direction.code;
            name.Text = direction.name;
            id_cathedra.SelectedItem = direction.id_cathedra;

            // EventHandler's
            name.TextChanged += Controls_Listener;
            code.TextChanged += Controls_Listener;
            id_cathedra.SelectionChanged += Controls_Listener;
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
                    // Get id decan name from Employees table for adding to Cathedras table
                    string cathedra_id_tmp = id_cathedra.SelectedItem.ToString().Trim();
                    string cathedra_id = SQLiteAdapter.GetValue($"cathedras WHERE cathedra = '{cathedra_id_tmp}'", "id")[0][0];

                    string new_value = "code = '" + code.Text.Trim() + "', " +
                                        "name = '" + name.Text.Trim() + "', " +
                                        "id_cathedra = '" + cathedra_id.Trim() + "'";
                    SQLiteAdapter.ChangeValueById("directions", direction.id, new_value);

                    Helper.RefreshOCollection();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
