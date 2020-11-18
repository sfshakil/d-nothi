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
    public partial class NothiAll : UserControl
    {
        public NothiAll()
        {
            InitializeComponent();
        }

        private string _nothi;
        private string _shakha;
        private string _desk;
        private int _noteTotal;
        private int _permitted;
        public int _onishponno;
        public int _nishponno;
        public int _archived;
        public string _noteLastDate;


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
        public string desk
        {
            get { return _desk; }
            set { _desk = value; lbDesk.Text = value; }
        }
        //public int id
        //{
        //    get { return _id; }
        //    set { _id = value;}
        //}
        [Category("Custom Props")]
        public int noteTotal
        {
            get { return _noteTotal; }
            set { _noteTotal = value; lbNoteTotal.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public int permitted
        {
            get { return _permitted; }
            set { _permitted = value; lbPermitted.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public int onishponno
        {
            get { return _onishponno; }
            set { _onishponno = value; lbOnishponno.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public int nishponno
        {
            get { return _nishponno; }
            set { _nishponno = value; lbNishponno.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public int archived
        {
            get { return _archived; }
            set { _archived = value; lbArchived.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public string noteLastDate
        {
            get { return _noteLastDate; }
            set { _noteLastDate = value; lbNoteLastDate.Text = value; }
        }

    }
}
