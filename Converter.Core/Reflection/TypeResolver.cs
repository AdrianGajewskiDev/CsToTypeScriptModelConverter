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
                var properties = type.GetMembers().Select(Parse);

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
                        {

                            var type = namedType.Name + "<";
                            var args = namedType.TypeArguments;
                            var argsNames = args.Select(x => x.Name);

                            foreach (var name in argsNames)
                            {
                                type += name.ConvertToTS() + ",";
                            }
                            type += ">";

                            var lastCommaIndex = type.IndexOf(">") - 1;
                            type = type.Remove(lastCommaIndex, 1);
                            return new CSharpProperty { Type = type, Value = property.Name };
                        }


                        return new CSharpProperty { Type = property.Type.Name, Value = property.Name };
                    }
                case SymbolKind.Field:
                    {
                        var property = (IFieldSymbol)s;

                        return new CSharpField { Type = property.Type.Name, Value = property.Name };
                    }
                case SymbolKind.ArrayType:
                    {
                        var property = (IArrayTypeSymbol)s;

                        return new CSharpProperty { Type = property.ElementType.Name + "[]", Value = property.Name };
                    }
                default: return null;
            }
        };
    }
}
