
using Converter.Core.Values;

namespace Converter.Core.Converter
{
    public interface IPropertyConverter
    {
        void ConvertProperty(CSharpProperty prop, ref string result);
    }
}
