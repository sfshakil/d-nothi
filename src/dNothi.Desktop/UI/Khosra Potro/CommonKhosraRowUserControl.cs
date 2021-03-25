using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Utility;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class CommonKhosraRowUserControl : UserControl
    {
        public CommonKhosraRowUserControl()
        {
            InitializeComponent();
        }


        public string _sharokNo { get; set; }
        public string sharokNo { get { return _sharokNo; } set { _sharokNo = value; sharokNoLabel.Text = value; if (value == "") { sharokNoFlowLayoutPanel.Visible = false; } } }
        public string sharokNoEng { get { return _sharokNo; } set { _sharokNo = value; sharokNoLabel.Text = ConversionMethod.EnglishNumberToBangla(value); if (value == "") { sharokNoFlowLayoutPanel.Visible = false; } } }




        public string _sub { get; set; }
        public string sub { get { return _sub; } set { _sub = value; subLabel.Text = value; } }

        public string _date { get; set; }
        public string date { get { return _date; } set { _date = value; dateLabel.Text = value; } }


        public int _noteCount { get; set; }
        public int noteCount { get { return _noteCount; } set { _noteCount = value; noteCountLabel.Text = "নোট : "+ ConversionMethod.EnglishNumberToBangla(value.ToString()); } }





        public void ButtonVisibility(bool edit, bool attachment, bool details, bool onumodon)
        {
            editButton.Visible = edit;
            attachmentButton.Visible = attachment;
            eyeButton.Visible = details;
            onumodonButton.Visible = onumodon;
            
        }






        public bool _isDraft{get;set;}
        public bool isDraft{ get { return _isDraft; }
            set { _isDraft = value;
            if(value)
                {
                    noteCountLabel.Visible = false;
                    sharokNoFlowLayoutPanel.Visible = false;
                }
            
            }
        
        }
    }
}
