using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Desktop.UI.Dak;
using dNothi.Utility;

namespace dNothi.Desktop.UI.PotroJariGroups
{
    public partial class PatraJariGroupCreateUserControl : UserControl
    {
        AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
        int totalOfficer = 0;
        IDesignationSealService _designationSealService { get; set; }
        IUserService _userService { get; set; }
        List<PrapokDTO> officers = new List<PrapokDTO>();
        public PatraJariGroupCreateUserControl(IUserService userService ,
        IDesignationSealService designationSealService)
        {
            InitializeComponent();
            _designationSealService = designationSealService;
            _userService = userService;
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
                        comboBoxItems.Add(new ComboBoxItems { id = prapokDTO.officer_id, Name = prapokDTO.NameWithDesignation+", "+prapokDTO.office_unit+", "+prapokDTO.office_name_bng });
                    }
                }


            }
            catch (Exception Ex)
            {

            }

            officerSearchList.itemList = comboBoxItems;
            officerSearchList.isListShown = true;
        }
        private void bodyTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PatraJariGroupCreateUserControl_Load(object sender, EventArgs e)
        {
            var panels = selfInfoTableLayoutPanel.Controls.OfType<Panel>().Where(x => x.Name.EndsWith("Txt"));
            foreach (Panel p in panels)
            {
                p.Paint += new System.Windows.Forms.PaintEventHandler(allPanel_Paint);
            }
           
            LoadOfficer();
           
            talikaTableLayoutPanel.Controls.Clear();
            officers.Clear();

        }
        private void allPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void btnSaveToTalika_Click(object sender, EventArgs e)
        {
            
        }

        private void prerokBachaiOfficerButton_Click(object sender, EventArgs e)
        {
           
            if (officerSearchList.selectedId > 0)
            {
                PrapokDTO officer = new PrapokDTO();
                officer = designationSealListResponse.data.Where(x => x.officer_id == officerSearchList.selectedId).FirstOrDefault();
                officers.Add(officer);
                DesignationSealListOfficerRowUserControl officerTalika = new DesignationSealListOfficerRowUserControl();
                officerTalika.officerName = officerSearchList.searchButtonText;
                officerTalika.designationid = officerSearchList.selectedId;
                officerTalika.isNewlyAdded = true;

                officerTalika.DeleteButton += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, officerSearchList.selectedId); };


                UIDesignCommonMethod.AddRowinTable(talikaTableLayoutPanel, officerTalika);
                totalOfficer++;
                totalOfficerlabel.Text =ConversionMethod.EnglishNumberToBangla(totalOfficer.ToString());
                btnSave.Visible = true;
            }
        }

        
        private void officerTalika_DeleteButtonClick(object sender, EventArgs e, int officerId)
        {

            totalOfficer--;
            totalOfficerlabel.Text = ConversionMethod.EnglishNumberToBangla(totalOfficer.ToString());
            officers.RemoveAll(x=>x.officer_id== officerId);
            UpdateOfficerTalika();


        }

        private void UpdateOfficerTalika()
        {
            talikaTableLayoutPanel.Controls.Clear();
            foreach (var item in officers)
            {
                DesignationSealListOfficerRowUserControl officerTalika = new DesignationSealListOfficerRowUserControl();
                officerTalika.officerName =item.employee_name_bng+", "+item.designation_bng + ", " + item.office_unit + ", " + item.office_name_bng;
                officerTalika.designationid =item.designation_id;
                officerTalika.isNewlyAdded = true;

                officerTalika.DeleteButton += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, officerSearchList.selectedId); };


                UIDesignCommonMethod.AddRowinTable(talikaTableLayoutPanel, officerTalika);
            }
            if (officers.Count > 0)
            {
                btnSave.Visible = true;
            }

        }

        private void selfSaveiconButton_Click(object sender, EventArgs e)
        {
            PrapokDTO officer = new PrapokDTO();
            officer.employee_name_bng = namBanglaTxt.Text;
            officer.officer_name= namBanglaTxt.Text + ", " + padTxt.Text;
            officer.officer_bng = namBanglaTxt.Text;
            officer.officer_eng = namEngTxt.Text;
            officer.personal_email = emailTxt.Text;
            officer.personal_mobile = mobileTxt.Text;
            officer.office_name_bng = workPlaceTxt.Text;
            officer.office_name_eng = workplaceEngTxt.Text;
            officer.designation_bng = padTxt.Text;
            officer.designation_eng = padEngTxt.Text;
            officer.office_unit = branchTxt.Text;
            officer.office_unit_eng = branchENgTxt.Text;
            officer.NameWithDesignation= namBanglaTxt.Text + ", " + padTxt.Text;

            var officerid=  designationSealListResponse.data.Max(x=>x.officer_id);
            officer.officer_id = officerid++;
            officers.Add(officer);

            UpdateOfficerTalika();
        }
    }
}
