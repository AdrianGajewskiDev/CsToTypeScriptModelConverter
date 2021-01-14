using Converter.Core;
using Converter.Core.Converter;
using CSToTypeScritpModelConverter.ErrorHandling;
using CSToTypeScritpModelConverter.Windows.Commands;
using System.Windows.Input;

namespace CSToTypeScritpModelConverter.Windows.Models.ViewModels
{
    public class ConverterWindowViewModel : BaseViewModel
    {
        private IConverter m_Converter;

        public ConverterWindowViewModel()
        {
            ConvertCommand = new BaseCommand(Convert);
            m_Converter = new ConverterBuilder()
                .AddErrorHandler<ConverterErrorHandler>()
                .AddConverter<CTSConverter>()
                .Build();
        }


        public ICommand ConvertCommand;

        private string m_CSCode;
        private string m_TSCode;


        public string CSCode
        {
            get => m_CSCode;
            set => m_CSCode = value;
        }
        public string TSCode { get => m_TSCode; set => m_TSCode = value; }

        private void Convert()
        {
            TSCode = m_Converter.Convert(m_CSCode);
        }
    }
}
