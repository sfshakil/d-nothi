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
    public partial class MultipleSelectedDakListRow : UserControl
    {
        public MultipleSelectedDakListRow()
        {
            InitializeComponent();
            _isSelected = true;
            _isDeleted = false;
        }

        public bool _isSelected;
        public bool _isDeleted;
        public DakUserDTO _dakUserDTO;
        public string _prerok;
      

        public DakUserDTO dakUserDTO
        {
            get { return _dakUserDTO; }
            set
            {
                _dakUserDTO = value;
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


        public bool isSelected { get { return _isSelected; } set { _isSelected = value; hideButton.Enabled = !value; } }

        




        public event EventHandler DeleteDakFromList;
        private void hideButton_Click(object sender, EventArgs e)
        {
            _isDeleted = true;
            if (this.DeleteDakFromList != null)
                this.DeleteDakFromList(sender, e);
            this.Hide();
        }

       
    }
}
