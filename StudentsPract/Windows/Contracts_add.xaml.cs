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

namespace StudentsPract.Windows
{
    /// <summary>
    /// Логика взаимодействия для Contracts_add.xaml
    /// </summary>
    public partial class Contracts_add : Window
    {
        DataGridHelper dataGridHelper = new DataGridHelper(); // create instance for DataGridHelper
        DBTableHelper DBTableHelper = new DBTableHelper();

        public Contracts_add()
        {
            InitializeComponent();

            load_data_grid();
        }

        private void Button_Listener(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "CreateContract":
                    MessageBox.Show("Договор сформирован", "Формирование договора", MessageBoxButton.OK);
                    break;
                case "FormClose": this.Close();
                    break;
                default:
                    break;
            }
        }

        #region DataGrid: Filtering
        public void FilterValue(object sender, EventArgs e)
        {
            dataGridHelper.FilterDataGrid<Student>(sender, e, dataGrid_Students);
        }
        #endregion

        private void load_data_grid()
        {
            List<Student> values = DBTableHelper.GetStudentsTable();

            for (int i = 0; i < values.Count; i++) if (!group.Items.Contains(values[i].group)) group.Items.Add(values[i].group); // ComboBox repeat values check

            dataGrid_Students.ItemsSource = values; // Binding items in DataGrid
        }

        private void dataGrid_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid_ = (DataGrid)sender;
            if(dataGrid_.SelectedIndex != -1)
            {
                btn_StudentAdd.IsEnabled = true;
                //MessageBox.Show("Row selected");
            }


        }

        private void dataGrid_Students_LostFocus(object sender, RoutedEventArgs e)
        {
            if (btn_StudentAdd.IsMouseOver)
            {
                MessageBox.Show("Pressed");
            } else
            {
                btn_StudentAdd.IsEnabled = false; //MessageBox.Show("Row not");
            }
            dataGrid_Students.SelectedIndex = -1;
        }
    }
}
