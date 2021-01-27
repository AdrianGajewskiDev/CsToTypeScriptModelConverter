using Converter.Core.Converter;
using Converter.Core.ErrorHandling;
using Converter.Core.Reflection;

namespace Converter.Core
{
    public class ConverterBuilder<TConverter> : IBuilder<TConverter> where TConverter : IConverter, new()
    {
        private IConverter m_Converter;

        public IBuilder<TConverter> AddConverter() 
        {
            m_Converter = new TConverter();

            return this;
        }

        public IBuilder<TConverter> AddErrorHandler<TErrorHandler>() where TErrorHandler : ErrorHandler, new()
        {
            TypeResolver.HandleError += new TErrorHandler().Handle;

            return this;
        }

        public TConverter Build() => (TConverter)m_Converter;
    }
}
