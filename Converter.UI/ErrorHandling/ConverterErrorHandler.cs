using Converter.Core.ErrorHandling;
using System.Windows.Forms;

namespace Converter.UI.ErrorHandling
{
    public class ConverterErrorHandler : ErrorHandler
    {
        public override void Handle()
        {
            MessageBox.Show("Please paste valid C# code", "Invalid C# code", MessageBoxButtons.OK);
        }
    }
}
