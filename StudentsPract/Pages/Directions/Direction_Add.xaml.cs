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
    /// Логика взаимодействия для Direction_Add.xaml
    /// </summary>
    public partial class Direction_Add : Window
    {
        private List<Control> controls = new List<Control>();

        public Direction_Add()
        {
            InitializeComponent();
            controls = new List<Control>() { name, code, id_cathedra };

            foreach (List<string> value in SQLiteAdapter.GetValue("cathedras WHERE cathedras.id NOT IN(SELECT directions.id_cathedra FROM directions)", "cathedra"))
            {
                if (!id_cathedra.Items.Contains(value[0])) id_cathedra.Items.Add(value[0]);
            }

            // EventHandler's
            name.TextChanged += Controls_Listener;
            code.TextChanged += Controls_Listener;
            id_cathedra.SelectionChanged += Controls_Listener;
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
                    string cathedra_id_tmp = id_cathedra.SelectedItem.ToString().Trim();
                    string cathedra_id = SQLiteAdapter.GetValue($"cathedras WHERE cathedra = '{cathedra_id_tmp}'", "id")[0][0];

                    SQLiteAdapter.SetValue("directions",
                            code.Text.Trim(),
                            name.Text.Trim(),
                            cathedra_id
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
