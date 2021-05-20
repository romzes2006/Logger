using System;
using System.IO;
using System.Threading.Tasks;

namespace Logger
{
    public class LogToFile
    {
        private readonly string _path;

        public LogToFile(string path)
        {
            _path = path ?? throw new Exception("Передан пустой путь к файлу логирования");
        }
        public LogToFile()
        {
            _path = "logger.log";
        }

        private async Task WriteToFileAsync(string message)
        {
            try
            {
                await using var file = new StreamWriter(_path, true);
                await file.WriteLineAsync(message);
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Отказано в доступе");
            }
            catch (ArgumentException)
            {
                throw new Exception("Путь к файлу пуст или содержит имя системного устройства (com1, com2 и т. д.)");
            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("Указан недопустимый путь (например, он ведет на несопоставленный диск)");
            }
            catch (ObjectDisposedException)
            {
                throw new Exception("Удалено средство записи потока");
            }
            catch (InvalidOperationException)
            {
                //throw new Exception("Средство записи потока в настоящее время используется предыдущей операцией записи");
                await WriteToFileAsync(message);
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

        public async Task CustomAsync(string type, string message)
        {
            await WriteToFileAsync($"{DateTime.Now:G} [{type}] {message}");
        }

        public async Task LogAsync(LogType type, string message)
        {
            await WriteToFileAsync($"{DateTime.Now:G} [{type.ToString()}] {message}");
        }
    }
}