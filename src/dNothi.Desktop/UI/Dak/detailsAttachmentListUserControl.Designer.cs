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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsAttachmentListUserControl));
            this.attachmentCountLabel = new System.Windows.Forms.Label();
            this.attachmentListFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.attachmentZipDownloadButton = new System.Windows.Forms.Button();
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
            this.attachmentListFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attachmentListFlowLayoutPanel.Location = new System.Drawing.Point(11, 33);
            this.attachmentListFlowLayoutPanel.Name = "attachmentListFlowLayoutPanel";
            this.attachmentListFlowLayoutPanel.Size = new System.Drawing.Size(796, 374);
            this.attachmentListFlowLayoutPanel.TabIndex = 72;
            // 
            // attachmentZipDownloadButton
            // 
            this.attachmentZipDownloadButton.BackColor = System.Drawing.Color.Transparent;
            this.attachmentZipDownloadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("attachmentZipDownloadButton.BackgroundImage")));
            this.attachmentZipDownloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attachmentZipDownloadButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.attachmentZipDownloadButton.FlatAppearance.BorderSize = 0;
            this.attachmentZipDownloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.attachmentZipDownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentZipDownloadButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentZipDownloadButton.Location = new System.Drawing.Point(768, 6);
            this.attachmentZipDownloadButton.Name = "attachmentZipDownloadButton";
            this.attachmentZipDownloadButton.Size = new System.Drawing.Size(21, 18);
            this.attachmentZipDownloadButton.TabIndex = 81;
            this.attachmentZipDownloadButton.UseVisualStyleBackColor = false;
            // 
            // DetailsAttachmentListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.attachmentZipDownloadButton);
            this.Controls.Add(this.attachmentListFlowLayoutPanel);
            this.Controls.Add(this.attachmentCountLabel);
            this.Name = "DetailsAttachmentListUserControl";
            this.Size = new System.Drawing.Size(858, 430);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label attachmentCountLabel;
        private System.Windows.Forms.FlowLayoutPanel attachmentListFlowLayoutPanel;
        private System.Windows.Forms.Button attachmentZipDownloadButton;
    }
}
