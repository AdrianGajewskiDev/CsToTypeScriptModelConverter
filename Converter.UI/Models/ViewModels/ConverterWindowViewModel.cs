using Converter.Core;
using Converter.Core.Converter;
using Converter.UI.ErrorHandling;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Converter.UI.Models.ViewModels
{
    public class ConverterWindowViewModel
    {
        private IConverter m_Converter;

        public ConverterWindowViewModel()
        {
            m_Converter = new ConverterBuilder<CTSConverter>()
                .AddConverter()
                .AddErrorHandler<ConverterErrorHandler>()
                .Build();

        }

        private string m_CSCode;
        private string m_TSCode;

        public string CSCode { get => m_CSCode; set => m_CSCode = value; }
        public string TSCode { get => m_TSCode; set => m_TSCode = value; }

        public void Convert(string code)
        {
            TSCode = m_Converter.Convert(code);
        }
        public void Reset()
        {
            CSCode = string.Empty;
            TSCode = string.Empty;
        }
        public void SaveFile(string content)
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
                    sw.Write(content);
                }
                stream.Close();
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Invalid file path", MessageBoxButton.OK);
            }
        }
        public async Task OpenFileAsync(object sender, Action<string> callbackAction)
        {
            var dialog = new OpenFileDialog();

            //just for now dont allow to select multiple file, 
            //TOOD: implement multiselect handling
            dialog.Multiselect = false;
            dialog.DefaultExt = ".cs";
            dialog.ShowDialog();

            string code = string.Empty;

            if (string.IsNullOrEmpty(dialog.FileName))
                return;

            try
            {
                var fullPath = Path.GetFullPath(dialog.FileName);
                code = await ReadFromFileAsync(fullPath);
                callbackAction.Invoke(code);
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Invalid file", MessageBoxButton.OK);
            }
        }
        private async Task<string> ReadFromFileAsync(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(stream))
                {
                    var result = await sr.ReadToEndAsync();
                    return result;
                }
            }
        }
    }
}
