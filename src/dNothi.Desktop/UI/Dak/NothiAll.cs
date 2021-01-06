using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiAll : UserControl
    {
        private int originalWidth;
        private int originalHeight;
        public NothiAll()
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            pnlNewAllNote.Visible = false;
            newAllNoteFlowLayoutPanel.Visible = false;
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }
        private string _nothi;
        private string _shakha;
        private string _desk;
        private int _noteTotal;
        private int _permitted;
        public int _onishponno;
        public int _nishponno;
        public int _archived;
        public string _noteLastDate;
        public int _flag;

        [Category("Custom Props")]
        public string nothi
        {
            get { return _nothi; }
            set { _nothi = value; lbNothi.Text = value; }
        }


        [Category("Custom Props")]
        public string shakha
        {
            get { return _shakha; }
            set { _shakha = value; lbShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string desk
        {
            get { return _desk; }
            set { _desk = value; lbDesk.Text = value; }
        }
        //public int id
        //{
        //    get { return _id; }
        //    set { _id = value;}
        //}
        [Category("Custom Props")]
        public int noteTotal
        {
            get { return _noteTotal; }
            set { _noteTotal = value; lbNoteTotal.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public int permitted
        {
            get { return _permitted; }
            set { _permitted = value; lbPermitted.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public int onishponno
        {
            get { return _onishponno; }
            set { _onishponno = value; lbOnishponno.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public int nishponno
        {
            get { return _nishponno; }
            set { _nishponno = value; lbNishponno.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public int archived
        {
            get { return _archived; }
            set { _archived = value; lbArchived.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public string noteLastDate
        {
            get { return _noteLastDate; }
            set { _noteLastDate = value; lbNoteLastDate.Text = value; }
        }
        [Category("Custom Props")]
        public int flag
        {
            get { return _flag; }
            set { _flag = value;
                if (value == 1)
                {
                    lbDesk.Visible = false; btnNote.Visible = false; btnOnumodito.Visible = false;
                    btnOnishponno.Visible = false; btnNishponno.Visible = false; btnArchive.Visible = false;
                    lbNoteLastDate.Visible = false; iconButton2.Visible = false; iconButton4.Visible = false;
                    iconButton5.Visible = false; iconButton6.Visible = false; iconButton7.Visible = false;
                    lbNoteTotal.Visible = false; lbPermitted.Visible = false; lbOnishponno.Visible = false;
                    lbNishponno.Visible = false; lbArchived.Visible = false;
                    nothiShompadonIcon.Visible = true;
                }
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                //int totalNote = Convert.ToInt32(totalnothi.Substring(9));
                this.Height = 100 + originalHeight;
                this.Width = originalWidth;
                pnlNewAllNote.Visible = true;
                newAllNoteFlowLayoutPanel.Visible = true;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Minus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                pnlNewAllNote.Visible = false;
                newAllNoteFlowLayoutPanel.Visible = false;

                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Plus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
            }
        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
            iconButton3.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                iconButton3.IconColor = Color.FromArgb(27, 197, 189);
                iconButton3.BackColor = Color.FromArgb(201, 247, 245);

            }
        }

        private void nothiShompadonIcon_MouseHover(object sender, EventArgs e)
        {
            nothiShompadonIcon.IconColor = Color.Salmon;
        }

        private void nothiShompadonIcon_MouseLeave(object sender, EventArgs e)
        {
            nothiShompadonIcon.IconColor = Color.FromArgb(54, 153, 255);
        }
    }
}
