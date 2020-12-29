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
    public partial class AddDesignationSeal : Form
    {
   
        public AddDesignationSeal()
        {
            InitializeComponent();

            LoadOwnOffice();
            LoadOwnOfficerTree();

        }

        private void LoadOwnOfficerTree()
        {


          
            TreeNode Rootnode1 = new TreeNode("শাখা কোড (১)");
            
            TreeNode Rootnode2 = new TreeNode("ব্যক্তিগত কর্মকর্তা");
            
            Rootnode2.Nodes.Add("1", "জি.এম. জাহাঙ্গীর হোসেন");
            Rootnode2.Nodes.Add("1", "শহিদুল ইসলাম");

            Rootnode1.Nodes.Add(Rootnode2);


            prapokownOfficeTreeView.Nodes.Add(Rootnode1);
            

          
        }

        private void LoadOwnOffice()
        {
            
            DesignationSealBranchRowUserControl designationSealBranchRowUserControl = new DesignationSealBranchRowUserControl();
            designationSealBranchRowUserControl.branchOfficeName = "যুগ্ম প্রকল্প পরিচালক (কম্পোনেন্ট-২,৩)";
            string[] officer = { "সেলিনা পারভেজ,যুগ্ম প্রকল্প পরিচালক (কম্পোনেন্ট-২,৩) যুগ্ম প্রকল্প পরিচালক (কম্পোনেন্ট-২,৩),এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্রাম"};
            designationSealBranchRowUserControl.officerName = officer;
            ownOfficeRightFlowLayoutPanel.Controls.Add(designationSealBranchRowUserControl);
          



            DesignationSealBranchRowUserControl designationSealBranchRowUserControl2 = new DesignationSealBranchRowUserControl();
            designationSealBranchRowUserControl2.branchOfficeName = "প্রোগ্রাম ম্যানেজমেন্ট,রিসার্চ,এমএন্ডই";
            string[] officer2 = { "মোঃ শুয়াইব শাহরিয়ার রুশো,প্রোগ্রাম এ্যাসিসটেন্ট প্রোগ্রাম ম্যানেজমেন্ট,রিসার্চ,এমএন্ডই ,এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্রাম", "মাহমুদুল ইসলাম স্মরণ ,ডাটা এন্ড এমএন্ডই এক্সপার্ট প্রোগ্রাম ম্যানেজমেন্ট,রিসার্চ,এমএন্ডই ,এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্রাম", "মোঃ মাজেদুল ইসলাম,প্রোগ্রাম ইমপ্লিমেন্টেশন স্পেশালিস্ট (প্রজেক্ট ম্যানেজার) প্রোগ্রাম ম্যানেজমেন্ট,রিসার্চ,এমএন্ডই ,এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্রাম" };
            designationSealBranchRowUserControl2.officerName = officer2;
     
            otherOfficeRightFlowLayoutPanel.Controls.Add(designationSealBranchRowUserControl2);
        }

        private void tabControlLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlLeft.SelectedTab == tabControlLeft.TabPages["ownOfficeTabPageLeft"])
            {
                tabControlRight.SelectTab(ownOfficeTabPageRight);
            }
            else if(tabControlLeft.SelectedTab == tabControlLeft.TabPages["otherOfficeTabPageLeft"])
            {
                tabControlRight.SelectTab(otherOfficeTabPageRight);
            }
        }

        private void tabControlRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlRight.SelectedTab == tabControlRight.TabPages["ownOfficeTabPageRight"])
            {
                tabControlLeft.SelectTab(ownOfficeTabPageLeft);
            }
            else if(tabControlRight.SelectedTab == tabControlRight.TabPages["otherOfficeTabPageRight"])
            {
                tabControlLeft.SelectTab(otherOfficeTabPageLeft);
            }
        }

        
        private void AddDesignationCloseButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BorderBlueColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
    }
}
