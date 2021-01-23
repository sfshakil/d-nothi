namespace dNothi.Desktop.UI.CustomMessageBox
{
    partial class ConditonBoxForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.yesButton = new FontAwesome.Sharp.IconButton();
            this.noButton = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 1);
            this.label1.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(29, 13);
            this.messageLabel.MaximumSize = new System.Drawing.Size(280, 0);
            this.messageLabel.MinimumSize = new System.Drawing.Size(280, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(280, 21);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "আপনি কি ডাকটি ফেরত আনতে চান ?";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.messageLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.panel1.Size = new System.Drawing.Size(350, 49);
            this.panel1.TabIndex = 2;
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.yesButton.FlatAppearance.BorderSize = 0;
            this.yesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesButton.ForeColor = System.Drawing.Color.White;
            this.yesButton.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.yesButton.IconColor = System.Drawing.Color.White;
            this.yesButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.yesButton.IconSize = 24;
            this.yesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yesButton.Location = new System.Drawing.Point(114, 71);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(58, 32);
            this.yesButton.TabIndex = 3;
            this.yesButton.Text = "হ্যাঁ";
            this.yesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yesButton.UseVisualStyleBackColor = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.noButton.FlatAppearance.BorderSize = 0;
            this.noButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.ForeColor = System.Drawing.Color.Black;
            this.noButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.noButton.IconColor = System.Drawing.Color.Black;
            this.noButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.noButton.IconSize = 24;
            this.noButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.noButton.Location = new System.Drawing.Point(172, 71);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(58, 32);
            this.noButton.TabIndex = 5;
            this.noButton.Text = "না";
            this.noButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.noButton);
            this.panel2.Controls.Add(this.yesButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 117);
            this.panel2.TabIndex = 2;
            // 
            // ConditonBoxForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(370, 137);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConditonBoxForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConditonBoxForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton yesButton;
        private FontAwesome.Sharp.IconButton noButton;
        private System.Windows.Forms.Panel panel2;
    }
}