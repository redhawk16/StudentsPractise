using StudentsPract.Adapters;
using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace StudentsPract.Pages.Orders
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        ObservableCollection<Fill_data> fill_data { get; set; }
        private string dir;

        public Orders()
        {
            InitializeComponent();
            combobox_groupe.ItemsSource = Helper.OGroups.Select(i => i.groupe);
            combobox_otvetsven.ItemsSource = Helper.OEmployees.Select(i => i.surname);

            form_pract.ItemsSource = Helper.Practise_Forms;

            fill_data = new ObservableCollection<Fill_data>();
            datagrid.ItemsSource = fill_data;

            first_date.DisplayDateStart = DateTime.Now;
            first_date.SelectedDate = DateTime.Now;
            second_date.DisplayDateStart = DateTime.Now.AddDays(1);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fill_data.Clear();
            IEnumerable<Student> students = Helper.OStudents.Where(k => k.groupe.Equals(combobox_groupe.SelectedItem.ToString().Trim()));
            for (int i = 0; i < students.Count(); i++)
            {
                fill_data.Add(new Fill_data
                {
                    fio = students.ElementAt(i).surname + " " + students.ElementAt(i).name + " " + students.ElementAt(i).patronymic,
                    payable = students.ElementAt(i).free_study,
                    group = combobox_groupe.SelectedItem.ToString().Trim(),
                    employee = combobox_otvetsven.SelectedItem.ToString().Trim()
                });

            }
        }
        private void Form_order_Click(object sender, RoutedEventArgs e)
        {
            Group group = Helper.OGroups.Where(k => k.groupe.Equals(combobox_groupe.SelectedItem)).ElementAt(0);

            int enroll = Convert.ToInt32(group.enroll_year); // Год поступления 
            int end = Convert.ToInt32(group.end_year); // Год окончания

            int course = DateTime.Today.Year - enroll;
            int month = DateTime.Today.Month - 9;
            if (month >= 0) course++;
            Classes.Direction direction = Helper.ODirections.Where(k => k.name.Equals(group.direction)).ElementAt(0);
            string code = direction.code;

            this.dir = $"{Directory.GetCurrentDirectory()}\\documents\\orders\\Приказ {group.groupe} от {first_date.Text}\\";
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
            CreateOrder(course, code, direction.name);
        }
        private void CreateOrder(int course, string code, string direct)
        {
            string file = "order.docx";
            // создаём документ
            DocX document = DocX.Create(dir + file);

            document.SetDefaultFont(new Font("Times New Roman"), fontSize: 12); // Устанавливаем стандартный для документа шрифт и размер шрифта
            document.MarginLeft = 42.5f;
            document.MarginTop = 34.1f;
            document.MarginRight = 34.1f;
            document.MarginBottom = 34.1f;

            document.InsertParagraph($"Проект приказа\n\n").Bold().Alignment = Alignment.center;
            document.InsertParagraph($"\tВ соответствии с календарным графиком учебного процесса допустить "+
                $"и направить для прохождения {form_pract.SelectedItem.ToString().ToLower()} практики {combobox_type.SelectedItem} "+
                $"следующих студентов {course} курса, очной формы, направление подготовки {code} «{direct}», " +
                $"профиль «Прикладная информатика в государственном и муниципальном управлении», факультета "+
                $"«Информационные системы в управлении» с {first_date.Text}г. по {second_date.Text}.\n");
            document.InsertParagraph($"\tСпособ проведения практики: выездная и стационарная.");
            document.InsertParagraph($"\tСтационарная практика (без оплаты)\n").Bold();
            document.InsertParagraph($"\tОбучающихся за счет бюджетных ассигнований федерального бюджета");

            IEnumerable<Fill_data> studentsF = fill_data.Where(k => k.payable.Equals("Бюджет"));
            IEnumerable<Fill_data> studentsB = fill_data.Where(k => k.payable.Equals("Внебюджет"));

            Xceed.Document.NET.Table table = document.AddTable(studentsF.Count() + 1, 4);
            Xceed.Document.NET.Table tabpe_pay = document.AddTable(studentsB.Count() + 1, 4);

            table.Alignment = Alignment.center;
            table.AutoFit = AutoFit.Contents;

            tabpe_pay.Alignment = Alignment.center;
            tabpe_pay.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append("ФИО студента").Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append("Группа").Alignment = Alignment.center;
            table.Rows[0].Cells[2].Paragraphs[0].Append("Место прохождения практики").Alignment = Alignment.center;
            table.Rows[0].Cells[3].Paragraphs[0].Append("Руководитель практики").Alignment = Alignment.center;

            tabpe_pay.Rows[0].Cells[0].Paragraphs[0].Append("ФИО студента").Alignment = Alignment.center;
            tabpe_pay.Rows[0].Cells[1].Paragraphs[0].Append("Группа").Alignment = Alignment.center;
            tabpe_pay.Rows[0].Cells[2].Paragraphs[0].Append("Место прохождения практики").Alignment = Alignment.center;
            tabpe_pay.Rows[0].Cells[3].Paragraphs[0].Append("Руководитель практики").Alignment = Alignment.center;

            for (int i = 0; i < studentsF.Count(); i++)
            {
                table.Rows[i + 1].Cells[0].Paragraphs[0].Append(studentsF.ElementAt(i).fio);
                table.Rows[i + 1].Cells[1].Paragraphs[0].Append(combobox_groupe.SelectedItem.ToString());
                table.Rows[i + 1].Cells[2].Paragraphs[0].Append(studentsF.ElementAt(i).place);
                table.Rows[i + 1].Cells[3].Paragraphs[0].Append(combobox_otvetsven.SelectedItem.ToString());
            }

            for (int i = 0; i < studentsB.Count(); i++)
            {
                tabpe_pay.Rows[i + 1].Cells[0].Paragraphs[0].Append(studentsB.ElementAt(i).fio);
                tabpe_pay.Rows[i + 1].Cells[1].Paragraphs[0].Append(combobox_groupe.SelectedItem.ToString());
                tabpe_pay.Rows[i + 1].Cells[2].Paragraphs[0].Append(studentsB.ElementAt(i).place);
                tabpe_pay.Rows[i + 1].Cells[3].Paragraphs[0].Append(combobox_otvetsven.SelectedItem.ToString());
            }
            document.InsertParagraph().InsertTableAfterSelf(table);

            if (studentsB.Count() > 0) {
                document.InsertParagraph($"\tОбучающихся на платной основе");
                document.InsertParagraph().InsertTableAfterSelf(tabpe_pay);
            }
            document.InsertParagraph($"\tОтветственный по {form_pract.SelectedItem.ToString().ToLower()}  практики по кафедре в период с {first_date.Text} г. по  {second_date.Text} г. -  {combobox_otvetsven.Text} ст. преподаватель кафедры ПИЭ.");

            Classes.Direction directions = Helper.ODirections.Where(k => k.name.Equals(direct)).ElementAt(0);
            Cathedra cathedra = Helper.OCathedras.Where(k => k.cathedra.Equals(directions.id_cathedra)).ElementAt(0);

            document.InsertParagraph($@"
        Проректор по УР                    ________«____» ________ {first_date.SelectedDate.Value.Year}г.   С.В. Мельник
        Главный бухгалтер                ________«____» ________ {first_date.SelectedDate.Value.Year} г.  Г.И. Вилисова
        Начальник ПЭО                     ________«____» ________ {first_date.SelectedDate.Value.Year}г.   Т.В. Грачева
        Начальник ООП и СТВ          ________«____» ________{first_date.SelectedDate.Value.Year}г.   Ю.С. Сачук 
        Декан факультета «{directions.id_cathedra}»  ________«____» ________ {first_date.SelectedDate.Value.Year}г.   {cathedra.name.Remove(1)}.{cathedra.patronymic.Remove(1)}. {cathedra.surname}
        Ответственный за практику 
        и содействие трудоустройству
        на факультете                 ________«____» __________ {first_date.SelectedDate.Value.Year}г.   {cathedra.name.Remove(1)}.{cathedra.patronymic.Remove(1)}.{cathedra.surname}
");
            document.Save();
            MessageBox.Show("Документ успешно сформирован!","Документ", MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private class Fill_data
        {
            public string fio { get; set; }
            public string payable { get; set; }
            public string group { get; set; }
            public string place { get; set; }
            public string employee { get; set; }
        }

        private void Form_pract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combobox_type.IsEnabled = true;

            combobox_type.Items.Clear();
            List<List<string>> type_practs = SQLiteAdapter.GetValue($"pract_types INNER JOIN groups ON groups.id=pract_types.id_groupe WHERE groups.groupe='{combobox_groupe.SelectedItem}'", "pract_types.type_name");
            foreach (List<string> tmp in type_practs)
            {
                combobox_type.Items.Add(tmp[0]);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
