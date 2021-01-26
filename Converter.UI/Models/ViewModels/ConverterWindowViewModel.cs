using Converter.Core;
using Converter.Core.Converter;
using Converter.UI.Windows.Commands;
using System.Windows.Input;

namespace Converter.UI.Models.ViewModels
{
    public class ConverterWindowViewModel
    {
        private IConverter m_Converter;

        public ConverterWindowViewModel()
        {
            ConvertCommand = new BaseCommand(Convert);
            m_Converter = new ConverterBuilder()
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
