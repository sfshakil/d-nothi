namespace dNothi.Desktop.UI.NothiUI
{
    partial class KhosraReviewOfficerRowUserControl
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
            this.deleteButton = new FontAwesome.Sharp.IconButton();
            this.officeUnitLabel = new System.Windows.Forms.Label();
            this.designationLabel = new System.Windows.Forms.Label();
            this.officerNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.permissionPanel = new System.Windows.Forms.Panel();
            this.permissionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.permissionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSize = true;
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.deleteButton.IconColor = System.Drawing.Color.White;
            this.deleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.deleteButton.IconSize = 24;
            this.deleteButton.Location = new System.Drawing.Point(917, 0);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.MaximumSize = new System.Drawing.Size(40, 34);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(40, 34);
            this.deleteButton.TabIndex = 33;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // officeUnitLabel
            // 
            this.officeUnitLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.officeUnitLabel, 2);
            this.officeUnitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.officeUnitLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.officeUnitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.officeUnitLabel.Location = new System.Drawing.Point(0, 34);
            this.officeUnitLabel.Margin = new System.Windows.Forms.Padding(0);
            this.officeUnitLabel.Name = "officeUnitLabel";
            this.officeUnitLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.officeUnitLabel.Size = new System.Drawing.Size(780, 31);
            this.officeUnitLabel.TabIndex = 32;
            this.officeUnitLabel.Text = "প্রকল্প পরিচালকের দপ্তর এসপায়ার টু ইনোভেট (এটুআই) ";
            // 
            // designationLabel
            // 
            this.designationLabel.AutoSize = true;
            this.designationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designationLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.designationLabel.Location = new System.Drawing.Point(301, 0);
            this.designationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.designationLabel.Name = "designationLabel";
            this.designationLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.designationLabel.Size = new System.Drawing.Size(479, 34);
            this.designationLabel.TabIndex = 31;
            this.designationLabel.Text = "(প্রকল্প পরিচালক (অতিরিক্ত সচিব))";
            // 
            // officerNameLabel
            // 
            this.officerNameLabel.AutoSize = true;
            this.officerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.officerNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.officerNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.officerNameLabel.Location = new System.Drawing.Point(0, 0);
            this.officerNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.officerNameLabel.Name = "officerNameLabel";
            this.officerNameLabel.Size = new System.Drawing.Size(301, 34);
            this.officerNameLabel.TabIndex = 30;
            this.officerNameLabel.Text = "ড. মোঃ আব্দুল মান্নান. পিএএ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.designationLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.officeUnitLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.officerNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.permissionPanel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 65);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // permissionPanel
            // 
            this.permissionPanel.Controls.Add(this.permissionComboBox);
            this.permissionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissionPanel.Location = new System.Drawing.Point(780, 0);
            this.permissionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.permissionPanel.Name = "permissionPanel";
            this.permissionPanel.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.SetRowSpan(this.permissionPanel, 2);
            this.permissionPanel.Size = new System.Drawing.Size(137, 65);
            this.permissionPanel.TabIndex = 93;
            this.permissionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.permissionPanel_Paint);
            // 
            // permissionComboBox
            // 
            this.permissionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissionComboBox.DropDownHeight = 110;
            this.permissionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.permissionComboBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permissionComboBox.FormattingEnabled = true;
            this.permissionComboBox.IntegralHeight = false;
            this.permissionComboBox.Location = new System.Drawing.Point(1, 1);
            this.permissionComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.permissionComboBox.Name = "permissionComboBox";
            this.permissionComboBox.Size = new System.Drawing.Size(135, 34);
            this.permissionComboBox.TabIndex = 92;
            this.permissionComboBox.SelectedIndexChanged += new System.EventHandler(this.permissionComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(957, 1);
            this.label1.TabIndex = 34;
            // 
            // KhosraReviewOfficerRowUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "KhosraReviewOfficerRowUserControl";
            this.Size = new System.Drawing.Size(957, 80);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.permissionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton deleteButton;
        public System.Windows.Forms.Label officeUnitLabel;
        public System.Windows.Forms.Label designationLabel;
        public System.Windows.Forms.Label officerNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox permissionComboBox;
        private System.Windows.Forms.Panel permissionPanel;
    }
}
