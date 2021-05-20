using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logger
{
    public class LogToJSON
    {
        //TODO Переделать!
        private List<LogJSON> _logs;
        private string _path;

        public LogToJSON(string path)
        {
            _path = path ?? throw new Exception("Передан пустой путь к файлу логирования");
            _logs = new List<LogJSON>();
        }

        private async Task WriteToJson()
        {
            await using var file = new FileStream(_path, FileMode.Truncate);
            await JsonSerializer.SerializeAsync(file, _logs);
        }

        public async Task Log(LogType type, string message)
        {
            var log = new LogJSON
            {
                DateTime = DateTime.Now,
                Type = type,
                Message = message
            };
            _logs.Add(log);
            await WriteToJson();
        }

        public async Task Info(string message)
        {
            await Log(LogType.Info, message);
        }
        
        public async Task Success(string message)
        {
            await Log(LogType.Success, message);
        }
        
        public async Task Warning(string message)
        {
            await Log(LogType.Warning, message);
        }
        
        public async Task Error(string message)
        {
            await Log(LogType.Error, message);
        }
    }
}