using dNothi.Desktop.UI;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
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

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class NothiOnuccedReviewForm : Form
    {
        IDesignationSealService _designationSealService { get; set; }
        IUserService _userService { get; set; }
        AllAlartMessage alartMessage = new AllAlartMessage();
        public List<int> _selectedOfficerDesignations = new List<int>();
        AllDesignationSealListResponse designationSealListResponse = new AllDesignationSealListResponse();
        public NothiOnuccedReviewForm(IDesignationSealService designationSealService, IUserService userService)
        {
            _designationSealService = designationSealService;
            _userService = userService;
         
            InitializeComponent();

           
        }
     
        private NothiReviewerDTO _nothiReviewerDTO { get; set; }
        public NothiReviewerDTO nothiReviewerDTO { get=> _nothiReviewerDTO;
            set { _nothiReviewerDTO = value;

                if (value != null)
                {
                    if (value.users.Count > 0)
                    {
                        officerEmptyPanel.Visible = false;
                        officerTableLayoutPanel.Controls.Clear();
                        foreach (var item in value.users)
                        {
                            int designationId = Convert.ToInt32(item.designation_id);
                            KhosraReviewOfficerRowUserControl officerTalika = new KhosraReviewOfficerRowUserControl();
                            officerTalika.permission = item.review_mode;
                            officerTalika.officerName = item.officer;
                            officerTalika.designation = item.designation;
                            officerTalika.officeName = item.office;
                            officerTalika.designationId = designationId;
                            _selectedOfficerDesignations.Add(designationId);
                            officerTalika.DeleteButtonClick += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, designationId); };


                            UIDesignCommonMethod.AddRowinTable(officerTableLayoutPanel, officerTalika);
                        }
                        saveIconButton.Visible = true;
                        shareStopIconButton.Visible = true;
                    }
                    else
                    {
                        officerEmptyPanel.Visible = true;
                    }
                }
                else
                {
                    officerEmptyPanel.Visible = true;
                }
            } }
        private void NothiOnuccedReviewForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = scr.WorkingArea.Height;
            SetDefaultFont(this.Controls);
        }
        private void NothiOnuccedReviewForm_Shown(object sender, EventArgs e)
        {
            LoadOfficer();

           // LoadAssignOfficerList();
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
                        comboBoxItems.Add(new ComboBoxItems { id = prapokDTO.officer_id, Name = prapokDTO.NameWithDesignation +","+prapokDTO.office });
                    }
                }


            }
            catch (Exception Ex)
            {

            }

            officerSearchList.itemList = comboBoxItems;
            officerSearchList.isListShown = true;
        }
      
        private void officerTalika_DeleteButtonClick(Object sender,EventArgs e, int designationId)
        {
            if(_selectedOfficerDesignations.Contains(designationId))
            {
                var officerList = officerTableLayoutPanel.Controls.OfType<KhosraReviewOfficerRowUserControl>().Where(a => a.Hide != true).ToList();

                _selectedOfficerDesignations.Remove(designationId);

                if (officerList.Count == 0)
                {
                    officerEmptyPanel.Visible = true;
                    shareStopIconButton.Visible=false;
                    saveIconButton.Visible = false;
                }
                else
                {
                    officerEmptyPanel.Visible = false;
                    saveIconButton.Visible = true;

                }
            }

           // ReloadOfficerList();
        }
        

        private void ReloadOfficerList()
        {
            var officerList = officerTableLayoutPanel.Controls.OfType<KhosraReviewOfficerRowUserControl>().Where(a => a.Hide != true).ToList();


            if (officerList.Count == 0)
            {
                officerEmptyPanel.Visible = true;
            }
            else
            {
                officerEmptyPanel.Visible = false;

            }

        }
        private void prerokBachaiOfficerButton_Click(object sender, EventArgs e)
        {
            int officerId= officerSearchList.selectedId;
            var officerdata = designationSealListResponse.data.Where(x => x.officer_id == officerSearchList.selectedId).FirstOrDefault();

            if (officerId > 0 && !_selectedOfficerDesignations.Contains(officerdata.designation_id))
            {
                officerEmptyPanel.Visible = false;
               
                KhosraReviewOfficerRowUserControl officerTalika = new KhosraReviewOfficerRowUserControl();
                officerTalika.permission = "write";
                officerTalika.officerName = officerdata.officer_bng;
                officerTalika.designation = officerdata.designation_bng;
                officerTalika.officeName = officerdata.office;
                officerTalika.designationId = officerdata.designation_id;
                _selectedOfficerDesignations.Add(officerdata.designation_id);

                officerTalika.DeleteButtonClick += delegate (object s1, EventArgs e1) { officerTalika_DeleteButtonClick(s1, e1, officerdata.designation_id); };

                UIDesignCommonMethod.AddRowinTable(officerTableLayoutPanel, officerTalika);

                saveIconButton.Visible = true;
                officerSearchList.searchButtonText = "নাম/পদবী দিয়ে খুঁজুন";
                officerSearchList.selectedId = 0;
            }
           
        }

       
    }
}
