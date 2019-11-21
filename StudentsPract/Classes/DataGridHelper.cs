using StudentsPract.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StudentsPract.Classes
{
    class DataGridHelper
    {
        SQLiteAdapter sqliteAdapter = new SQLiteAdapter(); // create instance for SQLiteAdapter

        #region DataGrid

        #region DataGrid: Editing
        public void EditDataGrid<T>(DataGridCellEditEndingEventArgs e, string table_name, DataGrid dataGrid) // Editing DataGrid Row
        {
            dynamic selected_items = (T)dataGrid.SelectedItem; // Getting DataGrid selected items(can get Student class properties)
            string column_name = e.Column.SortMemberPath; // Getting edited/changed column name
            string new_value = ((TextBox)e.EditingElement).Text.Trim(); // Getting entered value
            Type propertyInfo = typeof(T);
            string old_value = propertyInfo.GetProperty(column_name).GetValue(selected_items, null).ToString(); // Get previous value in edited cells

            if (e.EditAction == DataGridEditAction.Commit && !new_value.Equals("") && !new_value.Equals(old_value)) // Checking entered value for empty
            {
                MessageBoxResult msgBox = MessageBox.Show("Вы действительно хотите изменить текушие данные?", "Изменение данных", MessageBoxButton.YesNo);
                if (msgBox == MessageBoxResult.Yes) // If answer YES
                {
                    sqliteAdapter.ChangeValueById(table_name, selected_items.id, column_name, new_value);
                    // TODO: Добавить проверку выполненности изменения данных в БД, если FALSE, то откат изменений в DataGrid
                }
                else
                { // If answer No
                    dataGrid.CancelEdit(); //DataGridEditingUnit.Row
                }
            }
            else if (e.EditAction == DataGridEditAction.Cancel) { return; }
            else { dataGrid.CancelEdit(); } // Cancel editing row
        }
        #endregion


        #region DataGrid: Deleting
        public void DeleteDataGrid<T>(KeyEventArgs e, string table_name, DataGrid dataGrid) // Deleting DataGrid Row
        {
            if (e.Key == Key.Delete)
            {
                MessageBoxResult msgBox = MessageBox.Show("Вы действительно хотите удалить данного студента?", "Удаление студента", MessageBoxButton.YesNo);
                if (msgBox == MessageBoxResult.Yes)
                {
                    dynamic selected_items = (T)dataGrid.SelectedItem; // Getting DataGrid selected items(can get Student class properties)
                    sqliteAdapter.DeleteRowById(table_name, selected_items.id);
                }
                else { e.Handled = true; } // Cancel delete row
            }
        }
        #endregion

        #region DataGrid: Filtering
        public void FilterDataGrid<T>(object sender, EventArgs e, DataGrid dataGrid)
        {
            dynamic control = (dynamic)sender;
            string filter = control.Text; // Entered Text

            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            List<string> columns = new List<string>();
            Type propertyInfo = typeof(T);
            foreach (PropertyInfo propertyName in propertyInfo.GetProperties()) columns.Add(propertyName.Name); // Get properties from Student class and add it to List columns

            // add check edititem exception
            if (filter == "") cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    T p = (T)o;
                    foreach (string column in columns)
                    {
                        string filteredItem = propertyInfo.GetProperty(column).GetValue(p, null).ToString(); // Get property by name(List coumns) and get its value
                        if (control.Name.Equals(column)) return filteredItem.ToUpper().StartsWith(filter.ToUpper()); // Find/Check filtered textbox by name and filter datagrid by entered value
                    }
                    return false;
                };
            }
        }
        #endregion

        #endregion
    }
}
