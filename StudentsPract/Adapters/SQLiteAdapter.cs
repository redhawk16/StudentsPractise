using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Runtime.CompilerServices;

namespace StudentsPract.Adapters
{
    class SQLiteAdapter
    {
        private static SQLiteConnection connection;
        private static SQLiteCommand command;

        private static string db_name = "database.db";
        private static string db_path = Directory.GetCurrentDirectory() + "\\database\\";

        private static SQLiteAdapter instance;

        public static SQLiteAdapter getInstance()
        {
            if (instance == null)
                instance = new SQLiteAdapter();
            return instance;
        }

        public SQLiteAdapter()
        {
            if (!File.Exists(db_path + db_name))
            {
                createDB(); // Call create database function if db is'nt exists
            }
            else { return; }
        }

        private static void connect(string query = null)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + db_path + db_name + ";Version=3;"); //databse connection
                // if query = null|empty then USE command.CommandText to set the query!
                command = new SQLiteCommand(query, connection); // create sql command using query
                connection.Open(); // open connection to database
                // After open the connection always CLOSE it!
            }
            catch (SQLiteException e) { Console.WriteLine("Ошибка при подключении к БД: " + e); }
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
                    "[groupe] INTEGER NOT NULL," +
                    "[free_study] TEXT NOT NULL," +
                    "[email] TEXT," +
                    "[phone] TEXT," +
                    "FOREIGN KEY([groupe]) REFERENCES [groups]([id])" +
            ")" });
            #endregion

            #region Table: groups
            queries.Add(new string[] { "groups", "CREATE TABLE IF NOT EXISTS [groups] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                    "[groupe] TEXT NOT NULL UNIQUE," +
                    "[direction] INTEGER NOT NULL," +
                    "[form_study] TEXT NOT NULL," +
                    "[enroll_year] TEXT NOT NULL," +
                    "[end_year] TEXT NOT NULL," +
                    "FOREIGN KEY ([direction]) REFERENCES [directions]([id])" +
            ")" });
            #endregion

            #region Table: cathedras
            queries.Add(new string[] { "cathedras", "CREATE TABLE [cathedras] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[number] INTEGER NOT NULL UNIQUE,"+
                    "[cathedra] TEXT NOT NULL UNIQUE,"+
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
                    "FOREIGN KEY([id_cathedra]) REFERENCES [cathedras]([id])" +
            ")" });
            #endregion

            #region Table: employees
            queries.Add(new string[] { "employees", "CREATE TABLE [employees] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[surname] TEXT NOT NULL," +
                    "[name] TEXT NOT NULL," +
                    "[patronymic] TEXT NOT NULL," +
                    "[phone] TEXT," +
                    "[email] TEXT NOT NULL UNIQUE," +
                    "[account] TEXT NOT NULL UNIQUE," +
                    "[lvl] INTEGER NOT NULL" +
            ")" });
            #endregion

            #region Table: practise_base
            queries.Add(new string[] { "practise_base", "CREATE TABLE [practise_base] (" +
                    "[id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[name] TEXT NOT NULL," +
                    "[address] TEXT NOT NULL," +
                    "[employeer] TEXT NOT NULL," +
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

        public static List<List<string>> GetValue(string table_name, string column = "*")
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
                } else { return null; }
            } catch(SQLiteException e) { Console.WriteLine("Ошибка при открытии подключения к БД: " + e); }
            finally { connection.Close(); } // close connection to database

            return result;
        }

        public static void SetValue(string table_name, params string[] values)
        {
            try
            {
                string query = null;

                switch (table_name)
                {
                    case "students":
                        query = $"INSERT INTO [{table_name}]('surname', 'name', 'patronymic', 'groupe', 'free_study', 'email', 'phone') " +
                            $"VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                        break;
                    case "groups":
                        query = $"INSERT INTO [{table_name}]('groupe', 'direction', 'form_study', 'enroll_year', 'end_year') " +
                            $"VALUES(@param1, @param2, @param3, @param4, @param5)";
                        break;
                    case "employees":
                        query = $"INSERT INTO [{table_name}]('surname', 'name', 'patronymic', 'phone', 'email', 'account', 'lvl') " +
                            $"VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                        break;
                    case "cathedras":
                        query = $"INSERT INTO [{table_name}]('number', 'cathedra', 'phone', 'id_decan') " +
                            $"VALUES(@param1, @param2, @param3, @param4)";
                        break;
                    case "directions":
                        query = $"INSERT INTO [{table_name}]('code', 'name', 'id_cathedra') " +
                            $"VALUES(@param1, @param2, @param3)";
                        break;
                    case "practise_base":
                        query = $"INSERT INTO [{table_name}]('name', 'address', 'employeer', 'phone', 'date_end') " +
                            $"VALUES(@param1, @param2, @param3, @param4, @param5)";
                        break;
                    default:
                        break;
                }

                if (query != null || query.Length != 0) connect(query);
                else { Console.WriteLine("Запрос не может быть пустым!"); return; }

                if ((connection.State.ToString()).Equals("Open"))
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        command.Parameters.Add(new SQLiteParameter("@param" + (i + 1), values[i]));
                    }
                    command.ExecuteNonQuery(); // execute query
                }
            } catch (SQLiteException e) { Console.WriteLine("Ошибка: " + e); MessageBox.Show("Ошибка: " + e.Message); } /* TODO: Добавить описание по кодам ошибок */ 
            finally { connection.Close(); } // close connection to database
        }        
        
        public static void ChangeValueById(string table_name, string id, string new_value)
        {
            try {
                string query;
                //(SELECT groupe FROM groups WHERE groups.groupe='{new_value}')
                query = $"UPDATE [{table_name}] SET {new_value} WHERE [id] = '{id}'";
                connect(query);
                if ((connection.State.ToString()).Equals("Open"))
                {
                    command.ExecuteNonQuery(); // execute query
                }
            }
            catch(SQLiteException e) { Console.WriteLine("Ошибка: " + e); }
            finally { connection.Close(); } // close connection to database
        }

        public static bool DeleteRowById(string table_name, string id)
        {
            bool result = false; // return false for success
            try
            {
                string query;

                query = $"DELETE FROM [{table_name}] WHERE [id] = '{id}'";
                connect(query);
                if ((connection.State.ToString()).Equals("Open"))
                {
                    command.ExecuteNonQuery(); // execute query
                }
            }
            catch (SQLiteException e) { Console.WriteLine("Ошибка: " + e); result = true; }
            finally { connection.Close(); } // close connection to database
            return result;
        }
    }
}
