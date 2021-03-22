namespace dNothi.Desktop.UI.Khosra_Potro
{
    partial class KhosraAttachmentForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HeadingPanel = new System.Windows.Forms.Panel();
            this.singleDakHeaderLabel = new System.Windows.Forms.Label();
            this.crossButton = new FontAwesome.Sharp.IconButton();
            this.sliderCrossButton = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.tabControlLeft = new System.Windows.Forms.TabControl();
            this.currentNothiAttachmentTabPageLeft = new System.Windows.Forms.TabPage();
            this.allNothiAttachmentTabPageLeft = new System.Windows.Forms.TabPage();
            this.ownComputerTabPage = new System.Windows.Forms.TabPage();
            this.selectedAttachmentTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.HeadingPanel.SuspendLayout();
            this.tabControlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControlLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HeadingPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconButton1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(25, 0, 25, 10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 468);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // HeadingPanel
            // 
            this.HeadingPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HeadingPanel.Controls.Add(this.crossButton);
            this.HeadingPanel.Controls.Add(this.sliderCrossButton);
            this.HeadingPanel.Controls.Add(this.singleDakHeaderLabel);
            this.HeadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeadingPanel.Location = new System.Drawing.Point(25, 0);
            this.HeadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeadingPanel.Name = "HeadingPanel";
            this.HeadingPanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.HeadingPanel.Size = new System.Drawing.Size(799, 73);
            this.HeadingPanel.TabIndex = 40;
            // 
            // singleDakHeaderLabel
            // 
            this.singleDakHeaderLabel.AutoSize = true;
            this.singleDakHeaderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.singleDakHeaderLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleDakHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.singleDakHeaderLabel.Location = new System.Drawing.Point(0, 25);
            this.singleDakHeaderLabel.Name = "singleDakHeaderLabel";
            this.singleDakHeaderLabel.Size = new System.Drawing.Size(53, 21);
            this.singleDakHeaderLabel.TabIndex = 28;
            this.singleDakHeaderLabel.Text = "সংযুক্তি";
            // 
            // crossButton
            // 
            this.crossButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.crossButton.AutoSize = true;
            this.crossButton.CausesValidation = false;
            this.crossButton.FlatAppearance.BorderSize = 0;
            this.crossButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crossButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.crossButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.crossButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.crossButton.IconSize = 24;
            this.crossButton.Location = new System.Drawing.Point(766, 22);
            this.crossButton.MaximumSize = new System.Drawing.Size(30, 28);
            this.crossButton.Name = "crossButton";
            this.crossButton.Size = new System.Drawing.Size(30, 28);
            this.crossButton.TabIndex = 39;
            this.crossButton.UseVisualStyleBackColor = true;
            this.crossButton.Click += new System.EventHandler(this.crossButton_Click);
            // 
            // sliderCrossButton
            // 
            this.sliderCrossButton.BackColor = System.Drawing.Color.White;
            this.sliderCrossButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.sliderCrossButton.FlatAppearance.BorderSize = 0;
            this.sliderCrossButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sliderCrossButton.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.sliderCrossButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sliderCrossButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.sliderCrossButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.sliderCrossButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.sliderCrossButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.sliderCrossButton.IconSize = 18;
            this.sliderCrossButton.Location = new System.Drawing.Point(799, 25);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.MaximumSize = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.TabIndex = 38;
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.iconButton1.AutoSize = true;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(86)))));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(86)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.Location = new System.Drawing.Point(725, 417);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(96, 38);
            this.iconButton1.TabIndex = 41;
            this.iconButton1.Text = "বন্ধ করুন";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // tabControlLeft
            // 
            this.tabControlLeft.Controls.Add(this.currentNothiAttachmentTabPageLeft);
            this.tabControlLeft.Controls.Add(this.allNothiAttachmentTabPageLeft);
            this.tabControlLeft.Controls.Add(this.ownComputerTabPage);
            this.tabControlLeft.Controls.Add(this.selectedAttachmentTabPage);
            this.tabControlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLeft.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlLeft.Location = new System.Drawing.Point(25, 73);
            this.tabControlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlLeft.Name = "tabControlLeft";
            this.tabControlLeft.Padding = new System.Drawing.Point(20, 12);
            this.tabControlLeft.SelectedIndex = 0;
            this.tabControlLeft.Size = new System.Drawing.Size(799, 341);
            this.tabControlLeft.TabIndex = 42;
            // 
            // currentNothiAttachmentTabPageLeft
            // 
            this.currentNothiAttachmentTabPageLeft.ForeColor = System.Drawing.Color.DarkGray;
            this.currentNothiAttachmentTabPageLeft.ImageIndex = 1;
            this.currentNothiAttachmentTabPageLeft.Location = new System.Drawing.Point(4, 45);
            this.currentNothiAttachmentTabPageLeft.Margin = new System.Windows.Forms.Padding(0);
            this.currentNothiAttachmentTabPageLeft.Name = "currentNothiAttachmentTabPageLeft";
            this.currentNothiAttachmentTabPageLeft.Padding = new System.Windows.Forms.Padding(3);
            this.currentNothiAttachmentTabPageLeft.Size = new System.Drawing.Size(791, 292);
            this.currentNothiAttachmentTabPageLeft.TabIndex = 0;
            this.currentNothiAttachmentTabPageLeft.Text = "বর্তমান নথির পত্র";
            this.currentNothiAttachmentTabPageLeft.UseVisualStyleBackColor = true;
            // 
            // allNothiAttachmentTabPageLeft
            // 
            this.allNothiAttachmentTabPageLeft.ImageIndex = 0;
            this.allNothiAttachmentTabPageLeft.Location = new System.Drawing.Point(4, 45);
            this.allNothiAttachmentTabPageLeft.Name = "allNothiAttachmentTabPageLeft";
            this.allNothiAttachmentTabPageLeft.Padding = new System.Windows.Forms.Padding(3);
            this.allNothiAttachmentTabPageLeft.Size = new System.Drawing.Size(791, 292);
            this.allNothiAttachmentTabPageLeft.TabIndex = 1;
            this.allNothiAttachmentTabPageLeft.Text = "সকল অনুমোদিত পত্র (নিজ অফিস)";
            this.allNothiAttachmentTabPageLeft.UseVisualStyleBackColor = true;
            // 
            // ownComputerTabPage
            // 
            this.ownComputerTabPage.Location = new System.Drawing.Point(4, 45);
            this.ownComputerTabPage.Name = "ownComputerTabPage";
            this.ownComputerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ownComputerTabPage.Size = new System.Drawing.Size(791, 292);
            this.ownComputerTabPage.TabIndex = 2;
            this.ownComputerTabPage.Text = "নিজ কম্পিউটার";
            this.ownComputerTabPage.UseVisualStyleBackColor = true;
            // 
            // selectedAttachmentTabPage
            // 
            this.selectedAttachmentTabPage.Location = new System.Drawing.Point(4, 45);
            this.selectedAttachmentTabPage.Name = "selectedAttachmentTabPage";
            this.selectedAttachmentTabPage.Size = new System.Drawing.Size(791, 292);
            this.selectedAttachmentTabPage.TabIndex = 3;
            this.selectedAttachmentTabPage.Text = "বাছাইকৃত";
            this.selectedAttachmentTabPage.UseVisualStyleBackColor = true;
            // 
            // KhosraAttachmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 468);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KhosraAttachmentForm";
            this.Text = "KhosraAttachmentForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.HeadingPanel.ResumeLayout(false);
            this.HeadingPanel.PerformLayout();
            this.tabControlLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel HeadingPanel;
        private FontAwesome.Sharp.IconButton crossButton;
        private FontAwesome.Sharp.IconButton sliderCrossButton;
        private System.Windows.Forms.Label singleDakHeaderLabel;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TabControl tabControlLeft;
        private System.Windows.Forms.TabPage currentNothiAttachmentTabPageLeft;
        private System.Windows.Forms.TabPage allNothiAttachmentTabPageLeft;
        private System.Windows.Forms.TabPage ownComputerTabPage;
        private System.Windows.Forms.TabPage selectedAttachmentTabPage;
    }
}