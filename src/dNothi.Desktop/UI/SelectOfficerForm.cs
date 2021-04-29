using AutoMapper;
using dNothi.Desktop.View_Model;
using dNothi.JsonParser.Entity.Dak;
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
    public partial class SelectOfficerForm : Form
    {
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();
        public List<int> _selectedOfficerDesignations = new List<int>();
        public SelectOfficerForm()
        {
            InitializeComponent();
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public bool _isOneOfficerAllowed;

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
            SetDefaultFont(this.Controls);
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
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

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
                officerRowUserControl.Width = officerListFlowLayoutPanel.Width-50;

                _selectedOfficerDesignations.Add(_designationId);
                officerListFlowLayoutPanel.Controls.Add(officerRowUserControl);

            }


            var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();





            ReloadOfficerList();


            _designationId = 0;

            if(_isOneOfficerAllowed)
            {
                finalSave(sender, e);
            }
           
            

        }

        private void ReloadOfficerList()
        {
            var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();



            if (officerList.Count == 0)
            {
                officerEmptyPanel.Visible = true;
            }
            else
            {
                officerEmptyPanel.Visible = false;
            }


            countOfficer.Text = string.Concat(officerList.Count.ToString().Select(c => (char)('\u09E6' + c - '0')));

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public event EventHandler SaveButtonClick;
        private void finalSaveButton_Click(object sender, EventArgs e)
        {
            finalSave(sender,e);
        }

        private void finalSave(object sender, EventArgs e)
        {
            var officerList = officerListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();

            _selectedOfficerDesignations.Clear();


            foreach (var officer in officerList)
            {
                _selectedOfficerDesignations.Add(officer._designationId);
            }


            if (this.SaveButtonClick != null)
                this.SaveButtonClick(sender, e);

            this.Hide();
        }

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

        private void officerRowUserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
