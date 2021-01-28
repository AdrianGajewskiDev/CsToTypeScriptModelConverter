namespace Converter.Core.Values
{
    public class CSharpField : IClassMember
    {
        public CSharpField() { }

        public CSharpField(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        public string Value { get; set; }
    }
}
