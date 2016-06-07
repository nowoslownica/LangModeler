using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace Common
{
    public class SQLite
    {
        private const string DatabaseName = "Db.sqlite";

        private SQLiteConnection Connection;

        private bool FileExists(string variable)
        {
            if (File.Exists(variable))
            {
                return true;
            }
            return false;
        }

        private bool CreateDb(string variable)
        {
            if (FileExists(variable)) return true;
            SQLiteConnection.CreateFile(DatabaseName);
            if (FileExists(variable)) return true;
            return false;
        }

        private bool ConnectToDb()
        {
            if (!FileExists(DatabaseName))
            {
                CreateDb(DatabaseName);
                Connection =
                    new SQLiteConnection(string.Format("Data Source={0};", DatabaseName));
                return true;
            }
            return false;
        }

        private void ExecuteWriter(SQLiteCommand command)
        {
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
        }

        private SQLiteDataReader ExecuteReader(SQLiteCommand command)
        {
            Connection.Open();
            var result = command.ExecuteReader();
            Connection.Close();
            return result;
        }

        //разобраться с созданием таблиц
        private bool SendWriteRequest(string tableName, string variable, bool toVerify)
        {
            if (ConnectToDb())
            {
                if ((toVerify) && (ShowTable(tableName) != null))
                {
                    SQLiteCommand command =
                        new SQLiteCommand(variable);
                    ExecuteWriter(command);
                    return true;
                }
            }
            return false;
        }

        private SQLiteDataReader SendReadRequest(string tableName, string variable)
        {
            if (ConnectToDb())
            {
                if (ShowTable(tableName) != null)
                {
                    SQLiteCommand command =
                        new SQLiteCommand(variable);
                    return ExecuteReader(command);
                }
            }
            return null;
        }

        public bool CreateTable(string tableName, string colValName)
        {
            var comandToDo = string.Format("CREATE TABLE {0} (id INTEGER PRIMARY KEY, {1} TEXT);", tableName, colValName);
            return SendWriteRequest(tableName, comandToDo, false);
        }

        public SQLiteDataReader ShowTable(string tableName)
        {
            var commandToDo = string.Format("SELECT * FROM {0};", tableName);
            return SendReadRequest(tableName, commandToDo);
        }

        public SQLiteDataReader ShowTable(string tableName, string condition)
        {
            var commandToDo = string.Format("SELECT * FROM {0} WHERE {1};", tableName, condition);
            return SendReadRequest(tableName, commandToDo);
        }

        public bool InsertIntoTable(string tableName, string value)
        {
            var commandToDo = string.Format("INSERT INTO {0} VALUES {1};", tableName, value);
            return SendWriteRequest(tableName, commandToDo, true);
        }

        public bool DeleteFromTable(string tableName, string condition)
        {
            var commandToDo = string.Format("DELETE FROM {0} WHERE {1};", tableName, condition);
            return SendWriteRequest(tableName, commandToDo, true);
        }

    }
}
