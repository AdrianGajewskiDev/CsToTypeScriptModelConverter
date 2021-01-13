using Converter.Core.Reflection;
using Converter.Core.Values;
using System;

namespace Converter.Core.Converter
{
    public class CTSConverter : IConverter
    {

        public string Convert(string csCode)
        {
            var scClass = TypeResolver.Get(csCode);
            string tsCode = $@"export class {scClass.ClassName}" + "{ /";

            foreach (var prop in scClass.GetProperties())
            {
               ConvertProperty(prop, ref tsCode);
            }
            tsCode += "}";

            tsCode = tsCode.Replace("/", Environment.NewLine);
            return tsCode;

        }

        public void ConvertProperty(CSharpProperty prop, ref string result)
        {
            result += $"{prop.Value}: {prop.Type} /";
        }
    }
}
