namespace Converter.CLI.Files
{
    internal record CodeFile
    {
        public CodeFile(string fileName, string code, string extension)
        {
            this.FileName = fileName;
            this.Code = code;
            this.Extension = extension;
        }

        public string FileName { get; private set; }
        public string Code { get; private set; }
        public string Extension { get; private set; }

        public string FullName { get => string.Concat(FileName, Extension); }

        public void SwapCode(string newCode)
        {
            this.Code = newCode;
        }
    }
}
