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
    public partial class NothiInbox : UserControl
    {
        public NothiInbox()
        {
            InitializeComponent();
        }
        private string _nothi;
        private string _shakha;
        private string _totalnothi;
        private string _lastdate;

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
        public string totalnothi
        {
            get { return _totalnothi; }
            set { _totalnothi = value; lbTotalNothi.Text = value; }
        }

        [Category("Custom Props")]
        public string lastdate
        {
            get { return _lastdate; }
            set { _lastdate = value; lbNoteLastDate.Text = value; }
        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
            iconButton3.BackColor = Color.FromArgb(27, 197, 189);
        }
        

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Minus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);

            }
            else
            {
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Plus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
            }
            
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                iconButton3.IconColor = Color.FromArgb(27, 197, 189);
                iconButton3.BackColor = Color.FromArgb(201, 247, 245);

            }
            
        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            if (pnlNewAllNote.Visible == true && newAllNoteFlowLayoutPanel.Visible == true)
            {
                pnlNewAllNote.Visible = false;
                newAllNoteFlowLayoutPanel.Visible = false;
            }
            else
            {
                pnlNewAllNote.Visible = true;
                newAllNoteFlowLayoutPanel.Visible = true;
            }
        }
    }
}
