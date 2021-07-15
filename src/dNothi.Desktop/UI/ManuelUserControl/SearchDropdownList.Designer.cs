
namespace dNothi.Desktop.UI.ManuelUserControl
{
    partial class SearchDropdownList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchListBox = new System.Windows.Forms.ListBox();
            this.searchBoxPanel = new System.Windows.Forms.Panel();
            this.searchXTextBox = new dNothi.Desktop.XTextBox();
            this.searchButton = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.searchPanel.SuspendLayout();
            this.searchBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.AutoSize = true;
            this.searchPanel.Controls.Add(this.searchListBox);
            this.searchPanel.Controls.Add(this.searchBoxPanel);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(0, 33);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(5);
            this.searchPanel.Size = new System.Drawing.Size(262, 216);
            this.searchPanel.TabIndex = 90;
            this.searchPanel.Visible = false;
            // 
            // searchListBox
            // 
            this.searchListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchListBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchListBox.FormattingEnabled = true;
            this.searchListBox.ItemHeight = 21;
            this.searchListBox.Items.AddRange(new object[] {
            "hadvgba",
            "askhndlas",
            "asnjdaslk",
            "knbadj",
            "asadnlkadna",
            "aknbfa",
            "kabnflad",
            "kabfla",
            "abnflkaak",
            "kabfjlas",
            "kbaslbas",
            "kasbf;as"});
            this.searchListBox.Location = new System.Drawing.Point(5, 37);
            this.searchListBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.searchListBox.Name = "searchListBox";
            this.searchListBox.Size = new System.Drawing.Size(252, 174);
            this.searchListBox.TabIndex = 32;
            this.searchListBox.SelectedIndexChanged += new System.EventHandler(this.searchListBox_SelectedIndexChanged);
            // 
            // searchBoxPanel
            // 
            this.searchBoxPanel.Controls.Add(this.searchXTextBox);
            this.searchBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBoxPanel.Location = new System.Drawing.Point(5, 5);
            this.searchBoxPanel.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.searchBoxPanel.Name = "searchBoxPanel";
            this.searchBoxPanel.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.searchBoxPanel.Size = new System.Drawing.Size(252, 32);
            this.searchBoxPanel.TabIndex = 34;
            this.searchBoxPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.searchBoxPanel_Paint);
            // 
            // searchXTextBox
            // 
            this.searchXTextBox.BackColor = System.Drawing.Color.White;
            this.searchXTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchXTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchXTextBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchXTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchXTextBox.Location = new System.Drawing.Point(2, 5);
            this.searchXTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.searchXTextBox.Name = "searchXTextBox";
            this.searchXTextBox.Size = new System.Drawing.Size(248, 22);
            this.searchXTextBox.TabIndex = 33;
            this.searchXTextBox.TextChanged += new System.EventHandler(this.searchXTextBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchButton.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            this.searchButton.IconColor = System.Drawing.Color.Black;
            this.searchButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.searchButton.IconSize = 15;
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchButton.Location = new System.Drawing.Point(0, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.searchButton.Size = new System.Drawing.Size(262, 33);
            this.searchButton.TabIndex = 89;
            this.searchButton.Text = "ডাকযোগে";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            this.searchButton.Paint += new System.Windows.Forms.PaintEventHandler(this.searchButton_Paint);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(222, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(18, 22);
            this.iconButton1.TabIndex = 34;
            this.iconButton1.Text = "x";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Visible = false;
            // 
            // SearchDropdownList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.searchButton);
            this.Name = "SearchDropdownList";
            this.Size = new System.Drawing.Size(262, 249);
            this.searchPanel.ResumeLayout(false);
            this.searchBoxPanel.ResumeLayout(false);
            this.searchBoxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.ListBox searchListBox;
        private System.Windows.Forms.Panel searchBoxPanel;
        private XTextBox searchXTextBox;
        private FontAwesome.Sharp.IconButton searchButton;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}
