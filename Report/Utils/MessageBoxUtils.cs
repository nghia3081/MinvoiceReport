using System.Windows.Forms;
namespace MinvoiceReport.Utils
{
    public class MessageBoxUtils
    {
        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
