namespace MediaLink.Lib.LogService
{
    public interface ILocalDBLogger : ILogger
    {
        LogEntry GetLogEntryById(int id);
    }
}
