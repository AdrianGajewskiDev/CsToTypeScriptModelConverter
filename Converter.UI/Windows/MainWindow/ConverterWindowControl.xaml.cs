using Converter.UI.Models.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Converter.UI.Windows.MainWindow
{
    /// <summary>
    /// Interaction logic for ConverterWindowControl.
    /// </summary>
    public partial class ConverterWindowControl : UserControl
    {

        private ConverterWindowViewModel viewModel = new ConverterWindowViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterWindowControl"/> class.
        /// </summary>
        public ConverterWindowControl()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CSCode = MainTextBox.Text;
            if (!string.IsNullOrEmpty(viewModel.CSCode))
            {
                viewModel.ConvertCommand.Execute(sender);
                ClearTextbox();
                MainTextBox.Text = viewModel.TSCode;
            }
            else
                System.Windows.MessageBox.Show("Please paste your CSharp code", "Invalid C# code", System.Windows.MessageBoxButton.OK);

        }

        void ClearTextbox() => MainTextBox.Text = string.Empty;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(viewModel.TSCode))
                System.Windows.MessageBox.Show("Cannot save empty file", "Empty code", System.Windows.MessageBoxButton.OK);

        }
    }
}