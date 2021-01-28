using System.Collections.Generic;

namespace Converter.Core.Values
{
    public class CSharpClass
    {
        private IList<CSharpProperty> properties;
        private IList<CSharpField> fields;
        private string m_ClassName;
        private string m_BaseType;

        public string ClassName { get => m_ClassName; }
        public string BaseTypeName { get => m_BaseType; }
        public bool HasBaseType { get => !string.IsNullOrEmpty(m_BaseType); }

        public CSharpClass(IEnumerable<IClassMember> symbols, string className, string baseType)
        {
            properties = new List<CSharpProperty>();
            fields = new List<CSharpField>();

            if (!string.IsNullOrEmpty(baseType) && !baseType.Equals("Object"))
                m_BaseType = baseType;

            m_ClassName = className;
            Parse(symbols);
        }

        void Parse(IEnumerable<IClassMember> members)
        {
            foreach (var member in members)
            {
                if (member.GetType() == typeof(CSharpField))
                    fields.Add(new CSharpField(member.Type, member.Value));
                else if(member.GetType() == typeof(CSharpProperty))
                    properties.Add(new CSharpProperty(member.Type, member.Value));
            }
        }

        public IList<CSharpProperty> GetProperties() => properties;
        public IList<CSharpField> GetFields() => fields;
    }
}
