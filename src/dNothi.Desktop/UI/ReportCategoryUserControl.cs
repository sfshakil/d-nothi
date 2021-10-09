using dNothi.JsonParser.Entity;
using dNothi.Services.DakServices;
using dNothi.Services.ReportServices;
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

namespace dNothi.Desktop.UI
{
    public partial class ReportCategoryUserControl : UserControl
    {
        IUserService _userService { get; set; }
        IReportService _reportService { get; set; }
        List<Category> categories = new List<Category>();
        List<Category> updateCategories = new List<Category>();
        public ReportCategoryUserControl(IUserService userService, IReportService reportService)
        {
            _userService = userService;
            _reportService = reportService;
            InitializeComponent();
            loadrow();
            SubHeaderPanel.Height = OntorvuktiHeaderPanel.Height;
        }
        private void loadrow()
        {
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            ReportCategoryResponse reportCategoryResponse = _reportService.GetReportCategoryList(_dakuserparam,"list");
            if (reportCategoryResponse.status == "success")
            {
                int i = 1;
                foreach (ReportCategoryData response in reportCategoryResponse.data)
                {
                    var row = UserControlFactory.Create<ReportCategoryRowUserControl>();
                    response.serialNumber = i;
                    row.btnEditSaveClick += delegate (object sender1, EventArgs e1) { btnEditSave_ButtonClick(sender1 as ReportCategoryAddData, e1); };
                    row.btnDeleteClick += delegate (object sender1, EventArgs e1) { btnDelete_ButtonClick(sender1 as ReportCategoryAddData, e1); };
                    row.setResponse(response);
                    UIDesignCommonMethod.AddRowinTable(ListFlowLayoutPanel, row);
                    i++;
                    categories.Add(new Category { id = response.id, serial = response.serial});
                }
            }
            else
            {
                ListFlowLayoutPanel.Controls.Clear();
            }
            
        }
        private void btnEditSave_ButtonClick(ReportCategoryAddData reportCategoryAddData, EventArgs e)
        {
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            ReportCategoryAddResponse reportCategorySerialUpdateResponse = _reportService.GetReportCategoryAdd(_dakuserparam, reportCategoryAddData);
            if (reportCategorySerialUpdateResponse.status == "success")
            {
                UIDesignCommonMethod.SuccessMessage("ক্যাটাগরি অন্তর্ভুক্ত করা হয়েছে");
                updateCategories.Clear();
                categories.Clear();
                ListFlowLayoutPanel.Controls.Clear();
                loadrow();
            }
        }
        private void btnDelete_ButtonClick(ReportCategoryAddData reportCategoryAddData, EventArgs e)
        {
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
            ReportCategoryDeleteResponse reportCategorySerialUpdateResponse = _reportService.GetReportCategoryDelete(_dakuserparam, reportCategoryAddData);
            if (reportCategorySerialUpdateResponse.status == "success")
            {
                UIDesignCommonMethod.SuccessMessage("ক্যাটাগরি মুছে ফেলা হয়েছে।");
                updateCategories.Clear();
                categories.Clear();
                ListFlowLayoutPanel.Controls.Clear();
                loadrow();
            }
        }
        private void OntorvuktiButton_Click(object sender, EventArgs e)
        {
            OntorvuktiHeaderPanel.Visible = false;
            tableLayoutPanel1.RowStyles[1].Height = OntorvuktiPanel.Height;
            panel7.Visible = true;
            TextBoxPanel.Visible = true;
            panel10.Visible = true;
            OntorvuktiTextBox.Visible = true;
            OntorvuktiSaveButton.Visible = true;
            DeleteButton.Visible = true;

            OntorvuktiPanel.Height = panel7.Height + TextBoxPanel.Height + panel10.Height;
            
            SubHeaderPanel.Height = OntorvuktiPanel.Height;
            OntorvuktiPanel.Visible = true;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            OntorvuktiHeaderPanel.Visible = true;
            OntorvuktiPanel.Visible = false;
            SubHeaderPanel.Height = OntorvuktiHeaderPanel.Height;
        }

        private void TextBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

        private void SerialUpdateButton_Click(object sender, EventArgs e)
        {
            foreach (ReportCategoryRowUserControl row in ListFlowLayoutPanel.Controls)
            {
                bool containsItem = categories.Any(item => item.id == row.id && item.serial == Convert.ToInt32(row.reportSerialNumber));
                if (!containsItem)
                {
                    updateCategories.Add(new Category { id = row.id, serial = Convert.ToInt32(row.reportSerialNumber) });
                }
            }
            if (updateCategories.Count>0)
            {
                DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();
                ReportCategorySerialUpdateResponse reportCategorySerialUpdateResponse = _reportService.GetReportCategorySerialUpdate(_dakuserparam, "serial_update", updateCategories);
                if (reportCategorySerialUpdateResponse.status == "success")
                {
                    UIDesignCommonMethod.SuccessMessage("ক্রম সংশোধন করা হয়েছে");
                    updateCategories.Clear();
                    categories.Clear();
                    ListFlowLayoutPanel.Controls.Clear();
                    loadrow();
                }
            }
            else
            {
                updateCategories.Clear();
            }
        }

        private void OntorvuktiSaveButton_Click(object sender, EventArgs e)
        {
            DakUserParam _dakuserparam = _userService.GetLocalDakUserParam();

            ReportCategoryAddData reportCategoryAddData = new ReportCategoryAddData();
            reportCategoryAddData.type = "add";
            reportCategoryAddData.category_name = OntorvuktiTextBox.Text;

            ReportCategoryAddResponse reportCategorySerialUpdateResponse = _reportService.GetReportCategoryAdd(_dakuserparam, reportCategoryAddData);
            if (reportCategorySerialUpdateResponse.status == "success")
            {
                UIDesignCommonMethod.SuccessMessage("ক্যাটাগরি অন্তর্ভুক্ত করা হয়েছে");
                updateCategories.Clear();
                categories.Clear();
                ListFlowLayoutPanel.Controls.Clear();
                DeleteButton_Click(null,null);
                loadrow();
            }
        }
    }
}
