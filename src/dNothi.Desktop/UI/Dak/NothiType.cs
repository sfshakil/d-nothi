﻿using System;
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

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiType : UserControl
    {
        IUserService _userService { get; set; }
        INothiTypeListServices _nothiType { get; set; }
        public NothiType(IUserService userService, INothiTypeListServices nothiType)
        {
            _userService = userService;
            _nothiType = nothiType;
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
        private void LoadNothiTypeList()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var token = _userService.GetToken();
            var nothiType = _nothiType.GetNothiTypeList(dakListUserParam);
            if (nothiType.status == "success")
            {
                if (nothiType.data.Count > 0)
                {
                    LoadNothiTypeListinPanel(nothiType.data);
                    int value = nothiType.data.Count;
                    totalNothi = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
            }
        }

        private void LoadNothiTypeListinPanel(List<NothiTypeListDTO> nothiTypeLists)
        {
            List<NothiTypeList> nothiTypes = new List<NothiTypeList>();
            int i = 0, k = 1;
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
            nothiTypeListFlowLayoutPanel.Controls.Clear();
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
