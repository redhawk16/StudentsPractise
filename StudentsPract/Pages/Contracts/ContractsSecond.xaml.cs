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

namespace StudentsPract.Pages.Contracts
{
    /// <summary>
    /// Логика взаимодействия для ContractsSecond.xaml
    /// </summary>
    public partial class ContractsSecond : Page
    {
        private List<string> groups { get; set; }

        private string contract_num;
        private string contract_org;
        private string contract_empl;
        private string date;

        public ContractsSecond(string contract_num, // Номер договора
                                string contract_org, // База практики
                                string contract_empl, // Руководитель практики
                                string date, // Дата
                                List<string> selected_dir, // Список выбранных направлений
                                List<List<string>> selected_course) // Список выбранных курсов
        {
            InitializeComponent();

            this.contract_num = contract_num;
            this.contract_org = contract_org;
            this.contract_empl = contract_empl;
            this.date = date;

            groups = Selected_Groups(selected_dir, selected_course);

            formPract.ItemsSource = Helper.Practise_Forms; // Вид практики
            // Преобразовать курсы в группы
            type_pract.ItemsSource = Practise_Types();
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
                case "btnCreate":
                    MessageBox.Show("Договор сформирован", "Формирование договора", MessageBoxButton.OK);
                    break;
                default:
                    break;
            }
        }

        private List<string> Selected_Groups(List<string> selected_dir, List<List<string>> selected_course)
        {
            List<string> groups = new List<string>();
            for (int i = 0; i < selected_course.Count; i++)
            {
                for (int j = 0; j < selected_course[i].Count; j++)
                {
                    //Конвертируем курс в группу
                    int course = Convert.ToInt32(selected_course[i].ElementAt(j).Split()[0]);
                    int month = DateTime.Today.Month - 9; // Текущий месяц - месяц поступления
                    if (month >= 0) course--;
                    int enroll = DateTime.Today.Year - course; // Год поступления 

                    List<List<string>> groups_arr = SQLiteAdapter.GetValue($"groups INNER JOIN directions ON directions.id=groups.direction WHERE code ='{selected_dir[i]}' AND enroll_year='{enroll}'", "groups.groupe");
                    foreach (List<string> group_tmp in groups_arr) groups.Add(group_tmp[0]);
                }
            }

            return groups;
        }

        private List<string> Practise_Types()
        {
            // Получаем типы практики для выбранных групп
            string query_group = "";
            foreach(string group in groups) query_group = query_group + $"'{group}', ";
            query_group = query_group.TrimEnd(new char[] { ',', ' ' });

            // Получение списка типов практики по выбранным группам
            List<List<string>> type_practs = SQLiteAdapter.GetValue($"pract_types INNER JOIN groups ON groups.id=pract_types.id_groupe WHERE groups.groupe IN ({query_group})", "groups.groupe, pract_types.type_name");
            List<string> practs = new List<string>(); // Список типов практки

            /* TODO: переделать ( у всех групп должны быть совпадения по типам практики)*/

            if (type_practs.Count <= 0)
            {
                MessageBox.Show("Список типов практик у выбранных групп пуст!", "Ошибка!", MessageBoxButton.OK);
                return null;
            }

            // Поиск групп с одинаковыми именами => обьединение
            for(int j = 0; j < type_practs.Count; j++)
            {
                for (int i = 0; i < type_practs.Count; i++)
                {
                    if (type_practs[j][0].Equals(type_practs[i][0])) // Проверка на одинаковое имя
                    {
                        foreach (string tmp in type_practs[i])
                            if (!type_practs[j].Contains(tmp)) type_practs[j].Add(tmp); // Копируем все данные из совпадающей группы в одну

                        if (i > j) {
                            type_practs.RemoveAt(i); // Удаляем скопированную группу
                            i--; // Корректировка смещения из за удаленного элемента
                        }
                    }

                }
            }


            type_practs.ForEach(i=>i.RemoveAt(0)); // Удаляем наименования групп

            for(int i = 1; i < type_practs.Count; i++)
            {
                /* Проверяем совпадают ли типы практики у двух групп, если нет, то удаляем этот тип практики, так как нам нужны только те которые 100% у всех повторяются,
                 * а следовательно если у одного нет, то по условию не пройдет и у других
                 */
                type_practs[0] = type_practs[0].Select(k => k.ToString()).Intersect(type_practs[i]).ToList();
            }
            practs = type_practs[0];

/*                for (int j = 1; j < type_practs[i].Count; j++) // 0-ый элемент - имя группы
                {

                    if (type_practs[i][1].Equals(type_practs[i][j])) type_practs[i].RemoveAt(j); // Удаляем дубликаты типов практики в группах
                }
                if (type_practs[0][1].Equals(type_practs[i][1]))
                {
                    if (!practs.Contains(type_practs[i][1])) practs.Add(type_practs[i][1]);
                }
                else
                {
                    practs.Clear();
                    break;
                }*/


            /*for (int j = 1; j < type_practs.Count; j++)
            {
                if (type_practs[0][0].Equals(type_practs[j][1])) 
                {
                    if (!practs.Contains(type_practs[j][1])) practs.Add(type_practs[j][1]);
                }

                if(j == type_practs.Count - 1)
                    type_practs.RemoveAt(0);
            }*/
            
            if(practs.Count <= 0) 
            { 
                MessageBox.Show("Общих типов практики для выбранных курсов не найденно!\nВернитесь на первую страницу и выберите другие курсы", "Ошибка!", MessageBoxButton.OK);
                return null;
            }

            return practs;
        }
    }
}
