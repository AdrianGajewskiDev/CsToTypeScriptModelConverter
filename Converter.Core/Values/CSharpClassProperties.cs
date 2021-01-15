using Converter.Core.Extensions;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Converter.Core.Values
{
    public class CSharpClass
    {
        private IList<CSharpProperty> properties;
        private string m_ClassName;
        private string m_BaseType;

        public string ClassName { get => m_ClassName; }
        public string BaseTypeName { get => m_BaseType; }
        public bool HasBaseType { get => !string.IsNullOrEmpty(m_BaseType); }

        public CSharpClass(IEnumerable<ISymbol> symbols, string className, string baseType)
        {
            properties = new List<CSharpProperty>();
            if (!string.IsNullOrEmpty(baseType) && !baseType.Equals("Object"))
                m_BaseType = baseType;

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
                else if(property.Type is INamedTypeSymbol namedType && namedType.IsGenericType)
                {
                    type = namedType.Name + "<";
                    var args = namedType.TypeArguments;
                    var argsNames = args.Select(x => x.Name);

                    foreach (var name in argsNames)
                    {
                        type += name.ConvertToTS() + ",";
                    }
                    type += ">";

                    var lastCommaIndex = type.IndexOf(">") - 1;
                    type = type.Remove(lastCommaIndex, 1);
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
