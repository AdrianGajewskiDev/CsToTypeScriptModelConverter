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

        public string CSCode
        {
            get => m_CSCode;
            set => m_CSCode = value;
        }

        private void Convert()
        {
            
            m_CSCode += "sadsa";
        }
    }
}
