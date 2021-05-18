using System;
using System.IO;
using System.Threading.Tasks;

namespace Logger
{
    public class LogToFile
    {
        private string _path;

        public LogToFile(string path)
        {
            _path = path;
        }
        public LogToFile()
        {
            _path = "log.log";
        }

        private async Task WriteToFileAsync(string message)
        {
            using (var file = new StreamWriter(_path, true))
            {
                await file.WriteLineAsync(message);
            }
        }

        public async Task InfoAsync(string message)
        {
            await WriteToFileAsync($"{DateTime.Now:G} [INFO] {message}");
        }
        
        public async Task SuccessAsync(string message)
        {
            await WriteToFileAsync($"{DateTime.Now:G} [SUCCESS] {message}");
        }
        
        public async Task ErrorAsync(string message)
        {
            await WriteToFileAsync($"{DateTime.Now:G} [ERROR] {message}");
        }

        public async Task WarningAsync(string message)
        {
            await WriteToFileAsync($"{DateTime.Now:G} [WARNING] {message}");
        }
    }
}