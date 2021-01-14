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
            prop.Type = ConvertPropertyType(prop.Type);

            stringBuilder.Append($"{prop.Value}: {prop.Type} /");
        }

        public void ConvertProperty(CSharpProperty prop, ref string result)
        {
            prop.Type = ConvertPropertyType(prop.Type);

            result += $"{prop.Value}: {prop.Type} /";
        }

        public string ConvertPropertyType(string type)
        {
            bool isArrayType = false;
            string convertedType = type;

            if (convertedType.Contains("[]"))
            {
                isArrayType = true;
                convertedType = convertedType.Replace("[]", string.Empty);
            }

            switch (convertedType)
            {
                case "String": convertedType = "string"; break;
                case "Char": convertedType = "string"; break;
                case "bool": convertedType = "boolean"; break;
                case "Single": convertedType = "number"; break;
                case "Int32": convertedType = "number"; break;
                case "Decimal": convertedType = "number"; break;
                case "Int16": convertedType = "number"; break;
                case "UInt16": convertedType = "number"; break;
                case "Int64": convertedType = "number"; break;
                case "Double": convertedType = "number"; break;
                case "UInt": convertedType = "number"; break;
                case "UInt64": convertedType = "number"; break;
                case "UInt32": convertedType = "number"; break;
                case "ULong": convertedType = "number"; break;
                case "Byte": convertedType = "number"; break;
                case "SByte": convertedType = "number"; break;
            }

            if (isArrayType)
                convertedType += "[]";

            return convertedType;
        }
    }
}
