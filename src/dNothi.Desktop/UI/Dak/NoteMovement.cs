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
    public partial class NoteMovement : UserControl
    {
        public NoteMovement()
        {
            InitializeComponent();
        }

        private string _date;
        private string _formName;
        private string _formDesignation;
        private string _toName;
        private string _toDesignation;
        private string _thumb;
        private int _movement_type;

        [Category("Custom Props")]
        public string date
        {
            get { return _date; }
            set { _date = value; lbDate.Text = value; }
        }
        public string formName
        {
            get { return _formName; }
            set { _formName = value; lbFromName.Text = value; }
        }public string formDesignation
        {
            get { return _formDesignation; }
            set { _formDesignation = value; lbFromDesignation.Text = value; }
        }public string toName
        {
            get { return _toName; }
            set { _toName = value; lbToName.Text = value; }
        }public string toDesignation
        {
            get { return _toDesignation; }
            set { _toDesignation = value; lbToDesignatoim.Text = value; }
        }public string thumb
        {
            get { return _thumb; }
            set { _thumb = value; 
                if (value != "") 
                { 
                    cPBthumb.Load(value); 
                    cPBthumb.SizeMode = PictureBoxSizeMode.StretchImage;
                    cPBthumb.Size = new Size(50,50);
                } 
            }
        }
        public int movement_type
        {
            get { return _movement_type; }
            set { _movement_type = value;
                if (_movement_type == 2)
                {
                    btnArrow.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
                    btnArrow.IconColor = Color.FromArgb(255, 168, 0);
                    MyToolTip.SetToolTip(btnArrow, "নথি ফেরত আনা হয়েছে");
                }
            }
        }
    }
}
