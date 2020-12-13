using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.View_Model;
using dNothi.JsonParser.Entity.Dak;
using AutoMapper;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakUploadUserControl : UserControl
    {
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        List<string> sendMediumListCollection = new List<string>();
        int mulPrapokColumn = 9;
        int onulipiColumn = 10;
        bool NijOffice = true;
        List<ViewDesignationSealList> viewDesignationSealLists = new List<ViewDesignationSealList>();



        public DakUploadUserControl()
        {
            InitializeComponent();


            PriorityListCollection.Clear();

            foreach (string str in dakPriorityListBox.Items)
            {
                PriorityListCollection.Add(str);
            }

            SecurityListCollection.Clear();
            foreach (string str in securityLevelListBox.Items)
            {
                SecurityListCollection.Add(str);
            }

            sendMediumListCollection.Clear();
            foreach (string str in sendMediumListBox.Items)
            {
                sendMediumListCollection.Add(str);
            }


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
                        viewDesignationSealLists.Add(viewdesignationListOwnOffice);
                    }

                    foreach (PrapokDTO otherOfficeDTO in value.data.other_office)
                    {
                        var config = new MapperConfiguration(cfg =>
                      cfg.CreateMap<PrapokDTO, ViewDesignationSealList>()
                  );
                        var mapper = new Mapper(config);
                        var viewdesignationListOtherOffice = mapper.Map<ViewDesignationSealList>(otherOfficeDTO);

                        viewDesignationSealLists.Add(viewdesignationListOtherOffice);
                    }

                    PopulateGrid();
                }
                catch
                {

                }



            }

        }


        int designationColumn = 2;
        private void SaveOnulipiPrapok(int row_index)
        {

            for (int i = 0; i <= prapokDataGridView.Rows.Count - 1; i++)
            {
                if (i == row_index)
                {
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    SetThisMulprapokfalse(designation_id);
                }
            }
        }

        private void SetThisMulprapokfalse(int designation_id)
        {
            viewDesignationSealLists.FirstOrDefault(a => a.designation_id == designation_id).mul_prapok = false;


        }

        private void SaveMulPrapok(int row_index)
        {
            for (int i = 0; i <= prapokDataGridView.Rows.Count - 1; i++)
            {
                prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;

                if (i != row_index)
                {
                    prapokDataGridView.Rows[i].Cells[mulPrapokColumn].Value = false;



                }
                else
                {
                    int designation_id = (int)prapokDataGridView.Rows[i].Cells[designationColumn].Value;
                    prapokDataGridView.Rows[i].Cells[onulipiColumn].Value = false;

                    SetOtherMulprapokfalse(designation_id);

                }
            }
        }

        private void SetOtherMulprapokfalse(int designation_id)
        {
            foreach (ViewDesignationSealList viewDesignationSealList in viewDesignationSealLists)
            {
                if (viewDesignationSealList.designation_id != designation_id)
                {
                    viewDesignationSealList.mul_prapok = false;
                }
                else
                {
                    viewDesignationSealList.mul_prapok = true;
                }
            }
        }

        private void ownOfficeButton_Click(object sender, EventArgs e)
        {
            PopulateGrid();


        }
        public void PopulateGrid()
        {
            prapokDataGridView.DataSource = null;
            prapokDataGridView.DataSource = viewDesignationSealLists.Where(a => a.nij_Office == NijOffice).ToList();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sendMediumButton_Click(object sender, EventArgs e)
        {
            if (sendMediumPanel.Visible)
            {
                sendMediumPanel.Visible = false;
            }
            else
            {
                sendMediumPanel.Visible = true;
            }
        }

        private void prioritySearchButton_Click(object sender, EventArgs e)
        {
            if (prioritySearchPanel.Visible)
            {
                prioritySearchPanel.Visible = false;
            }
            else
            {
                prioritySearchPanel.Visible = true;
            }
        }

        private void secretLevelSearchButton_Click(object sender, EventArgs e)
        {
            if (secretLevelSearchButton.Visible)
            {
                secretLevelSearchButton.Visible = false;
            }
            else
            {
                secretLevelSearchButton.Visible = true;
            }
        }

        private void dakPriorityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            prioritySearchPanel.Visible = false;
            prioritySearchButton.Text = dakPriorityListBox.GetItemText(dakPriorityListBox.SelectedItem);
        }

        private void securityLevelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            secretLevelSearchButton.Visible = false;
            secretLevelSearchButton.Text = dakPriorityListBox.GetItemText(dakPriorityListBox.SelectedItem);
        }

        private void prioritySearchXTextBox_TextChanged(object sender, EventArgs e)
        {
            dakPriorityListBox.Items.Clear();
            if (prioritySearchXTextBox.Text == "")
            {
                foreach (string str in PriorityListCollection)
                {
                    dakPriorityListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in PriorityListCollection)
                {
                    if (str.StartsWith(prioritySearchXTextBox.Text))
                    {
                        dakPriorityListBox.Items.Add(str);
                    }

                }

            }
        }

        private void securityLevelXTextBox_TextChanged(object sender, EventArgs e)
        {
            securityLevelListBox.Items.Clear();
            if (securityLevelXTextBox.Text == "")
            {
                foreach (string str in SecurityListCollection)
                {
                    securityLevelListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in SecurityListCollection)
                {
                    if (str.StartsWith(securityLevelXTextBox.Text))
                    {
                        securityLevelListBox.Items.Add(str);
                    }

                }

            }
        }

        private void sendMediumListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sendMediumPanel.Visible = false;
            sendMediumButton.Text = sendMediumListBox.GetItemText(sendMediumListBox.SelectedItem);
        }

        private void sendMediumSearchXTextBox_TextChanged(object sender, EventArgs e)
        {
            sendMediumListBox.Items.Clear();
            if (sendMediumSearchXTextBox.Text == "")
            {
                foreach (string str in sendMediumListCollection)
                {
                    sendMediumListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in sendMediumListCollection)
                {
                    if (str.StartsWith(sendMediumSearchXTextBox.Text))
                    {
                        sendMediumListBox.Items.Add(str);
                    }

                }

            }
        }

        private void dakUploadPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prapokDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;
            //bool mulprapok = (bool)prapokDataGridView.Rows[row_index].Cells[mulPrapokColumn].Value;
            //bool Onulipi = (bool)prapokDataGridView.Rows[row_index].Cells[onulipiColumn].Value;
            //  if(e.ColumnIndex==prapokDataGridView.Columns["mul_prapok"].Index)
            if (e.ColumnIndex == mulPrapokColumn)
            {
                SaveMulPrapok(row_index);
            }
            else if (e.ColumnIndex == onulipiColumn)
            {
                SaveOnulipiPrapok(row_index);
            }

            prapokDataGridView.Refresh();
        }

        private void officerSearchXTextBox_TextChanged(object sender, EventArgs e)
        {

            var prapokList = prapokDataGridView.DataSource;

            List<ViewDesignationSealList> designationSealListsinGridView = (List<ViewDesignationSealList>)prapokList;
            List<ViewDesignationSealList> NewViewDesignationSealLists = new List<ViewDesignationSealList>();


            if (officerSearchXTextBox.Text == "")
            {
                PopulateGrid();
            }
            else
            {
                foreach (var des in designationSealListsinGridView)
                {
                    if (des.designation.StartsWith(officerSearchXTextBox.Text)|| des.employee_name_bng.StartsWith(officerSearchXTextBox.Text))
                    {
                        NewViewDesignationSealLists.Add(des);
                    }

                }
                prapokDataGridView.DataSource = null;
                prapokDataGridView.DataSource = NewViewDesignationSealLists.ToList();
            }

           
                
                }

        private void ownOfficeButton_Click_1(object sender, EventArgs e)
        {
            NijOffice = false;
            PopulateGrid();
        }

        private void senderSearchButton_Click(object sender, EventArgs e)
        {
            senderSortSidePanel.Visible = true;
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            senderSortSidePanel.Visible = false;
        }

        private void fileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
        }
    }
}
