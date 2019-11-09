using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace StudentsPract.Adapters
{
    public class SQLiteAdapter
    {
        private string db_name = "database.db";
        private string db_path = Directory.GetCurrentDirectory() + "\\database\\";

        public SQLiteAdapter()
        {
            if (!File.Exists(db_path + db_name))
            {
                createDB(); // Call create database function if db is'nt exists
            }
            else { return; }
        }

        private void createDB()
        {
            // TODO: Create function of creation database structure

            List<string[]> queries = new List<string[]>();
            queries.Add(new string[] { "students", "CREATE TABLE IF NOT EXISTS [students] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [name] TEXT)" });
            queries.Add(new string[] { "groups", "CREATE TABLE IF NOT EXISTS [groups] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                    "[group] TEXT NOT NULL UNIQUE," +
                    "[direction] TEXT NOT NULL," +
                    "[year] TEXT NOT NULL," +
                    "[form_study] TEXT NOT NULL," +
                    "FOREIGN KEY ([direction]) REFERENCES [directions]([direction])" +
                    ")" });

            if (!Directory.Exists(db_path)) { Directory.CreateDirectory(db_path); } // create databse directory if not exists
            SQLiteConnection.CreateFile(db_path + db_name); // create database zero-byte file

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + db_path + db_name +";Version=3;")) //databse connection
            {
                SQLiteCommand command = new SQLiteCommand(null, connection); // create sql command using query
                connection.Open(); // open connection to database

                for(int i = 0; i < queries.Count; i++)
                {
                    command.CommandText = queries[i][1]; // prepare query
                    command.ExecuteNonQuery(); // execute query

                    Console.WriteLine("Таблица " + queries[i][0] + "создана!");
                }
                connection.Close(); // close connection to database
            }

        }
    }
}
