using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
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
    public partial class DakBoxSharingForm : Form
    {
        IDesignationSealService _designationSealService { get; set; }
        IUserService _userService { get; set; }
        public DakBoxSharingForm(IDesignationSealService designationSealService, IUserService userService)
        {
            _designationSealService = designationSealService;
            _userService = userService;
            InitializeComponent();
            DakBoxSharedOfficerRowUserControl dakBoxSharedOfficerRowUserControl = new DakBoxSharedOfficerRowUserControl();
            dakBoxSharedOfficerRowUserControl.Dock = DockStyle.Top;

            int row = officerTableLayoutPanel.RowCount++;

            officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            if (row == 1)
            {
                row = officerTableLayoutPanel.RowCount++;
                officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            }
            officerTableLayoutPanel.Controls.Add(dakBoxSharedOfficerRowUserControl, 0, row);
            
            officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            officerTableLayoutPanel.Controls.Add(dakBoxSharedOfficerRowUserControl, 0, row+1);


        }
        
        private void DakBoxSharingForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = scr.WorkingArea.Height;
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

        private void dakBoxSharedOfficerRowUserControl2_Load(object sender, EventArgs e)
        {

        }

        private void BorderTableLayoutColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);

        }

        private void BorderTableLayoutColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);

        }

        private void crossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void searchOfficerRightButton_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightListBox_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void searchOfficerRightListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }

        private void searchOfficerRightXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void prerokBachaiButton_Click(object sender, EventArgs e)
        {

        }

        private void prerokBachaifroOfficeRightButton_Click(object sender, EventArgs e)
        {

        }

        private void searchOfficerRightControl_Load(object sender, EventArgs e)
        {

        }

        private void officeAddressManualEntryXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void prerokBachaiOwnRightButton_Click(object sender, EventArgs e)
        {

        }



        public void LoadOfficer()
        {
            DakUserParam userParam = _userService.GetLocalDakUserParam();
            AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
            designationSealListResponse = _designationSealService.GetAllDesignationSeal(userParam, userParam.office_id);
            List<ComboBoxItems> comboBoxItems = new List<ComboBoxItems>();
            try
            {

                if (designationSealListResponse.data.Count > 0)
                {

                    foreach (PrapokDTO prapokDTO in designationSealListResponse.data)
                    {
                        comboBoxItems.Add(new ComboBoxItems { id = prapokDTO.officer_id, Name = prapokDTO.NameWithDesignation });
                    }
                }


            }
            catch (Exception Ex)
            {

            }

            officerSearchList.itemList = comboBoxItems;
            officerSearchList.isListShown = true;

        }

        private void DakBoxSharingForm_Shown(object sender, EventArgs e)
        {
            LoadOfficer();
        }
    }
}
