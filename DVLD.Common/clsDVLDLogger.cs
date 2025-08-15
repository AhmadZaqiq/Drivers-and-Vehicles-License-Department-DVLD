using System;
using System.Diagnostics;

public static class clsDVLDLogger
{
    private static readonly string Source = "DVLD Application";
    private static readonly string LogName = "Application";

    static clsDVLDLogger()
    {
        if (!EventLog.SourceExists(Source))
        {
            EventLog.CreateEventSource(Source, LogName);
        }
    }

    public static void LogException(Exception ex)
    {
        string Message = $"Exception Message: {ex.Message}{Environment.NewLine}" +
                         $"Stack Trace: {ex.StackTrace}{Environment.NewLine}" +
                         $"Source: {ex.Source}";

        EventLog.WriteEntry(Source, Message, EventLogEntryType.Warning);
    }
}
