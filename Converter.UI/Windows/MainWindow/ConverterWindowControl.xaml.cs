using Converter.UI.Models.ViewModels;
using System;
using System.Threading.Tasks;
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
            MainTextBox.TextChanged += TextChangedCallback;
        }

        private void TextChangedCallback(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;

            if (!string.IsNullOrEmpty(textbox.Text))
                return;

            viewModel.Reset();
        }

        private void ConvertCode(object sender, RoutedEventArgs e)
        {
            viewModel.CSCode = MainTextBox.Text;
            ConvertCode(viewModel.CSCode);
        }

        void ClearTextbox() => MainTextBox.Text = string.Empty;

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MainTextBox.Text))
                MessageBox.Show("Cannot save empty file", "Empty code", MessageBoxButton.OK);
            else
                viewModel.SaveFile(MainTextBox.Text);
        }
        private async void SelectFile(object sender, RoutedEventArgs e)
        {
            await viewModel.OpenFileAsync(sender, ConvertCode);
        }

        private void ConvertCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                viewModel.Convert(code);
                MainTextBox.Text = viewModel.TSCode;
            }
            else
                MessageBox.Show("Please paste your CSharp code", "Invalid C# code", MessageBoxButton.OK);

        }
    }
}