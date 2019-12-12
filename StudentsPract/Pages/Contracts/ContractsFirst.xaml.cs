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
        private List<Control> controls = new List<Control>();

        private List<string> selected_dir;
        private List<List<string>> selected_course;

        public ContractsFirst()
        {
            InitializeComponent();

            controls = new List<Control>() { date, contract_num, contract_org };

            date.SelectedDate = DateTime.Today;
            date.DisplayDateStart = DateTime.Today;

            foreach (Practise tmp in Helper.OPractise.ToList())
            {
                if(!contract_org.Items.Contains(tmp.name)) contract_org.Items.Add(tmp.name);
            }

            // TreeView fill
            this.TreeView = new ObservableCollection<Parent>();
            List<List<string>> directions = SQLiteAdapter.GetValue("directions", "code");

            foreach(List<string> tmp in directions)
            {
                List<Child> Member = new List<Child>();

                List<List<string>> study_years = SQLiteAdapter.GetValue("groups INNER JOIN directions ON directions.id=groups.direction WHERE code ='" + tmp[0] + "'", "groups.enroll_year, groups.end_year");
                foreach(List<string> tmpYears in study_years)
                {
                    int enroll = Convert.ToInt32(tmpYears[0]); // Год поступления 
                    int end = Convert.ToInt32(tmpYears[1]); // Год окончания

                    //Вычислить курс
                    // Месяц и Год текущий - Месяц и Год поступления
                    int course = DateTime.Today.Year - enroll;
                    int month = DateTime.Today.Month - 9;
                    if (month >= 0) course++;

                    if (!Member.Exists(i=>i.Name.Equals(course + " курс")))
                    {
                        Member.Add(new Child() { Name = course + " курс" });
                    }
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


            // EventHandler's
            date.SelectedDateChanged += Controls_Listener;
            contract_num.TextChanged += Controls_Listener;
            contract_org.SelectionChanged += Controls_Listener;
        }

        protected void Controls_Listener(object sender, EventArgs e)
        {
            if (sender is ComboBox && ((Control)sender).Name.Equals("contract_org"))
            {
                Practise Selected_Pract = Helper.OPractise.Single(i => i.name.Equals(((ComboBox)sender).SelectedItem));
                contract_empl.Text = Selected_Pract.employeer.ToString();
            }

            btnNext.IsEnabled = Helper.Controls_Listener(controls);
        }

        private void Button_PrintCrew_Click(object sender, RoutedEventArgs e)
        {
            // selected_dir - хранятся выбранные направления соответстувющие индексу в массиве selected_course - выбранные курсы
            selected_dir = new List<string>();
            selected_course = new List<List<string>>();

            string selected = "";
            foreach (Parent parent in this.TreeView)
            {
                List<string> tmp = new List<string>();
                foreach (Child child in parent.Members)
                {
                    if (ItemHelper.GetIsChecked(child) == true)
                    {
                        if(!selected_dir.Contains(parent.Name)) selected_dir.Add(parent.Name);
                        if(!tmp.Contains(child.Name)) tmp.Add(child.Name);
                        selected += child.Name + ", ";
                        /*Parent tmp = (Parent)ItemHelper.GetParent(child);
                        tmp.Name;*/
                    }
                }
                if(tmp.Count > 0) selected_course.Add(tmp); 
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
                    /* TODO: Передать параметры
                     * Номер договора (contract_num)
                     * Наименование организации (contract_org)
                     * Руководитель практики (contract_empl)
                     * Дата (date)
                     * Выбранные направления с курсами (
                     *  -   selected_dir - выбранные направления
                     *  -   selected_course - выбранные курсы)
                     */

                    //if (this.NavigationService.CanGoForward) this.NavigationService.GoForward();
                    //else 
                    this.NavigationService.Navigate(new ContractsSecond(contract_num.Text.Trim(), 
                                                                                contract_org.Text.Trim(), 
                                                                                contract_empl.Text.Trim(), 
                                                                                date.Text.Trim(), 
                                                                                selected_dir, 
                                                                                selected_course));
                    Trace.WriteLine("Page 1 navigating to page 2");
                    break;
                default:
                    break;
            }
        }
    }
}
