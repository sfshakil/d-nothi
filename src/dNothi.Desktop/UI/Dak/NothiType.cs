using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Utility;
using dNothi.Core.Interfaces;
using dNothi.Core.Entities;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiType : UserControl
    {
        IUserService _userService { get; set; }
        INothiTypeListServices _nothiType { get; set; }
        IRepository<NothiTypeItemAction> _nothiTypeItemAction;
        public NothiType(IUserService userService, INothiTypeListServices nothiType, IRepository<NothiTypeItemAction> nothiTypeItemAction)
        {
            _userService = userService;
            _nothiType = nothiType;
            _nothiTypeItemAction = nothiTypeItemAction;

            InitializeComponent();
            LoadNothiTypeList();
            SetDefaultFont(this.Controls);
            
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }
        public NothiTypeListResponse nothiType;
        int i = 0, k = 1;
        private void LoadNothiTypeList()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            int value = 0;
            if (!InternetConnection.Check())
            {
                List<NothiTypeItemAction> nothiTypeItemActions = _nothiTypeItemAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                if (nothiTypeItemActions != null && nothiTypeItemActions.Count > 0)
                {
                    List<NothiTypeList> nothiTypes = new List<NothiTypeList>();
                    foreach (NothiTypeItemAction nothiTypeItemAction in nothiTypeItemActions)
                    {
                        var nothiType = UserControlFactory.Create<NothiTypeList>();
                        nothiType.serialNo = k.ToString();
                        nothiType.nothiSubjectType = nothiTypeItemAction.nothiDhoron;
                        nothiType.nothiCode = nothiTypeItemAction.nothiDhoronCode;
                        nothiType.offline();
                        i = i + 1;
                        k++; value++;
                        if (i % 2 != 0)
                            nothiType.BackColor = Color.FromArgb(243, 246, 249);
                        nothiTypes.Add(nothiType);
                    }
                    nothiTypeListFlowLayoutPanel.Controls.Clear();
                    nothiTypeListFlowLayoutPanel.AutoScroll = true;
                    nothiTypeListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                    nothiTypeListFlowLayoutPanel.WrapContents = false;

                    for (int j = 0; j <= nothiTypes.Count - 1; j++)
                    {
                        nothiTypeListFlowLayoutPanel.Controls.Add(nothiTypes[j]);


                    }
                }
            }
            
            var token = _userService.GetToken();
            nothiType = _nothiType.GetNothiTypeList(dakListUserParam);
            if (nothiType.status == "success")
            {
                if (nothiType.data.Count > 0)
                {
                    LoadNothiTypeListinPanel(nothiType.data);
                    value = value + nothiType.data.Count;
                    totalNothi = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
            }
        }

        private void LoadNothiTypeListinPanel(List<NothiTypeListDTO> nothiTypeLists)
        {
            List<NothiTypeList> nothiTypes = new List<NothiTypeList>();
            
            foreach (NothiTypeListDTO nothiTypeListDTO in nothiTypeLists)
            {
                var nothiType = UserControlFactory.Create<NothiTypeList>();
                nothiType.serialNo = k.ToString();
                nothiType.nothiSubjectType = nothiTypeListDTO.nothi_type;
                nothiType.nothiCode = nothiTypeListDTO.nothi_type_code;
                nothiType.nothiNumber = nothiTypeListDTO.nothi_type_count;
                nothiType.noteId = nothiTypeListDTO.id.ToString();
                i = i + 1;
                k++;
                if (i % 2 != 0)
                    nothiType.BackColor = Color.FromArgb(243, 246, 249);
                nothiTypes.Add(nothiType);

            }
            if (InternetConnection.Check())
            {
                nothiTypeListFlowLayoutPanel.Controls.Clear();
            }
            
            nothiTypeListFlowLayoutPanel.AutoScroll = true;
            nothiTypeListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            nothiTypeListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiTypes.Count - 1; j++)
            {
                nothiTypeListFlowLayoutPanel.Controls.Add(nothiTypes[j]);
               
                    
            }
        }

        private void btnNothiTypeCross_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            { f.Hide(); }
            var form = FormFactory.Create<Nothi>();
            form.forceLoadNewNothi();
            form.ShowDialog();
        }
        private string _totalNothi;

        [Category("Custom Props")]
        public string totalNothi
        {
            get { return _totalNothi; }
            set { _totalNothi = value; lbTotalNothi.Text = value; }
        }

        private void btnNewNothiCreate_Click(object sender, EventArgs e)
        {
            var createNewNothiType = UserControlFactory.Create<CreateNewNothiType>();
            createNewNothiType.nothiTypeList(nothiType.data);
            foreach (NothiTypeListDTO nothiTypeListDTO in nothiType.data)
            {
                createNewNothiType.nothiType = nothiTypeListDTO.nothi_type;
                createNewNothiType.invisibleNothiType = nothiTypeListDTO.nothi_type;
                createNewNothiType.nothiType = string.Concat(nothiTypeListDTO.nothi_type_code.ToString().Select(c => (char)('\u09E6' + c - '0')));
                createNewNothiType.nothiType = Environment.NewLine;

            }
            
            createNewNothiType.Visible = true;
            createNewNothiType.Location = new System.Drawing.Point(0, 74);
            Controls.Add(createNewNothiType);
            createNewNothiType.BringToFront();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
           ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }

    }
}
