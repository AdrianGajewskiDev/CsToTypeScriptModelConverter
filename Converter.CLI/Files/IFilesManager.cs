using System.IO;
using System.Threading.Tasks;

namespace Converter.CLI.Files
{
    internal interface IFilesManager
    {
        FileInfo[] GetFiles(string path, string extension);
        Task<string> ReadCodeAsync(string path);
        Task SaveToFileAsync(string code, string filePath);

    }
}
