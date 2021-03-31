using dNothi.Desktop.UI.CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class PotrojariGroupContent : UserControl
    {
        public PotrojariGroupContent()
        {
            InitializeComponent();
            rvwDashBoardContentShare.Visible = false;
        }

        private void detailsPanel_MouseHover(object sender, EventArgs e)
        {
            lbDetails.ForeColor = Color.FromArgb(78, 165, 254);
            this.BackColor = Color.FromArgb(245,245,245);
        }

        private void detailsPanel_MouseLeave(object sender, EventArgs e)
        {
            lbDetails.ForeColor = Color.FromArgb(63, 66, 84);
            this.BackColor = Color.FromArgb(250, 250, 250);
        }
        public event EventHandler PotrojariEditButtonClick;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.PotrojariEditButtonClick != null)
                this.PotrojariEditButtonClick(sender, e);
        }
        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "আপনি কি মুছে ফেলতে চান?";
            //string title = "আপনি কি নথি ধরনটি মুছে ফেলতে চান?";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);
            if (conditonBoxForm.Yes)
            {
                SuccessMessage("মুছে ফেলা হয়েছে।");
            }
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            btnEdit.IconColor = Color.Red;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.IconColor = Color.FromArgb(78, 165, 254); 
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.IconColor = Color.Red;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.IconColor = Color.FromArgb(78, 165, 254);
        }
        ReviewDashBoardContentShare rvwDashBoardContentShare = new ReviewDashBoardContentShare();
        private void btnTotalPerson_Click(object sender, EventArgs e)
        {
            if (rvwDashBoardContentShare.Visible)
            {
                rvwDashBoardContentShare.Visible = false;
            }
            else
            {
                Controls.Add(rvwDashBoardContentShare);
                rvwDashBoardContentShare.Location = new Point(430, 56);
                rvwDashBoardContentShare.Visible = true;
                rvwDashBoardContentShare.BringToFront();
            }
        
        }
    }
}
