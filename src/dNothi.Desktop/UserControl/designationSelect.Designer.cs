namespace dNothi.Desktop
{
    partial class designationSelect
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.logoutButton = new FontAwesome.Sharp.IconButton();
            this.profileButton = new FontAwesome.Sharp.IconButton();
            this.helpDeskButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.designationRowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "পদবি নির্বাচন করুন";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 1);
            this.label2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.designationRowTableLayoutPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 71);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.logoutButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.profileButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.helpDeskButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(368, 41);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // logoutButton
            // 
            this.logoutButton.AutoSize = true;
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.logoutButton.ForeColor = System.Drawing.Color.White;
            this.logoutButton.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.logoutButton.IconColor = System.Drawing.Color.White;
            this.logoutButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logoutButton.IconSize = 20;
            this.logoutButton.Location = new System.Drawing.Point(226, 0);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.logoutButton.Size = new System.Drawing.Size(142, 41);
            this.logoutButton.TabIndex = 71;
            this.logoutButton.Text = "লগ আউট ";
            this.logoutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MyToolTip.SetToolTip(this.logoutButton, "লগ আউট ");
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // profileButton
            // 
            this.profileButton.AutoSize = true;
            this.profileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.profileButton.FlatAppearance.BorderSize = 0;
            this.profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.profileButton.ForeColor = System.Drawing.Color.White;
            this.profileButton.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.profileButton.IconColor = System.Drawing.Color.White;
            this.profileButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.profileButton.IconSize = 20;
            this.profileButton.Location = new System.Drawing.Point(0, 0);
            this.profileButton.Margin = new System.Windows.Forms.Padding(0);
            this.profileButton.Name = "profileButton";
            this.profileButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.profileButton.Size = new System.Drawing.Size(108, 41);
            this.profileButton.TabIndex = 69;
            this.profileButton.Text = "প্রোফাইল";
            this.profileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MyToolTip.SetToolTip(this.profileButton, "প্রোফাইল ");
            this.profileButton.UseVisualStyleBackColor = false;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // helpDeskButton
            // 
            this.helpDeskButton.AutoSize = true;
            this.helpDeskButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(183)))), ((int)(((byte)(175)))));
            this.helpDeskButton.FlatAppearance.BorderSize = 0;
            this.helpDeskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpDeskButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.helpDeskButton.ForeColor = System.Drawing.Color.White;
            this.helpDeskButton.IconChar = FontAwesome.Sharp.IconChar.UserAstronaut;
            this.helpDeskButton.IconColor = System.Drawing.Color.White;
            this.helpDeskButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.helpDeskButton.IconSize = 20;
            this.helpDeskButton.Location = new System.Drawing.Point(108, 0);
            this.helpDeskButton.Margin = new System.Windows.Forms.Padding(0);
            this.helpDeskButton.Name = "helpDeskButton";
            this.helpDeskButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.helpDeskButton.Size = new System.Drawing.Size(118, 41);
            this.helpDeskButton.TabIndex = 70;
            this.helpDeskButton.Text = "হেল্প ডেস্ক ";
            this.helpDeskButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MyToolTip.SetToolTip(this.helpDeskButton, "হেল্প ডেস্ক ");
            this.helpDeskButton.UseVisualStyleBackColor = false;
            this.helpDeskButton.Click += new System.EventHandler(this.helpDeskButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 30);
            this.panel1.TabIndex = 0;
            // 
            // designationRowTableLayoutPanel
            // 
            this.designationRowTableLayoutPanel.AutoSize = true;
            this.designationRowTableLayoutPanel.ColumnCount = 1;
            this.designationRowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.designationRowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.designationRowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.designationRowTableLayoutPanel.Location = new System.Drawing.Point(3, 39);
            this.designationRowTableLayoutPanel.Name = "designationRowTableLayoutPanel";
            this.designationRowTableLayoutPanel.RowCount = 1;
            this.designationRowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.designationRowTableLayoutPanel.Size = new System.Drawing.Size(382, 0);
            this.designationRowTableLayoutPanel.TabIndex = 15;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // designationSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "designationSelect";
            this.Size = new System.Drawing.Size(485, 88);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton profileButton;
        private FontAwesome.Sharp.IconButton logoutButton;
        private System.Windows.Forms.ToolTip MyToolTip;
        private FontAwesome.Sharp.IconButton helpDeskButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel designationRowTableLayoutPanel;
    }
}
