using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.ManuelUserControl;

namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    public partial class UCGuardFileList : UserControl
    {
       
        List<gdftype> fl = new List<gdftype>();
       
        public UCGuardFileList()
        {
            InitializeComponent();
           
            fl.Add(new gdftype() { rowNo = "1", type = "বাজেট ", typeNo = "1" });
            fl.Add(new gdftype() { rowNo = "2", type = "test", typeNo = "2" });
            fl.Add(new gdftype() { rowNo = "3", type = "test2", typeNo = "3" });
            fl.Add(new gdftype() { rowNo = "4", type = "test3", typeNo = "4" });

            LoadGuardFileList();
          
            
            var data= from s in fl
                            select new ComboBoxItems
                            {
                                id = Convert.ToInt32(s.rowNo),
                                Name = s.type
                            };
            typesearchComboBox.isListShown = true;
            typesearchComboBox.itemList = data.ToList();
           



        }
        public void LoadGuardFileList()
        {
            if (fl != null)
            {
                if (fl.Count > 0)
                {
                    foreach (gdftype gd in fl)
                    {
                        
                        var guardFileTable = UserControlFactory.Create<GuarFileListViewDeleteUC>();
                        guardFileTable.id = Convert.ToInt32(gd.rowNo);
                        guardFileTable.name = gd.type;
                        guardFileTable.type = gd.type;


                        guardFileTable.Dock = DockStyle.Fill;


                        UIDesignCommonMethod.AddRowinTable(guardListTableLayoutPanel, guardFileTable);


                    }
                }
            }
        }
        private void UCGuardFileList_Load(object sender, EventArgs e)
        {

        }

        private void Table_Border_Color_Blue(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Color_Blue(sender, e);
        }

        private void Table_Border_Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Table_Cell_Color_Blue(sender, e);
        }
    }
}
