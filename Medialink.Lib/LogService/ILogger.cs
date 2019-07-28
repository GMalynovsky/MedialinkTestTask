namespace MediaLink.Lib.LogService
{
    public interface ILogger
    {
        int Log(string message, LogEntryType type, params int[] p);
    }
}
