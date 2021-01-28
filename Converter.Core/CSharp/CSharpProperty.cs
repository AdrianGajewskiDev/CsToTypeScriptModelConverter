namespace Converter.Core.Values
{
    public class CSharpProperty : IClassMember
    {
        public CSharpProperty() { }

        public CSharpProperty(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        public string Value { get; set; }
    }
}
