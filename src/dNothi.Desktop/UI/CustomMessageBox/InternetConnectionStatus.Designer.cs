namespace dNothi.Desktop.UI.CustomMessageBox
{
    partial class InternetConnectionStatus
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.messageIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkIconPictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.messageLabel.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.White;
            this.messageLabel.Location = new System.Drawing.Point(2, 21);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.messageLabel.MaximumSize = new System.Drawing.Size(320, 0);
            this.messageLabel.MinimumSize = new System.Drawing.Size(220, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(220, 20);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "You Are Offline!";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.messageLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(84, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(320, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(213, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 60);
            this.panel1.TabIndex = 40;
            // 
            // checkIconPictureBox
            // 
            this.checkIconPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.checkIconPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkIconPictureBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.checkIconPictureBox.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.checkIconPictureBox.IconSize = 42;
            this.checkIconPictureBox.Location = new System.Drawing.Point(0, 0);
            this.checkIconPictureBox.Name = "checkIconPictureBox";
            this.checkIconPictureBox.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.checkIconPictureBox.Size = new System.Drawing.Size(42, 60);
            this.checkIconPictureBox.TabIndex = 42;
            this.checkIconPictureBox.TabStop = false;
            this.checkIconPictureBox.Visible = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.messageIconPictureBox);
            this.panel3.Controls.Add(this.checkIconPictureBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(84, 60);
            this.panel3.TabIndex = 43;
            // 
            // messageIconPictureBox
            // 
            this.messageIconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.messageIconPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.messageIconPictureBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.messageIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.messageIconPictureBox.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.messageIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.messageIconPictureBox.IconSize = 42;
            this.messageIconPictureBox.Location = new System.Drawing.Point(42, 0);
            this.messageIconPictureBox.Name = "messageIconPictureBox";
            this.messageIconPictureBox.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.messageIconPictureBox.Size = new System.Drawing.Size(42, 60);
            this.messageIconPictureBox.TabIndex = 0;
            this.messageIconPictureBox.TabStop = false;
            // 
            // InternetConnectionStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "InternetConnectionStatus";
            this.Size = new System.Drawing.Size(314, 60);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkIconPictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messageIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox checkIconPictureBox;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconPictureBox messageIconPictureBox;
    }
}
