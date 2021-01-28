using Converter.Core.Extensions;
using Converter.Core.Values;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace Converter.Core.Reflection
{
    public static class TypeResolver
    {
        public static event Action HandleError;

        public static CSharpClass Get(string code)
        {
            try
            {

                var csCode = CSharpSyntaxTree.ParseText(code);

                var compilation = CSharpCompilation.Create("Compilation").AddSyntaxTrees(csCode);
                var semanticModel = compilation.GetSemanticModel(csCode, true);

                var type = semanticModel.GetDeclaredSymbol(csCode.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First());
                var baseType = type.BaseType.Name;
                var properties = type.GetMembers().Where(x => x.Kind == SymbolKind.Property || x.Kind == SymbolKind.Field).Select(Parse);

                if (properties.Count() == 0)
                    return null;

                return new CSharpClass(properties, type.Name, baseType);
            }
            catch (Exception ex)
            {
                HandleError?.Invoke();

                return null;
            }
        }
        private static Func<ISymbol, IClassMember> Parse = (s) => 
        {
            switch (s.Kind)
            {
                case SymbolKind.Property: 
                    {
                        var property = (IPropertySymbol)s;

                        if (property.Type is INamedTypeSymbol namedType && namedType.IsGenericType)
                            return ParseGeneric<CSharpProperty>(namedType, property.Name);
                        else if (property.Type is IArrayTypeSymbol arrayType)
                            return new CSharpProperty { Type = arrayType.ElementType.Name + "[]", Value = s.Name };

                        return new CSharpProperty { Type = property.Type.Name, Value = property.Name };
                    }
                case SymbolKind.Field:
                    {
                        var property = (IFieldSymbol)s;

                        if (property.Type is INamedTypeSymbol namedType && namedType.IsGenericType)
                            return ParseGeneric<CSharpField>(namedType, property.Name);

                        return new CSharpField { Type = property.Type.Name, Value = property.Name };
                    }
                default: return null;
            }
        };

        private static T ParseGeneric<T>(INamedTypeSymbol typeSymbol, string propName) where T:IClassMember, new()
        {

            var type = typeSymbol.Name + "<";
            var args = typeSymbol.TypeArguments;
            var argsNames = args.Select(x => x.Name);

            foreach (var name in argsNames)
            {
                type += name.ConvertToTS() + ",";
            }
            type += ">";

            var lastCommaIndex = type.IndexOf(">") - 1;
            type = type.Remove(lastCommaIndex, 1);

            var member = new T();

            member.Type = type;
            member.Value = propName;

            return member;
            
        }
    }
}
