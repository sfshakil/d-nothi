using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Xamarin.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class TinyMCE : UserControl
    {
        public TinyMCE()
        {
            InitializeComponent();
        }

        public string HtmlContent
        {
            get
            {
                string content = string.Empty;
                if (webBrowser.Document != null)
                {
                    object html = webBrowser.Document.InvokeScript("GetContent");
                    content = html as string;
                }
                return content;
            }
            set
            {
                if (webBrowser.Document != null)
                {
                    webBrowser.Document.InvokeScript("SetContent", new object[] { value });
                }
            }
        }

        public void CreateEditor()
        {
            string str = AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce\jscripts\tiny_mce\tiny_mce.js")))
            {
                webBrowser.Url = new Uri(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tinymce.htm").Replace('\\', '/'));
            }
            else
            {
                MessageBox.Show("Could not find the tinyMCE script directory. Please ensure the directory is in the same location as tinymce.htm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        
    }
}
