using dNothi.JsonParser.Entity.Nothi;
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
    public partial class ReviewDashBoardContent : UserControl
    {
        public ReviewDashBoardContent()
        {
            InitializeComponent();
            rvwDashBoardContentShare.Visible = false;
        }
        private NothiShaeredByMeRecord _nothiShaeredByMeRecord;
        private string _nothi;
        private string _note;
        private string _noteSubject;
        private string _modifiedDate;
        private string _potroType;
        public string nothi
        {
            get { return _nothi; }
            set { _nothi = value; lbNothi.Text = value; }
        }
        public string note
        {
            get { return _note; }
            set { _note = value; lbNote.Text = value; }
        }
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
        }
        public string modifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; lbModifiedDate.Text = value; }
        }
        public string potroType
        {
            get { return _potroType; }
            set { _potroType = value; lbPotroType.Text = value; }
        }
        public NothiShaeredByMeRecord nothiShaeredByMeRecord
        {
            get { return _nothiShaeredByMeRecord; }
            set { _nothiShaeredByMeRecord = value;
                if (_nothiShaeredByMeRecord!= null)
                {
                    nothi = _nothiShaeredByMeRecord.nothi.nothi_detail.nothi_no + " " + _nothiShaeredByMeRecord.nothi.nothi_detail.nothi_subject;
                    note = string.Concat(_nothiShaeredByMeRecord.nothi.nothi_detail.note_no.ToString().Select(c => (char)('\u09E6' + c - '0'))) + "." + string.Concat(_nothiShaeredByMeRecord.nothi.nothi_detail.onucched_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    noteSubject = _nothiShaeredByMeRecord.nothi.nothi_detail.note_subject;
                    modifiedDate = _nothiShaeredByMeRecord.user.modified;
                    potroType = _nothiShaeredByMeRecord.nothi.type;
                }
            }
        }
        private void ReviewDashBoardContent_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void ReviewDashBoardContent_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            lbNoteSubject.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            lbNothi.ForeColor = Color.FromArgb(78, 165, 254);

        }

        

        private void label10_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            lbNote.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            lbPotroType.ForeColor = Color.FromArgb(78, 165, 254);
        }

        

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            lbNoteSubject.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            lbNothi.ForeColor = Color.FromArgb(63, 66, 84);
        }

        

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            lbNote.ForeColor = Color.FromArgb(63, 66, 84);
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            lbPotroType.ForeColor = Color.FromArgb(63, 66, 84);
        }

        

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            btnShare.IconColor = Color.FromArgb(246, 78, 96);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
            btnShare.IconColor = Color.FromArgb(78, 165, 254);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245);
            btnShowInEditor.IconColor = Color.FromArgb(246, 78, 96);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
            btnShowInEditor.IconColor = Color.FromArgb(78, 165, 254);
        }
        ReviewDashBoardContentShare rvwDashBoardContentShare = UserControlFactory.Create<ReviewDashBoardContentShare>();
        private void btnShare_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ExtraPopUPWindow")
                {
                    BeginInvoke((Action)(() => f.Hide()));
                }

            }
            if (rvwDashBoardContentShare.Visible)
            {
                rvwDashBoardContentShare.Visible = false;
            }
            else
            {
                
                rvwDashBoardContentShare.Visible = true;
                rvwDashBoardContentShare.nothiSharedId = _nothiShaeredByMeRecord.user.shared_nothi_id;
                NextStepControlToForm(rvwDashBoardContentShare);
            }
        }
        public void NextStepControlToForm(Control control)
        {
            Form form = new Form();
            form.TopMost = true;
            form.TopMost = false;
            form.Name = "ExtraPopUPWindow";
            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.AutoSize = true;
            form.ShowInTaskbar = false;

            form.Location = new Point(Cursor.Position.X - control.Width,Cursor.Position.Y);
            control.Location = new System.Drawing.Point(0, 0);
            //form.Size = control.Size;
            form.Height = control.Height;
            form.Width = control.Width;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Height = form.Height;
            form.Controls.Add(control);
            form.Show();
        }

        private void btnShowInEditor_Click(object sender, EventArgs e)
        {
            RvwDashContentShowInEditor rvwDashContentShowInEditor = FormFactory.Create<RvwDashContentShowInEditor>();
            rvwDashContentShowInEditor.Show();
        }

        private void label14_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);
        }
    }
}
