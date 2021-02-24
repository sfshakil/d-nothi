namespace dNothi.Desktop.UI.Dak
{
    partial class DetailsAttachmentUserControl
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
            this.attachmentSizeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainAttachmentIconPanel = new System.Windows.Forms.Panel();
            this.attachmentNameLabel = new System.Windows.Forms.LinkLabel();
            this.attchmentTypePanel = new System.Windows.Forms.Panel();
            this.downloadButton = new FontAwesome.Sharp.IconButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.shareButton = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachmentSizeLabel
            // 
            this.attachmentSizeLabel.AutoSize = true;
            this.attachmentSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.attachmentSizeLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentSizeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.attachmentSizeLabel.Location = new System.Drawing.Point(44, 22);
            this.attachmentSizeLabel.Name = "attachmentSizeLabel";
            this.attachmentSizeLabel.Size = new System.Drawing.Size(52, 18);
            this.attachmentSizeLabel.TabIndex = 2;
            this.attachmentSizeLabel.Text = "১৭৩৬.৫";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.mainAttachmentIconPanel);
            this.panel1.Controls.Add(this.attachmentNameLabel);
            this.panel1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(43, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 21);
            this.panel1.TabIndex = 3;
            // 
            // mainAttachmentIconPanel
            // 
            this.mainAttachmentIconPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainAttachmentIconPanel.BackgroundImage = global::dNothi.Desktop.Properties.Resources.mulpotro;
            this.mainAttachmentIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainAttachmentIconPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainAttachmentIconPanel.Location = new System.Drawing.Point(690, 0);
            this.mainAttachmentIconPanel.Name = "mainAttachmentIconPanel";
            this.mainAttachmentIconPanel.Size = new System.Drawing.Size(34, 21);
            this.mainAttachmentIconPanel.TabIndex = 2;
            // 
            // attachmentNameLabel
            // 
            this.attachmentNameLabel.AutoSize = true;
            this.attachmentNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.attachmentNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentNameLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.attachmentNameLabel.Location = new System.Drawing.Point(0, 0);
            this.attachmentNameLabel.MaximumSize = new System.Drawing.Size(700, 0);
            this.attachmentNameLabel.Name = "attachmentNameLabel";
            this.attachmentNameLabel.Size = new System.Drawing.Size(690, 36);
            this.attachmentNameLabel.TabIndex = 6;
            this.attachmentNameLabel.TabStop = true;
            this.attachmentNameLabel.Text = "ই-ফাইল ব্যবহার সহায়িকা-১(লগইন প্রক্রিয়া ও প্রোফাইল ব্যবস্থাপনা) (1).pdf dbghasdgb" +
    "vhas hgsahdgvashghsahasgdhasd hasgdh hsagdhas ";
            this.attachmentNameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.attachmentNameLabel_LinkClicked);
            // 
            // attchmentTypePanel
            // 
            this.attchmentTypePanel.BackColor = System.Drawing.Color.Transparent;
            this.attchmentTypePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attchmentTypePanel.Location = new System.Drawing.Point(17, 7);
            this.attchmentTypePanel.Name = "attchmentTypePanel";
            this.attchmentTypePanel.Size = new System.Drawing.Size(24, 24);
            this.attchmentTypePanel.TabIndex = 0;
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.IconChar = FontAwesome.Sharp.IconChar.CloudDownloadAlt;
            this.downloadButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(211)))));
            this.downloadButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.downloadButton.IconSize = 32;
            this.downloadButton.Location = new System.Drawing.Point(776, 5);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(31, 24);
            this.downloadButton.TabIndex = 6;
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // shareButton
            // 
            this.shareButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.shareButton.FlatAppearance.BorderSize = 0;
            this.shareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shareButton.IconChar = FontAwesome.Sharp.IconChar.ShareAlt;
            this.shareButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.shareButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.shareButton.IconSize = 22;
            this.shareButton.Location = new System.Drawing.Point(807, 5);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(31, 24);
            this.shareButton.TabIndex = 7;
            this.shareButton.UseVisualStyleBackColor = false;
            // 
            // DetailsAttachmentUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.shareButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.attachmentSizeLabel);
            this.Controls.Add(this.attchmentTypePanel);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Name = "DetailsAttachmentUserControl";
            this.Size = new System.Drawing.Size(846, 50);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel attchmentTypePanel;
        private System.Windows.Forms.Label attachmentSizeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainAttachmentIconPanel;
        private System.Windows.Forms.LinkLabel attachmentNameLabel;
        private FontAwesome.Sharp.IconButton downloadButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private FontAwesome.Sharp.IconButton shareButton;
    }
}
