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
    public partial class MultipleDakActionResultDakRowUserControl : UserControl
    {
        public MultipleDakActionResultDakRowUserControl()
        {
            InitializeComponent();
        }

       
        public DakUserDTO _dakUserDTO;
        public string _prerok;
        public string _error;

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

        public string error
        {
            get { return _error; }
            set
            {
                _error = value;
                errorLabel.Text = value;


            }
        }



    }
}
