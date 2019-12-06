using StudentsPract.Adapters;
using StudentsPract.Classes;
using StudentsPract.Pages.Cathedras;
using StudentsPract.Pages.Directions;
using StudentsPract.Pages.Employees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentsPract.Pages.Others
{
    /// <summary>
    /// Логика взаимодействия для Others.xaml
    /// </summary>
    public partial class Others : UserControl
    {

        public Others()
        {
            InitializeComponent();

            //CathedrasGrid.ItemsSource = Helper.OCathedras;
        }

        private void ButtonListener_Manage(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            
            switch (button.Name)
            {

                #region Buttons attached to cathedras
                case "btnAdd_cathedra":
                    new Cathedras_Add().ShowDialog();
                    break;
                case "btnEdit_cathedra":
                    if (CathedrasGrid.SelectedIndex != -1) { new Cathedras_Edit(CathedrasGrid.SelectedItem as Cathedra).ShowDialog(); }
                    break;
                case "btnDel_cathedra":
                    if (CathedrasGrid.SelectedIndex != -1) 
                    {
                        if (DataGridHelper.DeleteDataGrid<Cathedra>(CathedrasGrid) == false) // Deleting row from DB
                        {
                            Helper.OCathedras.Remove(Helper.OCathedras.Where(i => i.Equals(CathedrasGrid.SelectedItem)).Single()); // Deleting row from OCathedras(ObservableCollection)
                        }
                    }
                    break;
                #endregion

                #region Buttons attached to employees
                case "btnAdd_employee":
                    new Employee_Add().ShowDialog();
                    break;
                case "btnEdit_employee":
                    if (EmployeesGrid.SelectedIndex != -1) { new Employee_Edit(EmployeesGrid.SelectedItem as Employee).ShowDialog(); }
                    break;
                case "btnDel_employee":
                    if (EmployeesGrid.SelectedIndex != -1)
                    { 
                        if (DataGridHelper.DeleteDataGrid<Employee>(EmployeesGrid) == false) Helper.OEmployees.Remove(Helper.OEmployees.Where(i => i.Equals(EmployeesGrid.SelectedItem)).Single());
                    }
                    break;
                #endregion

                #region Buttons attached to directions
                case "btnAdd_direction":
                    new Direction_Add().ShowDialog();
                    break;
                case "btnEdit_direction":
                    if (DirectionsGrid.SelectedIndex != -1) { new Direction_Edit(DirectionsGrid.SelectedItem as Direction).ShowDialog(); }
                    break;
                case "btnDel_direction":
                    if (DirectionsGrid.SelectedIndex != -1) 
                    { 
                        if (DataGridHelper.DeleteDataGrid<Direction>(DirectionsGrid) == false) Helper.ODirections.Remove(Helper.ODirections.Where(i => i.Equals(DirectionsGrid.SelectedItem)).Single());
                    }
                    break;
                #endregion

                default: break;
            }
            //load_data_grid(); // Update dataGrid values
        }
    }
}
