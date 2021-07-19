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
using System.Text.RegularExpressions;
using com.sun.rowset.@internal;
using dNothi.Services.PotroJariGroup.Models;
using dNothi.Services.PotroJariGroup;
using dNothi.Core.Entities;

namespace dNothi.Desktop.UI.PotroJariGroups
{
    public partial class PatraJariGroupCreateUserControl : UserControl
    {
        AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
        int totalOfficer = 0;
        AllAlartMessage alartMessage = new AllAlartMessage();
        IDesignationSealService _designationSealService { get; set; }
        IPotroJariGroupService _potroJariGroupService { get; set; }
        IUserService _userService { get; set; }
        List<PotrojariGroupModel.User> officers = new List<PotrojariGroupModel.User>();
        public string _groupName { get; set; }
        public string groupName { get => _groupName; set { _groupName = value; txtSubject.Text = value; } }
      
        public PatraJariGroupCreateUserControl(IUserService userService ,
        IDesignationSealService designationSealService,
         IPotroJariGroupService potroJariGroupService)
        {
            InitializeComponent();
            _designationSealService = designationSealService;
            _userService = userService;
            _potroJariGroupService = potroJariGroupService;
        }
        private PotrojariGroupModel.Record _potrojariGroupModel { get; set; }
        public PotrojariGroupModel.Record potrojariGroupModel
        {
            get => _potrojariGroupModel;
            set
            {
                _potrojariGroupModel = value;
                foreach (var item in value.users)
                {
                    int rowid = officers.Count>0  ? officers.Max(x => x.rowId) : 0;
                    
                    item.rowId = rowid+1;
                    officers.Add(item);
                    totalOfficer++;
                    totalOfficerlabel.Text = ConversionMethod.EnglishNumberToBangla(totalOfficer.ToString());
                }
                UpdateOfficerTalika();
            }
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
           //if((_potrojariGroupModel!=null? _potrojariGroupModel.group.id:0)>0)
           //     {

           // }
           // else {
           //     talikaTableLayoutPanel.Controls.Clear();
           //     officers.Clear();
           // }

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
               
               var officerdata = designationSealListResponse.data.Where(x => x.officer_id == officerSearchList.selectedId).FirstOrDefault();
                PotrojariGroupModel.User officer = new PotrojariGroupModel.User();
                officer.office_id = officerdata.office_id;
                officer.office_eng = officerdata.office_name_eng;
                officer.office = officerdata.office_name_bng;

                officer.office_unit_id = officerdata.office_unit_id;
                officer.office_unit_eng = officerdata.office_unit_eng;
                officer.office_unit = officerdata.office_unit;

                officer.designation = officerdata.designation_bng;
                officer.designation_eng = officerdata.designation_eng;
                officer.designation_id = officerdata.designation_id;

                officer.officer_id = officerdata.officer_id;
                officer.officer = officerdata.employee_name_bng ;
                officer.officer = officerdata.officer_bng;
                officer.officer_eng = officerdata.officer_eng;
                officer.officer_email = officerdata.personal_email;
                officer.officer_mobile= officerdata.personal_mobile ;

                officer.designation_level = officerdata.designation_level;
               officer.designation_sequence = officerdata.designation_sequence;

                officer.id = 0;

                int rowid = officers.Count>0? officers.Max(x => x.rowId):0;

                officer.rowId = rowid+1;
                officers.Add(officer);
                DesignationSealListOfficerRowUserControl officerTalika = new DesignationSealListOfficerRowUserControl();
                officerTalika.officerName = officerSearchList.searchButtonText;
                officerTalika.designationid = officerSearchList.selectedId;
                officerTalika.isNewlyAdded = true;

                officerTalika.DeleteButton += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, officer.rowId); };


                UIDesignCommonMethod.AddRowinTable(talikaTableLayoutPanel, officerTalika);
                totalOfficer++;
                totalOfficerlabel.Text =ConversionMethod.EnglishNumberToBangla(totalOfficer.ToString());
                btnSave.Visible = true;
            }
        }

        private void officerTalika_DeleteButtonClick(object sender, EventArgs e, int rowid)
        {
            int id=  officers.Where(x => x.rowId == rowid).Select(x=>x.id).FirstOrDefault();
            if (id == 0)
            {
                

                officers.RemoveAll(x => x.rowId == rowid);
                totalOfficer--;
                totalOfficerlabel.Text = ConversionMethod.EnglishNumberToBangla(totalOfficer.ToString());
                UpdateOfficerTalika();
            }

        }

        private void UpdateOfficerTalika()
        {
            talikaTableLayoutPanel.Controls.Clear();
            foreach (var item in officers)
            {
                DesignationSealListOfficerRowUserControl officerTalika = new DesignationSealListOfficerRowUserControl();
                officerTalika.officerName =item.officer+", "+item.designation + ", " + item.office_unit + ", " + item.office;
                officerTalika.designationid =item.designation_id;
                officerTalika.isNewlyAdded = true;

                officerTalika.DeleteButton += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, item.rowId); };


                UIDesignCommonMethod.AddRowinTable(talikaTableLayoutPanel, officerTalika);
            }
            if (officers.Count > 0)
            {
                btnSave.Visible = true;
            }

        }
        private void clearfrom()
        {
            namBanglaTxt.Text = string.Empty ;
        
            namEngTxt.Text= string.Empty;
             emailTxt.Text= string.Empty;
            mobileTxt.Text= string.Empty;
         workPlaceTxt.Text= string.Empty;
      workplaceEngTxt.Text= string.Empty;
               padTxt.Text= string.Empty;
            padEngTxt.Text= string.Empty;
            branchTxt.Text= string.Empty;
         branchENgTxt.Text = string.Empty;
        }
        private void selfSaveiconButton_Click(object sender, EventArgs e)
        {

            PotrojariGroupModel.User officer = new PotrojariGroupModel.User();
            officer.officer = namBanglaTxt.Text;
           // officer.officer_name= namBanglaTxt.Text + ", " + padTxt.Text;
           // officer.officer_bng = namBanglaTxt.Text;
            officer.officer_eng = namEngTxt.Text;
            officer.officer_email = emailTxt.Text;
            officer.officer_mobile = mobileTxt.Text;
            officer.office = workPlaceTxt.Text;
            officer.office_eng = workplaceEngTxt.Text;
            officer.designation = padTxt.Text;
            officer.designation_eng = padEngTxt.Text;
            officer.office_unit = branchTxt.Text;
            officer.office_unit_eng = branchENgTxt.Text;
            officer.id = 0;
           // officer.NameWithDesignation= namBanglaTxt.Text + ", " + padTxt.Text;

            int rowid= officers.Count>0? officers.Max(x => x.rowId):0;
            officer.rowId = rowid+1;

            if (officer.officer_email != string.Empty && officer.designation != string.Empty && officer.office != string.Empty)
            {
                officers.Add(officer);
                clearfrom();
                totalOfficer++;
                totalOfficerlabel.Text = ConversionMethod.EnglishNumberToBangla(totalOfficer.ToString());
            }
            else
            {
                if (officer.officer_email == string.Empty)
                {
                    alartMessage.ErrorMessage("দুঃখিত! ইমেইল ফাকা রাখা যাবে না।");
                    
                    return;
                }
                if (officer.designation == string.Empty)
                {
                    alartMessage.ErrorMessage("দুঃখিত! পদ ফাকা রাখা যাবে না।");
                    return;
                }
                if (officer.office == string.Empty)
                {
                    alartMessage.ErrorMessage("দুঃখিত! কার্যালয় ফাকা রাখা যাবে না।");
                    return;
                }
                Regex mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(officer.officer_email.Trim()))
                {
                    alartMessage.ErrorMessage("দুঃখিত! ইমেইল এর গঠন সঠিক হয়নি");
                    return;
                }
                if (officer.officer_mobile.Length == 11)
                {
                    alartMessage.ErrorMessage("দুঃখিত! মোবাইল নম্বর শুধুমাত্র ১১ অঙ্কের হতে পারবে");
                    return;
                }
            }

            UpdateOfficerTalika();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DakUserParam userParam = _userService.GetLocalDakUserParam();
            PotrojariGroupModel.Group group = new PotrojariGroupModel.Group();
            if ((_potrojariGroupModel != null ? _potrojariGroupModel.group.id : 0) > 0)
            {
                group.id = _potrojariGroupModel.group.id;
            }
            else
            {
                group.id = 0;
            }
            group.group_name = txtSubject.Text;
            group.group_value = string.Empty;
            group.privacy_type = "public";

            List<PotroJariGroupModels.User> users = new List<PotroJariGroupModels.User>();
           
            foreach (var item in officers)
            {
                PotroJariGroupModels.User user = new PotroJariGroupModels.User { id = item.id.ToString(),
                 designation=item.designation, designation_id=item.designation_id.ToString(), designation_level=item.designation_level.ToString(),
                 designation_sequence=item.designation_sequence.ToString(), office=item.office, officer=item.officer, officer_email=item.officer_email, 
                 officer_id=item.officer_id.ToString(), officer_mobile= item.officer_mobile, office_id=item.office_id.ToString(), office_unit=item.office_unit,
                 office_unit_id=item.office_unit_id.ToString(), designation_eng=item.designation_eng, officer_eng=item.officer_eng,
                    office_eng=item.office_eng, office_unit_eng=item.office_unit_eng};

               // user= MappingModels.MapModel<PotrojariGroupModel.User, PotroJariGroupModels.User>(item);
                users.Add(user);
            }
            if (group.group_name != string.Empty)
            {
                var response = _potroJariGroupService.PatroJariGroupCreateUpdate(userParam, group, users);
                if(response.data.status=="success")
                    {
                        totalOfficer = 0;
                        alartMessage.SuccessMessage(response.data.data);
                        txtSubject.Text = string.Empty;
                        btnSave.Visible = false;
                        totalOfficerlabel.Text= ConversionMethod.EnglishNumberToBangla(totalOfficer.ToString());
                        talikaTableLayoutPanel.Controls.Clear();
                        officers.Clear();
                    }
                else
                {
                    alartMessage.ErrorMessage("দুঃখিত!");

                    return;

                }

            }
            else
            {
                alartMessage.ErrorMessage("দুঃখিত!গ্রুপের নাম ফাকা রাখা যাবে না।");

                return;

            }
        }

        private void selfInfoTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }
    }
}
