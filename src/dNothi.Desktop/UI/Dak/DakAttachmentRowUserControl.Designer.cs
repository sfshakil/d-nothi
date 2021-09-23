namespace dNothi.Desktop.UI.Dak
{
    partial class DakAttachmentRowUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DakAttachmentRowUserControl));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.shareButton = new FontAwesome.Sharp.IconButton();
            this.downloadButton = new FontAwesome.Sharp.IconButton();
            this.btnWhatsappShare = new FontAwesome.Sharp.IconButton();
            this.btnMailShare = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.attchmentTypePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mainAttachmentIconPanel = new System.Windows.Forms.Panel();
            this.attachmentNameLabel = new System.Windows.Forms.LinkLabel();
            this.attachmentSizeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // shareButton
            // 
            this.shareButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.shareButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.shareButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shareButton.FlatAppearance.BorderSize = 0;
            this.shareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shareButton.IconChar = FontAwesome.Sharp.IconChar.ShareAlt;
            this.shareButton.IconColor = System.Drawing.Color.White;
            this.shareButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.shareButton.IconSize = 22;
            this.shareButton.Location = new System.Drawing.Point(543, 26);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(31, 24);
            this.shareButton.TabIndex = 10;
            this.toolTip1.SetToolTip(this.shareButton, "শেয়ার");
            this.shareButton.UseVisualStyleBackColor = false;
            this.shareButton.Click += new System.EventHandler(this.shareButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.downloadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.IconChar = FontAwesome.Sharp.IconChar.CloudDownloadAlt;
            this.downloadButton.IconColor = System.Drawing.Color.White;
            this.downloadButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.downloadButton.IconSize = 26;
            this.downloadButton.Location = new System.Drawing.Point(506, 26);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(31, 24);
            this.downloadButton.TabIndex = 9;
            this.toolTip1.SetToolTip(this.downloadButton, "ডাউনলোড ");
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // btnWhatsappShare
            // 
            this.btnWhatsappShare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWhatsappShare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnWhatsappShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhatsappShare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWhatsappShare.FlatAppearance.BorderSize = 0;
            this.btnWhatsappShare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnWhatsappShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnWhatsappShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhatsappShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhatsappShare.ForeColor = System.Drawing.Color.White;
            this.btnWhatsappShare.IconChar = FontAwesome.Sharp.IconChar.Whatsapp;
            this.btnWhatsappShare.IconColor = System.Drawing.Color.White;
            this.btnWhatsappShare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWhatsappShare.IconSize = 20;
            this.btnWhatsappShare.Location = new System.Drawing.Point(540, 77);
            this.btnWhatsappShare.Margin = new System.Windows.Forms.Padding(0);
            this.btnWhatsappShare.Name = "btnWhatsappShare";
            this.btnWhatsappShare.Size = new System.Drawing.Size(36, 20);
            this.btnWhatsappShare.TabIndex = 79;
            this.toolTip1.SetToolTip(this.btnWhatsappShare, "হোয়াটসঅ্যাপে শেয়ার করুন");
            this.btnWhatsappShare.UseVisualStyleBackColor = false;
            this.btnWhatsappShare.Visible = false;
            this.btnWhatsappShare.Click += new System.EventHandler(this.btnWhatsappShare_Click);
            // 
            // btnMailShare
            // 
            this.btnMailShare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMailShare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnMailShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMailShare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMailShare.FlatAppearance.BorderSize = 0;
            this.btnMailShare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnMailShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnMailShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMailShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMailShare.ForeColor = System.Drawing.Color.White;
            this.btnMailShare.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.btnMailShare.IconColor = System.Drawing.Color.White;
            this.btnMailShare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMailShare.IconSize = 20;
            this.btnMailShare.Location = new System.Drawing.Point(503, 77);
            this.btnMailShare.Margin = new System.Windows.Forms.Padding(0);
            this.btnMailShare.Name = "btnMailShare";
            this.btnMailShare.Size = new System.Drawing.Size(36, 20);
            this.btnMailShare.TabIndex = 78;
            this.toolTip1.SetToolTip(this.btnMailShare, "মেইলে শেয়ার করুন");
            this.btnMailShare.UseVisualStyleBackColor = false;
            this.btnMailShare.Visible = false;
            this.btnMailShare.Click += new System.EventHandler(this.btnMailShare_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.attchmentTypePanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 219);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // attchmentTypePanel
            // 
            this.attchmentTypePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.attchmentTypePanel.BackColor = System.Drawing.Color.Transparent;
            this.attchmentTypePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attchmentTypePanel.Location = new System.Drawing.Point(10, 10);
            this.attchmentTypePanel.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.attchmentTypePanel.MaximumSize = new System.Drawing.Size(24, 24);
            this.attchmentTypePanel.MinimumSize = new System.Drawing.Size(24, 24);
            this.attchmentTypePanel.Name = "attchmentTypePanel";
            this.attchmentTypePanel.Size = new System.Drawing.Size(24, 24);
            this.attchmentTypePanel.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.attachmentSizeLabel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(37, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(583, 213);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.mainAttachmentIconPanel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.attachmentNameLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.shareButton, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.downloadButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnWhatsappShare, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnMailShare, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(577, 97);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // mainAttachmentIconPanel
            // 
            this.mainAttachmentIconPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mainAttachmentIconPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainAttachmentIconPanel.BackgroundImage = global::dNothi.Desktop.Properties.Resources.mulpotro;
            this.mainAttachmentIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainAttachmentIconPanel.Location = new System.Drawing.Point(473, 26);
            this.mainAttachmentIconPanel.Name = "mainAttachmentIconPanel";
            this.mainAttachmentIconPanel.Size = new System.Drawing.Size(27, 24);
            this.mainAttachmentIconPanel.TabIndex = 8;
            // 
            // attachmentNameLabel
            // 
            this.attachmentNameLabel.AutoSize = true;
            this.attachmentNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentNameLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.attachmentNameLabel.Location = new System.Drawing.Point(3, 0);
            this.attachmentNameLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.attachmentNameLabel.Name = "attachmentNameLabel";
            this.attachmentNameLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.attachmentNameLabel.Size = new System.Drawing.Size(400, 77);
            this.attachmentNameLabel.TabIndex = 7;
            this.attachmentNameLabel.TabStop = true;
            this.attachmentNameLabel.Text = resources.GetString("attachmentNameLabel.Text");
            this.attachmentNameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.attachmentNameLabel_LinkClicked);
            // 
            // attachmentSizeLabel
            // 
            this.attachmentSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.attachmentSizeLabel.AutoSize = true;
            this.attachmentSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.attachmentSizeLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentSizeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.attachmentSizeLabel.Location = new System.Drawing.Point(3, 149);
            this.attachmentSizeLabel.Name = "attachmentSizeLabel";
            this.attachmentSizeLabel.Size = new System.Drawing.Size(51, 18);
            this.attachmentSizeLabel.TabIndex = 3;
            this.attachmentSizeLabel.Text = "১৭৩৬.৫";
            // 
            // DakAttachmentRowUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Name = "DakAttachmentRowUserControl";
            this.Size = new System.Drawing.Size(623, 219);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel attchmentTypePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label attachmentSizeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.LinkLabel attachmentNameLabel;
        private System.Windows.Forms.Panel mainAttachmentIconPanel;
        private FontAwesome.Sharp.IconButton downloadButton;
        private FontAwesome.Sharp.IconButton shareButton;
        private FontAwesome.Sharp.IconButton btnWhatsappShare;
        private FontAwesome.Sharp.IconButton btnMailShare;
    }
}
