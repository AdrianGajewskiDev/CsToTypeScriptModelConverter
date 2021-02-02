using Converter.Core.Extensions;
using Converter.Core.Helpers;
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

            string template = $"";

            if (scClass.HasBaseType)
                template = $@"export class {scClass.ClassName}" + $" extends {scClass.BaseTypeName}" + "{ /";
            else
                template = $@"export class {scClass.ClassName}" + "{ /";


            var tsCode = new StringBuilder().Append(template);

            foreach (var prop in scClass.GetProperties())
            {
                if (prop.Value == SkippedTypes.EqualityContract)
                    continue;

                ConvertClassMember(prop, tsCode);
            }

            foreach (var field in scClass.GetFields())
            {
                if (field.Value == SkippedTypes.EqualityContract)
                    continue;

                ConvertClassMember(field, tsCode);
            }

            tsCode.Append("}/");

            tsCode = tsCode.Replace("/", Environment.NewLine);
            return tsCode.ToString();

        }

        public void ConvertClassMember(IClassMember prop, StringBuilder stringBuilder)
        {
            prop.Type = prop.Type.ConvertToTS();

            stringBuilder.Append($"{prop.Value}: {prop.Type}; /");
        }

        public void ConvertClassMember(IClassMember prop, string result)
        {
            prop.Type = prop.Type.ConvertToTS();

            result += $"{prop.Value}: {prop.Type}; /";
        }

    }
}
