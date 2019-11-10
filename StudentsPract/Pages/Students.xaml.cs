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
using StudentsPract.Adapters;

namespace StudentsPract.Pages
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : UserControl
    {
        public ObservableCollection<TreeView> Groups { get; set; }

        public Students()
        {
            InitializeComponent();

            SQLiteAdapter sqliteAdapter = new SQLiteAdapter(); // create instance for SQLiteAdapter

        }
    }
}
