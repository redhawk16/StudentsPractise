using StudentsPract.Adapters;
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
    /// Логика взаимодействия для Student_add.xaml
    /// </summary>
    public partial class Student_add : Window
    {
        SQLiteAdapter adapter = new SQLiteAdapter();

        public Student_add()
        {
            InitializeComponent();

            formStudy.ItemsSource = new List<string>() { "Бюджет", "Внебюджет" };

            foreach(List<string> groups in adapter.GetValue("groups", "groupe"))
            {
                if(!group.Items.Contains(groups[0])) group.Items.Add(groups[0]);
            }
            
        }

        private void Button_Listener(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "FormClose":
                    this.Close();
                    break;
                case "AddStudent":
                    break;
                default:
                    break;
            }
        }

        private void formStudy_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox ff = (ComboBox)sender;
            int tt = ff.SelectedItem.ToString().Length;
            ff = formStudy;
            Console.WriteLine(ff);
        }
    }
}
