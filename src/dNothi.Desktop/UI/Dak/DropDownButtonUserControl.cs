using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DropDownButtonUserControl : UserControl
    {
        public DropDownButtonUserControl()
        {
            InitializeComponent();
        }
        private string _buttontext;
        public string ButtonText { get { return _buttontext; }


            set { _buttontext = value;daptorikDakUploadButton.Text = "-"+value; }
                
                }
    }
}
