namespace Converter.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertToTS(this string code)
        {
            string convertedType = code;

            string firstValue = string.Empty;
            string secondtValue = string.Empty;

            if (convertedType.Contains("Dictionary"))
            {
                var startIndex = convertedType.IndexOf("<") + 1;
                var endIndex = convertedType.IndexOf(">") - 1;

                if(startIndex != 0 && startIndex != -1 && endIndex != 0 && endIndex != -1)
                {
                    int length = endIndex - startIndex + 1;
                    var substring = convertedType.Substring(startIndex, length);

                    string[] values = substring.Split(',');

                    if (values != null)
                    {
                        convertedType = "Dictionary";
                        firstValue = values[0].ConvertToTS();
                        secondtValue = values[1].ConvertToTS();
                    }
                }
            }

            bool isArrayType = false;

            if (convertedType.Contains("[]"))
            {
                isArrayType = true;
                convertedType = convertedType.Replace("[]", string.Empty);
            }

            switch (convertedType)
            {
                case "String": convertedType = "string"; break;
                case "string": convertedType = "string"; break;
                case "Char": convertedType = "string"; break;
                case "int": convertedType = "number"; break;
                case "Boolean": convertedType = "boolean"; break;
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
                case "DateTime": convertedType = "Date";break;
                case "Dictionary": convertedType = "{[" +$"key: {firstValue}]: {secondtValue}" + "}";break;
            }

            if (isArrayType)
                convertedType += "[]";

            return convertedType;
        }
    }
}
