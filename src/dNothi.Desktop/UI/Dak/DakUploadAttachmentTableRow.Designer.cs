namespace dNothi.Desktop.UI.Dak
{
    partial class DakUploadAttachmentTableRow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DakUploadAttachmentTableRow));
            this.dakAttachmentTableRadioButton = new System.Windows.Forms.RadioButton();
            this.attachmentLink = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.attachmentOCRButton = new FontAwesome.Sharp.IconButton();
            this.rejectButton = new System.Windows.Forms.Button();
            this.attachmentDeleteButton = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dakUploadAttachmentNameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentLink)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dakAttachmentTableRadioButton
            // 
            this.dakAttachmentTableRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.dakAttachmentTableRadioButton.Location = new System.Drawing.Point(4, 5);
            this.dakAttachmentTableRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dakAttachmentTableRadioButton.Name = "dakAttachmentTableRadioButton";
            this.dakAttachmentTableRadioButton.Padding = new System.Windows.Forms.Padding(50);
            this.dakAttachmentTableRadioButton.Size = new System.Drawing.Size(114, 55);
            this.dakAttachmentTableRadioButton.TabIndex = 0;
            this.dakAttachmentTableRadioButton.TabStop = true;
            this.dakAttachmentTableRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.dakAttachmentTableRadioButton.UseVisualStyleBackColor = false;
            this.dakAttachmentTableRadioButton.CheckedChanged += new System.EventHandler(this.dakAttachmentTableRadioButton_CheckedChanged);
            // 
            // attachmentLink
            // 
            this.attachmentLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.attachmentLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentLink.Location = new System.Drawing.Point(125, 4);
            this.attachmentLink.Name = "attachmentLink";
            this.attachmentLink.Size = new System.Drawing.Size(194, 57);
            this.attachmentLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.attachmentLink.TabIndex = 6;
            this.attachmentLink.TabStop = false;
            this.attachmentLink.Click += new System.EventHandler(this.attachmentLink_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(212, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // attachmentOCRButton
            // 
            this.attachmentOCRButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.attachmentOCRButton.FlatAppearance.BorderSize = 0;
            this.attachmentOCRButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentOCRButton.ForeColor = System.Drawing.Color.White;
            this.attachmentOCRButton.IconChar = FontAwesome.Sharp.IconChar.CircleNotch;
            this.attachmentOCRButton.IconColor = System.Drawing.Color.White;
            this.attachmentOCRButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.attachmentOCRButton.IconSize = 24;
            this.attachmentOCRButton.Location = new System.Drawing.Point(78, 6);
            this.attachmentOCRButton.Name = "attachmentOCRButton";
            this.attachmentOCRButton.Size = new System.Drawing.Size(138, 44);
            this.attachmentOCRButton.TabIndex = 11;
            this.attachmentOCRButton.Text = "OCR ব্যবহার করুন";
            this.attachmentOCRButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.attachmentOCRButton.UseVisualStyleBackColor = false;
            this.attachmentOCRButton.Visible = false;
            this.attachmentOCRButton.Click += new System.EventHandler(this.attachmentOCRButton_Click);
            // 
            // rejectButton
            // 
            this.rejectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rejectButton.BackgroundImage")));
            this.rejectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rejectButton.FlatAppearance.BorderSize = 0;
            this.rejectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rejectButton.Location = new System.Drawing.Point(222, 5);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(88, 44);
            this.rejectButton.TabIndex = 9;
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Visible = false;
            // 
            // attachmentDeleteButton
            // 
            this.attachmentDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.attachmentDeleteButton.FlatAppearance.BorderSize = 0;
            this.attachmentDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentDeleteButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.attachmentDeleteButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(149)))), ((int)(((byte)(160)))));
            this.attachmentDeleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.attachmentDeleteButton.IconSize = 24;
            this.attachmentDeleteButton.Location = new System.Drawing.Point(17, 6);
            this.attachmentDeleteButton.Name = "attachmentDeleteButton";
            this.attachmentDeleteButton.Size = new System.Drawing.Size(55, 44);
            this.attachmentDeleteButton.TabIndex = 10;
            this.attachmentDeleteButton.UseVisualStyleBackColor = false;
            this.attachmentDeleteButton.Click += new System.EventHandler(this.attachmentDeleteButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dakAttachmentTableRadioButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.attachmentLink, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1024, 65);
            this.tableLayoutPanel2.TabIndex = 12;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dakUploadAttachmentNameTextBox);
            this.panel2.Location = new System.Drawing.Point(326, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 37);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // dakUploadAttachmentNameTextBox
            // 
            this.dakUploadAttachmentNameTextBox.BackColor = System.Drawing.Color.White;
            this.dakUploadAttachmentNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dakUploadAttachmentNameTextBox.Location = new System.Drawing.Point(3, 9);
            this.dakUploadAttachmentNameTextBox.Name = "dakUploadAttachmentNameTextBox";
            this.dakUploadAttachmentNameTextBox.Size = new System.Drawing.Size(273, 19);
            this.dakUploadAttachmentNameTextBox.TabIndex = 8;
            this.dakUploadAttachmentNameTextBox.TextChanged += new System.EventHandler(this.dakUploadAttachmentNameTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.attachmentOCRButton);
            this.panel1.Controls.Add(this.attachmentDeleteButton);
            this.panel1.Controls.Add(this.rejectButton);
            this.panel1.Location = new System.Drawing.Point(612, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 57);
            this.panel1.TabIndex = 7;
            // 
            // DakUploadAttachmentTableRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1024, 0);
            this.MinimumSize = new System.Drawing.Size(1024, 65);
            this.Name = "DakUploadAttachmentTableRow";
            this.Size = new System.Drawing.Size(1024, 65);
            ((System.ComponentModel.ISupportInitialize)(this.attachmentLink)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton dakAttachmentTableRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox attachmentLink;
        private FontAwesome.Sharp.IconButton attachmentOCRButton;
        private System.Windows.Forms.Button rejectButton;
        private FontAwesome.Sharp.IconButton attachmentDeleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox dakUploadAttachmentNameTextBox;
        private System.Windows.Forms.Panel panel2;
    }
}
