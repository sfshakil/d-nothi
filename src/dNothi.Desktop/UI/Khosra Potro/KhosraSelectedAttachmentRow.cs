using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraSelectedAttachmentRow : UserControl
    {
        public KhosraSelectedAttachmentRow()
        {
            InitializeComponent();
        }

       
        public int _id { get; set; }
        public int id { get { return _id; } set { _id = value; } }

        public string _fileName { get; set; }
        public string fileName { get { return _fileName; } set { _fileName = value; attachmentNameLabel.Text = value; } }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.Hide();

         

        }

        private void TableBorderColor(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void TableBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }
    }
}
