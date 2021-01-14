using Converter.Core.Converter;
using Converter.Core.ErrorHandling;
using Converter.Core.Reflection;

namespace Converter.Core
{
    public class ConverterBuilder
    {
        private IConverter m_Converter;

        public ConverterBuilder AddErrorHandler<T>() where T:ErrorHandler, new()
        {
            var handler = new T();

            TypeResolver.HandleError += handler.Handle;

            return this;
        }

        public ConverterBuilder AddConverter<T>() where T: IConverter, new()
        {
            m_Converter = new T();

            return this;
        }

        public IConverter Build() => m_Converter;

    }
}
