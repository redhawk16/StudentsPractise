using StudentsPract.Adapters;
using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsPract.Pages.Groups
{
    /// <summary>
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : UserControl
    {

        public Groups()
        {
            InitializeComponent();

            /*List<Group> groups = DBTableHelper.GetGroupsTable();
            foreach (Group group in groups) {
                dataGrid.Items.Add(group);
            }*/
            //dataGrid.ItemsSource = DBTableHelper.GetGroupsTable();

            //load_data_grid(); // DataGrid Binding
        }

        #region DataGrid Methods

        #region DataGrid: Editing
        /*private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) // Editing DataGrid Row
        {
            dataGridHelper.EditDataGrid<Group>(e, table_name, dataGrid);
            load_data_grid();
        }*/
        #endregion

        #region DataGrid: Deleting
        /*private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e) // Deleting DataGrid Row
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = DataGridHelper.DeleteDataGrid<Group>(dataGrid);
            }
        }*/
        #endregion

        #region DataGrid: Filtering
        /*public void FilterValue(object sender, EventArgs e)
        {
            dataGridHelper.FilterDataGrid<Group>(sender, e, dataGrid);
        }*/
        #endregion

        #endregion

        private void Group_Hotkey(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "Group_add":
                    new Groups_Add().ShowDialog();
                    break;
                case "Group_edit":
                    if (dataGrid.SelectedIndex != -1) { new Groups_Edit(dataGrid.SelectedItem as Group).ShowDialog(); }
                    break;
                case "Group_del":
                    if (dataGrid.SelectedIndex != -1) 
                    {
                        if(DataGridHelper.DeleteDataGrid<Group>(dataGrid) == false)
                        {
                            string group_id = ((Group)dataGrid.SelectedItem).id;
                            Helper.OGroups.Remove(Helper.OGroups.Where(i => i.Equals(dataGrid.SelectedItem)).Single()); // Deleting row from OCathedras(ObservableCollection)
                            SQLiteAdapter.DeleteRowById("pract_types", $"[id_groupe]='{group_id}'");
                        }
                    }
                    break;
                default: break;
            }
        }

        /*private void load_data_grid()
        {
            List<Group> values = Helper.GetTableByClass<Group>();

            //for (int i = 0; i < values.Count; i++) if (!groupe.Items.Contains(values[i].group)) group.Items.Add(values[i].group); // ComboBox repeat values check

            dataGrid.ItemsSource = values; // Binding items in DataGrid
        }*/
    }

}
