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
                    row.setResponse(response);
                    UIDesignCommonMethod.AddRowinTable(ListFlowLayoutPanel, row);
                    i++;
                }
            }
            else
            {
                ListFlowLayoutPanel.Controls.Clear();
            }
            
        }

        private void OntorvuktiButton_Click(object sender, EventArgs e)
        {
            OntorvuktiHeaderPanel.Visible = false;
            tableLayoutPanel1.RowStyles[1].Height = OntorvuktiPanel.Height;
            panel7.Visible = true;
            TextBoxPanel.Visible = true;
            panel10.Visible = true;
            placeholderTextBox2.Visible = true;
            iconButton2.Visible = true;
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
    }
}
