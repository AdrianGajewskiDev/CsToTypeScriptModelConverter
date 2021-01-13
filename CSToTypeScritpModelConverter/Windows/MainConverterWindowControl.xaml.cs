namespace CSToTypeScritpModelConverter.Windows
{
    using CSToTypeScritpModelConverter.Windows.Models.ViewModels;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainConverterWindowControl.
    /// </summary>
    public partial class ConverterWindowControl : UserControl
    {
        private ConverterWindowViewModel viewModel = new ConverterWindowViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterWindowControl "/> class.
        /// </summary>
        public ConverterWindowControl()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.CSCode = MainTextBox.Text;
            viewModel.ConvertCommand.Execute(sender);
            ClearTextbox();
            MainTextBox.Text = viewModel.TSCode;
            
        }

        void ClearTextbox() => MainTextBox.Text = string.Empty;
    }
}