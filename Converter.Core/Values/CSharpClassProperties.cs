using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace Converter.Core.Values
{
    public class CSharpClass
    {
        private IList<CSharpProperty> properties;
        private string m_ClassName;

        public string ClassName { get => m_ClassName; }

        public CSharpClass(IEnumerable<ISymbol> symbols, string className)
        {
            properties = new List<CSharpProperty>();
            m_ClassName = className;
            Parse(symbols);
        }

        void Parse(IEnumerable<ISymbol> symbols)
        {
            foreach (var symbol in symbols)
            {
                var property = (IPropertySymbol)symbol;
                string type = property.Type.Name;

                if(property.Type is IArrayTypeSymbol arraySymbolType)
                {
                    type = arraySymbolType.ElementType.Name + "[]";
                }

                properties.Add(new CSharpProperty 
                {
                    Type = type,
                    Value = symbol.Name
                });
            }
        }

        public IList<CSharpProperty> GetProperties() => properties;
    }
}
