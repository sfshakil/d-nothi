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
    public partial class Potrojari : UserControl
    {
        public Potrojari()
        {
            InitializeComponent();
        }
        public static string Base64Decode1(string base64EncodedData)
        {
            string decodedString = base64EncodedData;
            try
            {
                byte[] data = Convert.FromBase64String(decodedString);
                decodedString = Encoding.UTF8.GetString(data);
                return decodedString;
            }
            catch
            {
                decodedString = decodedString.Replace('-', '+').Replace('_', '/').Replace(',', '=').Replace("&quot;", "");
                byte[] data = Convert.FromBase64String(decodedString);
                decodedString = Encoding.UTF8.GetString(data);// &quot;
                return decodedString;
            }
        } 
        public void loadPotrojariBrowser(string encodeData)
        {
            potrojariWeBrowser.DocumentText = encodeData;
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            //hideform.Size = this.Size;
            hideform.Height = 729;
            hideform.Width = 1366;
            hideform.Opacity = .4;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        public Form AttachSharokNoControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Location = new System.Drawing.Point(100, 250);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        private void btnPotrojari_Click(object sender, EventArgs e)
        {
            ChangeSharokNumber form = new ChangeSharokNumber();
            var nothiNoteMovementListform = AttachSharokNoControlToForm(form);
            CalPopUpWindow(nothiNoteMovementListform);
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Note")
                    f.Close();
            }
        }

        public string _pageSize;
        public string _pageLayout;
        public string _topMargin;
        public string _bottomMargin;
        public string _rightMargin;
        public string _leftMargin;

        public event EventHandler PotrojariButtonClick;
        private void btnPotrojari_Click_1(object sender, EventArgs e)
        {
            if(this.PotrojariButtonClick != null)
            {
                _pageLayout = pageLayoutType.Text;
                _pageSize = pageSize.Text;
                _topMargin = topMargin.Text;
                _bottomMargin = bottomMargin.Text;
                _rightMargin = rightMargin.Text;
                _leftMargin = leftMargin.Text;


                this.PotrojariButtonClick(sender, e);

                this.Parent.Hide();
            }
        }
    }
}
