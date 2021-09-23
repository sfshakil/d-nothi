using dNothi.Desktop.UI.OtherModule.GuardFileUserControls;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Utility;
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
    public partial class NothiGaurdFileListRow : UserControl
    {
       public int includedGuardFileCount = 0;
        public NothiGaurdFileListRow()
        {
            InitializeComponent();
            VisibleRow();
        }
        private void VisibleRow()
        {
            if (includedGuardFileCount > 0)
            {
                countPanel.Visible = true;
                countLabel.Text = "গার্ড ফাইলটি মোট যুক্ত করা হয়েছে (" + ConversionMethod.EnglishNumberToBangla(includedGuardFileCount.ToString()) + ") বার";
            }
            else
            {
                countPanel.Visible = false;
            }
        }
        private int _id;
        public int id { get=>_id; set=>_id=value; }
        private string _nameText;
        private string _categoryNameText;
        private string attachmentURL { get; set; }
        public string _attachmentURL { get=> attachmentURL; set { attachmentURL = value; 
                if (value != string.Empty) { btnShow.Visible = true; } else { btnShow.Visible = false; } } }

        public int _office_unit_organogram_id { get; set; }
        public int _designation_id { get; set; }
        public int designation_id
        {
            get { return _designation_id; }
            set
            {
                _designation_id = value;
            }
        }
        public int office_unit_organogram_id
        {

            get
            {

                return _office_unit_organogram_id;
            }

            set
            {
                _office_unit_organogram_id = value;

                if (value != designation_id)

                {
                    btnDelete.Visible = false;

                }
                else
                {
                    btnDelete.Visible = true;
                }

            }
        }

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
            var guardfilereference = FormFactory.Create<UCGuardFileReferenceNothi>();
            guardfilereference.fileAddInWebBrowser(attachmentURL, _nameText);
            guardfilereference.GaurdFileAddButtonOnucced += delegate (object sender1, EventArgs e1) { GaurdFileAddButtonOnucced_ButtonClick(sender1, e1); };
            
            UIDesignCommonMethod.CalPopUpWindow(guardfilereference, this.ParentForm);

        }
        private void GaurdFileAddButtonOnucced_ButtonClick(object sender, EventArgs e)
        {
            GaurdFileRecord gaurdFileRecord = new GaurdFileRecord();
            gaurdFileRecord.id = _id;
            gaurdFileRecord.name_bng = _nameText + " পৃষ্ঠাঃ " + ConversionMethod.EngDigittoBanDigit(sender.ToString());

            GaurdFileAttachment gaurdFileAttachment = new GaurdFileAttachment();
            gaurdFileAttachment.url = attachmentURL;

            gaurdFileRecord.attachment = gaurdFileAttachment;

            if (this.GaurdFileAddButton != null)
            {
                includedGuardFileCount++;
                VisibleRow();
                gaurdFileRecord.includedGuardFileCount = includedGuardFileCount;
                this.GaurdFileAddButton(gaurdFileRecord, e);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
            fileViewWebBrowser.fileAddInWebBrowser(attachmentURL, _nameText);
            UIDesignCommonMethod.CalPopUpWindow(fileViewWebBrowser,this);
        }
        

        public event EventHandler btnDeleteButtonClick;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.btnDeleteButtonClick != null)
                this.btnDeleteButtonClick(sender,e);

        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }
    }
}
