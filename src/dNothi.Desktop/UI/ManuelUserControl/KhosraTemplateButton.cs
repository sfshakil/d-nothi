using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Khosra;

namespace dNothi.Desktop.UI.ManuelUserControl
{
    public partial class KhosraTemplateButton : UserControl
    {
        public KhosraTemplateButton()
        {
            InitializeComponent();
        }


        public KhasraPotroTemplateDataDTO _khasraPotroTemplateData { get; set; }
        public KhasraPotroTemplateDataDTO khasraPotroTemplateData { get { return _khasraPotroTemplateData; } set { _khasraPotroTemplateData = value; TemplateNameText.Text = value.template_name; } }
       




        public string _templateName { get; set; }
        public string templateName { get { return _templateName; } set { _templateName = value; TemplateNameText.Text = value; } }





        public event EventHandler TemplateClick;
        private void khosraTemplatePictureBox_Click(object sender, EventArgs e)
        {
            if (this.TemplateClick != null)
                this.TemplateClick(sender, e);
        }

        private void KhosraTemplateButton_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Gainsboro;
        }

        private void KhosraTemplateButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
