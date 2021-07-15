using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.ManuelUserControl
{
    public partial class SearchDropdownList : UserControl
    {
        public SearchDropdownList()
        {
            InitializeComponent();
        }

       

        private void searchBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Gray(sender, e);
        }


        public List<ComboBoxItems> _itemList;
        public string _selectedString;
        public int _id;
        public bool _isListShown;
        public int _height;

        public int height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                this.height = value;
                
            }
        }
        public List<ComboBoxItems> itemList
        {
            get { return _itemList; }
            set
            {
                _itemList = value;

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
        public int selectedId
        {
            get { return _id; }
            set
            {
                _id = value;

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

                searchPanel.Visible = true;
                searchPanel.BringToFront();
                searchPanel.Focus();
                searchXTextBox.Focus();
            }
        }

        private void searchXTextBox_TextChanged(object sender, EventArgs e)
        {
            searchListBox.DataSource = null;
            if (searchXTextBox.Text == "")
            {

                searchListBox.Visible = false;

            }
            else
            {

                List<ComboBoxItems> items = _itemList.Where(a => a.Name.Contains(searchXTextBox.Text)).ToList();




                if (items.Count > 0)
                {
                    searchListBox.DisplayMember = "Name";
                    searchListBox.DataSource = null;
                    searchListBox.DataSource = items;

                    searchListBox.Visible = true;
                }
                else
                {
                    searchListBox.Visible = false;

                }

            }
        }

        public event EventHandler ChangeSelectedIndex;
        private void searchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                _id = (searchListBox.SelectedItem as ComboBoxItems).id;

                if (this.ChangeSelectedIndex != null)
                    this.ChangeSelectedIndex(sender, e);

            }
            catch (Exception Ex)
            {
                _id = 0;
            }


            searchPanel.Visible = false;
            searchButtonText = searchListBox.GetItemText(searchListBox.SelectedItem);

        }

        private void searchButton_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void SearchUserController_Load(object sender, EventArgs e)
        {
        }

        private void searchListBox_MouseEnter(object sender, ListViewItemMouseHoverEventArgs e)
        {
            e.Item.BackColor = Color.Green;
        }

        private void searchListBox_Enter(object sender, EventArgs e)
        {
            //(sender as ListView).SelectedIndices.c
        }
        public bool isListShown
        {
            get { return _isListShown; }
            set
            {
                _isListShown = isListShown;
                if (value)
                {
                    string btnText = searchButton.Text;

                    searchListBox.DataSource = null;
                    if(_itemList.Count>15)
                    {
                        searchListBox.DataSource = _itemList.Take(15);
                    }
                    else
                    {
                        searchListBox.DataSource = _itemList;
                    }
                    
                    searchListBox.DisplayMember = "Name";
                    searchListBox.ValueMember = "id";
                    searchButtonText = btnText;
                    _id = 0;

                }
            }

        }
        public void isSearchBoxShown(bool decision)
        {
            if (decision)
            {
                searchBoxPanel.Visible = true;
            }
            else
            {
                searchBoxPanel.Visible = false;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }


    
}

