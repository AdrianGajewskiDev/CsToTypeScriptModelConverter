using Converter.CLI.Files;

namespace Converter.CLI.Factories
{
    internal static class FilesManagerFactory
    {
        public static IFilesManager Create() => new FilesManager();
    }
}
