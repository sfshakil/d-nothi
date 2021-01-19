using dNothi.JsonParser.Entity.Nothi;
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

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiNextStep : UserControl
    {
        IUserService _userService { get; set; }
        public NothiNextStep(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                SetDefaultFont(ctrl.Controls);
            }

        }

        private string _noteTotal;
        private string _noteSubject;

        [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
        }

        [Category("Custom Props")]
        public string noteTotal
        {
            get { return _noteTotal; }
            set { _noteTotal = value; lbTotalNothi.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        int i = 1;
        public void loadFlowLayout(onumodonDataRecordDTO record)
        {
            
            NothiOnumodonRow nothiOnumodonRow = new NothiOnumodonRow();
            nothiOnumodonRow.name = record.officer;
            nothiOnumodonRow.designation = record.designation+","+record.office_unit +"," +record.nothi_office_name;
            nothiOnumodonRow.level = i.ToString();
            nothiOnumodonRow.flag = 1;
            DesignationFLP.Controls.Add(nothiOnumodonRow);
            i++;
        }
    }
}
