using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsPract.Adapters;

namespace StudentsPract.Classes
{
    class DBTableHelper
    {
        SQLiteAdapter sqliteAdapter = new SQLiteAdapter();

        public List<Student> GetStudentsTable()
        {
            List<Student> values = new List<Student>();
            List<List<string>> tmp = sqliteAdapter.GetValue("students");

            foreach (List<string> column in tmp)
            {
                values.Add(new Student
                {
                    id = column[0],
                    surname = column[1],
                    name = column[2],
                    patronymic = column[3],
                    group = column[4],
                    free_study = column[5],
                    email = column[6],
                    phone = column[7]
                });
            }

            return values;
        }

        public List<Group> GetGroupsTable()
        {
            List<Group> values = new List<Group>();
            List<List<string>> tmp = sqliteAdapter.GetValue("groups");

            foreach (List<string> column in tmp)
            {
                values.Add(new Group
                {
                    id = column[0],
                    group = column[1],
                    direction = column[2],
                    form_study = column[3],
                    enroll_year = column[4],
                    end_year = column[5]
                });
            }

            return values;
        }
    }


    #region Classes

    class Group
    {
        public string id { get; set; }
        public string group { get; set; }
        public string direction { get; set; }
        public string form_study { get; set; }
        public string enroll_year { get; set; }
        public string end_year { get; set; }
    }

    class Student
    {
        public string id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string group { get; set; }
        public string free_study { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    #endregion
}
