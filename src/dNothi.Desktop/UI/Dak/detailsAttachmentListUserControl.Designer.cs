namespace dNothi.Desktop.UI.Dak
{
    partial class DetailsAttachmentListUserControl
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
            this.attachmentCountLabel = new System.Windows.Forms.Label();
            this.attachmentZipDownloadButton = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.attachmentListFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachmentCountLabel
            // 
            this.attachmentCountLabel.AutoSize = true;
            this.attachmentCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.attachmentCountLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentCountLabel.Location = new System.Drawing.Point(12, 19);
            this.attachmentCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.attachmentCountLabel.Name = "attachmentCountLabel";
            this.attachmentCountLabel.Size = new System.Drawing.Size(96, 26);
            this.attachmentCountLabel.TabIndex = 68;
            this.attachmentCountLabel.Text = "সংযুক্তি (৩)";
            // 
            // attachmentZipDownloadButton
            // 
            this.attachmentZipDownloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.attachmentZipDownloadButton.FlatAppearance.BorderSize = 0;
            this.attachmentZipDownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentZipDownloadButton.IconChar = FontAwesome.Sharp.IconChar.CloudDownloadAlt;
            this.attachmentZipDownloadButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(211)))));
            this.attachmentZipDownloadButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.attachmentZipDownloadButton.IconSize = 32;
            this.attachmentZipDownloadButton.Location = new System.Drawing.Point(1085, 19);
            this.attachmentZipDownloadButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.attachmentZipDownloadButton.Name = "attachmentZipDownloadButton";
            this.attachmentZipDownloadButton.Size = new System.Drawing.Size(41, 30);
            this.attachmentZipDownloadButton.TabIndex = 7;
            this.attachmentZipDownloadButton.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.attachmentCountLabel);
            this.panel2.Controls.Add(this.attachmentZipDownloadButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1140, 78);
            this.panel2.TabIndex = 69;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1140, 447);
            this.panel1.TabIndex = 70;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.attachmentListFlowLayoutPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(1130, 437);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderColorBlue);
            // 
            // attachmentListFlowLayoutPanel
            // 
            this.attachmentListFlowLayoutPanel.AutoSize = true;
            this.attachmentListFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentListFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.attachmentListFlowLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.attachmentListFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.attachmentListFlowLayoutPanel.Name = "attachmentListFlowLayoutPanel";
            this.attachmentListFlowLayoutPanel.Size = new System.Drawing.Size(1122, 429);
            this.attachmentListFlowLayoutPanel.TabIndex = 72;
            // 
            // DetailsAttachmentListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DetailsAttachmentListUserControl";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(1144, 529);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderColorBlue);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label attachmentCountLabel;
        private FontAwesome.Sharp.IconButton attachmentZipDownloadButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel attachmentListFlowLayoutPanel;
    }
}
