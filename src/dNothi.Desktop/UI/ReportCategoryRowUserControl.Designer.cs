
namespace dNothi.Desktop.UI
{
    partial class ReportCategoryRowUserControl
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OfficeNoLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ReportSerialNumberTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SerialNumberLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReportCategoryTextBox = new System.Windows.Forms.TextBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.EditCancelButton = new FontAwesome.Sharp.IconButton();
            this.EditSaveButton = new FontAwesome.Sharp.IconButton();
            this.ReportCategoryEditButton = new FontAwesome.Sharp.IconButton();
            this.ReportCategoryDeleteButton = new FontAwesome.Sharp.IconButton();
            this.btnSchedule = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.776963F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.46075F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.19809F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05649F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.36097F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1343, 56);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.OfficeNoLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(701, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 17, 0, 0);
            this.panel3.Size = new System.Drawing.Size(137, 56);
            this.panel3.TabIndex = 9;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // OfficeNoLabel
            // 
            this.OfficeNoLabel.AutoSize = true;
            this.OfficeNoLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.OfficeNoLabel.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OfficeNoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(117)))));
            this.OfficeNoLabel.Location = new System.Drawing.Point(5, 17);
            this.OfficeNoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OfficeNoLabel.Name = "OfficeNoLabel";
            this.OfficeNoLabel.Size = new System.Drawing.Size(19, 22);
            this.OfficeNoLabel.TabIndex = 1;
            this.OfficeNoLabel.Text = "0";
            this.OfficeNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ReportSerialNumberTextBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(838, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(50, 15, 50, 10);
            this.panel5.Size = new System.Drawing.Size(283, 56);
            this.panel5.TabIndex = 8;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ReportSerialNumberTextBox
            // 
            this.ReportSerialNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportSerialNumberTextBox.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSerialNumberTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(117)))));
            this.ReportSerialNumberTextBox.Location = new System.Drawing.Point(50, 15);
            this.ReportSerialNumberTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ReportSerialNumberTextBox.Multiline = true;
            this.ReportSerialNumberTextBox.Name = "ReportSerialNumberTextBox";
            this.ReportSerialNumberTextBox.Size = new System.Drawing.Size(183, 31);
            this.ReportSerialNumberTextBox.TabIndex = 0;
            this.ReportSerialNumberTextBox.TextChanged += new System.EventHandler(this.ReportSerialNumberTextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SerialNumberLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(104, 56);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // SerialNumberLabel
            // 
            this.SerialNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SerialNumberLabel.AutoSize = true;
            this.SerialNumberLabel.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(117)))));
            this.SerialNumberLabel.Location = new System.Drawing.Point(31, 17);
            this.SerialNumberLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SerialNumberLabel.Name = "SerialNumberLabel";
            this.SerialNumberLabel.Size = new System.Drawing.Size(19, 22);
            this.SerialNumberLabel.TabIndex = 1;
            this.SerialNumberLabel.Text = "0";
            this.SerialNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReportCategoryTextBox);
            this.panel1.Controls.Add(this.CategoryLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(104, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 17, 5, 5);
            this.panel1.Size = new System.Drawing.Size(597, 56);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ReportCategoryTextBox
            // 
            this.ReportCategoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportCategoryTextBox.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportCategoryTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(117)))));
            this.ReportCategoryTextBox.Location = new System.Drawing.Point(326, 17);
            this.ReportCategoryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ReportCategoryTextBox.Multiline = true;
            this.ReportCategoryTextBox.Name = "ReportCategoryTextBox";
            this.ReportCategoryTextBox.Size = new System.Drawing.Size(266, 34);
            this.ReportCategoryTextBox.TabIndex = 2;
            this.ReportCategoryTextBox.Visible = false;
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CategoryLabel.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(117)))));
            this.CategoryLabel.Location = new System.Drawing.Point(5, 17);
            this.CategoryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(321, 22);
            this.CategoryLabel.TabIndex = 1;
            this.CategoryLabel.Text = "আঞ্চলিক অফিস, মৃত্তিকা সম্পদ উন্নয়ন ইনস্টিটিউট ";
            this.CategoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSchedule);
            this.panel4.Controls.Add(this.EditCancelButton);
            this.panel4.Controls.Add(this.EditSaveButton);
            this.panel4.Controls.Add(this.ReportCategoryEditButton);
            this.panel4.Controls.Add(this.ReportCategoryDeleteButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1121, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 56);
            this.panel4.TabIndex = 10;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // EditCancelButton
            // 
            this.EditCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.EditCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.EditCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditCancelButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.EditCancelButton.ForeColor = System.Drawing.Color.White;
            this.EditCancelButton.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.EditCancelButton.IconColor = System.Drawing.SystemColors.Window;
            this.EditCancelButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.EditCancelButton.IconSize = 28;
            this.EditCancelButton.Location = new System.Drawing.Point(112, 5);
            this.EditCancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.EditCancelButton.Name = "EditCancelButton";
            this.EditCancelButton.Size = new System.Drawing.Size(50, 46);
            this.EditCancelButton.TabIndex = 72;
            this.EditCancelButton.UseVisualStyleBackColor = false;
            this.EditCancelButton.Visible = false;
            this.EditCancelButton.Click += new System.EventHandler(this.EditCancelButton_Click);
            // 
            // EditSaveButton
            // 
            this.EditSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.EditSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.EditSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditSaveButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.EditSaveButton.ForeColor = System.Drawing.Color.White;
            this.EditSaveButton.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.EditSaveButton.IconColor = System.Drawing.SystemColors.Window;
            this.EditSaveButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.EditSaveButton.IconSize = 28;
            this.EditSaveButton.Location = new System.Drawing.Point(62, 5);
            this.EditSaveButton.Margin = new System.Windows.Forms.Padding(0);
            this.EditSaveButton.Name = "EditSaveButton";
            this.EditSaveButton.Size = new System.Drawing.Size(50, 46);
            this.EditSaveButton.TabIndex = 71;
            this.EditSaveButton.UseVisualStyleBackColor = false;
            this.EditSaveButton.Visible = false;
            this.EditSaveButton.Click += new System.EventHandler(this.EditSaveButton_Click);
            // 
            // ReportCategoryEditButton
            // 
            this.ReportCategoryEditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ReportCategoryEditButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ReportCategoryEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportCategoryEditButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.ReportCategoryEditButton.ForeColor = System.Drawing.Color.White;
            this.ReportCategoryEditButton.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.ReportCategoryEditButton.IconColor = System.Drawing.SystemColors.Window;
            this.ReportCategoryEditButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ReportCategoryEditButton.IconSize = 24;
            this.ReportCategoryEditButton.Location = new System.Drawing.Point(62, 5);
            this.ReportCategoryEditButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReportCategoryEditButton.Name = "ReportCategoryEditButton";
            this.ReportCategoryEditButton.Size = new System.Drawing.Size(50, 46);
            this.ReportCategoryEditButton.TabIndex = 70;
            this.ReportCategoryEditButton.UseVisualStyleBackColor = false;
            this.ReportCategoryEditButton.Click += new System.EventHandler(this.ReportCategoryEditButton_Click);
            // 
            // ReportCategoryDeleteButton
            // 
            this.ReportCategoryDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.ReportCategoryDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.ReportCategoryDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportCategoryDeleteButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.ReportCategoryDeleteButton.ForeColor = System.Drawing.Color.White;
            this.ReportCategoryDeleteButton.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.ReportCategoryDeleteButton.IconColor = System.Drawing.SystemColors.Window;
            this.ReportCategoryDeleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ReportCategoryDeleteButton.IconSize = 22;
            this.ReportCategoryDeleteButton.Location = new System.Drawing.Point(112, 5);
            this.ReportCategoryDeleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReportCategoryDeleteButton.Name = "ReportCategoryDeleteButton";
            this.ReportCategoryDeleteButton.Size = new System.Drawing.Size(50, 46);
            this.ReportCategoryDeleteButton.TabIndex = 69;
            this.ReportCategoryDeleteButton.UseVisualStyleBackColor = false;
            this.ReportCategoryDeleteButton.Click += new System.EventHandler(this.ReportCategoryDeleteButton_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSchedule.Enabled = false;
            this.btnSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            this.btnSchedule.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnSchedule.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSchedule.IconSize = 28;
            this.btnSchedule.Location = new System.Drawing.Point(62, 8);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(33, 38);
            this.btnSchedule.TabIndex = 121;
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Visible = false;
            // 
            // ReportCategoryRowUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReportCategoryRowUserControl";
            this.Size = new System.Drawing.Size(1343, 56);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label SerialNumberLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label OfficeNoLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox ReportSerialNumberTextBox;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton ReportCategoryEditButton;
        private FontAwesome.Sharp.IconButton ReportCategoryDeleteButton;
        private System.Windows.Forms.TextBox ReportCategoryTextBox;
        private FontAwesome.Sharp.IconButton EditCancelButton;
        private FontAwesome.Sharp.IconButton EditSaveButton;
        private FontAwesome.Sharp.IconButton btnSchedule;
    }
}
