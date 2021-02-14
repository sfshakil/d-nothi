namespace dNothi.Desktop.UI.Dak
{
    partial class DraftedDakUserControl
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
            this.dateLabel = new System.Windows.Forms.Label();
            this.dakActionPanel = new System.Windows.Forms.Panel();
            this.dakEditButton = new FontAwesome.Sharp.IconButton();
            this.dakSendButton = new FontAwesome.Sharp.IconButton();
            this.dakDeleteButton = new FontAwesome.Sharp.IconButton();
            this.dakAttachmentButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.senderAndReceiverPanel = new System.Windows.Forms.Panel();
            this.mainReceiverLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.senderLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.subjectPanel = new System.Windows.Forms.Panel();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rightInfoPanel = new dNothi.Desktop.UI.Dak.DakRightTopInfoIconUserControl();
            this.dakActionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.senderAndReceiverPanel.SuspendLayout();
            this.subjectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(904, 54);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(156, 23);
            this.dateLabel.TabIndex = 64;
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dakActionPanel
            // 
            this.dakActionPanel.AutoSize = true;
            this.dakActionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.dakActionPanel.Controls.Add(this.dakEditButton);
            this.dakActionPanel.Controls.Add(this.dakSendButton);
            this.dakActionPanel.Controls.Add(this.dakDeleteButton);
            this.dakActionPanel.Location = new System.Drawing.Point(985, 15);
            this.dakActionPanel.Name = "dakActionPanel";
            this.dakActionPanel.Size = new System.Drawing.Size(96, 34);
            this.dakActionPanel.TabIndex = 82;
            this.dakActionPanel.Visible = false;
            // 
            // dakEditButton
            // 
            this.dakEditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dakEditButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.dakEditButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.dakEditButton.FlatAppearance.BorderSize = 2;
            this.dakEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dakEditButton.IconChar = FontAwesome.Sharp.IconChar.MoneyCheck;
            this.dakEditButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dakEditButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dakEditButton.IconSize = 24;
            this.dakEditButton.Location = new System.Drawing.Point(0, 0);
            this.dakEditButton.Margin = new System.Windows.Forms.Padding(0);
            this.dakEditButton.Name = "dakEditButton";
            this.dakEditButton.Size = new System.Drawing.Size(32, 34);
            this.dakEditButton.TabIndex = 70;
            this.toolTip1.SetToolTip(this.dakEditButton, "সম্পাদন");
            this.dakEditButton.UseVisualStyleBackColor = false;
            this.dakEditButton.Click += new System.EventHandler(this.dakEditButton_Click);
            this.dakEditButton.MouseLeave += new System.EventHandler(this.dakEditButton_MouseLeave);
            this.dakEditButton.MouseHover += new System.EventHandler(this.dakEditButton_MouseHover);
            // 
            // dakSendButton
            // 
            this.dakSendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dakSendButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.dakSendButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.dakSendButton.FlatAppearance.BorderSize = 2;
            this.dakSendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dakSendButton.IconChar = FontAwesome.Sharp.IconChar.Share;
            this.dakSendButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dakSendButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dakSendButton.IconSize = 24;
            this.dakSendButton.Location = new System.Drawing.Point(32, 0);
            this.dakSendButton.Margin = new System.Windows.Forms.Padding(0);
            this.dakSendButton.Name = "dakSendButton";
            this.dakSendButton.Size = new System.Drawing.Size(32, 34);
            this.dakSendButton.TabIndex = 71;
            this.toolTip1.SetToolTip(this.dakSendButton, "ডাক প্রেরণ করুন");
            this.dakSendButton.UseVisualStyleBackColor = false;
            this.dakSendButton.Click += new System.EventHandler(this.dakSendButton_Click);
            this.dakSendButton.MouseLeave += new System.EventHandler(this.dakSendButton_MouseLeave);
            this.dakSendButton.MouseHover += new System.EventHandler(this.dakSendButton_MouseHover);
            // 
            // dakDeleteButton
            // 
            this.dakDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dakDeleteButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.dakDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.dakDeleteButton.FlatAppearance.BorderSize = 2;
            this.dakDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dakDeleteButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.dakDeleteButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dakDeleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dakDeleteButton.IconSize = 24;
            this.dakDeleteButton.Location = new System.Drawing.Point(64, 0);
            this.dakDeleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.dakDeleteButton.Name = "dakDeleteButton";
            this.dakDeleteButton.Size = new System.Drawing.Size(32, 34);
            this.dakDeleteButton.TabIndex = 69;
            this.toolTip1.SetToolTip(this.dakDeleteButton, "মুছুন");
            this.dakDeleteButton.UseVisualStyleBackColor = false;
            this.dakDeleteButton.Click += new System.EventHandler(this.dakDeleteButton_Click);
            this.dakDeleteButton.MouseLeave += new System.EventHandler(this.dakDeleteButton_MouseLeave);
            this.dakDeleteButton.MouseHover += new System.EventHandler(this.dakDeleteButton_MouseHover);
            // 
            // dakAttachmentButton
            // 
            this.dakAttachmentButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.dakAttachmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dakAttachmentButton.IconChar = FontAwesome.Sharp.IconChar.Link;
            this.dakAttachmentButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(213)))), ((int)(((byte)(132)))));
            this.dakAttachmentButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dakAttachmentButton.IconSize = 24;
            this.dakAttachmentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dakAttachmentButton.Location = new System.Drawing.Point(857, 51);
            this.dakAttachmentButton.Name = "dakAttachmentButton";
            this.dakAttachmentButton.Size = new System.Drawing.Size(45, 29);
            this.dakAttachmentButton.TabIndex = 83;
            this.dakAttachmentButton.TabStop = false;
            this.dakAttachmentButton.Text = "1";
            this.dakAttachmentButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dakAttachmentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dakAttachmentButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 41);
            this.panel1.TabIndex = 85;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.sourceLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(12, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(419, 41);
            this.panel3.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(-1, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 21);
            this.label1.TabIndex = 67;
            this.label1.Text = "উৎসঃ";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.BackColor = System.Drawing.Color.Transparent;
            this.sourceLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceLabel.Location = new System.Drawing.Point(43, 18);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(0, 21);
            this.sourceLabel.TabIndex = 68;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(12, 41);
            this.panel5.TabIndex = 0;
            // 
            // senderAndReceiverPanel
            // 
            this.senderAndReceiverPanel.AutoScroll = true;
            this.senderAndReceiverPanel.BackColor = System.Drawing.Color.Transparent;
            this.senderAndReceiverPanel.Controls.Add(this.mainReceiverLabel);
            this.senderAndReceiverPanel.Controls.Add(this.label6);
            this.senderAndReceiverPanel.Controls.Add(this.senderLabel);
            this.senderAndReceiverPanel.Controls.Add(this.panel7);
            this.senderAndReceiverPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.senderAndReceiverPanel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senderAndReceiverPanel.Location = new System.Drawing.Point(0, 41);
            this.senderAndReceiverPanel.MaximumSize = new System.Drawing.Size(1080, 0);
            this.senderAndReceiverPanel.MinimumSize = new System.Drawing.Size(1080, 20);
            this.senderAndReceiverPanel.Name = "senderAndReceiverPanel";
            this.senderAndReceiverPanel.Size = new System.Drawing.Size(1080, 20);
            this.senderAndReceiverPanel.TabIndex = 86;
            // 
            // mainReceiverLabel
            // 
            this.mainReceiverLabel.AutoSize = true;
            this.mainReceiverLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainReceiverLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainReceiverLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainReceiverLabel.Location = new System.Drawing.Point(81, 0);
            this.mainReceiverLabel.Name = "mainReceiverLabel";
            this.mainReceiverLabel.Size = new System.Drawing.Size(0, 18);
            this.mainReceiverLabel.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(12, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 60;
            this.label6.Text = "মূল প্রাপকঃ";
            // 
            // senderLabel
            // 
            this.senderLabel.AutoSize = true;
            this.senderLabel.BackColor = System.Drawing.Color.Transparent;
            this.senderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.senderLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senderLabel.Location = new System.Drawing.Point(12, 0);
            this.senderLabel.Name = "senderLabel";
            this.senderLabel.Size = new System.Drawing.Size(0, 18);
            this.senderLabel.TabIndex = 59;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(12, 20);
            this.panel7.TabIndex = 62;
            // 
            // subjectPanel
            // 
            this.subjectPanel.AutoSize = true;
            this.subjectPanel.Controls.Add(this.subjectLabel);
            this.subjectPanel.Controls.Add(this.label7);
            this.subjectPanel.Controls.Add(this.panel8);
            this.subjectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subjectPanel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectPanel.Location = new System.Drawing.Point(0, 61);
            this.subjectPanel.Name = "subjectPanel";
            this.subjectPanel.Size = new System.Drawing.Size(1095, 18);
            this.subjectPanel.TabIndex = 87;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.BackColor = System.Drawing.Color.Transparent;
            this.subjectLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLabel.Location = new System.Drawing.Point(53, 0);
            this.subjectLabel.MaximumSize = new System.Drawing.Size(660, 0);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(444, 18);
            this.subjectLabel.TabIndex = 62;
            this.subjectLabel.Text = "asa hbfhjfvghaf hfddaksj  hvfbghsadvjf hvfsadj hvgfdhsagv hddgvfhsad hgvsafjsad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(12, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 18);
            this.label7.TabIndex = 56;
            this.label7.Text = "বিষয়ঃ";
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(12, 18);
            this.panel8.TabIndex = 63;
            // 
            // rightInfoPanel
            // 
            this.rightInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightInfoPanel.attentionTypeIconValue = null;
            this.rightInfoPanel.AutoSize = true;
            this.rightInfoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rightInfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightInfoPanel.dakPrioriy = null;
            this.rightInfoPanel.dakSecurityIconValue = null;
            this.rightInfoPanel.dakType = null;
            this.rightInfoPanel.dakViewStatus = null;
            this.rightInfoPanel.Location = new System.Drawing.Point(1091, 15);
            this.rightInfoPanel.Name = "rightInfoPanel";
            this.rightInfoPanel.potrojari = 0;
            this.rightInfoPanel.Size = new System.Drawing.Size(0, 32);
            this.rightInfoPanel.TabIndex = 88;
            // 
            // DraftedDakUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.dakActionPanel);
            this.Controls.Add(this.rightInfoPanel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dakAttachmentButton);
            this.Controls.Add(this.subjectPanel);
            this.Controls.Add(this.senderAndReceiverPanel);
            this.Controls.Add(this.panel1);
            this.Name = "DraftedDakUserControl";
            this.Size = new System.Drawing.Size(1095, 84);
            this.Load += new System.EventHandler(this.DraftedDakUserControl_Load);
            this.MouseEnter += new System.EventHandler(this.DraftedDakUserControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.DraftedDakUserControl_MouseLeave);
            this.dakActionPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.senderAndReceiverPanel.ResumeLayout(false);
            this.senderAndReceiverPanel.PerformLayout();
            this.subjectPanel.ResumeLayout(false);
            this.subjectPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Panel dakActionPanel;
        private FontAwesome.Sharp.IconButton dakEditButton;
        private FontAwesome.Sharp.IconButton dakSendButton;
        private FontAwesome.Sharp.IconButton dakDeleteButton;
        private FontAwesome.Sharp.IconButton dakAttachmentButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel senderAndReceiverPanel;
        private System.Windows.Forms.Label mainReceiverLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label senderLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel subjectPanel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ToolTip toolTip1;
        private DakRightTopInfoIconUserControl rightInfoPanel;
    }
}
