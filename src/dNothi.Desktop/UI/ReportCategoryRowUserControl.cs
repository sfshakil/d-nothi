using dNothi.JsonParser.Entity;
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
        private string _serialNumber;
        private string _reportSerialNumber;
        private string _category;
        private string _officeNo;
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
    }
}
