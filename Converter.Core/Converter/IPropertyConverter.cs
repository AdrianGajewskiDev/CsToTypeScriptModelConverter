
using Converter.Core.Values;
using System.Text;

namespace Converter.Core.Converter
{
    public interface IPropertyConverter
    {
        void ConvertProperty(CSharpProperty prop, StringBuilder stringBuilder);
        void ConvertProperty(CSharpProperty prop, string result);
    }
}
