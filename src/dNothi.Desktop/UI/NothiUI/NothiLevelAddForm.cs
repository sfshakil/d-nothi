using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.NothiUI
{
    public partial class NothiLevelAddForm : Form
    {
        public NothiLevelAddForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        
        public void SetLevelComboBox(int Level)
        {
            List<ComboBoxItems> comboBoxItems = new List<ComboBoxItems>();
            List<OnumodonLevel> onumodonLevels = new List<OnumodonLevel>();

            comboBoxItems.Add(new ComboBoxItems { id = Level+1, Name = "নতুন লেভেল(উপরে)" });
         


            comboBoxItems.Add(new ComboBoxItems { id = 0, Name = "নতুন লেভেল(নিচে)"});
            
            for (int i = 1; i <= Level; i++)
            {
                onumodonLevels.Add(new OnumodonLevel(i));
            }



            try

            {
                    foreach (OnumodonLevel onumodon in onumodonLevels)
                        {
                            comboBoxItems.Add(new ComboBoxItems { id =onumodon.id, Name = onumodon.Text });
                        }
            }
                
            catch (Exception Ex)
                {
                    
                }
           
            selectLevelComboBox.itemList = comboBoxItems.ToList();
            selectLevelComboBox.isListShown = true;

            selectLevelComboBox.selectedId = Level + 1;
            selectLevelComboBox.isSearchBoxShown(false);



        }

        public int _selectedLevel { get; set; }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler SaveButtonClick;
        private void saveButton_Click(object sender, EventArgs e)
        {

            _selectedLevel = selectLevelComboBox._id;
            if (this.SaveButtonClick != null)
                this.SaveButtonClick(sender, e);
            this.Hide();
        }
    }
}
