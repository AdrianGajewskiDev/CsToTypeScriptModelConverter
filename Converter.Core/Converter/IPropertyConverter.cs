
namespace Converter.Core.Converter
{
    public interface IPropertyConverter
    {
        string ConvertProperty(string prop, out string result);
    }
}
