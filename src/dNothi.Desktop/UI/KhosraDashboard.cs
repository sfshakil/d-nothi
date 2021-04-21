using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.KasaraPatraDashBoardService;
using dNothi.Services.UserServices;
using dNothi.Utility;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace dNothi.Desktop.UI
{
    public partial class KhosraDashboard : Form
    {

        IKasaraPatraDashBoardService _kasaraPatraDashBoardService { get; set; }
      
        int page = 1;
        int pageLimit = 10;
        int menuNo = 1;
        int totalPage = 1;
        int start = 1;
        int end = 10;
        int totalrecord = 0;
        IUserService _userService { get; set; }
        public KhosraDashboard(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;

         }


        private void MakeThisPanelClicked(object sender)
        {
            Panel panel = sender as Panel;
            if(panel == null)
            {
                panel = (sender as Control).Parent as Panel;
            }


            foreach (Control control in menuTableLayoutPanel.Controls)
            {
                if (control is Panel)
                {
                    if (control == panel)
                    {
                        MakeClickUnClickButton(control, Color.FromArgb(243, 246, 249), Color.FromArgb(78, 165, 254));

                    }
                    else
                    {
                        if(control is Button)
                        {
                            listTypeLabel.Text = control.Text;
                        }
                        MakeClickUnClickButton(control, Color.FromArgb(254, 254, 254), Color.FromArgb(97, 99, 114));

                    }
                }
            }
        }

        private void MakeClickUnClickButton(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            if (control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {

                    c.ForeColor = foreColor;


                }
            }
        }

        private void draftPotroPanel_Click(object sender, EventArgs e)
        {
            menuNo = 1;
            page = 1;
            start = 1;
            
            MakeThisPanelClicked(sender);
            LoadData(true, menuNo,page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());


            // LoadFakeRow(true);
        }

        private void noteAttachmentKhosraButton_Click(object sender, EventArgs e)
        {
            menuNo = 2;
            page = 1;
            start = 1;
           
            MakeThisPanelClicked(sender);
            LoadData(true, menuNo,page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());


            // LoadFakeRow(false);
        }

        private void pendingApprovalPanel_Click(object sender, EventArgs e)
        {
            menuNo = 3;
            page = 1;
            start = 1;
          
            MakeThisPanelClicked(sender);
            LoadData(false, menuNo,page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

            // LoadFakeRow(false);
        }

        private void pendingForwardPanel_Click(object sender, EventArgs e)
        {
            menuNo = 4;
            page = 1;
            start = 1;
           
            MakeThisPanelClicked(sender);
            LoadData(false, menuNo, page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

            //LoadApprovedData(false,page);
            // LoadFakeRow(false);
        }

        private void jarikritoButton_Click(object sender, EventArgs e)
        {
            menuNo = 5;
            page = 1;
            start = 1;
           
            MakeThisPanelClicked(sender);
           // LoadJarikritaData(false,page);
            LoadData(false, menuNo, page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

            //  LoadFakeRow(false);
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }

       

        private void KhosraDashboard_Shown(object sender, EventArgs e)
        {
            // LoadFakeRow(true); 
            page = 1;
            start = 1;
           
            LoadData(true, menuNo,page);
            if (totalrecord < 10) { end = totalrecord; }
            else { end = 10; }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());
        }

        //private void LoadFakeRow(bool v)
        //{
        //    khosraListTableLayoutPanel.Controls.Clear();
           
        //    CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl.isDraft = v;

        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);




        //    CommonKhosraRowUserControl commonKhosraRowUserControl2 = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl2.isDraft = v;


        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl2);


        //    CommonKhosraRowUserControl commonKhosraRowUserControl3 = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl3.isDraft = v;


        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl3);




        //    CommonKhosraRowUserControl commonKhosraRowUserControl4 = new CommonKhosraRowUserControl();

        //    commonKhosraRowUserControl4.isDraft = v;


        //    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl4);

        //}

        private void LoadData(bool v,int menuNo,int pages)
        {
            khosraListTableLayoutPanel.Controls.Clear();
            _kasaraPatraDashBoardService = new KararaPotroDashBoardServices();
           
            var dakListUserParam = _userService.GetLocalDakUserParam();

            dakListUserParam.limit = pageLimit;
            dakListUserParam.page = pages;
          
            var kasarapatralist = _kasaraPatraDashBoardService.GetList(dakListUserParam, menuNo);
            if (kasarapatralist.status == "success")
            {
                foreach (var item in kasarapatralist.data.records)
                {
                    
                    CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl(_userService);

                    commonKhosraRowUserControl.sharokNo = item.basic.sarok_no;
                    commonKhosraRowUserControl.sub = item.basic.potro_subject;
                    commonKhosraRowUserControl.date = item.basic.modified;
                    commonKhosraRowUserControl.isDraft = v;
                    commonKhosraRowUserControl.Record = item;
                    commonKhosraRowUserControl.attachmentButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_attachmentButtonClick(sender, e); };
                    commonKhosraRowUserControl.onumodonButtonClick += delegate (object sender, EventArgs e) { commonKhosraRowUserControl_onumodonButtonClick(sender, e); };


                    UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);

                }
                 totalrecord = kasarapatralist.data.total_records;
                totalLabel.Text = "সর্বমোট:" + ConversionMethod.EnglishNumberToBangla(totalrecord.ToString());
                float pagesize = totalrecord / pageLimit;
                totalPage =(int) Math.Ceiling(pagesize);
            }

        }

        private void commonKhosraRowUserControl_attachmentButtonClick(object sender, EventArgs e)
        {
        }
        private void commonKhosraRowUserControl_onumodonButtonClick(object sender, EventArgs e)
        {
        }

        //    private void LoadApprovedData(bool v,int pages)
        //    {
        //        khosraListTableLayoutPanel.Controls.Clear();
        //        _patraJarirApekkaiService = new PatraJarirApekkaiService();
        //        //  _userService = new UserService();
        //        //  DakUserParam dakListUserParams = new DakUserParam();
        //        var dakListUserParam = _userService.GetLocalDakUserParam();

        //        // Satic Class
        //        dakListUserParam.limit = pageLimit;
        //        dakListUserParam.page = pages;

        //        var patraJarirApekkaiServicelist = _patraJarirApekkaiService.GetList(dakListUserParam);

        //        if (patraJarirApekkaiServicelist.status == "success")
        //        {
        //            foreach (var item in patraJarirApekkaiServicelist.data.records)
        //            {
        //                CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();

        //                commonKhosraRowUserControl.sharokNo = item.basic.sarok_no;
        //                commonKhosraRowUserControl.sub = item.basic.potro_subject;
        //                commonKhosraRowUserControl.date = item.basic.modified;
        //                commonKhosraRowUserControl.isDraft = v;
        //                UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);

        //            }

        //            totalLabel.Text = "সর্বমোট " + patraJarirApekkaiServicelist.data.total_records.ToString() + " টি";
        //        }
        //        }

        //    private void LoadJarikritaData(bool v,int pages)
        //    {
        //        khosraListTableLayoutPanel.Controls.Clear();
        //        _jarikritaPattraService = new JarikritaPattraService();
        //        //  _userService = new UserService();
        //        //  DakUserParam dakListUserParams = new DakUserParam();
        //        var dakListUserParam = _userService.GetLocalDakUserParam();

        //        // Satic Class
        //        dakListUserParam.limit = pageLimit;
        //        dakListUserParam.page = pages;

        //        var jarikritaPattraServicelist = _jarikritaPattraService.GetList(dakListUserParam);
        //        if(jarikritaPattraServicelist.status== "success")
        //        { 
        //        foreach (var item in jarikritaPattraServicelist.data.records)
        //        {
        //            CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();

        //            commonKhosraRowUserControl.sharokNo = item.basic.sarok_no;
        //            commonKhosraRowUserControl.sub = item.basic.potro_subject;
        //            commonKhosraRowUserControl.date = item.basic.modified;
        //            commonKhosraRowUserControl.isDraft = v;
        //            UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);

        //        }

        //        totalLabel.Text = "সর্বমোট "+ jarikritaPattraServicelist.data.total_records.ToString()+ " টি";
        //        }

        //}

        private void DakModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.DakModuleClick(this);
        }
        private void NothiModule_CLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.NothiModuleClick(this);
        }

        private void designationDetailsPanel_Load(object sender, EventArgs e)
        {

        }

        private void nextIconButton_Click(object sender, EventArgs e)
        {
            string endrow;
           
            if (page <= totalPage)
            {
                page += 1;
                start +=  pageLimit;
                end += pageLimit;
                
            }
            else
            {
                page = totalPage;
                start = start;
                end = end;
                
            }
            endrow = end.ToString();
            LoadData(true, menuNo, page);
            if (totalrecord < end) { endrow = totalrecord.ToString(); }
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(endrow);
            //perPageRowLabel.Text = start.ToString()+"-" + endrow; 
        }

        private void PreviousIconButton_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {
               
                page -= 1;
                start -= pageLimit;
                end -= pageLimit;
                
            }
            else
            {
                page = 1;
                start = start;
                end = end;

            }
           
            LoadData(true, menuNo, page);
            perPageRowLabel.Text = ConversionMethod.EnglishNumberToBangla(start.ToString()) + "-" + ConversionMethod.EnglishNumberToBangla(end.ToString());

           
        }
    }
}
