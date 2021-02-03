using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Utility;
using dNothi.JsonParser.Entity.Dak_List_Inbox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakMovementStatusListUserControl : UserControl
    {
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
        public DakMovementStatusListUserControl()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }
        private string _userType;
        private string _userDesignation;

        public string userType
        {
            get { return _userType; }
            set { _userType = value; if (value == null) { userTypeLabel.Visible = false; } else { userTypeLabel.Text = value; } }
        }



        public string userDesignation
        {
            get { return _userDesignation; }
            set { _userDesignation = value; userDesignationLabel.Text = value; }
        }





    }
}
