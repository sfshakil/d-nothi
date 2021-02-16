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
            this.attachmentListFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.attachmentZipDownloadButton = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachmentCountLabel
            // 
            this.attachmentCountLabel.AutoSize = true;
            this.attachmentCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.attachmentCountLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentCountLabel.Location = new System.Drawing.Point(10, 6);
            this.attachmentCountLabel.Name = "attachmentCountLabel";
            this.attachmentCountLabel.Size = new System.Drawing.Size(66, 18);
            this.attachmentCountLabel.TabIndex = 68;
            this.attachmentCountLabel.Text = "সংযুক্তি (৩)";
            // 
            // attachmentListFlowLayoutPanel
            // 
            this.attachmentListFlowLayoutPanel.AutoSize = true;
            this.attachmentListFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.attachmentListFlowLayoutPanel.Location = new System.Drawing.Point(3, 4);
            this.attachmentListFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.attachmentListFlowLayoutPanel.Name = "attachmentListFlowLayoutPanel";
            this.attachmentListFlowLayoutPanel.Size = new System.Drawing.Size(790, 374);
            this.attachmentListFlowLayoutPanel.TabIndex = 72;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.attachmentListFlowLayoutPanel);
            this.panel1.Location = new System.Drawing.Point(13, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(796, 382);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderColorBlue);
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
            this.attachmentZipDownloadButton.Location = new System.Drawing.Point(772, 2);
            this.attachmentZipDownloadButton.Name = "attachmentZipDownloadButton";
            this.attachmentZipDownloadButton.Size = new System.Drawing.Size(31, 24);
            this.attachmentZipDownloadButton.TabIndex = 7;
            this.attachmentZipDownloadButton.UseVisualStyleBackColor = false;
            // 
            // DetailsAttachmentListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.attachmentZipDownloadButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.attachmentCountLabel);
            this.Name = "DetailsAttachmentListUserControl";
            this.Size = new System.Drawing.Size(858, 430);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label attachmentCountLabel;
        private System.Windows.Forms.FlowLayoutPanel attachmentListFlowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton attachmentZipDownloadButton;
    }
}
