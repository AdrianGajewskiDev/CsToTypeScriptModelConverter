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
                var semanticModel = compilation.GetSemanticModel(csCode);

                var type = semanticModel.GetDeclaredSymbol(csCode.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First());
                var baseType = type.BaseType.Name;
                var properties = type.GetMembers().Where(x => x.Kind == SymbolKind.Property);

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

    }
}
