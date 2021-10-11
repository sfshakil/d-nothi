using dNothi.JsonParser.Entity;
using dNothi.Utility;
using System;
using System.Collections;
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
    public partial class ReportCategoryRowUserControl : UserControl
    {
        public ReportCategoryRowUserControl()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }
        public void setResponse(ReportCategoryData response)
        {
            serialNumber = response.serialNumber.ToString();
            category = response.name;
            reportSerialNumber = response.serial.ToString();
            id = response.id;

            string str = response.offices.ToString();
            IList collection = (IList)response.offices;
            bool f = str.Contains("\"-\"");
            if (f)
            {
                bool f1 = str.Contains(",");
                if (f1)
                {
                    officeNo = collection.Count.ToString();
                }
                else
                {
                    officeNo = "0";
                }
                
            }
            else{
                officeNo =  collection.Count.ToString();
            }
        }
        public void setLocalData(string category_name)
        {
            category = category_name;
            btnSchedule.Visible = true;
            ReportCategoryEditButton.Visible = false;
            ReportCategoryDeleteButton.Visible = false;
        }
        private string _serialNumber;
        private string _reportSerialNumber;
        private string _category;
        private string _officeNo;
        private int  _id;
        public string serialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; SerialNumberLabel.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public string category
        {
            get { return _category; }
            set { _category = value; CategoryLabel.Text = value; }
        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string reportSerialNumber
        {
            get { return _reportSerialNumber; }
            set { _reportSerialNumber = value; ReportSerialNumberTextBox.Text = value; }
        }
        public string officeNo
        {
            get { return _officeNo; }
            set { _officeNo = value; OfficeNoLabel.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        private void ReportSerialNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            reportSerialNumber = ReportSerialNumberTextBox.Text;
        }

        private void ReportCategoryEditButton_Click(object sender, EventArgs e)
        {
            CategoryLabel.Visible = false;
            ReportCategoryEditButton.Visible = false;
            ReportCategoryDeleteButton.Visible = false;
            ReportCategoryTextBox.Visible = true;
            EditSaveButton.Visible = true;
            EditCancelButton.Visible = true;

            ReportCategoryTextBox.Text = CategoryLabel.Text;

        }

        private void EditCancelButton_Click(object sender, EventArgs e)
        {
            CategoryLabel.Visible = true;
            ReportCategoryEditButton.Visible = true;
            ReportCategoryDeleteButton.Visible = true;

            ReportCategoryTextBox.Visible = false;
            EditSaveButton.Visible = false;
            EditCancelButton.Visible = false;
        }
        public event EventHandler btnEditSaveClick;
        public event EventHandler btnDeleteClick;
        private void EditSaveButton_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                ReportCategoryAddData reportCategoryAddData = new ReportCategoryAddData();
                reportCategoryAddData.type = "add";
                reportCategoryAddData.category_id = id.ToString();
                reportCategoryAddData.category_name = ReportCategoryTextBox.Text;
                reportCategoryAddData.serial = Convert.ToInt32(ReportSerialNumberTextBox.Text);
                if (this.btnEditSaveClick != null)
                {
                    this.btnEditSaveClick(reportCategoryAddData, e);
                }
            }
            else
            {
                ReportCategoryAddData reportCategoryAddData = new ReportCategoryAddData();
                reportCategoryAddData.type = "add";
                reportCategoryAddData.category_id = id.ToString();
                reportCategoryAddData.category_name = ReportCategoryTextBox.Text;
                reportCategoryAddData.serial = Convert.ToInt32(ReportSerialNumberTextBox.Text);
                if (this.btnEditSaveClick != null)
                {
                    this.btnEditSaveClick(reportCategoryAddData, e);
                }
                EditCancelButton_Click(null,null);
            }
            
        }

        private void ReportCategoryDeleteButton_Click(object sender, EventArgs e)
        {
            
            if (InternetConnection.Check())
            {
                ReportCategoryAddData reportCategoryAddData = new ReportCategoryAddData();

                reportCategoryAddData.type = "delete";
                reportCategoryAddData.category_id = id.ToString();
                reportCategoryAddData.category_name = CategoryLabel.Text;

                if (this.btnDeleteClick != null)
                {
                    this.btnDeleteClick(reportCategoryAddData, e);
                }
            }
            else
            {
                this.Hide();
                ReportCategoryAddData reportCategoryAddData = new ReportCategoryAddData();

                reportCategoryAddData.type = "delete";
                reportCategoryAddData.category_id = id.ToString();
                reportCategoryAddData.category_name = CategoryLabel.Text;

                if (this.btnDeleteClick != null)
                {
                    this.btnDeleteClick(reportCategoryAddData, e);
                }
            }
        }
    }
}
