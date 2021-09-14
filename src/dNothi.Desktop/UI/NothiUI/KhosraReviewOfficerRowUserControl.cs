using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class KhosraReviewOfficerRowUserControl : UserControl
    {
        public KhosraReviewOfficerRowUserControl()
        {
            InitializeComponent();
            permissionComboBox.DataSource = getPermission();
            permissionComboBox.DisplayMember = "Name";
            permissionComboBox.ValueMember = "Id";
        }


        public bool Hide { get; set; }

        private List<ComboBoxItem> getPermission()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
       
            comboBoxItems.Add(new ComboBoxItem("সম্পাদনা", 1));
           
            comboBoxItems.Add(new ComboBoxItem("দেখা", 2));
           
            return comboBoxItems;
        }

        private string _permission { get; set; }
        public string permission { get=> _permission; 
            set { _permission = value; 
                  if(value=="read")
                    {
                    permissionComboBox.SelectedValue = 2;
                    }
                    if(value=="write")
                    {
                        permissionComboBox.SelectedValue = 1;
                    }
            } 
        }
        private string _officerName { get; set; }
        public string officerName { get { return _officerName; } set { _officerName = value; officerNameLabel.Text = value; } }

        private string _designation { get; set; }
        public string designation { get { return _designation; } set { _designation = value; designationLabel.Text = value; } }

        private int _designationId { get; set; }
        public int designationId { get { return _designationId; } set { _designationId = value; } }


        private string _officeName { get; set; }
        public string officeName { get { return _officeName; } set { _officeName = value; officeUnitLabel.Text = value; } }


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]

        public event EventHandler DeleteButtonClick;
        private void deleteButton_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি নিশ্চিতভাবে মুছে ফেলতে চান?";
            conditonBoxForm.ShowDialog();

            if (conditonBoxForm.Yes)
            {
                Hide = true;
                if (this.DeleteButtonClick != null)
                    this.DeleteButtonClick(sender, e);
                    this.Hide();
            }
        }

        private void permissionPanel_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
    }
}
