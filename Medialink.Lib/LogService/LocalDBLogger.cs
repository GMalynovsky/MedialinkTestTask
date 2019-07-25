using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace MediaLink.Lib.LogService
{
    class LocalDBLogger : ILocalDBLogger
    {
        public void Log(string message, LogEntryType type)
        {
            try
            {
                switch (type)
                {
                    case LogEntryType.Error:
                        LogError(message);
                        break;
                    case LogEntryType.Unknown:
                    case LogEntryType.Event:
                    default:
                        LogEvent(message);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void LogError(string message)
        {
            Debug.WriteLine(message);
        }

        void LogEvent(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
