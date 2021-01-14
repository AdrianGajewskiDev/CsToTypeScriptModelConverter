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

                var properties = type.GetMembers().Where(x => x.Kind == SymbolKind.Property);

                return new CSharpClass(properties, type.Name);
            }
            catch(Exception ex)
            {

                HandleError?.Invoke();

                return null;
            }
        }
    }
}
