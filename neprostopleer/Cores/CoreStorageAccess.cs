﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;

namespace neprostopleer.Cores
{
    class CoreStorageAccess : IDisposable
    {
        private readonly string DATABASE_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "neprostopleer.sqlite3");
        private SQLiteConnection _connection;

        /*
         * There's no need to call this method directly - Database will be initialized on first call,
         * however, you may manually initialize database when program is idling
         */
        public void InitializeDatabaseAccess()
        {
            if (_connection == null)
            {
                DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");
                _connection = (SQLiteConnection)fact.CreateConnection();
                _connection.ConnectionString = "Data Source=" + DATABASE_LOCATION;
                _connection.Open();
                SQLiteCommand createCommand = new SQLiteCommand(_connection);
                createCommand.CommandText = @"CREATE TABLE IF NOT EXISTS tracks('ID' TEXT NOT NULL, 'STATE' TEXT, 'DISKLOCATION' TEXT, 'FETCHTIME' INTEGER)";
                createCommand.ExecuteNonQuery();
            }
        }
        public SQLiteCommand GetCommand(string query)
        {
            if (_connection == null)
                InitializeDatabaseAccess();
            SQLiteCommand fetchcommand = new SQLiteCommand(_connection);

            fetchcommand.CommandText = query;
            return fetchcommand;
        }


        protected void Finalize()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Close();
        }

    }
}
