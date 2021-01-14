using Converter.Core.ErrorHandling;
using Converter.Core.Extensions;
using Converter.Core.Reflection;
using Converter.Core.Values;
using System;
using System.Text;

namespace Converter.Core.Converter
{
    public class CTSConverter : IConverter
    {

        public string Convert(string csCode)
        {
            var scClass = TypeResolver.Get(csCode);

            if (scClass == null)
                return string.Empty;

            var tsCode = new StringBuilder().Append($@"export class {scClass.ClassName}" + "{ /");

            foreach (var prop in scClass.GetProperties())
            {
               ConvertProperty(prop, tsCode);
            }
            tsCode.Append("}/");

            tsCode = tsCode.Replace("/", Environment.NewLine);
            return tsCode.ToString();

        }

        public void ConvertProperty(CSharpProperty prop, StringBuilder stringBuilder)
        {
            prop.Type = prop.Type.ConvertToTS();

            stringBuilder.Append($"{prop.Value}: {prop.Type} /");
        }

        public void ConvertProperty(CSharpProperty prop, ref string result)
        {
            prop.Type = prop.Type.ConvertToTS();

            result += $"{prop.Value}: {prop.Type} /";
        }

    }
}
