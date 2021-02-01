using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Converter.CLI.Files
{
    internal class FilesManager : IFilesManager
    {
        public FileInfo[] GetFiles(string path, string extension)
        {

            if(string.IsNullOrEmpty(path) || string.IsNullOrEmpty(extension))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var files = new DirectoryInfo(path).GetFiles().Where(x => x.Extension == extension).ToArray();

            return files;
        }

        public async Task<string> ReadCodeAsync(string path)
        {
            string result = string.Empty;

            using var streamReader = new StreamReader(path);

            result = await streamReader.ReadToEndAsync();

            return result;

        }

        public async Task SaveToFileAsync(string code, string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Create);
            using var sw = new StreamWriter(fileStream);

            await sw.WriteAsync(code);
        }
    }
}
