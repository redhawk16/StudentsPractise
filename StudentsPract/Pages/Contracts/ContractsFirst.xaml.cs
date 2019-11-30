using StudentsPract.Adapters;
using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace StudentsPract.Pages.Contracts
{
    /// <summary>
    /// Логика взаимодействия для ContractsFirst.xaml
    /// </summary>
    public partial class ContractsFirst : Page
    {
        public ObservableCollection<Parent> TreeView { get; set; }
        SQLiteAdapter adapter = new SQLiteAdapter();

        public ContractsFirst()
        {
            InitializeComponent();

            date.SelectedDate = DateTime.Today;
            date.DisplayDateStart = DateTime.Today;


            // TreeView fill
            this.TreeView = new ObservableCollection<Parent>();
            List<List<string>> directions = adapter.GetValue("directions", "code");

            foreach(List<string> tmp in directions)
            {
                List<Child> Member = new List<Child>();

                List<List<string>> study_years = adapter.GetValue("groups INNER JOIN directions ON directions.name=groups.direction WHERE code ='" + tmp[0] + "'", "groups.enroll_year, groups.end_year");
                foreach(List<string> tmpYears in study_years)
                {
                    int enroll = Convert.ToInt32(tmpYears[0]); // Год поступления 
                    int end = Convert.ToInt32(tmpYears[1]); // Год окончания

                    //Вычислить курс
                    // Месяц и Год текущий - Месяц и Год поступления
                    int course = DateTime.Today.Year - enroll;
                    int month = DateTime.Today.Month - 9;
                    if (month >= 0)
                    {
                        course++;
                    }

                    Member.Add(new Child() { Name = course + " курс" });
                }

                if(Member.Count != 0)
                {
                    this.TreeView.Add(new Parent()
                    {
                        Name = tmp[0],
                        Members = Member
                    });
                }
            }


            /*this.TreeView.Add(new Parent() { 
                Name = "Simpsons", 
                Members = new List<Child>() { 
                    new Child() { Name = "Homer" }, 
                    new Child() { Name = "Bart" } 
                } 
            });*/

            foreach (Parent parent in this.TreeView)
            {
                foreach (Child child in parent.Members)
                {
                    child.SetValue(ItemHelper.ParentProperty, parent);
                }
            }
        }

        private void Button_PrintCrew_Click(object sender, RoutedEventArgs e)
        {
            string selected = "";
            foreach (Parent parent in this.TreeView)
            {
                foreach (Child child in parent.Members)
                {

                    if (ItemHelper.GetIsChecked(child) == true)
                    {
                        selected += child.Name + ", ";
                        /*Parent tmp = (Parent)ItemHelper.GetParent(child);
                        tmp.Name;*/
                    }
                }
            }
            selected = selected.TrimEnd(new char[] { ',', ' ' });
            //selectedParent = selectedParent.TrimEnd(new char[] { ',', ' ' });
            this.textBoxCrew.Text = "Вы выбрали: " + selected;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "btnClose":
                    Window parentWindow = Window.GetWindow(this);
                    parentWindow.Close();
                    break;
                case "btnNext":
                    if (this.NavigationService.CanGoForward) this.NavigationService.GoForward();
                    else this.NavigationService.Navigate(new ContractsSecond());
                    Trace.WriteLine("Page 1 navigating to page 2");
                    break;
                default:
                    break;
            }
        }
    }
}
