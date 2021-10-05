using System;
using System.Collections.Generic;
using System.Drawing;

using System.Linq;
using System.Windows.Forms;

using dNothi.Utility;

using dNothi.Services.NothiReportService;
using dNothi.Services.UserServices;
using dNothi.Services.BasicService;

using dNothi.Services.DakServices;
using dNothi.Services.KasaraPatraDashBoardService.Models;
using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.Services.NothiReportService.Model;
using dNothi.Services.KasaraPatraDashBoardService;
using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class NothiMasterRegisterReportUserControl : UserControl
    {
        string fromdate, todate;
        public int pageLimit = 1;
        public int pageNo = 1;
        int page = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        int lastCountValue = 1;
        int lastrecord = 0;
        string filePath = string.Empty;
        string datetextFromtextbox = string.Empty;
        NothiRegisterReport.Record nothiMasterFile = new NothiRegisterReport.Record();
        IUserService _userService { get; set; }
        INothiReportService _nothiReportService { get; set; }
        IBasicService _basicService { get; set; }
        IKasaraPatraDashBoardService _kasaraPatraDashBoardService;

        public NothiMasterRegisterReportUserControl(IUserService userService, INothiReportService nothiReportService, IBasicService basicService, IKasaraPatraDashBoardService kasaraPatraDashBoardService)
        {
            _userService = userService;
            _nothiReportService = nothiReportService;
            _basicService = basicService;
            _kasaraPatraDashBoardService = kasaraPatraDashBoardService;
            InitializeComponent();
           
        }

        private List<ComboBoxItem> getShaka(DakUserParam userparam)
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();

            var officeUnitResponse = _basicService.GetOfficeUnitList(userparam);
            if (officeUnitResponse.status == "success")
            {
                comboBoxItems.Add(new ComboBoxItem("শাখা নির্বাচন করুন", 0));
                foreach (var item in officeUnitResponse.data)
                {
                    comboBoxItems.Add(new ComboBoxItem(item.unit_name_bng, item.unit_id));
                }
            }
            return comboBoxItems;
        }
       
        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void dateRangePickerShow(object sender, EventArgs e)
        {
            if (customDatePicker.Visible)
            {
                customDatePicker.Visible = false;
            }
            else
            {
                customDatePicker.Visible = true;
                //  customDatePicker.Location =new Point(datePickerTableLayoutPanel.Location.X, datePickerTableLayoutPanel.Location.Y+datePickerTableLayoutPanel.Height);

            }
        }

        private void customDatePicker_OptionClick(object sender, EventArgs e)
        {
            
            dateTextBox.Text = customDatePicker._date;

            customDatePicker.Visible = false;
            Formload();
        }

        private void Formload()
        {
            page = 1;
            start = 1;
            LoadData(); 
            if (totalrecord < 1) { end = totalrecord; }
            else { end = 1; }
            NextPreviousButtonShow();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

        }
       

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //DataExportToExcel();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // DataExportToPDF(); 
           
        }
        private void LoadData()
        {
            var userParam = _userService.GetLocalDakUserParam();
          
            string dateRange = dateTextBox.Text;
            string unitid = dakPriorityComboBox.SelectedValue!=null? dakPriorityComboBox.SelectedValue.ToString(): userParam.office_unit_id.ToString();
            if (dateRange == string.Empty)
            {
                fromdate = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd");
                todate = DateTime.Now.ToString("yyyy/MM/dd");
                
            }
            else
            {
                fromdate = dateRange.Substring(0, dateRange.IndexOf(":"));
                todate = dateRange.Substring(dateRange.IndexOf(":") + 1);
            }

            userParam.page = page;
            userParam.limit = pageLimit;
            userParam.NameSearchParam = dakSearchSubTextBox.Text;

            var nothiRegisterBook = _nothiReportService.NothiRegisterBook(userParam, fromdate, todate, unitid, false, false, false, false, true);
            if (nothiRegisterBook.status == "success")
            {
                totalRowlabel.Text = "সর্বমোট "+ ConversionMethod.EnglishNumberToBangla( nothiRegisterBook.data.total_records.ToString())+" টি";
                noRowMessageLabel.Visible = false;
                lastrecord = nothiRegisterBook.data.records.Count();
               
             foreach(var item in nothiRegisterBook.data.records)
                {
                   
                    nothiMasterFile = item;
                    fileWebBrowser.Url = new Uri(item.mulpotro.url);
                }

                totalrecord = nothiRegisterBook.data.total_records;
                float pagesize = (float)(nothiRegisterBook.data.total_records) / (float)pageLimit;
                totalPage = (int)Math.Ceiling(pagesize);
              
            }
            else
            {
                noRowMessageLabel.Visible = true;
            }

        }
       
        private void RegisterReportUserControl_Load(object sender, EventArgs e)
        {
            fromdate = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd");
            todate = DateTime.Now.ToString("yyyy/MM/dd");
            dateTextBox.Text = fromdate + ":" + todate;

            var userparam = _userService.GetLocalDakUserParam();
            dakPriorityComboBox.DataSource = getShaka(userparam);
            dakPriorityComboBox.DisplayMember = "Name";
            dakPriorityComboBox.ValueMember = "Id";
            dakPriorityComboBox.SelectedValue = userparam.office_unit_id;
        }

       
        #region Pagination
        private void NextPreviousButtonShow()
        {
            if (page < totalPage)
            {
                if (page == 1 && totalPage > 1)
                {
                    iconButton3.Enabled = false;
                }
                else
                {
                    iconButton3.Enabled = true;

                }
                pageNextButton.Enabled = true;
            }
            if (page == totalPage)
            {
                if (page == 1 && totalPage == 1)
                {
                    iconButton3.Enabled = false;

                }
                else
                {
                    iconButton3.Enabled = true;

                }
                pageNextButton.Enabled = false;
            }



        }
        private void pageNextButton_Click(object sender, EventArgs e)
        {
            string endrow;

            if (page <= totalPage)
            {
                page += 1;
                start += pageLimit;
                end += pageLimit;

            }
            else
            {
                page = totalPage;
               
            }
            endrow = end.ToString();
            LoadData();


            if (totalrecord < end) { endrow = totalrecord.ToString(); }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

            NextPreviousButtonShow();
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {

                page -= 1;
                start -= pageLimit;
                end -= pageLimit;
                lastCountValue -= (pageLimit+lastrecord);

            }
            else
            {
                page = 1;
                

            }


            LoadData();
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
            NextPreviousButtonShow();

        }

        #endregion

        private void prapokListIconButton_Click(object sender, EventArgs e)
        {
            PrapakerTalika prapakerTalika = new PrapakerTalika();
            var dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = pageLimit;
           
          prapakerTalika = _kasaraPatraDashBoardService.GetPrapakerTalika(dakListUserParam, nothiMasterFile.basic.id);
           
            if (prapakerTalika.status == "success")
            {

                KhosraPrapokListViewForm khosraPrapokListViewForm = new KhosraPrapokListViewForm();
                khosraPrapokListViewForm.prapakerTalika = prapakerTalika;


                UIDesignCommonMethod.CalPopUpWindow(khosraPrapokListViewForm, this);
            }
        }

        private void printIconButton_Click(object sender, EventArgs e)
        {
            
            filePath= UIDesignCommonMethod.DownLoadFiles(nothiMasterFile.mulpotro.url, nothiMasterFile.mulpotro.user_file_name);
            UIDesignCommonMethod.PrintFile(filePath);
        }

        private void sampadanIconButton_Click(object sender, EventArgs e)
        {

        }

        private void cloneIconButton_Click(object sender, EventArgs e)
        {

        }

        private void portalshareIconButton_Click(object sender, EventArgs e)
        {
            PotroPublishingForm potroPublishingForm = FormFactory.Create<PotroPublishingForm>();
            potroPublishingForm.subject = nothiMasterFile.basic.potro_subject;
            //potroPublishingForm.domainname= kasaraPotro.Basic

            // potroPublishingForm.dakAttachmentResponse = GetAllMulPattraAndSanjukti(kasaraPotro);

            UIDesignCommonMethod.CalPopUpWindow(potroPublishingForm, this);
        }

        private void dakSearchUsingTextButton_Click(object sender, EventArgs e)
        {
            Formload();
        }

        private void recycleIconButton_Click(object sender, EventArgs e)
        {
            dakSearchSubTextBox.Text = string.Empty;
        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dakPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dakPriorityComboBox.SelectedValue.ToString() != "dNothi.Desktop.ComboBoxItem")
                
            {
                Formload();
            }
        }

      

    }
}
