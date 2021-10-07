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
        public ReportCategoryUserControl()
        {
            InitializeComponent();
            loadrow();
        }
        private void loadrow()
        {
            var row = UserControlFactory.Create<ReportCategoryRowUserControl>();
            
            UIDesignCommonMethod.AddRowinTable(ListFlowLayoutPanel, row);
        }
    }
}
