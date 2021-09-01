namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    partial class UCGuardFilePortalCreate
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Heddingpanel = new System.Windows.Forms.Panel();
            this.lablePageName = new System.Windows.Forms.Label();
            this.iconButton14 = new FontAwesome.Sharp.IconButton();
            this.HeadingPanel = new System.Windows.Forms.Panel();
            this.AddDesignationCloseButton = new FontAwesome.Sharp.IconButton();
            this.sliderCrossButton = new FontAwesome.Sharp.IconButton();
            this.singleDakHeaderLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userIdPanel = new System.Windows.Forms.Panel();
            this.subjectTextBox = new PlaceholderTextBox.PlaceholderTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.typesearchComboBox = new dNothi.Desktop.UI.ManuelUserControl.SearchComboBox();
            this.guardFileAddButton = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.Heddingpanel.SuspendLayout();
            this.HeadingPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.userIdPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Heddingpanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HeadingPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 357);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Heddingpanel
            // 
            this.Heddingpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.tableLayoutPanel1.SetColumnSpan(this.Heddingpanel, 2);
            this.Heddingpanel.Controls.Add(this.lablePageName);
            this.Heddingpanel.Controls.Add(this.iconButton14);
            this.Heddingpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Heddingpanel.Location = new System.Drawing.Point(0, 69);
            this.Heddingpanel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.Heddingpanel.Name = "Heddingpanel";
            this.Heddingpanel.Size = new System.Drawing.Size(830, 35);
            this.Heddingpanel.TabIndex = 72;
            // 
            // lablePageName
            // 
            this.lablePageName.AutoSize = true;
            this.lablePageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablePageName.Location = new System.Drawing.Point(39, 1);
            this.lablePageName.Name = "lablePageName";
            this.lablePageName.Size = new System.Drawing.Size(145, 29);
            this.lablePageName.TabIndex = 6;
            this.lablePageName.Text = "নতুন গার্ড ফাইল";
            // 
            // iconButton14
            // 
            this.iconButton14.BackColor = System.Drawing.Color.Transparent;
            this.iconButton14.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton14.FlatAppearance.BorderSize = 0;
            this.iconButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton14.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            this.iconButton14.IconColor = System.Drawing.Color.Gray;
            this.iconButton14.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton14.IconSize = 30;
            this.iconButton14.Location = new System.Drawing.Point(0, 0);
            this.iconButton14.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton14.Name = "iconButton14";
            this.iconButton14.Size = new System.Drawing.Size(36, 35);
            this.iconButton14.TabIndex = 5;
            this.iconButton14.UseVisualStyleBackColor = false;
            // 
            // HeadingPanel
            // 
            this.HeadingPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.HeadingPanel, 2);
            this.HeadingPanel.Controls.Add(this.AddDesignationCloseButton);
            this.HeadingPanel.Controls.Add(this.sliderCrossButton);
            this.HeadingPanel.Controls.Add(this.singleDakHeaderLabel);
            this.HeadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeadingPanel.Location = new System.Drawing.Point(0, 0);
            this.HeadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeadingPanel.Name = "HeadingPanel";
            this.HeadingPanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.HeadingPanel.Size = new System.Drawing.Size(834, 69);
            this.HeadingPanel.TabIndex = 39;
            // 
            // AddDesignationCloseButton
            // 
            this.AddDesignationCloseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddDesignationCloseButton.AutoSize = true;
            this.AddDesignationCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.AddDesignationCloseButton.FlatAppearance.BorderSize = 0;
            this.AddDesignationCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddDesignationCloseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddDesignationCloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.AddDesignationCloseButton.IconColor = System.Drawing.Color.DimGray;
            this.AddDesignationCloseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AddDesignationCloseButton.IconSize = 20;
            this.AddDesignationCloseButton.Location = new System.Drawing.Point(803, 21);
            this.AddDesignationCloseButton.Name = "AddDesignationCloseButton";
            this.AddDesignationCloseButton.Size = new System.Drawing.Size(28, 31);
            this.AddDesignationCloseButton.TabIndex = 41;
            this.AddDesignationCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddDesignationCloseButton.UseVisualStyleBackColor = false;
            this.AddDesignationCloseButton.Click += new System.EventHandler(this.AddDesignationCloseButton_Click);
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
            this.sliderCrossButton.Location = new System.Drawing.Point(834, 25);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.MaximumSize = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.TabIndex = 38;
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            // 
            // singleDakHeaderLabel
            // 
            this.singleDakHeaderLabel.AutoSize = true;
            this.singleDakHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singleDakHeaderLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleDakHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(86)))));
            this.singleDakHeaderLabel.Location = new System.Drawing.Point(0, 25);
            this.singleDakHeaderLabel.MaximumSize = new System.Drawing.Size(150, 0);
            this.singleDakHeaderLabel.Name = "singleDakHeaderLabel";
            this.singleDakHeaderLabel.Size = new System.Drawing.Size(121, 21);
            this.singleDakHeaderLabel.TabIndex = 28;
            this.singleDakHeaderLabel.Text = "গার্ড ফাইল পোর্টাল";
            // 
            // panel7
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel7, 2);
            this.panel7.Controls.Add(this.SubmitButton);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 177);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(828, 34);
            this.panel7.TabIndex = 71;
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.SubmitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SubmitButton.FlatAppearance.BorderSize = 0;
            this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.ForeColor = System.Drawing.Color.White;
            this.SubmitButton.Location = new System.Drawing.Point(738, 0);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(90, 34);
            this.SubmitButton.TabIndex = 70;
            this.SubmitButton.Text = "সংরক্ষণ করুন";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userIdPanel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 64);
            this.panel1.TabIndex = 0;
            // 
            // userIdPanel
            // 
            this.userIdPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userIdPanel.BackColor = System.Drawing.Color.White;
            this.userIdPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userIdPanel.Controls.Add(this.subjectTextBox);
            this.userIdPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.userIdPanel.Location = new System.Drawing.Point(15, 20);
            this.userIdPanel.Name = "userIdPanel";
            this.userIdPanel.Size = new System.Drawing.Size(378, 33);
            this.userIdPanel.TabIndex = 78;
            this.userIdPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userIdPanel_Paint);
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTextBox.BackColor = System.Drawing.Color.White;
            this.subjectTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subjectTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.subjectTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectTextBox.Location = new System.Drawing.Point(5, 7);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.PlaceholderText = "শিরোনাম";
            this.subjectTextBox.Size = new System.Drawing.Size(368, 19);
            this.subjectTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(71, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "*";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "শিরোনাম :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(420, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 64);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(51, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "ধরণ :";
            // 
            // typesearchComboBox
            // 
            this.typesearchComboBox.AutoSize = true;
            this.typesearchComboBox.BackColor = System.Drawing.Color.White;
            this.typesearchComboBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typesearchComboBox.isListShown = false;
            this.typesearchComboBox.itemList = null;
            this.typesearchComboBox.Location = new System.Drawing.Point(455, 131);
            this.typesearchComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typesearchComboBox.MinimumSize = new System.Drawing.Size(120, 0);
            this.typesearchComboBox.Name = "typesearchComboBox";
            this.typesearchComboBox.searchButtonText = "ধরণ বাছাই করুন";
            this.typesearchComboBox.selectedId = 0;
            this.typesearchComboBox.Size = new System.Drawing.Size(375, 44);
            this.typesearchComboBox.TabIndex = 3;
            this.typesearchComboBox.ChangeSelectedIndex += new System.EventHandler(this.typesearchComboBox_ChangeSelectedIndex);
            // 
            // guardFileAddButton
            // 
            this.guardFileAddButton.BackColor = System.Drawing.Color.Silver;
            this.guardFileAddButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.guardFileAddButton.FlatAppearance.BorderSize = 0;
            this.guardFileAddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guardFileAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardFileAddButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardFileAddButton.ForeColor = System.Drawing.Color.Black;
            this.guardFileAddButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.guardFileAddButton.IconColor = System.Drawing.Color.Black;
            this.guardFileAddButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.guardFileAddButton.IconSize = 18;
            this.guardFileAddButton.Location = new System.Drawing.Point(734, 362);
            this.guardFileAddButton.Margin = new System.Windows.Forms.Padding(0);
            this.guardFileAddButton.MinimumSize = new System.Drawing.Size(34, 36);
            this.guardFileAddButton.Name = "guardFileAddButton";
            this.guardFileAddButton.Size = new System.Drawing.Size(120, 36);
            this.guardFileAddButton.TabIndex = 88;
            this.guardFileAddButton.Text = " বন্ধ করুন";
            this.guardFileAddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.guardFileAddButton.UseVisualStyleBackColor = false;
            this.guardFileAddButton.Click += new System.EventHandler(this.guardFileAddButton_Click);
            // 
            // UCGuardFilePortalCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 373);
            this.ControlBox = false;
            this.Controls.Add(this.guardFileAddButton);
            this.Controls.Add(this.typesearchComboBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(10, 20);
            this.Name = "UCGuardFilePortalCreate";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCGuardFileUpload_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Heddingpanel.ResumeLayout(false);
            this.Heddingpanel.PerformLayout();
            this.HeadingPanel.ResumeLayout(false);
            this.HeadingPanel.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.userIdPanel.ResumeLayout(false);
            this.userIdPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel userIdPanel;
        private PlaceholderTextBox.PlaceholderTextBox subjectTextBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Panel panel7;
        private ManuelUserControl.SearchComboBox typesearchComboBox;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.Panel HeadingPanel;
        private FontAwesome.Sharp.IconButton AddDesignationCloseButton;
        private FontAwesome.Sharp.IconButton sliderCrossButton;
        private System.Windows.Forms.Label singleDakHeaderLabel;
        private System.Windows.Forms.Panel Heddingpanel;
        private FontAwesome.Sharp.IconButton guardFileAddButton;
        private System.Windows.Forms.Label lablePageName;
        private FontAwesome.Sharp.IconButton iconButton14;
    }
}
