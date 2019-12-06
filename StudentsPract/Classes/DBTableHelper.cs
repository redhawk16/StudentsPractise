using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StudentsPract.Adapters;

namespace StudentsPract.Classes
{
    class DBTableHelper
    {

        /*public List<Student> GetStudentsTable()
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
                    groupe = column[4],
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
                    groupe = column[1],
                    direction = column[2],
                    form_study = column[3],
                    enroll_year = column[4],
                    end_year = column[5]
                });
            }

            return values;
        }*/

    }

    
}
