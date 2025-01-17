﻿
namespace ConfigureServiceExample.Services;

public class Log : ILog
{
    string _fileName;
    public Log()
    {
        _fileName = $"{DateTime.UtcNow.ToString("yyyy-dd-MM--HH-mm-ss")}.log";
    }

    public void WriteLog(string logData)
    {
        File.AppendAllText(_fileName, $"{DateTime.UtcNow}: {logData}");
    }
}
