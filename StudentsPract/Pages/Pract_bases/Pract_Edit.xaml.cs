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
    /// Логика взаимодействия для Pract_Edit.xaml
    /// </summary>
    public partial class Pract_Edit : Window
    {
        private Practise practise;
        private List<Control> controls = new List<Control>();

        public Pract_Edit(Practise practise)
        {
            InitializeComponent();

            this.practise = practise;

            controls = new List<Control>() { name, address, employeer, phone, date_end };

            date_end.DisplayDateStart = DateTime.Today;

            name.Text = practise.name;
            address.Text = practise.address;
            employeer.Text = practise.employeer;
            phone.Text = practise.phone;
            date_end.Text = practise.date_end;

            // EventHandler's
            name.TextChanged += Controls_Listener;
            address.TextChanged += Controls_Listener;
            employeer.TextChanged += Controls_Listener;
            phone.TextChanged += Controls_Listener;
            date_end.SelectedDateChanged += Controls_Listener;
        }

        protected void Controls_Listener(object sender, EventArgs e)
        {
            btnChange.IsEnabled = Helper.Controls_Listener(controls);
        }

        private void Button_Listener(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "FormClose":
                    this.Close();
                    break;
                case "btnChange":
                    string new_value =  "name = '" + name.Text.Trim() + "', " +
                                        "address = '" + address.Text.Trim() + "', " +
                                        "employeer = '" + employeer.Text.Trim() + "', " +
                                        "phone = '" + phone.Text.Trim() + "', " +
                                        "date_end = '" + date_end.Text.Trim() + "'";
                    SQLiteAdapter.ChangeValueById("practise_base", practise.id, new_value);

                    Helper.RefreshOCollection();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
