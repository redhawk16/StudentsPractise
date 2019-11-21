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
using StudentsPract.Adapters;
using StudentsPract.Classes;
using StudentsPract.Windows;

namespace StudentsPract.Pages
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : UserControl
    {
        SQLiteAdapter sqliteAdapter = new SQLiteAdapter(); // create instance for SQLiteAdapter
        DataGridHelper dataGridHelper = new DataGridHelper(); // create instance for DataGridHelper

        string table_name = "students";

        public Students()
        {
            InitializeComponent();

            load_data_grid();  // DataGrid Binding
        }

        #region DataGrid Methods

        #region DataGrid: Editing
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) // Editing DataGrid Row
        {
            dataGridHelper.EditDataGrid<Student>(e, table_name, dataGrid);
            load_data_grid();
        }
        #endregion

        #region DataGrid: Deleting
        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e) // Deleting DataGrid Row
        {
            dataGridHelper.DeleteDataGrid<Student>(e, table_name, dataGrid);
        }
        #endregion

        #region DataGrid: Filtering
        public void FilterValue(object sender, EventArgs e)
        {
            dataGridHelper.FilterDataGrid<Student>(sender, e, dataGrid);
        }
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
                    (new Student_add()).ShowDialog();
                    break;
                case "Student_edit":
                    break;
                case "Student_del":
                    break;
                default: break;
            }
        }

        private void load_data_grid()
        {
            List<Student> values = new List<Student>();
            List<List<string>> tmp = sqliteAdapter.GetValue(table_name);

            foreach (List<string> column in tmp)
            {
                values.Add(new Student { 
                    id          = column[0], 
                    surname     = column[1],
                    name        = column[2], 
                    patronymic  = column[3], 
                    group       = column[4], 
                    free_study  = column[5], 
                    email       = column[6], 
                    phone       = column[7] 
                });
            }

            for (int i = 0; i < values.Count; i++) if (!group.Items.Contains(values[i].group)) group.Items.Add(values[i].group); // ComboBox repeat values check

            dataGrid.ItemsSource = values; // Binding items in DataGrid
        }
    }

    class Student
    {
        public string id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string group { get; set; }
        public string free_study { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}