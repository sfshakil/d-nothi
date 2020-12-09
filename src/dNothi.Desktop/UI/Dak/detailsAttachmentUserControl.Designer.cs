namespace dNothi.Desktop.UI.Dak
{
    partial class detailsAttachmentUserControl
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
            this.attachmentNameLabel = new System.Windows.Forms.Label();
            this.attachmentSizeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainAttachmentIconPanel = new System.Windows.Forms.Panel();
            this.downloadButton = new System.Windows.Forms.Button();
            this.attchmentTypePanel = new System.Windows.Forms.Panel();
            this.shareButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachmentNameLabel
            // 
            this.attachmentNameLabel.AutoSize = true;
            this.attachmentNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.attachmentNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentNameLabel.ForeColor = System.Drawing.Color.Blue;
            this.attachmentNameLabel.Location = new System.Drawing.Point(0, 0);
            this.attachmentNameLabel.Name = "attachmentNameLabel";
            this.attachmentNameLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.attachmentNameLabel.Size = new System.Drawing.Size(367, 20);
            this.attachmentNameLabel.TabIndex = 1;
            this.attachmentNameLabel.Text = "ই-ফাইল ব্যবহার সহায়িকা-১(লগইন প্রক্রিয়া ও প্রোফাইল ব্যবস্থাপনা) (1).pdf";
            // 
            // attachmentSizeLabel
            // 
            this.attachmentSizeLabel.AutoSize = true;
            this.attachmentSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.attachmentSizeLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentSizeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.attachmentSizeLabel.Location = new System.Drawing.Point(53, 32);
            this.attachmentSizeLabel.Name = "attachmentSizeLabel";
            this.attachmentSizeLabel.Size = new System.Drawing.Size(50, 17);
            this.attachmentSizeLabel.TabIndex = 2;
            this.attachmentSizeLabel.Text = "১৭৩৬.৫";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainAttachmentIconPanel);
            this.panel1.Controls.Add(this.attachmentNameLabel);
            this.panel1.Location = new System.Drawing.Point(52, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 25);
            this.panel1.TabIndex = 3;
            // 
            // mainAttachmentIconPanel
            // 
            this.mainAttachmentIconPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainAttachmentIconPanel.BackgroundImage = global::dNothi.Desktop.Properties.Resources.mulpotro;
            this.mainAttachmentIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainAttachmentIconPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainAttachmentIconPanel.Location = new System.Drawing.Point(367, 0);
            this.mainAttachmentIconPanel.Name = "mainAttachmentIconPanel";
            this.mainAttachmentIconPanel.Size = new System.Drawing.Size(35, 25);
            this.mainAttachmentIconPanel.TabIndex = 2;
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadButton.BackgroundImage = global::dNothi.Desktop.Properties.Resources.icons8_download_from_cloud_641;
            this.downloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Location = new System.Drawing.Point(835, 9);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(24, 21);
            this.downloadButton.TabIndex = 4;
            this.downloadButton.UseVisualStyleBackColor = false;
            // 
            // attchmentTypePanel
            // 
            this.attchmentTypePanel.BackColor = System.Drawing.Color.Transparent;
            this.attchmentTypePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attchmentTypePanel.Location = new System.Drawing.Point(22, 9);
            this.attchmentTypePanel.Name = "attchmentTypePanel";
            this.attchmentTypePanel.Size = new System.Drawing.Size(24, 21);
            this.attchmentTypePanel.TabIndex = 0;
            // 
            // shareButton
            // 
            this.shareButton.BackColor = System.Drawing.Color.Transparent;
            this.shareButton.BackgroundImage = global::dNothi.Desktop.Properties.Resources.icons8_share_24;
            this.shareButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shareButton.FlatAppearance.BorderSize = 0;
            this.shareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shareButton.Location = new System.Drawing.Point(868, 9);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(24, 21);
            this.shareButton.TabIndex = 5;
            this.shareButton.UseVisualStyleBackColor = false;
            // 
            // detailsAttachmentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.shareButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.attachmentSizeLabel);
            this.Controls.Add(this.attchmentTypePanel);
            this.Name = "detailsAttachmentUserControl";
            this.Size = new System.Drawing.Size(903, 54);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel attchmentTypePanel;
        private System.Windows.Forms.Label attachmentNameLabel;
        private System.Windows.Forms.Label attachmentSizeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainAttachmentIconPanel;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button shareButton;
    }
}
