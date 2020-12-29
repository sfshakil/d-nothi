namespace dNothi.Desktop.UI.Dak
{
    partial class SearchUserController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchUserController));
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchListBox = new System.Windows.Forms.ListBox();
            this.searchXTextBox = new dNothi.Desktop.XTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.AutoSize = true;
            this.searchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPanel.Controls.Add(this.searchListBox);
            this.searchPanel.Controls.Add(this.panel1);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 32);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(148, 110);
            this.searchPanel.TabIndex = 88;
            this.searchPanel.Visible = false;
            // 
            // searchListBox
            // 
            this.searchListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchListBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchListBox.FormattingEnabled = true;
            this.searchListBox.ItemHeight = 18;
            this.searchListBox.Location = new System.Drawing.Point(0, 36);
            this.searchListBox.Name = "searchListBox";
            this.searchListBox.Size = new System.Drawing.Size(146, 72);
            this.searchListBox.TabIndex = 32;
            this.searchListBox.SelectedIndexChanged += new System.EventHandler(this.searchListBox_SelectedIndexChanged);
            // 
            // searchXTextBox
            // 
            this.searchXTextBox.BackColor = System.Drawing.Color.White;
            this.searchXTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchXTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchXTextBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchXTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchXTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchXTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.searchXTextBox.Multiline = true;
            this.searchXTextBox.Name = "searchXTextBox";
            this.searchXTextBox.Size = new System.Drawing.Size(146, 36);
            this.searchXTextBox.TabIndex = 33;
            this.searchXTextBox.TextChanged += new System.EventHandler(this.searchXTextBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = true;
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchButton.Location = new System.Drawing.Point(0, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(148, 32);
            this.searchButton.TabIndex = 89;
            this.searchButton.Text = "ডাকযোগে";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            this.searchButton.Paint += new System.Windows.Forms.PaintEventHandler(this.searchButton_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchXTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 36);
            this.panel1.TabIndex = 34;
            // 
            // SearchUserController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.searchButton);
            this.MinimumSize = new System.Drawing.Size(120, 0);
            this.Name = "SearchUserController";
            this.Size = new System.Drawing.Size(148, 142);
            this.Load += new System.EventHandler(this.SearchUserController_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.searchButton_Paint);
            this.searchPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.ListBox searchListBox;
        private XTextBox searchXTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel panel1;
    }
}
