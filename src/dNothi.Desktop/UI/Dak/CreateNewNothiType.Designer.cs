namespace dNothi.Desktop.UI.Dak
{
    partial class CreateNewNothiType
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNothiType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNothiDhoron = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInfo = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDhoronCode = new PlaceholderTextBox.PlaceholderTextBox();
            this.userIdPanel = new System.Windows.Forms.Panel();
            this.invisiblecbxNothiType = new System.Windows.Forms.ComboBox();
            this.lbNothitype2digitText = new System.Windows.Forms.Label();
            this.lbNothitype2digit = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.userIdPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "বিষয়ের ধরন";
            // 
            // cbxNothiType
            // 
            this.cbxNothiType.BackColor = System.Drawing.Color.White;
            this.cbxNothiType.DropDownHeight = 500;
            this.cbxNothiType.DropDownWidth = 400;
            this.cbxNothiType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNothiType.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNothiType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbxNothiType.FormattingEnabled = true;
            this.cbxNothiType.IntegralHeight = false;
            this.cbxNothiType.ItemHeight = 22;
            this.cbxNothiType.Location = new System.Drawing.Point(3, 1);
            this.cbxNothiType.Margin = new System.Windows.Forms.Padding(0);
            this.cbxNothiType.MaxDropDownItems = 100;
            this.cbxNothiType.Name = "cbxNothiType";
            this.cbxNothiType.Size = new System.Drawing.Size(329, 30);
            this.cbxNothiType.TabIndex = 0;
            this.cbxNothiType.Text = "বাছাই করুন";
            this.cbxNothiType.SelectedIndexChanged += new System.EventHandler(this.cbxNothiType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(372, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "২ ডিজিটের ধরন কোড";
            // 
            // btnNothiDhoron
            // 
            this.btnNothiDhoron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnNothiDhoron.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnNothiDhoron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNothiDhoron.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNothiDhoron.ForeColor = System.Drawing.Color.White;
            this.btnNothiDhoron.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNothiDhoron.Location = new System.Drawing.Point(280, 64);
            this.btnNothiDhoron.Name = "btnNothiDhoron";
            this.btnNothiDhoron.Size = new System.Drawing.Size(118, 43);
            this.btnNothiDhoron.TabIndex = 50;
            this.btnNothiDhoron.Text = "সংরক্ষণ করুন";
            this.btnNothiDhoron.UseVisualStyleBackColor = false;
            this.btnNothiDhoron.Click += new System.EventHandler(this.btnNothiDhoron_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(398, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 43);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "বাতিল করুন";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.btnInfo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.btnInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInfo.IconSize = 32;
            this.btnInfo.Location = new System.Drawing.Point(6, 64);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(34, 43);
            this.btnInfo.TabIndex = 63;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxNothiType);
            this.panel1.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 32);
            this.panel1.TabIndex = 64;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtDhoronCode
            // 
            this.txtDhoronCode.BackColor = System.Drawing.Color.White;
            this.txtDhoronCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDhoronCode.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDhoronCode.Location = new System.Drawing.Point(97, 74);
            this.txtDhoronCode.Name = "txtDhoronCode";
            this.txtDhoronCode.PlaceholderText = "২ ডিজিটের ধরন কোড";
            this.txtDhoronCode.Size = new System.Drawing.Size(53, 22);
            this.txtDhoronCode.TabIndex = 3;
            this.txtDhoronCode.Visible = false;
            // 
            // userIdPanel
            // 
            this.userIdPanel.BackColor = System.Drawing.Color.Transparent;
            this.userIdPanel.Controls.Add(this.lbNothitype2digitText);
            this.userIdPanel.Controls.Add(this.lbNothitype2digit);
            this.userIdPanel.Location = new System.Drawing.Point(363, 28);
            this.userIdPanel.Name = "userIdPanel";
            this.userIdPanel.Size = new System.Drawing.Size(150, 30);
            this.userIdPanel.TabIndex = 78;
            this.userIdPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userIdPanel_Paint);
            // 
            // invisiblecbxNothiType
            // 
            this.invisiblecbxNothiType.BackColor = System.Drawing.Color.White;
            this.invisiblecbxNothiType.DropDownHeight = 500;
            this.invisiblecbxNothiType.DropDownWidth = 400;
            this.invisiblecbxNothiType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invisiblecbxNothiType.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invisiblecbxNothiType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.invisiblecbxNothiType.FormattingEnabled = true;
            this.invisiblecbxNothiType.IntegralHeight = false;
            this.invisiblecbxNothiType.ItemHeight = 22;
            this.invisiblecbxNothiType.Location = new System.Drawing.Point(194, -6);
            this.invisiblecbxNothiType.Margin = new System.Windows.Forms.Padding(0);
            this.invisiblecbxNothiType.MaxDropDownItems = 100;
            this.invisiblecbxNothiType.Name = "invisiblecbxNothiType";
            this.invisiblecbxNothiType.Size = new System.Drawing.Size(23, 30);
            this.invisiblecbxNothiType.TabIndex = 79;
            this.invisiblecbxNothiType.Text = "বাছাই করুন";
            this.invisiblecbxNothiType.Visible = false;
            this.invisiblecbxNothiType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.invisiblecbxNothiType_DrawItem);
            this.invisiblecbxNothiType.SelectedIndexChanged += new System.EventHandler(this.invisiblecbxNothiType_SelectedIndexChanged);
            // 
            // lbNothitype2digitText
            // 
            this.lbNothitype2digitText.AutoSize = true;
            this.lbNothitype2digitText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNothitype2digitText.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNothitype2digitText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbNothitype2digitText.Location = new System.Drawing.Point(0, 0);
            this.lbNothitype2digitText.Name = "lbNothitype2digitText";
            this.lbNothitype2digitText.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lbNothitype2digitText.Size = new System.Drawing.Size(141, 24);
            this.lbNothitype2digitText.TabIndex = 87;
            this.lbNothitype2digitText.Text = "২ ডিজিটের ধরন কোড";
            // 
            // lbNothitype2digit
            // 
            this.lbNothitype2digit.BackColor = System.Drawing.Color.White;
            this.lbNothitype2digit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbNothitype2digit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNothitype2digit.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNothitype2digit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbNothitype2digit.Location = new System.Drawing.Point(0, 0);
            this.lbNothitype2digit.MaxLength = 2;
            this.lbNothitype2digit.Multiline = true;
            this.lbNothitype2digit.Name = "lbNothitype2digit";
            this.lbNothitype2digit.Size = new System.Drawing.Size(150, 30);
            this.lbNothitype2digit.TabIndex = 86;
            this.lbNothitype2digit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbNothitype2digit_MouseClick);
            // 
            // CreateNewNothiType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtDhoronCode);
            this.Controls.Add(this.invisiblecbxNothiType);
            this.Controls.Add(this.userIdPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNothiDhoron);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CreateNewNothiType";
            this.Size = new System.Drawing.Size(520, 116);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CreateNewNothiType_Paint);
            this.panel1.ResumeLayout(false);
            this.userIdPanel.ResumeLayout(false);
            this.userIdPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNothiType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNothiDhoron;
        private System.Windows.Forms.Button btnCancel;
        private FontAwesome.Sharp.IconButton btnInfo;
        private System.Windows.Forms.Panel panel1;
        private PlaceholderTextBox.PlaceholderTextBox txtDhoronCode;
        private System.Windows.Forms.Panel userIdPanel;
        private System.Windows.Forms.ComboBox invisiblecbxNothiType;
        private System.Windows.Forms.Label lbNothitype2digitText;
        private System.Windows.Forms.TextBox lbNothitype2digit;
    }
}
