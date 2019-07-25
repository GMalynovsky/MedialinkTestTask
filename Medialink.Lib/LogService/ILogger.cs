namespace MediaLink.Lib.LogService
{
    public interface ILogger
    {
        void Log(string message, LogEntryType type);
    }
}
