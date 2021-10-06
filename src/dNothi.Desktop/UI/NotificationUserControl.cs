using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class NotificationUserControl : UserControl
    {
        public NotificationUserControl()
        {
            InitializeComponent();
            loadNotificationRecords();
        }
        private void loadNotificationRecords()
        {
            var notificationRow = UserControlFactory.Create<NotificationRow>();
            UIDesignCommonMethod.AddRowinTable(notificationViewFLP, notificationRow);
        }
        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name == "ExtraNotificationForm")
                    f.Close();
            }
        }
    }
}
