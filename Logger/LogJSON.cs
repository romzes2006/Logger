using System;

namespace Logger
{
    public class LogJSON
    {
        public DateTime DateTime { get; set; }
        public LogType Type { get; set; }
        public string Message { get; set; }
    }
}