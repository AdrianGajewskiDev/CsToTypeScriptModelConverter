using Converter.Core.ErrorHandling;

namespace Converter.Core
{
    public interface IBuilder<T>
    {
        public IBuilder<T> AddConverter();
        public IBuilder<T> AddErrorHandler<TErrorHandler>() where TErrorHandler : ErrorHandler, new();
        public T Build();
    }
}