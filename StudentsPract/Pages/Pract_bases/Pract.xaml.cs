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

namespace StudentsPract.Pages.Pract_bases
{
    /// <summary>
    /// Логика взаимодействия для Pract.xaml
    /// </summary>
    public partial class Pract : UserControl
    {
        public Pract()
        {
            InitializeComponent();
        }

        private void ButtonListener_Manage(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "btnAdd":
                    new Pract_Add().ShowDialog();
                    break;
                case "btnEdit":
                    if (dataGrid.SelectedIndex != -1) { new Pract_Edit(dataGrid.SelectedItem as Practise).ShowDialog(); }
                    break;
                case "btnDel":
                    if (dataGrid.SelectedIndex != -1)
                    {
                        if (DataGridHelper.DeleteDataGrid<Practise>(dataGrid) == false) // Deleting row from DB
                        {
                            Helper.OPractise.Remove(Helper.OPractise.Where(i => i.Equals(dataGrid.SelectedItem)).Single()); // Deleting row from OCathedras(ObservableCollection)
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
