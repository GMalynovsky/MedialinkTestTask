using System;

namespace MediaLink.Lib.LogService
{
    internal abstract class Logger : ILogger
    {
        public int Log(string message, LogEntryType type, params int[] p)
        {
            try
            {
                switch (type)
                {
                    case LogEntryType.Error:
                        return LogError(message);
                    case LogEntryType.Unknown:
                    case LogEntryType.Event:
                    default:
                        return LogEvent(FormLogEntry(message, p));
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        protected abstract int LogEvent(LogEntry entry);

        protected abstract int LogError(string message);

        protected LogEntry FormLogEntry(string operation, params int[] p)
        {
            return new LogEntry()
            {
                Type = operation,
                A = p != null && p.Length > 0 ? p[0] : 0,
                B = p != null && p.Length > 1 ? p[1] : 0,
                Result = p != null && p.Length > 2 ? p[2] : 0,
                DateTime = DateTime.Now
            };
        }
    }
}
