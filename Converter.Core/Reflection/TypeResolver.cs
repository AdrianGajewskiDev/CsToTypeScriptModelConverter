using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Converter.Core.Reflection
{
    public static class TypeResolver
    {
        public static IEnumerable<ISymbol> Get(string code)
        {
            var csCode = CSharpSyntaxTree.ParseText(code);

            var compilation = CSharpCompilation.Create("Compilation").AddSyntaxTrees(csCode);
            var semanticModel = compilation.GetSemanticModel(csCode);
            
            var type = semanticModel.GetDeclaredSymbol(csCode.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First());

            var properties = type.GetMembers().Where(x => x.Kind == SymbolKind.Property);

            return properties;
        }
    }
}
