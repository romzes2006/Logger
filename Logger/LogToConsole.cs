using System;

namespace Logger
{
    public class LogToConsole
    {
        private void Log(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        public void LogCustom(string type, string message)
        {
            Log(ConsoleColor.Gray,$"{DateTime.Now:G} [{type}] {message}");
        }

        public void Info(string message)
        {
            Log(ConsoleColor.Blue,$"{DateTime.Now:G} [INFO] {message}");
        }
        public void Success(string message)
        {
            Log(ConsoleColor.Green,$"{DateTime.Now:G} [SUCCESS] {message}");
        }
        public void Warning(string message)
        {
            Log(ConsoleColor.Yellow,$"{DateTime.Now:G} [WARNING] {message}");
        }
        public void Error(string message)
        {
            Log(ConsoleColor.Red,$"{DateTime.Now:G} [ERROR] {message}");
        }
        
        public void LogConsole(LogType type, string message)
        {
            var color = type switch
            {
                LogType.Warning => ConsoleColor.Yellow,
                LogType.Info => ConsoleColor.Blue,
                LogType.Success => ConsoleColor.Green,
                LogType.Error => ConsoleColor.Red,
                _ => ConsoleColor.Gray
            };
            Log(color,$"{DateTime.Now:G} [WARNING] {message}");
        }
    }
}