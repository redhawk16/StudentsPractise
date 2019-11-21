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
        private SQLiteConnection connection;
        private SQLiteCommand command;

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

        private void connect(string query = null)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + db_path + db_name + ";Version=3;"); //databse connection
                // if query = null|empty then USE command.CommandText to set the query!
                command = new SQLiteCommand(query, connection); // create sql command using query
                connection.Open(); // open connection to database
                // After open the connection always CLOSE it!
            }
            catch (SQLiteException e) { Console.WriteLine("Ошибка при открытии подключения к БД: " + e); }
        }

        private void createDB()
        {
            // TODO: Create function of creation database structure

            #region Tables
            List<string[]> queries = new List<string[]>();

            #region Table: students
            queries.Add(new string[] { "students", "CREATE TABLE IF NOT EXISTS [students] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                    "[surname] TEXT NOT NULL," +
                    "[name] TEXT NOT NULL," +
                    "[patronymic] TEXT NOT NULL," +
                    "[group] TEXT NOT NULL," +
                    "[free_study] TEXT NOT NULL," +
                    "[email] TEXT," +
                    "[phone] TEXT," +
                    "FOREIGN KEY([group]) REFERENCES [groups]([group])" +
            ")" });
            #endregion

            #region Table: groups
            queries.Add(new string[] { "groups", "CREATE TABLE IF NOT EXISTS [groups] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                    "[group] TEXT NOT NULL UNIQUE," +
                    "[direction] TEXT NOT NULL," +
                    "[form_study] TEXT NOT NULL," +
                    "[enroll_year] TEXT NOT NULL," +
                    "[end_year] TEXT NOT NULL," +
                    "FOREIGN KEY ([direction]) REFERENCES [directions]([name])" +
            ")" });
            #endregion

            #region Table: cathedras
            queries.Add(new string[] { "cathedras", "CREATE TABLE [cathedras] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[number] INTEGER NOT NULL UNIQUE,"+
                    "[name] TEXT NOT NULL UNIQUE,"+
                    "[phone] TEXT NOT NULL UNIQUE,"+
                    "[id_decan] INTEGER NOT NULL UNIQUE,"+
                    "FOREIGN KEY([id_decan]) REFERENCES [employees]([id])" +
            ")" });
            #endregion

            #region Table: directions
            queries.Add(new string[] { "directions", "CREATE TABLE [directions] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[code] TEXT NOT NULL UNIQUE," +
                    "[name] TEXT NOT NULL UNIQUE," +
                    "[id_cathedra] INTEGER NOT NULL," +
                    "FOREIGN KEY([id_cathedra]) REFERENCES [cathedras]([number])" +
            ")" });
            #endregion

            #region Table: employees
            queries.Add(new string[] { "employees", "CREATE TABLE [employees] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[surname] TEXT NOT NULL," +
                    "[name] TEXT NOT NULL," +
                    "[patronymic] TEXT NOT NULL," +
                    "[account] TEXT NOT NULL UNIQUE," +
                    "[phone] TEXT" +
                    "[email] TEXT" +
            ")" });
            #endregion

            #region Table: practise_base
            queries.Add(new string[] { "practise_base", "CREATE TABLE [practise_base] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[name] TEXT NOT NULL," +
                    "[address] TEXT NOT NULL," +
                    "[phone] TEXT NOT NULL," +
                    "[date_end]  TEXT NOT NULL" +
            ")" });
            #endregion

            #endregion

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

                    Console.WriteLine("Таблица " + queries[i][0] + " создана!");
                }
                connection.Close(); // close connection to database
            }

        }

        public List<List<string>> GetValue(string table_name, string column = "*")
        {
            List<List<string>> result = new List<List<string>>();
            string query;

            query = $"SELECT " + column + " FROM " + table_name;

            try
            {
                connect(query);
                if ((connection.State.ToString()).Equals("Open"))
                {
                    command.ExecuteNonQuery(); // execute query
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<string> tmp = new List<string>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                tmp.Add(reader[i].ToString());
                                //Console.WriteLine(reader[i].ToString());
                            }
                            result.Add(tmp);
                        }
                    }

                    connection.Close(); // close connection to database
                } else { return null; }
            } catch(SQLiteException e) { Console.WriteLine("Ошибка при открытии подключения к БД: " + e); }

            return result;
        }

        public void SetValue(string table_name, params string[] values)
        {
        }        
        
        public void ChangeValueById(string table_name, string id, string column_name, string new_value)
        {
            try {
                string query;

                query = $"UPDATE [{table_name}] SET [{column_name}] = '{new_value}' WHERE [id] = '{id}'";
                connect(query);
                if ((connection.State.ToString()).Equals("Open"))
                {
                    command.ExecuteNonQuery(); // execute query
                    connection.Close(); // close connection to database
                }
            }
            catch(SQLiteException e) { Console.WriteLine("Ошибка: " + e); }
        }

        public void DeleteRowById(string table_name, string id)
        {
            try
            {
                string query;

                query = $"DELETE FROM [{table_name}] WHERE [id] = '{id}'";
                connect(query);
                if ((connection.State.ToString()).Equals("Open"))
                {
                    command.ExecuteNonQuery(); // execute query
                    connection.Close(); // close connection to database
                }
            }
            catch (SQLiteException e) { Console.WriteLine("Ошибка: " + e); }
        }
    }
}
