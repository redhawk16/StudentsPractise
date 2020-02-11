using StudentsPract.Adapters;
using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace StudentsPract.Pages.Contracts
{
    /// <summary>
    /// Логика взаимодействия для Contracts_Edit.xaml
    /// </summary>
    public partial class Contracts_Edit : Window
    {
        public ObservableCollection<Parent> TreeView { get; set; }
        private List<string> selected_group;
        private List<string> selected_dir = new List<string>();
        private List<List<string>> selected_course = new List<List<string>>();
        private List<List<string>> selected_student;
        private static string dir;
        private Classes.Contracts sel_items;

        public Contracts_Edit(Classes.Contracts sel_items)
        {
            InitializeComponent();

            this.sel_items = sel_items;

            contract_num.Text = sel_items.id;
            contract_org.Text = sel_items.contract_org;
            contract_empl.Text = sel_items.contract_empl;
            type_pract.Text = sel_items.type_pract;
            form_pract.ItemsSource = Helper.Practise_Forms;
            form_pract.SelectedItem = sel_items.form_pract;
            date.SelectedDate = Convert.ToDateTime(sel_items.date);

            dir = $"{Directory.GetCurrentDirectory()}\\documents\\contracts\\Договор №{contract_num.Text}\\";

            List<List<string>> elements = SQLiteAdapter.GetValue("contracts INNER JOIN attach ON attach.id_contract = contracts.id " +
                    "INNER JOIN students ON students.id = attach.id_student " +
                    "INNER JOIN groups ON groups.id = students.groupe " +
                    "INNER JOIN directions ON directions.id = groups.direction " +
                    $"WHERE contracts.id = '{sel_items.id}'", 
                "groups.groupe, students.surname, students.name, students.patronymic");

            // TreeView fill
            this.TreeView = new ObservableCollection<Parent>();
            
            for (int i=0;i<elements.Count;i++)
            {
                if(elements[i].Count > 2) // Если присутствуют отдельные строки ФИО
                {
                    elements[i][3] = $"{elements[i][1]} {elements[i][2]} {elements[i][3]}"; // Объединяем ФИО в одну строку
                    elements[i].RemoveAt(1); // Удаляем Имя
                    elements[i].RemoveAt(1); // Удаляем Отчестово, тоже id из за смещения на единицу после предыдущего удаления
                }
            }

            for (int j = 0; j < elements.Count; j++)
            {
                Group groups = Helper.OGroups.Where(k=>k.groupe.Equals(elements[j][0])).Single();
                Classes.Direction directions = Helper.ODirections.Where(k=>k.name.Equals(groups.direction)).Single();
                if(!this.selected_dir.Contains(directions.code)) this.selected_dir.Add(directions.code);

                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[j][0].Equals(elements[i][0])) // Проверка на одинаковое имя
                    {
                        foreach (string tmp in elements[i])
                            if (!elements[j].Contains(tmp)) elements[j].Add(tmp); // Копируем все данные из совпадающей группы в одну

                        if (i > j)
                        {
                            elements.RemoveAt(i); // Удаляем скопированную группу
                            i--; // Корректировка смещения из за удаленного элемента
                        }
                    }

                }
            }

            List<List<string>> elements_new = new List<List<string>>();
            for(int i = 0; i < elements.Count; i++)
            {
                elements_new.Add(new List<string>());
                for(int j=0;j<elements[i].Count;j++)
                {
                    elements_new[i].Add(elements[i][j].ToString());
                }
            }

            for (int i = 0; i < elements_new.Count; i++)
            {
                List<Student> student = Helper.OStudents.Where(k => k.groupe.Equals(elements_new[i][0])).ToList();
                foreach(Student tmp in student)
                {
                    if(!elements_new[i].Contains($"{tmp.surname} {tmp.name} {tmp.patronymic}"))
                    {
                        elements_new[i].Add($"{tmp.surname} {tmp.name} {tmp.patronymic}");
                    }
                }
            }

            foreach (List<string> element in elements_new)
            {
                List<Child> Member = new List<Child>();
                
                for(int i = 1; i < element.Count; i++) // Начинаем с 1, чтобы не добавлять группы
                {
                    if (!Member.Exists(k => k.Name.Equals(element[i])))
                    {
                        Member.Add(new Child() { Name = element[i] });
                    }

                }

                if (Member.Count != 0)
                {
                    this.TreeView.Add(new Parent()
                    {
                        Name = element[0], // Название группы
                        Members = Member
                    });
                }
            }

            foreach (Parent parent in this.TreeView)
            {
                foreach (Child child in parent.Members)
                {
                    child.SetValue(ItemHelper.ParentProperty, parent);

                    // Отмечаем элементы полученые из БД
                    foreach(List<string> tmp in elements)
                        if(tmp.Contains(child.Name))
                            ItemHelper.SetIsChecked(child, true);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "btnClose":
                    this.Close();
                    break;
                case "btnCreate":
                    if (CreateContract() == true)
                        MessageBox.Show("Договор сформирован!", "Формирование договора", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Ошибка формирования договора!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                default:
                    break;
            }
        }

        private bool CreateContract()
        {
            try
            {
                string file = $"Договор.docx";
                if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

                // создаём документ
                DocX document = DocX.Create(dir + file);

                document.SetDefaultFont(new Font("Times New Roman"), fontSize: 12); // Устанавливаем стандартный для документа шрифт и размер шрифта
                document.MarginLeft = 42.5f;
                document.MarginTop = 34.1f;
                document.MarginRight = 34.1f;
                document.MarginBottom = 34.1f;

                document.InsertParagraph($"Договор № {contract_num.Text}").Bold().Alignment = Alignment.center;
                document.InsertParagraph("о совместной деятельности при прохождении практики студентами").Bold().Alignment = Alignment.center;
                document.InsertParagraph($"г. Омск									{date.Text} г.").Alignment = Alignment.center;
                Paragraph paragraph1 = document.InsertParagraph();
                paragraph1.Append("\tФедеральное государственное бюджетное образовательное учреждение высшего образования \"Сибирский государственный автомобильно-дорожный университет(СибАДИ)\", ").Italic().Alignment = Alignment.both;
                paragraph1.Append($"именуемое в дальнейшем «Учреждение», в лице ректора Жигадло Александра Петровича, действующего на основании Устава, с одной стороны и, с другой стороны \"{contract_org.Text}\" ");
                paragraph1.Append($"именуемое в дальнейшем «Организация» в лице {contract_empl.Text} действующего на основании ______________, заключили между собой договор о нижеследующем.");

                #region 1 Предмет договора
                document.InsertParagraph("1\tПредмет договора").Bold().Alignment = Alignment.center;
                document.InsertParagraph("\t1.1 Учреждение направляет обучающихся, а Организация предоставляет им места для прохождения всех типов практик (далее – практика) по направлениям (специальностям), указанным в Приложении 1, на базе Организации в соответствии с программами и заданиями.").Alignment = Alignment.both;
                document.InsertParagraph("\t1.2 Для прохождения практики в Организацию направляются обучающиеся, перечень которых является неотъемлемой частью настоящего договора(Приложение 2).").Alignment = Alignment.both;
                document.InsertParagraph("\t1.3 С момента зачисления обучающихся в качестве практикантов на них распространяются правила охраны труда и правила внутреннего трудового распорядка, действующие в Организации.").Alignment = Alignment.both;
                #endregion

                #region 2 Права и обязанности сторон
                document.InsertParagraph("2\tПрава и обязанности сторон").Bold().Alignment = Alignment.center;
                document.InsertParagraph("\t2.2 Организация обязуется").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.2   Предоставить рабочие места обучающимся, назначить руководителей практики, определить наставников.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.3	Участвовать в определении процедуры оценки результатов освоения общих и профессиональных компетенций, полученных в период прохождения практики, а также оценке таких результатов.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.4   Обеспечить безопасные условия прохождения практики, отвечающие санитарным правилам и требованиям охраны труда.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.5   Проводить инструктаж обучающихся по ознакомлению с требованиями охраны труда, техники безопасности, пожарной безопасности, а также правилами внутреннего трудового распорядка.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.6   Обеспечить обучающихся необходимыми материалами, которые не составляют коммерческую тайну и могут быть использованы при написании выпускных квалификационных работ / курсовых работ(проектов).").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.7   Уведомлять Учреждение о нарушении обучающимися графика практики, а также правил внутреннего трудового распорядка.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.8   По окончании практики выдать каждому обучающемуся отзыв(характеристику) о его работе.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.9   Предоставлять возможность повторного направления обучающегося на практику, если он не прошел практику по уважительным причинам.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.10  Не привлекать обучающихся к выполнению тяжелых работ с вредными и опасными условиями труда.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.11  Несчастные случаи, происшедшие в Организации со студентами Учреждения во время прохождения практики, расследовать комиссией совместно с представителями Учреждения и учитывать в Организации в соответствии с Положением о расследовании и учете несчастных случаев на производстве.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.1.12  Не менее чем за один месяц до начала практики сообщить в письменном виде об отказе о предоставлении мест проведения практики студентов.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.2 Организация имеет право:").Alignment = Alignment.both;
                document.InsertParagraph("\t2.2.1   Не допускать обучающегося к прохождению практики в случае выявления фактов нарушения им правил внутреннего трудового распорядка, охраны труда, техники безопасности, а также в иных случаях нарушения условий настоящего договора обучающимся или Учреждением.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.3 Учреждение обязуется:").Alignment = Alignment.both;
                document.InsertParagraph("\t2.3.1   Направить в Организацию студентов в сроки, предусмотренные графиком учебного процесса.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.3.2   Определять совместно с Организацией процедуру оценки общих и профессиональных компетенций обучающихся, освоенных ими в ходе прохождения практики.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.3.3   Назначать в качестве руководителей практики от Учреждения квалифицированных сотрудников из числа научно-педагогических работников Учреждения.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.3.4   Оказывать руководителям практики студентов от Организации методическую помощь в проведении всех видов практики.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.3.5   Принимать участие в работе комиссии Организации по расследованию несчастных случаев с обучающимися.").Alignment = Alignment.both;
                document.InsertParagraph("\t2.4 Учреждение имеет право:").Alignment = Alignment.both;
                document.InsertParagraph("\t2.4.1   При непредставлении обучающемуся рабочего места и работ, отвечающих требованиям учебных программ специальности(направления), необеспечении условий безопасности труда, а также при использовании труда обучающегося на сторонних или подсобных работах отозвать обучающегося с места практики").Alignment = Alignment.both;
                #endregion

                #region 3 Ответственность
                document.InsertParagraph("3\tОтветственность").Bold().Alignment = Alignment.center;
                document.InsertParagraph("\t3.1 Стороны несут ответственность за неисполнение или ненадлежащее исполнение обязанностей по настоящему договору в соответствии с действующим законодательством Российской Федерации.").Alignment = Alignment.both;
                document.InsertParagraph("\t3.2 Ответственность за вред, который может наступить вследствие разглашения обучающимся конфиденциальной информации Организации, а также за нарушение интеллектуальных, авторских и иных неимущественных прав несет обучающийся.").Alignment = Alignment.both;
                document.InsertParagraph("\t3.3 Неисполнение условий настоящего пункта влечет для Сторон обязанность по возмещению убытков, связанных с неисполнением условий настоящего договора.").Alignment = Alignment.both;
                #endregion

                #region 4 Заключительные положения
                document.InsertParagraph("4\tЗаключительные положения").Bold().Alignment = Alignment.center;
                document.InsertParagraph("\t4.1 Настоящий договор составлен и подписан в двух аутентичных экземплярах - по одному для каждой Стороны.").Alignment = Alignment.both;
                document.InsertParagraph("\t4.2 Договор вступает в силу с момента подписания и действует до 31.12.2024 г.").Alignment = Alignment.both;
                document.InsertParagraph("\t4.3 Если до окончания срока действия настоящего договора ни одна из Сторон не заявит о прекращении действия договора, необходимости внесения в договор изменений и/ или дополнений, о необходимости заключения нового договора на иных условиях, настоящий договор считается продленным(пролонгированным) на _1 г.на прежних условиях.").Alignment = Alignment.both;
                document.InsertParagraph("\t4.4 Во всем остальном, что не предусмотрено настоящим договором, Стороны руководствуются действующим законодательством Российской Федерации.").Alignment = Alignment.both;
                #endregion

                #region 5 Реквизиты и подписи сторон
                document.InsertParagraph("5\tРеквизиты и подписи сторон").Bold().Alignment = Alignment.center;

                document.InsertParagraph("Учреждение: 644080, г.Омск, пр.Мира, 5		Организация:__________________________").Alignment = Alignment.both;
                document.InsertParagraph("ФГБОУ ВО «СибАДИ»				_______________________________________").Alignment = Alignment.both;
                document.InsertParagraph("тел.: 72 - 94 - 97					_______________________________________").Alignment = Alignment.both;
                document.InsertParagraph("Ректор 		А.П.Жигадло			________________ / _____________________ /").Alignment = Alignment.both;
                document.InsertParagraph("							подпись				расшифровка подписи").Script(Script.superscript).FontSize(10).Alignment = Alignment.both;
                document.InsertParagraph("МП								МП").FontSize(11).Alignment = Alignment.both;
                document.InsertParagraph("Имеет право подписи за руководителя(ректора)").FontSize(10).Alignment = Alignment.both;
                document.InsertParagraph("Проректор по учебной работе").FontSize(10).Alignment = Alignment.both;
                document.InsertParagraph("(доверенность № 61 от 29.10.2018)").FontSize(10).Alignment = Alignment.both;
                document.InsertParagraph("______________ / С.В.Мельник /").Alignment = Alignment.both;

                document.InsertParagraph("Начальник отдела организации практики").FontSize(10).Alignment = Alignment.both;
                document.InsertParagraph("и содействия трудоустройству выпускников").FontSize(10).Alignment = Alignment.both;
                document.InsertParagraph("______________ / Ю.С.Сачук /").Alignment = Alignment.both;
                document.InsertParagraph("Заведующий выпускающей кафедрой").FontSize(10).Alignment = Alignment.both;
                document.InsertParagraph("«_Прикладная инфрматика в экономике»").Alignment = Alignment.both;
                document.InsertParagraph("______________ / Л.И.Остринская /").Alignment = Alignment.both;
                document.InsertParagraph("подпись         расшифровка подписи").Script(Script.superscript).FontSize(10).Alignment = Alignment.both;
                #endregion

                if (CreateContract_Attch1() == false) return false;
                if (CreateContract_Attch2() == false) return false;

                SQLiteAdapter.DeleteRowById("contracts", $"[id]='{sel_items.id}'");
                // Добавляем данные в БД
                SQLiteAdapter.SetValue("contracts", contract_num.Text,
                                            $"{date.Text}",
                                            contract_org.Text,
                                            contract_empl.Text,
                                            form_pract.SelectedItem.ToString(),
                                            type_pract.Text);
                // сохраняем документ
                document.Save();

            }
            catch (Exception e)
            {
                SQLiteAdapter.DeleteRowById("contracts", $"[id]='{contract_num.Text}'");
                SQLiteAdapter.DeleteRowById("attach", $"[id_contract]='{contract_num.Text}'");
                MessageBox.Show($"Error: {e}", "Error", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private bool CreateContract_Attch1()
        {
            try
            {
                string file = $"Приложение 1.docx";

                // создаём документ
                DocX document = DocX.Create(dir + file);

                document.SetDefaultFont(new Font("Times New Roman"), fontSize: 12); // Устанавливаем стандартный для документа шрифт и размер шрифта
                document.MarginLeft = 42.5f;
                document.MarginTop = 34.1f;
                document.MarginRight = 34.1f;
                document.MarginBottom = 34.1f;

                document.InsertParagraph("Приложение 1").Alignment = Alignment.right;
                document.InsertParagraph($"к договору № {contract_num.Text} от {date.Text} г.").Alignment = Alignment.right;

                // создаём таблицу с N строками и 3 столбцами
                Table table = document.AddTable(selected_dir.Count + 2, 3);
                // располагаем таблицу по центру
                table.Alignment = Alignment.center;
                table.AutoFit = AutoFit.Contents;

                #region Стандартное заполнение
                table.Rows[0].Cells[0].Paragraphs[0].Append("№ п/п").Alignment = Alignment.center;
                table.Rows[0].Cells[1].Paragraphs[0].Append("Направление /специальность").Alignment = Alignment.center;
                table.Rows[0].Cells[2].Paragraphs[0].Append("Курс").Alignment = Alignment.center;

                table.Rows[1].Cells[0].Paragraphs[0].Append("1").Alignment = Alignment.center;
                table.Rows[1].Cells[1].Paragraphs[0].Append("2").Alignment = Alignment.center;
                table.Rows[1].Cells[2].Paragraphs[0].Append("3").Alignment = Alignment.center;
                #endregion

                for (int i = 0; i < selected_dir.Count; i++)
                {
                    Classes.Direction direction = Helper.ODirections.Where(k => k.code.Equals(selected_dir[i])).ElementAt(0);
                    table.Rows[i + 2].Cells[0].Paragraphs[0].Append((i + 1).ToString()).Alignment = Alignment.center;
                    table.Rows[i + 2].Cells[1].Paragraphs[0].Append(direction.code + " " + direction.name).Alignment = Alignment.both;
                    string courses = "";
                    foreach (string course in selected_course[i])
                    {
                        courses += Convert.ToInt32(course.Split()[0]) + ", ";
                    }

                    table.Rows[i + 2].Cells[2].Paragraphs[0].Append(courses.TrimEnd(new char[] { ',', ' ' })).Alignment = Alignment.center;
                }

                document.InsertParagraph().InsertTableAfterSelf(table);

                document.InsertParagraph();
                document.InsertParagraph("Согласовано:");
                document.InsertParagraph();
                Paragraph paragraph1 = document.InsertParagraph("ФГБОУ ВО «СибАДИ»				");
                paragraph1.Append($"__{contract_org.Text}__").UnderlineStyle(UnderlineStyle.singleLine);
                Paragraph paragraph2 = document.InsertParagraph("Ректор		А.П. Жигадло");
                paragraph2.Append("				наименование предприятия, учреждения, организации").Script(Script.superscript).FontSize(10);
                document.InsertParagraph("							____________________________________");
                document.InsertParagraph("							подпись			расшифровка подписи").Script(Script.superscript).FontSize(10);
                document.InsertParagraph("МП							МП");
                document.InsertParagraph("Имеет право подписи").Italic();
                document.InsertParagraph("за руководителя(ректора)").Italic();
                document.InsertParagraph("Проректор по учебной работе");
                document.InsertParagraph("(доверенность № 61 от 29.10.2018)");
                document.InsertParagraph("____________________ С.В. Мельник");

                // сохраняем документ
                document.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e}", "Error", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private bool CreateContract_Attch2()
        {
            try
            {
                string file = $"Приложение 2.docx";

                SQLiteAdapter.DeleteRowById("attach", $"[id_contract]='{sel_items.id}'"); // Удаляем существующие данные

                // создаём документ
                DocX document = DocX.Create(dir + file);

                document.SetDefaultFont(new Font("Times New Roman"), fontSize: 12); // Устанавливаем стандартный для документа шрифт и размер шрифта
                document.MarginLeft = 42.5f;
                document.MarginTop = 34.1f;
                document.MarginRight = 34.1f;
                document.MarginBottom = 34.1f;
                document.PageLayout.Orientation = Xceed.Document.NET.Orientation.Landscape;

                document.InsertParagraph("Приложение 2").Alignment = Alignment.right;
                document.InsertParagraph($"к договору № {contract_num.Text} от {date.Text} г.").Alignment = Alignment.right;

                document.InsertParagraph("Список студентов ФГБОУ ВО «СибАДИ», направляемых на производственные объекты").Alignment = Alignment.center;
                document.InsertParagraph($"\t\t{contract_org.Text}\t\t\t").UnderlineStyle(UnderlineStyle.singleLine).Alignment = Alignment.center;
                document.InsertParagraph("наименование предприятия, учреждения, организации").Script(Script.superscript).FontSize(12).Alignment = Alignment.center;
                document.InsertParagraph("для прохождения").Alignment = Alignment.center;
                Paragraph paragraph1 = document.InsertParagraph($"\t\t{form_pract.SelectedItem.ToString().Trim()}, {type_pract.Text}\t\t\t").UnderlineStyle(UnderlineStyle.singleLine);
                paragraph1.Append($"в {date.SelectedDate.Value.Year} г").Alignment = Alignment.center;
                document.InsertParagraph("вид и тип практики").Script(Script.superscript).FontSize(12).Alignment = Alignment.center;

                int _all_el = 0;
                foreach (List<string> tmp in selected_student)
                {
                    _all_el += tmp.Count;
                }

                // создаём таблицу с N строками и 3 столбцами
                Table table = document.AddTable(_all_el + 2, 9);
                // располагаем таблицу по центру
                table.Alignment = Alignment.center;
                table.AutoFit = AutoFit.Contents;

                #region Стандартное заполнение
                table.Rows[0].Cells[0].Paragraphs[0].Append("№ п/п").Alignment = Alignment.center;
                table.Rows[0].Cells[1].Paragraphs[0].Append("Название факультета, кафедры, заявивших студентов на практику ").Alignment = Alignment.center;
                table.Rows[0].Cells[2].Paragraphs[0].Append("Направление/специальность").Alignment = Alignment.center;
                table.Rows[0].Cells[3].Paragraphs[0].Append("Сроки практики").Alignment = Alignment.center;
                table.Rows[0].Cells[4].Paragraphs[0].Append("Курс").Alignment = Alignment.center;
                table.Rows[0].Cells[5].Paragraphs[0].Append("Группа").Alignment = Alignment.center;
                table.Rows[0].Cells[6].Paragraphs[0].Append("Ф.И.О. студента").Alignment = Alignment.center;
                table.Rows[0].Cells[7].Paragraphs[0].Append("Ф.И.О. руководителя практики от кафедры").Alignment = Alignment.center;
                table.Rows[0].Cells[8].Paragraphs[0].Append("Контактные телефоны кафедры по вопросам практики ").Alignment = Alignment.center;

                table.Rows[1].Cells[0].Paragraphs[0].Append("1").Alignment = Alignment.center;
                table.Rows[1].Cells[1].Paragraphs[0].Append("2").Alignment = Alignment.center;
                table.Rows[1].Cells[2].Paragraphs[0].Append("3").Alignment = Alignment.center;
                table.Rows[1].Cells[3].Paragraphs[0].Append("4").Alignment = Alignment.center;
                table.Rows[1].Cells[4].Paragraphs[0].Append("5").Alignment = Alignment.center;
                table.Rows[1].Cells[5].Paragraphs[0].Append("6").Alignment = Alignment.center;
                table.Rows[1].Cells[6].Paragraphs[0].Append("7").Alignment = Alignment.center;
                table.Rows[1].Cells[7].Paragraphs[0].Append("8").Alignment = Alignment.center;
                table.Rows[1].Cells[8].Paragraphs[0].Append("9").Alignment = Alignment.center;
                #endregion

                int row = 2;
                for (int i = 0; i < selected_student.Count; i++)
                {
                    foreach (string tmp_st in selected_student[i])
                    {
                        table.Rows[row].Cells[0].Paragraphs[0].Append((i + 1).ToString()).Alignment = Alignment.center;
                        Group group = Helper.OGroups.Where(k => k.groupe.Equals(selected_group[i])).ElementAt(0);
                        Classes.Direction direction = Helper.ODirections.Where(k => k.name.Equals(group.direction)).ElementAt(0);
                        Cathedra cathedra = Helper.OCathedras.Where(k => k.cathedra.Equals(direction.id_cathedra)).ElementAt(0);

                        #region Вычисляем курс
                        int enroll = Convert.ToInt32(group.enroll_year); // Год поступления 
                        int end = Convert.ToInt32(group.end_year); // Год окончания

                        int course = DateTime.Today.Year - enroll;
                        int month = DateTime.Today.Month - 9;
                        if (month >= 0) course++;
                        #endregion

                        table.Rows[row].Cells[1].Paragraphs[0].Append(cathedra.cathedra).Alignment = Alignment.center; // Кафедра
                        table.Rows[row].Cells[2].Paragraphs[0].Append(direction.code + " " + direction.name).Alignment = Alignment.center; // Направление
                        table.Rows[row].Cells[3].Paragraphs[0].Append(" - ").Alignment = Alignment.center; // Сроки практики
                        table.Rows[row].Cells[4].Paragraphs[0].Append(course.ToString()).Alignment = Alignment.center; // Курс
                        table.Rows[row].Cells[5].Paragraphs[0].Append(group.groupe).Alignment = Alignment.center; // Группа
                        table.Rows[row].Cells[6].Paragraphs[0].Append(tmp_st).Alignment = Alignment.center; // Ф.И.О. студента
                        table.Rows[row].Cells[7].Paragraphs[0].Append(cathedra.surname + " " + cathedra.name + " " + cathedra.patronymic).Alignment = Alignment.center; // Ф.И.О. руководителя от кафедры
                        table.Rows[row].Cells[8].Paragraphs[0].Append(cathedra.phone).Alignment = Alignment.center; // Телефон кафедры
                        row++;

                        // Добавляем студента в БД Attach
                        // Разбиваем ФИО студента на состовляющие
                        var fio = tmp_st.Split();
                        Student st_tmp = Helper.OStudents.Where(k => k.surname.Equals(fio[0]) && k.name.Equals(fio[1]) && k.patronymic.Equals(fio[2])).ElementAt(0);

                        SQLiteAdapter.SetValue("attach", contract_num.Text, st_tmp.id); // и записываем новые
                    }
                }

                document.InsertParagraph().InsertTableAfterSelf(table);

                document.InsertParagraph();
                document.InsertParagraph("Согласовано:");
                document.InsertParagraph("Заведующий выпускающей кафедрой");
                document.InsertParagraph("«___________________________________»	______________ /______________________/");
                document.InsertParagraph("							подпись             расшифровка подписи").Script(Script.superscript).FontSize(10);
                document.InsertParagraph("Декан факультета / Директор института");
                document.InsertParagraph("«___________________________________»	______________ /______________________/");
                document.InsertParagraph("							подпись             расшифровка подписи").Script(Script.superscript).FontSize(10);
                document.InsertParagraph("Начальник отдела организации практики");
                document.InsertParagraph("и содействия трудоустройству выпускников    ______________ / Ю.С.Сачук /");
                document.InsertParagraph("							подпись             расшифровка подписи").Script(Script.superscript).FontSize(10);

                // сохраняем документ
                document.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e}", "Error", MessageBoxButton.OK);
                return false;
            }

            return true;
        }


        private void Button_PrintCrew_Click(object sender, RoutedEventArgs e)
        {
            selected_group = new List<string>();
            selected_student = new List<List<string>>();

            string selected = "";
            foreach (Parent parent in this.TreeView)
            {
                List<string> tmp = new List<string>();
                List<string> tmp_course = new List<string>();
                foreach (Child child in parent.Members)
                {
                    if (ItemHelper.GetIsChecked(child) == true)
                    {
                        if (!selected_group.Contains(parent.Name)) selected_group.Add(parent.Name);
                        if (!tmp.Contains(child.Name)) tmp.Add(child.Name);
                        selected += child.Name + ", ";



                        Group groups = Helper.OGroups.Where(k=>k.groupe.Equals(parent.Name)).Single();
                        int enroll = Convert.ToInt32(groups.enroll_year); // Год поступления 
                        int end = Convert.ToInt32(groups.end_year); // Год окончания

                        //Вычислить курс
                        // Месяц и Год текущий - Месяц и Год поступления
                        int course = DateTime.Today.Year - enroll;
                        int month = DateTime.Today.Month - 9;
                        if (month >= 0) course++;

                        if (!tmp_course.Contains(course.ToString())) tmp_course.Add(course.ToString());
                    }
                }
                if (tmp.Count > 0) selected_student.Add(tmp);
                if (tmp_course.Count > 0) this.selected_course.Add(tmp_course);
            }
            selected = selected.TrimEnd(new char[] { ',', ' ' });
            //selectedParent = selectedParent.TrimEnd(new char[] { ',', ' ' });
            this.textBoxCrew.Text = "Вы выбрали: " + selected;
        }
    }
}
