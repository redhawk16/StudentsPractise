using StudentsPract.Adapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace StudentsPract.Classes
{
    public class Helper
    {
        #region ObservableCollection for Table
        public static ObservableCollection<Student> OStudents { get; set; }
        public static ObservableCollection<Group> OGroups { get; set; }
        public static ObservableCollection<Cathedra> OCathedras { get; set; }
        public static ObservableCollection<Employee> OEmployees { get; set; }
        public static ObservableCollection<Direction> ODirections { get; set; }
        public static ObservableCollection<Practise> OPractise { get; set; }
        #endregion

        private static Helper instance = null;

        public static Helper getInstance()
        {
            if (instance == null)
                instance = new Helper();
            return instance;
        }

        public Helper()
        {
            if (instance == null)
            {
                //RefreshOCollection();
                OStudents = new ObservableCollection<Student>(GetTableByClass<Student>("students INNER JOIN groups ON groups.id=students.groupe", "students.id, students.surname, students.name, students.patronymic, groups.groupe, students.free_study, students.email, students.phone"));
                OGroups = new ObservableCollection<Group>(GetTableByClass<Group>("groups INNER JOIN directions ON directions.id=groups.direction", "groups.id, groups.groupe, directions.name, groups.form_study, groups.enroll_year, groups.end_year"));
                OCathedras = new ObservableCollection<Cathedra>(GetTableByClass<Cathedra>("cathedras INNER JOIN employees ON employees.id=cathedras.id_decan"));
                OEmployees = new ObservableCollection<Employee>(GetTableByClass<Employee>());
                ODirections = new ObservableCollection<Direction>(GetTableByClass<Direction>("directions INNER JOIN cathedras ON cathedras.id=directions.id_cathedra", "directions.id, directions.code, directions.name, cathedras.cathedra"));
                OPractise = new ObservableCollection<Practise>(GetTableByClass<Practise>());
            }
        }


        public static void RefreshOCollection(string table = "*")
        {

            OStudents.Clear();
            foreach (var item in GetTableByClass<Student>("students INNER JOIN groups ON groups.id=students.groupe", "students.id, students.surname, students.name, students.patronymic, groups.groupe, students.free_study, students.email, students.phone"))
                OStudents.Add(item);

            OGroups.Clear();
            foreach (var item in GetTableByClass<Group>("groups INNER JOIN directions ON directions.id=groups.direction", "groups.id, groups.groupe, directions.name, groups.form_study, groups.enroll_year, groups.end_year"))
                OGroups.Add(item);

            OCathedras.Clear();
            foreach (var item in GetTableByClass<Cathedra>("cathedras INNER JOIN employees ON employees.id=cathedras.id_decan"))
                OCathedras.Add(item);

            OEmployees.Clear();
            foreach (var item in GetTableByClass<Employee>())
                OEmployees.Add(item);

            ODirections.Clear();
            foreach (var item in GetTableByClass<Direction>("directions INNER JOIN cathedras ON cathedras.id=directions.id_cathedra", "directions.id, directions.code, directions.name, cathedras.cathedra"))
                ODirections.Add(item);

            OPractise.Clear();
            foreach (var item in GetTableByClass<Practise>())
                OPractise.Add(item);
        }

        public static bool Controls_Listener(List<Control> controls)
        {
            int controls_check = 0;
            foreach (Control control in controls)
            {
                int control_length = 0;
                if (control is TextBox) { control_length = ((TextBox)control).Text.Trim().Length; }
                else if (control is ComboBox) { control_length = ((ComboBox)control).SelectedIndex + 1; }
                else if (control is DatePicker) { control_length = ((DatePicker)control).Text.Trim().Length; }
                else break;

                if (control_length > 0) { controls_check++; }
            }

            if (controls_check == controls.Count) { return true; }
            else return false;
        }

        public static List<T> GetTableByClass<T>(string table_name = null, string select = "*") where T : new()
        {
            if(table_name == null) table_name = GetTNameByClass<T>(); // Get table name in database by class

            Type properties = typeof(T);
            PropertyInfo property;
            List<T> values = new List<T>();
            List<List<string>> tmp = SQLiteAdapter.GetValue(table_name, select);

            foreach (List<string> column in tmp)
            {
                T ClassName = new T();

                for (int i = 0; i < properties.GetProperties().Count(); i++)
                {
                    property = properties.GetProperties().ElementAt(i);
                    if (column.Count > i) property.SetValue(ClassName, column[i]);
                    else break;
                }

                values.Add(ClassName);
            }

            return values;
        }

        public static string GetTNameByClass<T>()
        {
            if (typeof(T).Name.Equals("Group")) return "groups";
            else if (typeof(T).Name.Equals("Student")) return "students";
            else if (typeof(T).Name.Equals("Cathedra")) return "cathedras";
            else if (typeof(T).Name.Equals("Employee")) return "employees";
            else if (typeof(T).Name.Equals("Direction")) return "directions";
            else if (typeof(T).Name.Equals("Practise")) return "practise_base";

            return "Error";
        }

        #region
        public static List<Level> levels = new List<Level> { Level.User, Level.Admin };

        public enum Level
        {
            User = 0,
            Admin = 1
        }
        #endregion

        public static List<string> Practise_Types = new List<string> { "Учебная", "Производственная" };

    }


    #region Classes

    public class Group
    {
        public string id { get; set; }
        public string groupe { get; set; }
        public string direction { get; set; }
        public string form_study { get; set; }
        public string enroll_year { get; set; }
        public string end_year { get; set; }
    }

    public class Student
    {
        public string id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string groupe { get; set; }
        public string free_study { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Cathedra
    {
        public string id { get; set; }
        public string number { get; set; }
        public string cathedra { get; set; }
        public string phone { get; set; }
        public string id_decan { get; set; }
        public string id_employee { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }

    }

    public class Employee
    {
        public string id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string lvl { get; set; }
    }

    public class Direction
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string id_cathedra { get; set; }
    }

    public class Practise
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string employeer { get; set; }
        public string phone { get; set; }
        public string date_end { get; set; }
    }
    #endregion
}
