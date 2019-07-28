using Dapper;
using System;
using System.Data.SqlClient;

namespace MediaLink.Lib.LogService
{
    internal class LocalDBLogger : Logger, ILocalDBLogger
    {
        #region Consts

        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        private const string INSERT_ERROR_SQL = "INSERT INTO LogError (Message, DateTime) OUTPUT INSERTED.[Id] Values (@Message, @DateTime);";
        private const string INSERT_EVENT_SQL = "INSERT INTO LogEntry (Type, A, B, Result, DateTime) OUTPUT INSERTED.[Id] Values (@Type, @A, @B, @Result, @DateTime);";
        private const string SELECT_EVENT_SQL = "SELECT * FROM LogEntry WHERE Id = @Id;";

        #endregion Consts

        protected override int LogError(string message)
        {
            int id = -1;

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                id = connection.QuerySingle<int>(INSERT_ERROR_SQL, new { Message = message, DateTime = DateTime.Now });

                Console.WriteLine("Inserted row id: " + id);
            }

            return id;
        }

        protected override int LogEvent(LogEntry entry)
        {
            int id = -1;

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                id = connection.QuerySingle<int>(INSERT_EVENT_SQL, entry);

                Console.WriteLine("Inserted row id: " + id);
            }

            return id;
        }

        public LogEntry GetLogEntryById(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var logEntry = connection.QueryFirst<LogEntry>(SELECT_EVENT_SQL, new LogEntry{ Id = id });

                return logEntry;
            }
        }
    }
}
