
using Converter.Core.Values;
using System.Text;

namespace Converter.Core.Converter
{
    public interface IPropertyConverter
    {
        void ConvertClassMember(IClassMember prop, StringBuilder stringBuilder);
        void ConvertClassMember(IClassMember prop, string result);
    }
}
