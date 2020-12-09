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
    public partial class DakSendUserControl : UserControl
    {
        List<string> PriorityListCollection = new List<string>();
        List<string> SecurityListCollection = new List<string>();
        public DakSendUserControl()
        {
            InitializeComponent();
            PriorityListCollection.Clear();

            foreach(string str in dakPriorityListBox.Items)
            {
                PriorityListCollection.Add(str);
            }

            SecurityListCollection.Clear();
            foreach (string str in securityLevelListBox.Items)
            {
                SecurityListCollection.Add(str);
            }

        }

        private void prioritySearchXTextBox_TextChanged(object sender, EventArgs e)
        {
            dakPriorityListBox.Items.Clear();
            if(prioritySearchXTextBox.Text=="")
            {
                foreach(string str in PriorityListCollection)
                {
                    dakPriorityListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in PriorityListCollection)
                {
                    if(str.StartsWith(prioritySearchXTextBox.Text))
                    {
                        dakPriorityListBox.Items.Add(str);
                    }
                   
                }
             
            }
        }

        private void prioritySearchButton_Click(object sender, EventArgs e)
        {
            if(prioritySearchPanel.Visible)
            {
                prioritySearchPanel.Visible = false;
            }
            else
            {
                prioritySearchPanel.Visible = true;
            }
        }

        private void dakPriorityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            prioritySearchPanel.Visible = false;
            prioritySearchButton.Text = dakPriorityListBox.GetItemText(dakPriorityListBox.SelectedItem);
        }

        private void nothivuktoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = nothivuktoRadioButton.Text;
        }

        private void NothijatoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = NothijatoRadioButton.Text;
        }

        private void decisionOwnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = decisionComboBox.SelectedItem.ToString();
        }

        private void secretLevelSearchButton_Click(object sender, EventArgs e)
        {
            if (dakSecurityLevelPanel.Visible)
            {
                dakSecurityLevelPanel.Visible = false;
            }
            else
            {
                dakSecurityLevelPanel.Visible = true;
            }
        }

        private void securityLevelXTextBox_TextChanged(object sender, EventArgs e)
        {
            securityLevelListBox.Items.Clear();
            if (securityLevelXTextBox.Text == "")
            {
                foreach (string str in SecurityListCollection)
                {
                    securityLevelListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in SecurityListCollection)
                {
                    if (str.StartsWith(securityLevelXTextBox.Text))
                    {
                        securityLevelListBox.Items.Add(str);
                    }

                }

            }
        }

        private void securityLevelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dakSecurityLevelPanel.Visible = false;
            secretLevelSearchButton.Text = securityLevelListBox.GetItemText(securityLevelListBox.SelectedItem);
        }

        private void decisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            decisionXTextBox.Text = decisionComboBox.SelectedItem.ToString();
        }
    }
}
