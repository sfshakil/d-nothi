using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.Dak;
using com.sun.corba.se.spi.orbutil.fsm;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class UCGuardFileTypes : UserControl
    {
        public UCGuardFileTypes()
        {
            InitializeComponent();
            LoadGuardFileTypeList();
        }

        public void LoadGuardFileTypeList()
        {
            //guardFileTypeTableLayoutPanel.Controls.Clear();
            List<gdftype> fl = new List<gdftype>();
            fl.Add(new gdftype() { rowNo = "1", type = "বাজেট ", typeNo = "1" });
            fl.Add(new gdftype() { rowNo = "2", type = "test", typeNo = "2" });
            fl.Add(new gdftype() { rowNo = "3", type = "test2", typeNo = "3" });
            fl.Add(new gdftype() { rowNo = "4", type = "test3", typeNo = "4" });
            //DakUserParam userParam = _userService.GetLocalDakUserParam();

            //DakDecisionListResponse dakDecisionListResponse = _dakForwardService.GetDakDecisionListResponse(userParam);
            if (fl != null)
            {
                if (fl.Count > 0)
                {
                    foreach (gdftype gd in fl)
                    {
                        //var decisionTable = UserControlFactory.Create<DakDecisionTableUserControl>();
                        var decisionTable = UserControlFactory.Create<GuardFileTypeTableUserControl>();
                        decisionTable.id =Convert.ToInt32( gd.rowNo);
                        decisionTable.decision = gd.type;
                        
                        decisionTable.RadioButtonClick += delegate (object sender, EventArgs e) { dakDecisionTableUserControl_RadioButtonClick(sender, e, Convert.ToInt32(gd.rowNo)); };
                        //if (gd.dak_decision_employee == 1)
                        //{
                            //decisionTable.isAdded = true;
                        // decisionComboBox.Items.Add(gd.type);
                        // }
                        //else
                        //{
                        //    decisionTable.isAdded = false;
                        //}



                        decisionTable.Dock = DockStyle.Fill;

                        int row = guardFileTypeTableLayoutPanel.RowCount++;

                        guardFileTypeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                        guardFileTypeTableLayoutPanel.Controls.Add(decisionTable, 0, row);

                        guardFileTypeTableLayoutPanel.Controls.Add(decisionTable);

                    }
                }
            }
        }

        private void dakDecisionTableUserControl_RadioButtonClick(object sender, EventArgs e, int id)
        {
            var decisionTable = guardFileTypeTableLayoutPanel.Controls.OfType<GuardFileTypeTableUserControl>().ToList();

            foreach (var dakDecisionTableUser in decisionTable)
            {
                if (dakDecisionTableUser._id != id)
                {
                    //dakDecisionTableUser.isDecisionSelected = false;
                }
            }
        }
    }
}
