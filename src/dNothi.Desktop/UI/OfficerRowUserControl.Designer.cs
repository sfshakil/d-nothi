namespace dNothi.Desktop.UI
{
    partial class OfficerRowUserControl
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
            this.officerNameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteButton = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // officerNameLabel
            // 
            this.officerNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.officerNameLabel.Location = new System.Drawing.Point(11, 13);
            this.officerNameLabel.MaximumSize = new System.Drawing.Size(280, 13);
            this.officerNameLabel.Name = "officerNameLabel";
            this.officerNameLabel.Size = new System.Drawing.Size(214, 13);
            this.officerNameLabel.TabIndex = 0;
            this.officerNameLabel.Text = "[officerName jsdfbhsdjk fgbjksdbf sdjkf bgsd fjgsdfsd fjsdgfj dsjkfgbdsakj fvbfjk" +
    "dsa fkjdsa bfkjsadbf]";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.officerNameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 41);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.deleteButton.IconColor = System.Drawing.Color.Red;
            this.deleteButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.deleteButton.IconSize = 32;
            this.deleteButton.Location = new System.Drawing.Point(232, 10);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 23);
            this.deleteButton.TabIndex = 86;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // OfficerRowUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "OfficerRowUserControl";
            this.Size = new System.Drawing.Size(265, 41);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label officerNameLabel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton deleteButton;
    }
}
