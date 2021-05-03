using dNothi.Services.KasaraPatraDashBoardService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraPrapokListViewForm : Form
    {
        public KhosraPrapokListViewForm()
        {
           // attachmentTableLayoutPanel.Controls.Clear();
            InitializeComponent();
           
        }
        
        public PrapakerTalika _prapakerTalika { get; set; }
        public PrapakerTalika prapakerTalika
        {
            get { return _prapakerTalika; }
            set
            {
                _prapakerTalika = value;
                PrapokListRowUserControl.UserName = prapakerTalika.data.receiver.Select(x => x.officer).FirstOrDefault();
                PrapokListRowUserControl.UserDesignation = prapakerTalika.data.receiver.Select(x => x.designation).FirstOrDefault();
                PrapokListRowUserControl.UserOfficeName = prapakerTalika.data.receiver.Select(x => x.office).FirstOrDefault();

                senderListRowUserControl.UserName = prapakerTalika.data.sender.Select(x => x.officer).FirstOrDefault();
                senderListRowUserControl.UserDesignation = prapakerTalika.data.sender.Select(x => x.designation).FirstOrDefault();
                senderListRowUserControl.UserOfficeName = prapakerTalika.data.sender.Select(x => x.office).FirstOrDefault();

                aproverListRowUserControl.UserName = prapakerTalika.data.approver.Select(x => x.officer).FirstOrDefault();
                aproverListRowUserControl.UserDesignation = prapakerTalika.data.approver.Select(x => x.designation).FirstOrDefault();
                aproverListRowUserControl.UserOfficeName = prapakerTalika.data.approver.Select(x => x.office).FirstOrDefault();
            }
        }
        private void KhosraPrapokListViewForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void khosraPrapokListRowUserControl2_Load(object sender, EventArgs e)
        {  //sender
            //var senderListRowUserControl = new KhosraPrapokListRowUserControl();
            //senderListRowUserControl.UserName = prapakerTalika.data.receiver.Select(x => x.officer).FirstOrDefault();
            //senderListRowUserControl.UserDesignation= prapakerTalika.data.receiver.Select(x => x.designation).FirstOrDefault();
            //senderListRowUserControl.UserOfficeName = prapakerTalika.data.receiver.Select(x => x.office).FirstOrDefault();

        }

        private void khosraPrapokListRowUserControl1_Load(object sender, EventArgs e)
        {
            //reciver
            //var reciverListRowUserControl = new KhosraPrapokListRowUserControl();
            //reciverListRowUserControl.UserName = prapakerTalika.data.receiver.Select(x => x.officer).FirstOrDefault();
            //reciverListRowUserControl.UserDesignation = prapakerTalika.data.receiver.Select(x => x.designation).FirstOrDefault();
            //reciverListRowUserControl.UserOfficeName = prapakerTalika.data.receiver.Select(x => x.office).FirstOrDefault();
        }

        private void khosraPrapokListRowUserControl3_Load(object sender, EventArgs e)
        {
            //approver
            //var approverListRowUserControl = new KhosraPrapokListRowUserControl();
            //approverListRowUserControl.UserName = prapakerTalika.data.receiver.Select(x => x.officer).FirstOrDefault();
            //approverListRowUserControl.UserDesignation = prapakerTalika.data.receiver.Select(x => x.designation).FirstOrDefault();
            //approverListRowUserControl.UserOfficeName = prapakerTalika.data.receiver.Select(x => x.office).FirstOrDefault();

        }
    }
}
