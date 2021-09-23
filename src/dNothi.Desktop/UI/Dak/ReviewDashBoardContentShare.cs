using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
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
    public partial class ReviewDashBoardContentShare : UserControl
    {
        INothiReviewerServices _nothiReviewerServices { get; set; }
        IUserService _userService { get; set; }
        public ReviewDashBoardContentShare(INothiReviewerServices nothiReviewerServices, IUserService userService)
        {
            _nothiReviewerServices = nothiReviewerServices;
            _userService = userService;
            InitializeComponent();
        }
        private int _nothiSharedId;

        public int nothiSharedId
        {
            get { return _nothiSharedId; }
            set {  _nothiSharedId = value;
                loadSharedReviewer();
            }
        }
        private void loadSharedReviewer()
        {
            if (InternetConnection.Check())
            {
                var dakuserparam = _userService.GetLocalDakUserParam();
                var response = _nothiReviewerServices.GetNothiReviewer(dakuserparam, nothiSharedId);
                if (response != null )
                {
                    dakBodyFlowLayoutPanel.Controls.Clear();
                    if (response.users != null && response.users.Count > 0)
                    {
                        foreach (User user in response.users)
                        {
                            Reviewer noteOnuccedReview = new Reviewer();
                            noteOnuccedReview.officerName = user.officer;
                            noteOnuccedReview.officerDesignation = user.designation+","+user.office_unit+","+user.office;
                            UIDesignCommonMethod.AddRowinTable(dakBodyFlowLayoutPanel, noteOnuccedReview);
                        }
                        
                    }
                    else
                    {
                        
                    }
                }
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        
        private void panel1_MouseHover(object sender, EventArgs e)
        {
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void ReviewDashBoardContentShare_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
    }
}
