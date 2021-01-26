using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NoteViewNotInCurrentDesk : UserControl
    {
        public NoteViewNotInCurrentDesk()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }
        private string _totalNothi;
        private string _noteSubject;
        [Category("Custom Props")]
        public string totalNothi
        {
            get { return _totalNothi; }
            set { _totalNothi = value; lbTotalNothi.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
        }
    }
}
