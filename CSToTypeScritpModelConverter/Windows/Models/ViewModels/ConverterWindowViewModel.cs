using Converter.Core.Reflection;
using CSToTypeScritpModelConverter.Windows.Commands;
using System.Windows.Input;

namespace CSToTypeScritpModelConverter.Windows.Models.ViewModels
{
    public class ConverterWindowViewModel : BaseViewModel
    {
        public ConverterWindowViewModel()
        {
            ConvertCommand = new BaseCommand(Convert);
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
            var type = TypeResolver.Get(m_CSCode);

            foreach (var item in type)
            {
                m_TSCode += item.Name;
            }
        }
    }
}
