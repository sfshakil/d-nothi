
namespace dNothi.Desktop.UI.Dak
{
    partial class KhoshraToShareWindowUserControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNoteShakha = new System.Windows.Forms.Label();
            this.reviewDashboardButton = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbNoteShakha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 60);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reviewDashboardButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 67);
            this.panel2.TabIndex = 1;
            // 
            // lbNoteShakha
            // 
            this.lbNoteShakha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNoteShakha.AutoSize = true;
            this.lbNoteShakha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.lbNoteShakha.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbNoteShakha.ForeColor = System.Drawing.Color.White;
            this.lbNoteShakha.Location = new System.Drawing.Point(38, 10);
            this.lbNoteShakha.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoteShakha.Name = "lbNoteShakha";
            this.lbNoteShakha.Padding = new System.Windows.Forms.Padding(5);
            this.lbNoteShakha.Size = new System.Drawing.Size(223, 36);
            this.lbNoteShakha.TabIndex = 64;
            this.lbNoteShakha.Text = "পত্রটি রিভিউ অবস্থায় রয়েছে";
            // 
            // reviewDashboardButton
            // 
            this.reviewDashboardButton.AutoSize = true;
            this.reviewDashboardButton.BackColor = System.Drawing.Color.Transparent;
            this.reviewDashboardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewDashboardButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(80)))), ((int)(((byte)(252)))));
            this.reviewDashboardButton.FlatAppearance.BorderSize = 0;
            this.reviewDashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewDashboardButton.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.reviewDashboardButton.ForeColor = System.Drawing.Color.White;
            this.reviewDashboardButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.reviewDashboardButton.IconColor = System.Drawing.Color.AntiqueWhite;
            this.reviewDashboardButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reviewDashboardButton.IconSize = 20;
            this.reviewDashboardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reviewDashboardButton.Location = new System.Drawing.Point(0, 0);
            this.reviewDashboardButton.Margin = new System.Windows.Forms.Padding(0);
            this.reviewDashboardButton.Name = "reviewDashboardButton";
            this.reviewDashboardButton.Size = new System.Drawing.Size(310, 67);
            this.reviewDashboardButton.TabIndex = 79;
            this.reviewDashboardButton.Text = "শেয়ার উইন্ডোতে যান";
            this.reviewDashboardButton.UseVisualStyleBackColor = false;
            this.reviewDashboardButton.Click += new System.EventHandler(this.reviewDashboardButton_Click);
            // 
            // KhoshraToShareWindowUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(80)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "KhoshraToShareWindowUserControl";
            this.Size = new System.Drawing.Size(310, 127);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbNoteShakha;
        private FontAwesome.Sharp.IconButton reviewDashboardButton;
    }
}
