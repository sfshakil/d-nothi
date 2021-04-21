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
                attachmentTableLayoutPanel.Controls.Clear();

                if (prapakerTalika.data != null)
                {


                    if (prapakerTalika.data.approver != null && prapakerTalika.data.approver.Count > 0)
                    {
                        for (int p = 0; p <= prapakerTalika.data.approver.Count - 1; p++)
                        {
                            KhosraPrapokListRowUserControl PrapokListRowUserControl = new KhosraPrapokListRowUserControl();

                            if (p == 0)
                            {
                                PrapokListRowUserControl.UserType = "অনুমোদনকারী";
                            }

                            PrapokListRowUserControl.UserName = prapakerTalika.data.approver[p].officer;
                            PrapokListRowUserControl.UserDesignation = prapakerTalika.data.approver[p].designation;
                            PrapokListRowUserControl.UserOfficeName = prapakerTalika.data.approver[p].office_unit + "," + prapakerTalika.data.receiver[p].office;

                            UIDesignCommonMethod.AddRowinTable(attachmentTableLayoutPanel, PrapokListRowUserControl);

                        }

                    }

                    if (prapakerTalika.data.receiver != null && prapakerTalika.data.receiver.Count > 0)
                    {
                        for (int p=0; p<= prapakerTalika.data.receiver.Count - 1; p++)
                        {
                            KhosraPrapokListRowUserControl PrapokListRowUserControl = new KhosraPrapokListRowUserControl();

                            if (p==0)
                            {
                                PrapokListRowUserControl.UserType = "প্রাপক";
                            }

                            PrapokListRowUserControl.UserName = prapakerTalika.data.receiver[p].officer;
                            PrapokListRowUserControl.UserDesignation = prapakerTalika.data.receiver[p].designation;
                            PrapokListRowUserControl.UserOfficeName = prapakerTalika.data.receiver[p].office_unit +","+ prapakerTalika.data.receiver[p].office;

                            UIDesignCommonMethod.AddRowinTable(attachmentTableLayoutPanel, PrapokListRowUserControl);

                        }

                    }
                    if (prapakerTalika.data.sender != null && prapakerTalika.data.sender.Count > 0)
                    {
                        for (int p = 0; p <= prapakerTalika.data.sender.Count - 1; p++)
                        {
                            KhosraPrapokListRowUserControl PrapokListRowUserControl = new KhosraPrapokListRowUserControl();

                            if (p == 0)
                            {
                                PrapokListRowUserControl.UserType = "প্রেরক";
                            }

                            PrapokListRowUserControl.UserName = prapakerTalika.data.sender[p].officer;
                            PrapokListRowUserControl.UserDesignation = prapakerTalika.data.sender[p].designation;
                            PrapokListRowUserControl.UserOfficeName = prapakerTalika.data.sender[p].office_unit + "," + prapakerTalika.data.sender[p].office;

                            UIDesignCommonMethod.AddRowinTable(attachmentTableLayoutPanel, PrapokListRowUserControl);

                        }

                    }
                    
                    if (prapakerTalika.data.attention != null && prapakerTalika.data.attention.Count > 0)
                    {
                        for (int p = 0; p <= prapakerTalika.data.attention.Count - 1; p++)
                        {
                            KhosraPrapokListRowUserControl PrapokListRowUserControl = new KhosraPrapokListRowUserControl();

                            if (p == 0)
                            {
                                PrapokListRowUserControl.UserType = "দৃষ্টি আকর্ষণ";
                            }

                            PrapokListRowUserControl.UserName = prapakerTalika.data.attention[p].officer;
                            PrapokListRowUserControl.UserDesignation = prapakerTalika.data.attention[p].designation;
                            PrapokListRowUserControl.UserOfficeName = prapakerTalika.data.attention[p].office_unit + "," + prapakerTalika.data.attention[p].office;

                            UIDesignCommonMethod.AddRowinTable(attachmentTableLayoutPanel, PrapokListRowUserControl);

                        }

                    }
                    if (prapakerTalika.data.onulipi != null && prapakerTalika.data.onulipi.Count > 0)
                    {
                        for (int p = 0; p <= prapakerTalika.data.onulipi.Count - 1; p++)
                        {
                            KhosraPrapokListRowUserControl PrapokListRowUserControl = new KhosraPrapokListRowUserControl();

                            if (p == 0)
                            {
                                PrapokListRowUserControl.UserType = "অনুলিপি";
                            }

                            PrapokListRowUserControl.UserName = prapakerTalika.data.onulipi[p].officer;
                            PrapokListRowUserControl.UserDesignation = prapakerTalika.data.onulipi[p].designation;
                            PrapokListRowUserControl.UserOfficeName = prapakerTalika.data.onulipi[p].office_unit + "," + prapakerTalika.data.onulipi[p].office;

                            UIDesignCommonMethod.AddRowinTable(attachmentTableLayoutPanel, PrapokListRowUserControl);

                        }

                    }
                    if (prapakerTalika.data.drafter != null && prapakerTalika.data.drafter.Count > 0)
                    {
                        for (int p = 0; p <= prapakerTalika.data.drafter.Count - 1; p++)
                        {
                            KhosraPrapokListRowUserControl PrapokListRowUserControl = new KhosraPrapokListRowUserControl();

                            if (p == 0)
                            {
                                PrapokListRowUserControl.UserType = "খসড়া";
                            }

                            PrapokListRowUserControl.UserName = prapakerTalika.data.drafter[p].officer;
                            PrapokListRowUserControl.UserDesignation = prapakerTalika.data.drafter[p].designation;
                            PrapokListRowUserControl.UserOfficeName = prapakerTalika.data.drafter[p].office_unit + "," + prapakerTalika.data.drafter[p].office;

                            UIDesignCommonMethod.AddRowinTable(attachmentTableLayoutPanel, PrapokListRowUserControl);

                        }

                    }


                   
                }
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
