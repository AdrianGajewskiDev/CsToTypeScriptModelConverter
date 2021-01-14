namespace Converter.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertToTS(this string code)
        {
            bool isArrayType = false;
            string convertedType = code;

            if (convertedType.Contains("[]"))
            {
                isArrayType = true;
                convertedType = convertedType.Replace("[]", string.Empty);
            }

            switch (convertedType)
            {
                case "String": convertedType = "string"; break;
                case "Char": convertedType = "string"; break;
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
            }

            if (isArrayType)
                convertedType += "[]";

            return convertedType;
        }
    }
}
