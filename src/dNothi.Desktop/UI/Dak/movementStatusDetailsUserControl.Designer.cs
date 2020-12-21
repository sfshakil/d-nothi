namespace dNothi.Desktop.UI.Dak
{
    partial class MovementStatusDetailsUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.userDesignationLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userTypeLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.userDesignationLabel);
            this.panel1.Controls.Add(this.userNameLabel);
            this.panel1.Location = new System.Drawing.Point(66, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 21);
            this.panel1.TabIndex = 1;
            // 
            // userDesignationLabel
            // 
            this.userDesignationLabel.AutoSize = true;
            this.userDesignationLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.userDesignationLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userDesignationLabel.Location = new System.Drawing.Point(89, 0);
            this.userDesignationLabel.Name = "userDesignationLabel";
            this.userDesignationLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.userDesignationLabel.Size = new System.Drawing.Size(389, 16);
            this.userDesignationLabel.TabIndex = 3;
            this.userDesignationLabel.Text = "(ন্যাশনাল কনসালটেন্ট ফর ই-নথি ইমপ্লিমেন্টেশন  উপজেলা পর্যায়ের ইনি সংক্রান্ত ০১ দ" +
    "িনব্যাগী ";
            this.userDesignationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userDesignationLabel.Click += new System.EventHandler(this.userDesignationLabel_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.userNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(0, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.userNameLabel.Size = new System.Drawing.Size(89, 19);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "নিলুফা ইয়াসমিন";
            // 
            // userTypeLabel
            // 
            this.userTypeLabel.AutoSize = true;
            this.userTypeLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTypeLabel.Location = new System.Drawing.Point(12, 8);
            this.userTypeLabel.MaximumSize = new System.Drawing.Size(50, 0);
            this.userTypeLabel.Name = "userTypeLabel";
            this.userTypeLabel.Size = new System.Drawing.Size(49, 36);
            this.userTypeLabel.TabIndex = 2;
            this.userTypeLabel.Text = "অনুলিপি প্রাপক:";
            // 
            // MovementStatusDetailsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.userTypeLabel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MovementStatusDetailsUserControl";
            this.Size = new System.Drawing.Size(742, 52);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userDesignationLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userTypeLabel;
    }
}
