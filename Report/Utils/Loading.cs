
using Report.Forms;
using System.Threading;

using System.Windows.Forms;

namespace Report.Utils
{
    public class LoadingUtils
    {
        private delegate void CloseDelegate();

        //The type of form to be displayed as the splash screen.
        private static Loading loadingForm;

        static public void ShowProgress()
        {
            // Make sure it is only launched once.

            if (loadingForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(LoadingUtils.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            loadingForm = new Loading();
            Application.Run(loadingForm);
        }

        static public void HideProgress()
        {
            loadingForm.Invoke(new CloseDelegate(LoadingUtils.CloseForm));
        }
        static private void CloseForm()
        {
            loadingForm.Close();
            loadingForm = null;
        }
    }
}
