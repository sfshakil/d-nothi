using dNothi.Desktop.UI;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.UserServices;
using javax.sound.midi;
using javax.xml.crypto;
using Newtonsoft.Json;
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
        //  IDakSharingService<ShareList> _dakSharingService { get; set; }
        IDakSharingService<ResponseModel> _dakSharingService { get; set; }
        IUserService _userService { get; set; }
        AllAlartMessage alartMessage = new AllAlartMessage();
        AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
        public DakBoxSharingForm(IDesignationSealService designationSealService, IUserService userService, IDakSharingService<ResponseModel> dakSharingService)
        {
            _designationSealService = designationSealService;
            _userService = userService;
            _dakSharingService = dakSharingService;
            InitializeComponent();

           
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

        private void LoadAssignOfficerList()
        {
            int actionlink=1;
            var assignlist = _dakSharingService.GetList(_userService.GetLocalDakUserParam(), actionlink, null);
            try
            {
                if (assignlist.status == "success")
                {
                    officerTableLayoutPanel.Controls.Clear();
                   
                     ShareList.Data assigneelist=  JsonConvert.DeserializeObject<ShareList.Data>(assignlist.data.ToString());
                    if (assigneelist.assignee.Count > 0)
                    {
                       

                        foreach (ShareList.Assignee assignee in assigneelist.assignee)
                        {
                            DakBoxSharedOfficerRowUserControl dakBoxSharedOfficerRowUserControl = new DakBoxSharedOfficerRowUserControl();
                            dakBoxSharedOfficerRowUserControl.officerName = assignee.name;
                            dakBoxSharedOfficerRowUserControl.designation = assignee.designation_level;
                            dakBoxSharedOfficerRowUserControl.officeName = assignee.office_name;
                            dakBoxSharedOfficerRowUserControl.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(deleteSender, deleteeVent, assignee.designation_id); };
                            dakBoxSharedOfficerRowUserControl.Dock = DockStyle.Top;

                            int row = officerTableLayoutPanel.RowCount++;

                            officerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));

                            officerTableLayoutPanel.Controls.Add(dakBoxSharedOfficerRowUserControl, 0, row);
                        }
                    }
                }


            }
            catch (Exception Ex)
            {

            }

        }

       private void DeleteControl_ButtonClick(Object sender,EventArgs e, int assignee_designation_id)
        {
            var data = _dakSharingService.Delete(_userService.GetLocalDakUserParam(), assignee_designation_id);
            if(data.status=="success")
            {
                alartMessage.SuccessMessage("ডাক বক্সটি সফলভাবে মুছে ফেলা হয়েছে।");

            }
            else
            {
                alartMessage.ErrorMessage("failed");
            }


            LoadAssignOfficerList();

        }
        private void DakBoxSharingForm_Shown(object sender, EventArgs e)
        {
            LoadOfficer();
            LoadAssignOfficerList();
        }

        private void prerokBachaiOfficerButton_Click(object sender, EventArgs e)
        {
            var userParam = _userService.GetLocalDakUserParam();
            if (officerSearchList.selectedId > 0 && officerSearchList.selectedId!= userParam.officer_id)
            {
                var assignor = _userService.GetLocalDakUserParam();
                var assainee = designationSealListResponse.data.Where(x => x.officer_id == officerSearchList.selectedId).FirstOrDefault();
                var response = _dakSharingService.Add(assignor, assainee);

                if (response.status == "success")
                {
                    alartMessage.SuccessMessage("ডাক বক্সটি সফলভাবে হস্তান্তর করা হয়েছে।");
                  
                    officerSearchList.selectedId = 0;
                    officerSearchList.searchButtonText = "নাম / পদবী দিয়ে খুঁজুন";
                }
                else
                {
                    alartMessage.ErrorMessage("ডাক বক্সটি হস্তান্তর করা সফল হয়নি।");
                }
                LoadAssignOfficerList();
            }
            else
            {
                alartMessage.ErrorMessage("ডাক বক্স হস্তান্তর করা যায় না।");
            }
        }
    }
}
