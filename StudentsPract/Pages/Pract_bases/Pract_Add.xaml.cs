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

namespace StudentsPract.Pages.Pract_bases
{
    /// <summary>
    /// Логика взаимодействия для Pract_Add.xaml
    /// </summary>
    public partial class Pract_Add : Window
    {
        private List<Control> controls = new List<Control>();

        public Pract_Add()
        {
            InitializeComponent();

            controls = new List<Control>() { name, address, phone, employeer, date_end };

            date_end.DisplayDateStart = DateTime.Today;

            // EventHandler's
            name.TextChanged += Controls_Listener;
            address.TextChanged += Controls_Listener;
            employeer.TextChanged += Controls_Listener;
            phone.TextChanged += Controls_Listener;
            date_end.SelectedDateChanged += Controls_Listener;
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
                    SQLiteAdapter.SetValue("practise_base",
                            name.Text.Trim(),
                            address.Text.Trim(),
                            employeer.Text.Trim(),
                            phone.Text.Trim(),
                            date_end.Text.Trim()
                    );
                    // Refresh ObservableCollection for update dataGrids
                    Helper.RefreshOCollection();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
