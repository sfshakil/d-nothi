namespace dNothi.Desktop.UI.Dak
{
    partial class NothiOnumodonLevel
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
            this.btnChair = new FontAwesome.Sharp.IconButton();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.lbLevel = new System.Windows.Forms.Label();
            this.btnKarjodibosh = new FontAwesome.Sharp.IconButton();
            this.cbxNiontron = new System.Windows.Forms.CheckBox();
            this.deleteButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.officerTableLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.movementStatusSliderPanel1 = new dNothi.Desktop.CustomControl.MovementStatusSliderPanel();
            this.LeftPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChair
            // 
            this.btnChair.BackColor = System.Drawing.Color.Transparent;
            this.btnChair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.btnChair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.btnChair.IconChar = FontAwesome.Sharp.IconChar.Chair;
            this.btnChair.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnChair.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChair.IconSize = 32;
            this.btnChair.Location = new System.Drawing.Point(11, 10);
            this.btnChair.Name = "btnChair";
            this.btnChair.Size = new System.Drawing.Size(29, 36);
            this.btnChair.TabIndex = 104;
            this.btnChair.UseVisualStyleBackColor = false;
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LeftPanel.Controls.Add(this.btnChair);
            this.LeftPanel.Controls.Add(this.movementStatusSliderPanel1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(58, 72);
            this.LeftPanel.TabIndex = 6;
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbLevel.Location = new System.Drawing.Point(6, 18);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(55, 18);
            this.lbLevel.TabIndex = 50;
            this.lbLevel.Text = "লেভেল ১";
            // 
            // btnKarjodibosh
            // 
            this.btnKarjodibosh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(222)))));
            this.btnKarjodibosh.FlatAppearance.BorderSize = 0;
            this.btnKarjodibosh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKarjodibosh.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKarjodibosh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(87)))), ((int)(((byte)(0)))));
            this.btnKarjodibosh.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnKarjodibosh.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.btnKarjodibosh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKarjodibosh.IconSize = 32;
            this.btnKarjodibosh.Location = new System.Drawing.Point(68, 11);
            this.btnKarjodibosh.Name = "btnKarjodibosh";
            this.btnKarjodibosh.Size = new System.Drawing.Size(66, 35);
            this.btnKarjodibosh.TabIndex = 55;
            this.btnKarjodibosh.Text = "কার্যদিবস ";
            this.btnKarjodibosh.UseVisualStyleBackColor = false;
            // 
            // cbxNiontron
            // 
            this.cbxNiontron.AutoSize = true;
            this.cbxNiontron.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNiontron.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.cbxNiontron.Location = new System.Drawing.Point(140, 17);
            this.cbxNiontron.Name = "cbxNiontron";
            this.cbxNiontron.Size = new System.Drawing.Size(65, 22);
            this.cbxNiontron.TabIndex = 56;
            this.cbxNiontron.Text = "নিয়ন্ত্রিত";
            this.cbxNiontron.UseVisualStyleBackColor = true;
            this.cbxNiontron.CheckedChanged += new System.EventHandler(this.cbxNiontron_CheckedChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveBorder;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.Color.Transparent;
            this.deleteButton.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.deleteButton.IconColor = System.Drawing.Color.Red;
            this.deleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.deleteButton.IconSize = 18;
            this.deleteButton.Location = new System.Drawing.Point(208, 17);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(25, 23);
            this.deleteButton.TabIndex = 57;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.cbxNiontron);
            this.panel1.Controls.Add(this.btnKarjodibosh);
            this.panel1.Controls.Add(this.lbLevel);
            this.panel1.Location = new System.Drawing.Point(61, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 42);
            this.panel1.TabIndex = 7;
            // 
            // officerTableLayoutPanel
            // 
            this.officerTableLayoutPanel.AllowDrop = true;
            this.officerTableLayoutPanel.AutoSize = true;
            this.officerTableLayoutPanel.Location = new System.Drawing.Point(61, 44);
            this.officerTableLayoutPanel.MaximumSize = new System.Drawing.Size(429, 0);
            this.officerTableLayoutPanel.MinimumSize = new System.Drawing.Size(429, 0);
            this.officerTableLayoutPanel.Name = "officerTableLayoutPanel";
            this.officerTableLayoutPanel.Size = new System.Drawing.Size(429, 0);
            this.officerTableLayoutPanel.TabIndex = 8;
            // 
            // movementStatusSliderPanel1
            // 
            this.movementStatusSliderPanel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.movementStatusSliderPanel1.Location = new System.Drawing.Point(41, 0);
            this.movementStatusSliderPanel1.Name = "movementStatusSliderPanel1";
            this.movementStatusSliderPanel1.Size = new System.Drawing.Size(74, 86);
            this.movementStatusSliderPanel1.TabIndex = 0;
            // 
            // NothiOnumodonLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.officerTableLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LeftPanel);
            this.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.Name = "NothiOnumodonLevel";
            this.Size = new System.Drawing.Size(493, 72);
            this.LeftPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControl.MovementStatusSliderPanel movementStatusSliderPanel1;
        private FontAwesome.Sharp.IconButton btnChair;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Label lbLevel;
        private FontAwesome.Sharp.IconButton btnKarjodibosh;
        private System.Windows.Forms.CheckBox cbxNiontron;
        private FontAwesome.Sharp.IconButton deleteButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel officerTableLayoutPanel;
    }
}
