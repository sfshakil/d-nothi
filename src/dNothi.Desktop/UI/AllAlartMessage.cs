using dNothi.Desktop.UI.CustomMessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Desktop.UI
{
   public   class AllAlartMessage
    {
        public   void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            // successMessage.Show();
            successMessage.Visible=true;
            var t = Task.Delay(3000);
            t.Wait();
            successMessage.Visible = false;
           // successMessage.Hide();
        }
        public  void ShowAlertMessage(string mulpotroNotSelectErrorMessage)
        {
            UIFormValidationAlertMessageForm alertMessageBox = new UIFormValidationAlertMessageForm();
            alertMessageBox.message = mulpotroNotSelectErrorMessage;
            alertMessageBox.Visible = true;
            var t = Task.Delay(3000);
            t.Wait();
            alertMessageBox.Visible = false;
            // alertMessageBox.ShowDialog();
        }
        public   void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.Visible = true;
            var t = Task.Delay(3000);
            t.Wait();
            successMessage.Visible = false;
            // successMessage.ShowDialog();

        }
    }
}
