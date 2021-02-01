namespace Converter.CLI.Files
{
    internal record CodeFile
    {
        public CodeFile(string fileName, string code)
        {
            this.FileName = fileName;
            this.Code = code;
        }

        public string FileName { get; private set; }
        public string Code { get; private set; }

        public void SwapCode(string newCode)
        {
            this.FileName = newCode;
        }
    }
}
