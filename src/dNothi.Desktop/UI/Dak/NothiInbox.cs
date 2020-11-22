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
    public partial class NothiInbox : UserControl
    {
        public NothiInbox()
        {
            InitializeComponent();
        }
        private string _nothi;
        private string _shakha;
        private string _totalnothi;
        private string _lastdate;

        [Category("Custom Props")]
        public string nothi
        {
            get { return _nothi; }
            set { _nothi = value; lbNothi.Text = value; }
        }


        [Category("Custom Props")]
        public string shakha
        {
            get { return _shakha; }
            set { _shakha = value; lbShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string totalnothi
        {
            get { return _totalnothi; }
            set { _totalnothi = value; lbTotalNothi.Text = value; }
        }

        [Category("Custom Props")]
        public string lastdate
        {
            get { return _lastdate; }
            set { _lastdate = value; lbNoteLastDate.Text = value; }
        }

    }
}
