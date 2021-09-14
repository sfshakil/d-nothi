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
    public partial class SearchUserController : UserControl
    {
        string[] _listboxcollection;
        public string _selectedString;
      
        public SearchUserController()
        {
            InitializeComponent();
            
        }

        public string[] listboxcollection
        {
            get { return _listboxcollection; }
            set
            {
                _listboxcollection = value;
                try
                {
                    foreach (string str in _listboxcollection)
                    {
                        searchListBox.Items.Add(str);
                    }
                }
                catch(Exception Ex)
                {

                }
            }
        }

        public string searchButtonText
        {
            get { return _selectedString; }
            set
            {
                _selectedString = value;
                searchButton.Text = value;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchPanel.Visible)
            {
                searchPanel.Visible = false;
            }
            else
            {
                searchPanel.BringToFront();
                searchPanel.Visible = true;
                searchXTextBox.Focus();
            }
        }

        private void searchXTextBox_TextChanged(object sender, EventArgs e)
        {
            searchListBox.Items.Clear();
            if (searchXTextBox.Text == "")
            {
                foreach (string str in _listboxcollection)
                {
                    searchListBox.Items.Add(str);
                }
            }
            else
            {
                foreach (string str in _listboxcollection)
                {
                    if (str.StartsWith(searchXTextBox.Text))
                    {
                        searchListBox.Items.Add(str);
                    }

                }

            }
        }

        private void searchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchPanel.Visible = false;
            searchButton.Text = searchListBox.GetItemText(searchListBox.SelectedItem);
            _selectedString = searchListBox.GetItemText(searchListBox.SelectedItem);
        }

        private void searchButton_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void SearchUserController_Load(object sender, EventArgs e)
        {
                }

        private void SearchUserController_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchListBox_MouseEnter(object sender, ListViewItemMouseHoverEventArgs e)
        {
            e.Item.BackColor = Color.Green;
        }

        private void searchListBox_MouseEnter(object sender, EventArgs e)
        {
           
        }
    }
}
