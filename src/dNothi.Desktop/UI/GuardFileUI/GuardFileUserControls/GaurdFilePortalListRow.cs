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
    public partial class GaurdFilePortalListRow : UserControl
    {
        public GaurdFilePortalListRow()
        {
            InitializeComponent();
        }
        private string _nameText;
        private string _categoryNameText;
        
        public string attachmentURL;

        private int _id;
        public int id { get => _id; set => _id = value; }
        private int _layerId;
        public int layerId { get => _layerId; set => _layerId = value; }
        private string _link;
        public string link { get => _link; set => _link = value; }
        private string _subdomain;
        public string subdomain { get => _subdomain; set => _subdomain = value; }
         

       [Category("Custom Props")]
        public string nameText
        {
            get { return _nameText; }
            set { _nameText = value; lbname_bng.Text = value; }
        }
        public string categoryNameText
        {
            get { return _categoryNameText; }
            set { _categoryNameText = value; lbguard_file_category_name_bng.Text = value; }
        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        public event EventHandler GaurdFileAddButton;
        private void btnGaurdFileAdd_Click(object sender, EventArgs e)
        {
            if (this.GaurdFileAddButton != null)
                this.GaurdFileAddButton(sender, e);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
            fileViewWebBrowser.fileAddInWebBrowser(attachmentURL, _nameText);
            CalPopUpWindow(fileViewWebBrowser);
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }

      

        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }
    }
}
