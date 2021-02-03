using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak_List_Inbox;

namespace dNothi.Desktop.UI.Dak
{
    public partial class SelectedDakListUserControl : UserControl
    {
        public SelectedDakListUserControl()
        {
            InitializeComponent();
            _isSelected = true;
        }

        public bool _isSelected;
        public DakUserDTO _dakUserDTO;
        public string _prerok;

        public DakUserDTO dakUserDTO
        {
            get { return _dakUserDTO; }
            set { _dakUserDTO = value;
                subjectLinkLabel.Text = value.dak_subject;
                dateLabel.Text = value.last_movement_date;
            
            
            }
        }

        public string prerok
        {
            get { return _prerok; }
            set
            {
                _prerok = value;
                prerokLabel.Text = value;


            }
        }
        public bool isSelected { get { return _isSelected; } set { _isSelected = value; selectCheckBox.Checked = value; if (value) { hideButton.IconColor = Color.FromArgb(251, 173, 182); } else { hideButton.IconColor = Color.Red; } } }

        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isSelected = selectCheckBox.Checked;
        }





        public event EventHandler DeleteDakFromList;
        private void hideButton_Click(object sender, EventArgs e)
        {
            if(!selectCheckBox.Checked)
            {
                if (this.DeleteDakFromList != null)
                    this.DeleteDakFromList(sender, e);
                this.Hide();
            }
           
        }
    }
}
