using System.Windows.Forms;

namespace JustOneProject.WindowsForms.Utils
{
    public static class Messages
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, Constants.WindowsClientTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}