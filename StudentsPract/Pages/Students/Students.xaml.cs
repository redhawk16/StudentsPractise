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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsPract.Pages.Students
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : UserControl
    {

        public Students()
        {
            InitializeComponent();
        }

        #region DataGrid Methods

        #region DataGrid: Editing
        /*private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) // Editing DataGrid Row
        {
            DataGridHelper.EditDataGrid<Student>(e, table_name, dataGrid);
            load_data_grid();
        }*/
        #endregion

        #region DataGrid: Deleting
        /*private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e) // Deleting DataGrid Row
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = DataGridHelper.DeleteDataGrid<Student>(dataGrid);
            }
        }*/
        #endregion

        #region DataGrid: Filtering
        /*public void FilterValue(object sender, EventArgs e)
        {
            DataGridHelper.FilterDataGrid<Student>(sender, e, dataGrid);
        }*/
        #endregion

        /*
        #region DataGrid: Editing
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) // Editing DataGrid Row
        {
            var new_value = ((TextBox)e.EditingElement).Text.Trim(); // Getting entered value
            if (e.EditAction == DataGridEditAction.Commit && !new_value.Equals("")) // Checking entered value for empty
            {
                MessageBoxResult msgBox = MessageBox.Show("Вы действительно хотите изменить текушие данные?", "Изменение данных", MessageBoxButton.YesNo);
                if(msgBox == MessageBoxResult.Yes) // If answer YES
                {
                    var selected_items = (Student)dataGrid.SelectedItem; // Getting DataGrid selected items(can get Student class properties)
                    string column_name = e.Column.SortMemberPath; // Getting edited/changed column name

                    sqliteAdapter.ChangeValueById("students", selected_items.id, column_name, new_value);
                    // TODO: Добавить проверку выполненности изменения данных в БД, если FALSE, то откат изменений в DataGrid
                }
                else { // If answer No
                    dataGrid.CancelEdit(); //DataGridEditingUnit.Row
                }
            } else if (e.EditAction == DataGridEditAction.Cancel) { return; }
            else { dataGrid.CancelEdit(); } // Cancel editing row
        }
        #endregion

        #region DataGrid: Deleting
        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e) // Deleting DataGrid Row
        {
            if(e.Key == Key.Delete)
            {
                MessageBoxResult msgBox = MessageBox.Show("Вы действительно хотите удалить данного студента?", "Удаление студента", MessageBoxButton.YesNo);
                if (msgBox == MessageBoxResult.Yes)
                {
                    var selected_items = (Student)dataGrid.SelectedItem;
                    sqliteAdapter.DeleteRowById("students", selected_items.id);
                } else { e.Handled = true; } // Cancel delete row
            }
        }
        #endregion

        #region DataGrid: Filtering
        public void FilterValue(object sender, EventArgs e)
        {
            dynamic control = (dynamic)sender;
            string filter = control.Text; // Entered Text
            
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            List<string> columns = new List<string>();
            Type propertyInfo = typeof(Student);
            foreach(PropertyInfo propertyName in propertyInfo.GetProperties()) columns.Add(propertyName.Name); // Get properties from Student class and add it to List columns

            // add check edititem exception
            if (filter == "") cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Student p = (Student)o;
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
        */
        #endregion

        private void Student_Hotkey(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "Student_add":
                    new Student_Add().ShowDialog();
                    break;
                case "Student_edit":
                    if(dataGrid.SelectedIndex != -1) { new Student_Edit(dataGrid.SelectedItem as Student).ShowDialog(); }
                    break;
                case "Student_del":
                    if(dataGrid.SelectedIndex != -1) 
                    { 
                        if(DataGridHelper.DeleteDataGrid<Student>(dataGrid) == false)
                        {
                            Helper.OStudents.Remove(Helper.OStudents.Where(i => i.Equals(dataGrid.SelectedItem)).Single());
                        }
                    }
                    break;
                default: break;
            }

        }
    }
}
