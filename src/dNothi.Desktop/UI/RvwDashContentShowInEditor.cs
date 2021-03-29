using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class RvwDashContentShowInEditor : Form
    {
        public RvwDashContentShowInEditor()
        {
            InitializeComponent();
            khosraViewWebBrowser.Url = new Uri("https://dev.nothibs.tappware.com/api/content/view?token=NjA2MGU5ZTdhNmJjOCZvZmZpY2VJZF82NV80MDA%3D");
        }
    }
}
