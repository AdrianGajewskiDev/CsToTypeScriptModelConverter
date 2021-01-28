using Converter.Core;
using Converter.Core.Converter;
using Converter.UI.ErrorHandling;
using Converter.UI.Windows.Commands;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Converter.UI.Models.ViewModels
{
    public class ConverterWindowViewModel
    {
        private IConverter m_Converter;

        public ConverterWindowViewModel()
        {
            ConvertCommand = new BaseCommand(Convert);
            m_Converter = new ConverterBuilder<CTSConverter>()
                .AddConverter()
                .AddErrorHandler<ConverterErrorHandler>()
                .Build();

        }


        public ICommand ConvertCommand;

        private string m_CSCode;
        private string m_TSCode;

        public string CSCode { get => m_CSCode; set => m_CSCode = value; }
        public string TSCode { get => m_TSCode; set => m_TSCode = value; }

        private void Convert()
        {
            TSCode = m_Converter.Convert(m_CSCode);
        }

        public void SaveFile()
        {
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = ".ts";
            dialog.AddExtension = true;
            dialog.ShowDialog();

            try
            {
                var fileName = Path.GetFullPath(dialog.FileName);
                var stream = new FileStream(fileName, FileMode.Create);

                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(m_TSCode);
                }
                stream.Close();
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Invalid file path", MessageBoxButton.OK);
            }
        }
    }
}
