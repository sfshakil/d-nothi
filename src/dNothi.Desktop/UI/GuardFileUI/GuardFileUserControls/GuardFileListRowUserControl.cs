using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Services.GuardFile;
using dNothi.Services.GuardFile.Model;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;

namespace dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls
{

    public partial class GuardFileListRowUserControl : UserControl
    {

        public GuardFileListRowUserControl()
        {
            InitializeComponent();
        }

        public List<DakAttachmentDTO> _dakAttachmentDTOs { get; set; }
        public List<DakAttachmentDTO> dakAttachmentDTOs { get { return _dakAttachmentDTOs; } set { _dakAttachmentDTOs = value; } }

        public DakAttachmentDTO _dakAttachmentDTO { get; set; }
        public DakAttachmentDTO dakAttachmentDTO
        {
            get { return _dakAttachmentDTO; }
            set
            {
                _dakAttachmentDTO = value;
            }
        }


        public int _id { get; set; }
        public int _rowId { get; set; }

        public string _name { get; set; }
        public string _type { get; set; }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;

                typeNameLabel.Text = value;


            }

        }
        public string type
        {
            get { return _type; }
            set
            {
                _type = value;

                typeLabel.Text = value;


            }

        }
        public int rowId
        {
            get { return _rowId; }
            set
            {
                _rowId = value;




            }

        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private void Border_Color(object sender, PaintEventArgs e)
        {
            // UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }

        private void Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks delete button")]
        public event EventHandler DeleteButtonClick;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks view button")]
        public event EventHandler ViewButtonClick;


        private void guardFileTableUserControl_viewButtonClick(object sender, EventArgs e)
        {

            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();
            attachmentViewPopUpForm.dakAttachmentDTO = _dakAttachmentDTO;
            attachmentViewPopUpForm.dakAttachmentDTOs = _dakAttachmentDTOs;
            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(_dakAttachmentDTO, _dakAttachmentDTOs); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(_dakAttachmentDTO, _dakAttachmentDTOs); };

            CalPopUpWindow(attachmentViewPopUpForm);
            if (this.ViewButtonClick != null)
                this.ViewButtonClick(sender, e);
        }

        private void guardFileTableUserControl_deleteButtonClick(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি নিশ্চিতভাবে সিদ্ধান্ত টি মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                if (this.DeleteButtonClick != null)
                    this.DeleteButtonClick(sender, e);
            }
        }

        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();
            Screen scr = Screen.FromPoint(this.Location);

            hideform.BackColor = Color.Black;
            hideform.Width = scr.WorkingArea.Width;
            hideform.Height = scr.WorkingArea.Height;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();


        }

        private void Next(DakAttachmentDTO dakAttachmentDTO, List<DakAttachmentDTO> dakAttachmentDTOs)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();

            attachmentViewPopUpForm.dakAttachmentDTOs = dakAttachmentDTOs;


            if (_dakAttachmentDTOs != null)
            {
                for (int i = 0; i <= _dakAttachmentDTOs.Count - 1; i++)
                {
                    if (_dakAttachmentDTOs[i].attachment_id == dakAttachmentDTO.attachment_id)
                    {
                        if (i == _dakAttachmentDTOs.Count - 1)
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = _dakAttachmentDTOs[0];
                        }
                        else
                        {

                            attachmentViewPopUpForm.dakAttachmentDTO = _dakAttachmentDTOs[i + 1];
                        }
                        break;
                    }
                }
            }

            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };

            CalPopUpWindow(attachmentViewPopUpForm);

        }

        private void Previous(DakAttachmentDTO dakAttachmentDTO, List<DakAttachmentDTO> dakAttachmentDTOs)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();

            attachmentViewPopUpForm.dakAttachmentDTOs = dakAttachmentDTOs;

            if (dakAttachmentDTOs != null)
            {
                for (int i = dakAttachmentDTOs.Count - 1; i >= 0; i--)
                {
                    if (dakAttachmentDTOs[i].attachment_id == dakAttachmentDTO.attachment_id)
                    {
                        if (i == 0)
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[_dakAttachmentDTOs.Count - 1];
                        }

                        else
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[i - 1];
                        }
                        break;
                    }
                }
            }

            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(attachmentViewPopUpForm._dakAttachmentDTO, _dakAttachmentDTOs); };

            CalPopUpWindow(attachmentViewPopUpForm);
        }

    }
}
