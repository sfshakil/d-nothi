namespace dNothi.Desktop.UI.Khosra_Potro
{
    partial class KhosraSingleAttachmentUserControl
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
            this.fileTypeIconButton = new FontAwesome.Sharp.IconButton();
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.downloadButton = new FontAwesome.Sharp.IconButton();
            this.eyeButton = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.attachmentNameLabel = new System.Windows.Forms.Label();
            this.attachmentPageCountLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileTypeIconButton
            // 
            this.fileTypeIconButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fileTypeIconButton.FlatAppearance.BorderSize = 0;
            this.fileTypeIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileTypeIconButton.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.fileTypeIconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.fileTypeIconButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.fileTypeIconButton.IconSize = 24;
            this.fileTypeIconButton.Location = new System.Drawing.Point(352, 12);
            this.fileTypeIconButton.Name = "fileTypeIconButton";
            this.fileTypeIconButton.Size = new System.Drawing.Size(70, 22);
            this.fileTypeIconButton.TabIndex = 0;
            this.fileTypeIconButton.UseVisualStyleBackColor = true;
            this.fileTypeIconButton.Click += new System.EventHandler(this.fileTypeIconButton_Click);
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.selectCheckBox.AutoSize = true;
            this.selectCheckBox.FlatAppearance.BorderSize = 0;
            this.selectCheckBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(81)))), ((int)(((byte)(97)))));
            this.selectCheckBox.Location = new System.Drawing.Point(3, 16);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.selectCheckBox.Size = new System.Drawing.Size(20, 14);
            this.selectCheckBox.TabIndex = 3;
            this.selectCheckBox.UseVisualStyleBackColor = true;
            this.selectCheckBox.CheckedChanged += new System.EventHandler(this.selectCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.downloadButton);
            this.panel1.Controls.Add(this.eyeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(425, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(58, 46);
            this.panel1.TabIndex = 2;
            // 
            // downloadButton
            // 
            this.downloadButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.downloadButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(80)))), ((int)(((byte)(252)))));
            this.downloadButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.downloadButton.IconSize = 24;
            this.downloadButton.Location = new System.Drawing.Point(29, 0);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(29, 46);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // eyeButton
            // 
            this.eyeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.eyeButton.FlatAppearance.BorderSize = 0;
            this.eyeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eyeButton.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.eyeButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.eyeButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.eyeButton.IconSize = 24;
            this.eyeButton.Location = new System.Drawing.Point(0, 0);
            this.eyeButton.Name = "eyeButton";
            this.eyeButton.Size = new System.Drawing.Size(29, 46);
            this.eyeButton.TabIndex = 1;
            this.eyeButton.UseVisualStyleBackColor = true;
            this.eyeButton.Click += new System.EventHandler(this.eyeButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.attachmentNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.attachmentPageCountLabel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(26, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(323, 46);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // attachmentNameLabel
            // 
            this.attachmentNameLabel.AutoSize = true;
            this.attachmentNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(81)))), ((int)(((byte)(97)))));
            this.attachmentNameLabel.Location = new System.Drawing.Point(0, 0);
            this.attachmentNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.attachmentNameLabel.Name = "attachmentNameLabel";
            this.attachmentNameLabel.Padding = new System.Windows.Forms.Padding(5);
            this.attachmentNameLabel.Size = new System.Drawing.Size(247, 28);
            this.attachmentNameLabel.TabIndex = 1;
            this.attachmentNameLabel.Text = "৫৬.৪২.০০০০.০১০.২৫.০০৩.২১.২ - ২২.pdf";
            // 
            // attachmentPageCountLabel
            // 
            this.attachmentPageCountLabel.AutoSize = true;
            this.attachmentPageCountLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentPageCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(209)))));
            this.attachmentPageCountLabel.Location = new System.Drawing.Point(3, 28);
            this.attachmentPageCountLabel.Name = "attachmentPageCountLabel";
            this.attachmentPageCountLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.attachmentPageCountLabel.Size = new System.Drawing.Size(53, 18);
            this.attachmentPageCountLabel.TabIndex = 2;
            this.attachmentPageCountLabel.Text = "সংযুক্তি:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fileTypeIconButton, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 46);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // KhosraSingleAttachmentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "KhosraSingleAttachmentUserControl";
            this.Size = new System.Drawing.Size(483, 46);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label attachmentNameLabel;
        private System.Windows.Forms.Label attachmentPageCountLabel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton downloadButton;
        private FontAwesome.Sharp.IconButton eyeButton;
        private System.Windows.Forms.CheckBox selectCheckBox;
        private FontAwesome.Sharp.IconButton fileTypeIconButton;
    }
}
