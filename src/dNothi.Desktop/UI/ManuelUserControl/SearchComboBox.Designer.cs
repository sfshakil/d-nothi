namespace dNothi.Desktop.UI.ManuelUserControl
{
    partial class SearchComboBox
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
            this.searchPanel.SuspendLayout();
            this.searchBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.AutoSize = true;
            this.searchPanel.Controls.Add(this.searchListBox);
            this.searchPanel.Controls.Add(this.searchBoxPanel);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 32);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(5);
            this.searchPanel.Size = new System.Drawing.Size(148, 90);
            this.searchPanel.TabIndex = 88;
            this.searchPanel.Visible = false;
            this.searchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.searchButton_Paint);
            // 
            // searchListBox
            // 
            this.searchListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchListBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchListBox.FormattingEnabled = true;
            this.searchListBox.ItemHeight = 18;
            this.searchListBox.Location = new System.Drawing.Point(5, 31);
            this.searchListBox.MaximumSize = new System.Drawing.Size(0, 90);
            this.searchListBox.MinimumSize = new System.Drawing.Size(0, 60);
            this.searchListBox.Name = "searchListBox";
            this.searchListBox.Size = new System.Drawing.Size(138, 54);
            this.searchListBox.TabIndex = 32;
            this.searchListBox.Click += new System.EventHandler(this.searchListBox_SelectedIndexChanged);
            this.searchListBox.Enter += new System.EventHandler(this.searchListBox_Enter);
            // 
            // searchBoxPanel
            // 
            this.searchBoxPanel.Controls.Add(this.searchXTextBox);
            this.searchBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBoxPanel.Location = new System.Drawing.Point(5, 5);
            this.searchBoxPanel.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.searchBoxPanel.Name = "searchBoxPanel";
            this.searchBoxPanel.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.searchBoxPanel.Size = new System.Drawing.Size(138, 26);
            this.searchBoxPanel.TabIndex = 34;
            this.searchBoxPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.searchButton_Paint);
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
            this.searchXTextBox.Size = new System.Drawing.Size(134, 19);
            this.searchXTextBox.TabIndex = 33;
            this.searchXTextBox.TextChanged += new System.EventHandler(this.searchXTextBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.searchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchButton.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            this.searchButton.IconColor = System.Drawing.Color.Black;
            this.searchButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.searchButton.IconSize = 15;
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchButton.Location = new System.Drawing.Point(0, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.searchButton.Size = new System.Drawing.Size(148, 32);
            this.searchButton.TabIndex = 35;
            this.searchButton.Text = "ডাকযোগে";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            this.searchButton.Paint += new System.Windows.Forms.PaintEventHandler(this.searchButton_Paint);
            // 
            // SearchComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.searchButton);
            this.MinimumSize = new System.Drawing.Size(120, 0);
            this.Name = "SearchComboBox";
            this.Size = new System.Drawing.Size(148, 145);
            this.searchPanel.ResumeLayout(false);
            this.searchBoxPanel.ResumeLayout(false);
            this.searchBoxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.ListBox searchListBox;
        private FontAwesome.Sharp.IconButton searchButton;
        private System.Windows.Forms.Panel searchBoxPanel;
        private XTextBox searchXTextBox;
    }
}
