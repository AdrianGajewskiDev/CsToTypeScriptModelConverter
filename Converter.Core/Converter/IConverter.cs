using Converter.Core.ErrorHandling;

namespace Converter.Core.Converter
{
    public interface IConverter : IPropertyConverter
    {
        string Convert(string csCode);
    }
}
