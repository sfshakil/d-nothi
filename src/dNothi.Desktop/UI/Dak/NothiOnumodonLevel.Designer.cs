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
            this.btnChair.Location = new System.Drawing.Point(15, 12);
            this.btnChair.Margin = new System.Windows.Forms.Padding(4);
            this.btnChair.Name = "btnChair";
            this.btnChair.Size = new System.Drawing.Size(39, 44);
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
            this.LeftPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(77, 159);
            this.LeftPanel.TabIndex = 6;
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLevel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbLevel.Location = new System.Drawing.Point(10, 10);
            this.lbLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Padding = new System.Windows.Forms.Padding(0, 3, 30, 0);
            this.lbLevel.Size = new System.Drawing.Size(109, 29);
            this.lbLevel.TabIndex = 50;
            this.lbLevel.Text = "লেভেল ১";
            // 
            // btnKarjodibosh
            // 
            this.btnKarjodibosh.AutoSize = true;
            this.btnKarjodibosh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(222)))));
            this.btnKarjodibosh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKarjodibosh.FlatAppearance.BorderSize = 0;
            this.btnKarjodibosh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKarjodibosh.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKarjodibosh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(87)))), ((int)(((byte)(0)))));
            this.btnKarjodibosh.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnKarjodibosh.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.btnKarjodibosh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKarjodibosh.IconSize = 32;
            this.btnKarjodibosh.Location = new System.Drawing.Point(624, 10);
            this.btnKarjodibosh.Margin = new System.Windows.Forms.Padding(4);
            this.btnKarjodibosh.Name = "btnKarjodibosh";
            this.btnKarjodibosh.Size = new System.Drawing.Size(97, 32);
            this.btnKarjodibosh.TabIndex = 55;
            this.btnKarjodibosh.Text = "কার্যদিবস ";
            this.btnKarjodibosh.UseVisualStyleBackColor = false;
            this.btnKarjodibosh.Click += new System.EventHandler(this.btnKarjodibosh_Click);
            // 
            // cbxNiontron
            // 
            this.cbxNiontron.AutoSize = true;
            this.cbxNiontron.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbxNiontron.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNiontron.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.cbxNiontron.Location = new System.Drawing.Point(514, 10);
            this.cbxNiontron.Margin = new System.Windows.Forms.Padding(0);
            this.cbxNiontron.Name = "cbxNiontron";
            this.cbxNiontron.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.cbxNiontron.Size = new System.Drawing.Size(110, 32);
            this.cbxNiontron.TabIndex = 56;
            this.cbxNiontron.Text = "নিয়ন্ত্রিত";
            this.cbxNiontron.UseVisualStyleBackColor = true;
            this.cbxNiontron.CheckedChanged += new System.EventHandler(this.cbxNiontron_CheckedChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSize = true;
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveBorder;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.Color.Transparent;
            this.deleteButton.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.deleteButton.IconColor = System.Drawing.Color.Red;
            this.deleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.deleteButton.IconSize = 18;
            this.deleteButton.Location = new System.Drawing.Point(721, 10);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.deleteButton.Size = new System.Drawing.Size(36, 32);
            this.deleteButton.TabIndex = 57;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxNiontron);
            this.panel1.Controls.Add(this.btnKarjodibosh);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.lbLevel);
            this.panel1.Location = new System.Drawing.Point(81, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(767, 52);
            this.panel1.TabIndex = 7;
            // 
            // officerTableLayoutPanel
            // 
            this.officerTableLayoutPanel.AllowDrop = true;
            this.officerTableLayoutPanel.AutoSize = true;
            this.officerTableLayoutPanel.Location = new System.Drawing.Point(81, 54);
            this.officerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.officerTableLayoutPanel.MaximumSize = new System.Drawing.Size(767, 0);
            this.officerTableLayoutPanel.MinimumSize = new System.Drawing.Size(767, 0);
            this.officerTableLayoutPanel.Name = "officerTableLayoutPanel";
            this.officerTableLayoutPanel.Padding = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.officerTableLayoutPanel.Size = new System.Drawing.Size(767, 5);
            this.officerTableLayoutPanel.TabIndex = 8;
            // 
            // movementStatusSliderPanel1
            // 
            this.movementStatusSliderPanel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.movementStatusSliderPanel1.Location = new System.Drawing.Point(55, 0);
            this.movementStatusSliderPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.movementStatusSliderPanel1.Name = "movementStatusSliderPanel1";
            this.movementStatusSliderPanel1.Size = new System.Drawing.Size(99, 106);
            this.movementStatusSliderPanel1.TabIndex = 0;
            // 
            // NothiOnumodonLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.officerTableLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LeftPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NothiOnumodonLevel";
            this.Size = new System.Drawing.Size(853, 159);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NothiOnumodonLevel_Paint);
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
