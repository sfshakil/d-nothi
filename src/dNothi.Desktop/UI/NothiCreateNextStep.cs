using dNothi.Desktop.UI.Dak;
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

namespace dNothi.Desktop.UI
{
    public partial class NothiCreateNextStep : Form
    {
        public NothiCreateNextStep()
        {
            InitializeComponent();
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
        NothiCreateDTO _nothiCreate = new NothiCreateDTO();
        public void loadNewNothiInfo(NothiCreateDTO newNothiCreate)
        {
            _nothiCreate = newNothiCreate;
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            { BeginInvoke((Action)(() => f.Hide())); }
            var form = FormFactory.Create<Nothi>();
            form.ForceLoadNothiALL();
            //form.Visible = true;
            //form.BringToFront();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnYES_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            //form.ShowDialog();

            NothiListRecordsDTO nothiListRecordsDTO = new NothiListRecordsDTO();
            nothiListRecordsDTO.id = _nothiCreate.id;
            nothiListRecordsDTO.office_id = _nothiCreate.office_id;
            nothiListRecordsDTO.office_name = _nothiCreate.office_name;
            nothiListRecordsDTO.office_unit_id = _nothiCreate.office_unit_id;
            nothiListRecordsDTO.office_unit_name = _nothiCreate.office_unit_name;
            nothiListRecordsDTO.office_unit_organogram_id = _nothiCreate.office_unit_organogram_id;
            nothiListRecordsDTO.office_designation_name = _nothiCreate.office_designation_name;
            nothiListRecordsDTO.nothi_no = _nothiCreate.nothi_no;
            nothiListRecordsDTO.subject = _nothiCreate.subject;
            nothiListRecordsDTO.nothi_class = _nothiCreate.nothi_class;

            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiListRecordsDTO;
            form.GetNothiInboxRecords(nothiListRecordsDTO);
            form.SuccessfullyOnumodonSaveButton += delegate (object saveOnumodonButtonSender, EventArgs saveOnumodonButtonEvent) {
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide())); }
                var form1 = FormFactory.Create<Nothi>();
                form1.ForceLoadNothiALL();
                BeginInvoke((Action)(() => form1.ShowDialog()));
                form1.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
            };

            CalPopUpWindow(form);
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
    }
}
