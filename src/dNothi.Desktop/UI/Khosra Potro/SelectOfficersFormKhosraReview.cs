using AutoMapper;
using dNothi.Desktop.UI.GuardFileUI;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Desktop.UI.OtherModule;
//using dNothi.Desktop.UI.SelectOfficerUserControls;
using dNothi.Desktop.View_Model;
using dNothi.JsonParser.Entity.Dak;
using javax.sound.midi;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace dNothi.Desktop.UI
{
    public partial class SelectOfficersFormKhosraReview : Form
    {
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        public List<int> _selectedOfficerDesignations = new List<int>();
        List<gdftype> fl = new List<gdftype>();
        int tabpageno = 2;
        public SelectOfficersFormKhosraReview( )
        {
           
            InitializeComponent();

           
            fl.Add(new gdftype() { rowNo = "1", type = "বাজেট ", typeNo = "1" });
            fl.Add(new gdftype() { rowNo = "2", type = "test", typeNo = "2" });
            fl.Add(new gdftype() { rowNo = "3", type = "test2", typeNo = "3" });
            fl.Add(new gdftype() { rowNo = "4", type = "test3", typeNo = "4" });
            var data = from s in fl
                       select new ComboBoxItems
                       {
                           id = Convert.ToInt32(s.rowNo),
                           Name = s.type
                       };

            officeSearchComboBox.itemList = data.ToList();
            officeSearchComboBox.isListShown = true;

            LayersearchComboBox.itemList = data.ToList();
            LayersearchComboBox.isListShown = true;

            officeBacaiSearchComboBox.itemList = data.ToList();
            officeBacaiSearchComboBox.isListShown = true;

            originBacaiSearchComboBox.itemList = data.ToList();
            originBacaiSearchComboBox.isListShown = true;

            districtSearchComboBox.itemList = data.ToList();
            districtSearchComboBox.isListShown = true;
            loadTree();
            //SetDefaultFont(this.Controls);
           

        }

       

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private DesignationSealListResponse _designationSealListResponse;


        public DesignationSealListResponse designationSealListResponse
        {
            get { return _designationSealListResponse; }
            set
            {
                _designationSealListResponse = value;
                try
                {
                    foreach (PrapokDTO ownOfficeDTO in value.data.own_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOwnOffice = mapper.Map<ViewDesignationSealList>(ownOfficeDTO);



                        viewdesignationListOwnOffice.nij_Office = true;



                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOwnOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOwnOffice);
                        }

                    }

                    foreach (PrapokDTO otherOfficeDTO in value.data.other_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOtherOffice = mapper.Map<ViewDesignationSealList>(otherOfficeDTO);
                        if (!viewDesignationSealLists.Any(a => a.designation_id == viewdesignationListOtherOffice.designation_id))
                        {
                            viewDesignationSealLists.Add(viewdesignationListOtherOffice);
                        }

                    }

                  
                    PopulateSenderListBox();

                }
                catch
                {

                }



            }

        }
        private void SelectOfficerForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            
        }
        void SetDefaultFont(ControlCollection collection)
        {
            foreach (System.Windows.Forms.Control ctrl in collection)
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




               // SetDefaultFont(ctrl.Controls);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {

           ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
        private void PopulateSenderListBox()
        {
            searchOfficerRightListBox.DisplayMember = "designationwithname";
            searchOfficerRightListBox.DataSource = null;
            searchOfficerRightListBox.DataSource = viewDesignationSealLists;
            searchOfficerRightListBox.Visible = true;
        }
        private void searchOfficerRightButton_Click(object sender, EventArgs e)
        {
            if (searchOfficerRightPanel.Visible)
            {

                searchOfficerRightPanel.Visible = false;
            }
            else
            {
                searchOfficerRightXTextBox.Text = "";
                //searchOfficerRightListBox.Visible = false;
                searchOfficerRightPanel.Visible = true;
                // searchOfficerRightResultLabel.Text = "";

                searchOfficerRightXTextBox.Focus();
            }
        }

        private void searchOfficerRightXTextBox_TextChanged(object sender, EventArgs e)
        {
            searchOfficerRightListBox.DataSource = null;
            if (searchOfficerRightXTextBox.Text == "")
            {
                PopulateSenderListBox();

            }
            else
            {

                List<ViewDesignationSealList> viewDesignationSealListsforOfficerSearch = viewDesignationSealLists.Where(a => a.employee_name_bng.Contains(searchOfficerRightXTextBox.Text)).ToList();




                if (viewDesignationSealListsforOfficerSearch.Count > 0)
                {
                    searchOfficerRightListBox.DisplayMember = "designationwithname";
                    searchOfficerRightListBox.DataSource = null;
                    searchOfficerRightListBox.DataSource = viewDesignationSealListsforOfficerSearch;

                    searchOfficerRightListBox.Visible = true;
                }
                else
                {
                    searchOfficerRightListBox.Visible = false;
                    //searchOfficerRightResultLabel.Text = "";
                }

            }
        }

        private void searchOfficerRightListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchOfficerRightPanel.Visible)
            {

                searchOfficerRightPanel.Visible = false;
            }
            else
            {
                searchOfficerRightXTextBox.Text = "";
                //searchOfficerRightListBox.Visible = false;
                searchOfficerRightPanel.Visible = true;
                // searchOfficerRightResultLabel.Text = "";

                searchOfficerRightXTextBox.Focus();
            }
        }
        private int _designationId=0;
        private void searchOfficerRightListBox_Click(object sender, EventArgs e)
        {
            searchOfficerRightPanel.Visible = false;



            officerSearchOfficerNameLabel.Text = searchOfficerRightListBox.GetItemText(searchOfficerRightListBox.SelectedItem);
            _designationId = (searchOfficerRightListBox.SelectedItem as ViewDesignationSealList).designation_id;
           // _selectedOfficerDesignations.Add(_designationId);





        }

        private void saveOfficerButton_Click(object sender, EventArgs e)
        {
            



            if (!_selectedOfficerDesignations.Contains(_designationId) && _designationId !=0)
            {
                OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();
                officerRowUserControl.officerName = viewDesignationSealLists.FirstOrDefault(a => a.designation_id == _designationId).designationwithname;
                officerRowUserControl.designationId = _designationId;
               
                officerRowUserControl.DeleteButton+= delegate (object se, EventArgs ev) { ReloadOfficerList(); };
                //officerRowUserControl.Width = officerListFlowLayoutPanel.Width-10;
                officerRowUserControl.Width = officerListTableLayoutPanel.Width-10;
                // officerRowUserControl.Dock = DockStyle.Fill;
                //_selectedOfficerDesignations.Add(_designationId);
                //officerListFlowLayoutPanel.Controls.Add(officerRowUserControl);
                //officerListFlowLayoutPanel.Dock = DockStyle.Top;

                //officerListFlowLayoutPanel.AutoSize = true;
                //officerListFlowLayoutPanel.Visible = true;

                int row = officerListTableLayoutPanel.RowCount++;
                officerRowUserControl.Dock = DockStyle.Top;
                officerListTableLayoutPanel.Visible = true;

                officerListTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                officerListTableLayoutPanel.Controls.Add(officerRowUserControl, 0, row);
                // tableLayoutPanel1.SetColumnSpan(officerRowUserControl, 3);
                officerListTableLayoutPanel.Dock = DockStyle.Top;
                officerListTableLayoutPanel.Controls.Add(officerRowUserControl);
               // tableLayoutPanel1.Dock = DockStyle.Top;


            }


            // var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

            var officerList = officerListTableLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();




            ReloadOfficerList();


            _designationId = 0;


           
            

        }

        private void ReloadOfficerList()
        {
          //  var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

            var officerList = officerListTableLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

            

            if (officerList.Count == 0)
            {
                officerEmptyPanel.Visible = true;
                finalSaveButton.Visible = false;
            }
            else
            {
                officerEmptyPanel.Visible = false;
                finalSaveButton.Visible = true;
            }


            //countOfficer.Text = string.Concat(officerList.Count.ToString().Select(c => (char)('\u09E6' + c - '0')));

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public event EventHandler SaveButtonClick;
        private void finalSaveButton_Click(object sender, EventArgs e)
        {
           // var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a=>a.Hide!=true).ToList();

            var officerList = officerListTableLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();
            
            _selectedOfficerDesignations.Clear();


            foreach (var officer in officerList)
            {
                _selectedOfficerDesignations.Add(officer._designationId);
            }


            if (this.SaveButtonClick != null)
                this.SaveButtonClick(sender, e);

            this.Hide();
        }

        private void loadTree()
        {
            officerListTreeView.Nodes.Clear();
            officerListTreeView.Nodes.Add("first");
            officerListTreeView.Nodes.Add("second");
            officerListTreeView.Nodes.Add("third");

            officerListTreeView.Nodes[0].Nodes.Add("first1");
            officerListTreeView.Nodes[0].Nodes.Add("first2");
            officerListTreeView.Nodes[0].Nodes.Add("first3");

            officerListTreeView.Nodes[1].Nodes.Add("1");
            officerListTreeView.Nodes[1].Nodes.Add("2");
            officerListTreeView.Nodes[1].Nodes.Add("3");

            officerListTreeView.Nodes[2].Nodes.Add("1");
            officerListTreeView.Nodes[2].Nodes.Add("2");
            officerListTreeView.Nodes[2].Nodes.Add("3");

        }

        List<TreeNode> checkedNodes = new List<TreeNode>();
        //private void RemoveCheckedNode(TreeNodeCollection nodes)
        //{
        //    foreach(TreeNode node in nodes)
        //    {
        //        if(node.Checked)
        //        {
        //            checkedNodes.Add(node);
        //        }
        //        else
        //        {
        //            RemoveCheckedNode(node.Nodes);
        //        }
        //    }
        //    foreach(TreeNode cn in checkedNodes)
        //    {
        //        nodes.Remove(cn);
        //    }
        //}

        private void searchOfficerRightListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lbx = sender as ListBox;
            string itemText = lbx.GetItemText(lbx.Items[e.Index]);

            e.DrawBackground();
            e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), e.Bounds);

        }

        private void searchOfficerRightListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 60;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        //private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //void getFontProperty(ControlCollection controls)
        //{
        //    foreach(var control in controls)
        //    {

        //    }
        //}

        private void prapakSearchPane_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void officeSearchComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            treePanel.Visible = true;
        }

        private void officeSearchComboBox_DockChanged(object sender, EventArgs e)
        {
            treePanel.Visible = true;
        }

        private void officeSearchComboBox_Click(object sender, EventArgs e)
        {
            //SearchComboBox uc = new SearchComboBox();
            //uc.ChangeSelectedIndex += delegate (object deleteSender, EventArgs deleteeVent) { SelectedChangeControl(sender, e, officeSearchComboBox.selectedId); };
        }

        //private void SelectedChangeControl(object sender, EventArgs e, int id)
        //{
            
          

        //}

        private void officeSearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {
           // districtSearchComboBox.Visible = true;
            originBacaiSearchComboBox.Visible = true;
            officeBacaiSearchComboBox.Visible = true;
            officeBacaiSearchComboBox.Location = new Point(16, 303);
            LayersearchComboBox.Visible = true;
            LayersearchComboBox.Enabled = false;
           // districtSearchComboBox.Enabled = false;
            originBacaiSearchComboBox.Enabled = false;
            officeBacaiSearchComboBox.Enabled = false;

           // districtBacaiPanel.Visible = true;
            layerPanel.Visible = true;
            officeBacaiPanel.Visible = true;
            originBacaiPanel.Visible = true;
            treePanel.Visible = true;
            label7.Visible = true;
           
            prapakSearchPanel.Visible = true;
            //districtBacaiPanel.Enabled = false;
            layerPanel.Enabled = false;
            officeBacaiPanel.Enabled = false;
            originBacaiPanel.Enabled = false;
            officerListTreeView.Nodes.Clear();


            loadTree();
        }

        private void LayersearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {
          
            originBacaiSearchComboBox.Visible = true;
            officeBacaiSearchComboBox.Visible = true;


            officeBacaiSearchComboBox.Location = new Point(16, 303);
            officeBacaiPanel.Visible = true;
            originBacaiPanel.Visible = true;

            label7.Visible = false;
            treePanel.Visible = false;
            officerListTreeView.Nodes.Clear();

        }

        private void originBacaiSearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {
           
            officeBacaiSearchComboBox.Visible = true;
            officeBacaiSearchComboBox.Location = new Point(16, 303);
            officeBacaiPanel.Visible = true;
            label7.Visible = false;
            treePanel.Visible = false;
            officerListTreeView.Nodes.Clear();

        }

        private void officeBacaiSearchComboBox_ChangeSelectedIndex(object sender, EventArgs e)
        {
            prapakSearchPanel.Visible = true;
            label7.Visible = true;
            treePanel.Visible = true;
            loadTree();
        }

        //public void LoadGuardFileList()
        //{

        //    dataTableLayoutPanel.Controls.Clear();

           

        //     foreach (gdftype gd in fl)
        //        {

        //        PatrajariUserControl patrajariUserControl =new PatrajariUserControl();
        //        patrajariUserControl.id = Convert.ToInt32(gd.rowNo);
        //        patrajariUserControl.groupName = "পত্রজারি গ্রুপ তৈরি ও এডিট টেস্ট ";// gd.type;
        //        patrajariUserControl.userName = "ইমরুল হোসেন গ্রুপটি তৈরি করেছেন ";    //gd.typeNo;
        //        patrajariUserControl.status = gd.type;

        //        patrajariUserControl.Dock = DockStyle.Fill;
        //        patrajariUserControl.AutoSize = true;

        //        int row = dataTableLayoutPanel.RowCount++;
                
        //        dataTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
        //        dataTableLayoutPanel.Controls.Add(patrajariUserControl, 0, row);
        //       // patrajariTableLayoutPanel.SetColumnSpan(patrajariUserControl, 3);
        //       // patrajariTableLayoutPanel.Controls.Add(patrajariUserControl);

        //    }
               
        //}

        private void tabPage4_Click(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage4"])
            {
                //LoadGuardFileList();
            }
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void tabPage4_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void patrajariTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
           // ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void officerEmptyPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void officerListPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
