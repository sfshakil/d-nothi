namespace dNothi.Desktop.UI.Dak
{
    partial class DakAttachmentListBodyUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.attachmentListFlowLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachmentCountLabel
            // 
            this.attachmentCountLabel.AutoSize = true;
            this.attachmentCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.attachmentCountLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.attachmentCountLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentCountLabel.Location = new System.Drawing.Point(0, 10);
            this.attachmentCountLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.attachmentCountLabel.Name = "attachmentCountLabel";
            this.attachmentCountLabel.Size = new System.Drawing.Size(66, 18);
            this.attachmentCountLabel.TabIndex = 68;
            this.attachmentCountLabel.Text = "সংযুক্তি (৩)";
            // 
            // attachmentZipDownloadButton
            // 
            this.attachmentZipDownloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.attachmentZipDownloadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.attachmentZipDownloadButton.FlatAppearance.BorderSize = 0;
            this.attachmentZipDownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentZipDownloadButton.IconChar = FontAwesome.Sharp.IconChar.CloudDownloadAlt;
            this.attachmentZipDownloadButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(211)))));
            this.attachmentZipDownloadButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.attachmentZipDownloadButton.IconSize = 32;
            this.attachmentZipDownloadButton.Location = new System.Drawing.Point(868, 10);
            this.attachmentZipDownloadButton.Margin = new System.Windows.Forms.Padding(0);
            this.attachmentZipDownloadButton.MaximumSize = new System.Drawing.Size(31, 24);
            this.attachmentZipDownloadButton.MinimumSize = new System.Drawing.Size(31, 24);
            this.attachmentZipDownloadButton.Name = "attachmentZipDownloadButton";
            this.attachmentZipDownloadButton.Size = new System.Drawing.Size(31, 24);
            this.attachmentZipDownloadButton.TabIndex = 7;
            this.attachmentZipDownloadButton.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.attachmentZipDownloadButton);
            this.panel2.Controls.Add(this.attachmentCountLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panel2.Size = new System.Drawing.Size(899, 42);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(899, 1);
            this.label1.TabIndex = 69;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 20);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.attachmentListFlowLayoutPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 431);
            this.panel1.TabIndex = 0;
            // 
            // attachmentListFlowLayoutPanel
            // 
            this.attachmentListFlowLayoutPanel.AutoSize = true;
            this.attachmentListFlowLayoutPanel.ColumnCount = 1;
            this.attachmentListFlowLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.attachmentListFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.attachmentListFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.attachmentListFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.attachmentListFlowLayoutPanel.Name = "attachmentListFlowLayoutPanel";
            this.attachmentListFlowLayoutPanel.RowCount = 1;
            this.attachmentListFlowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.attachmentListFlowLayoutPanel.Size = new System.Drawing.Size(893, 0);
            this.attachmentListFlowLayoutPanel.TabIndex = 1;
            // 
            // DakAttachmentListBodyUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DakAttachmentListBodyUserControl";
            this.Size = new System.Drawing.Size(909, 500);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label attachmentCountLabel;
        private FontAwesome.Sharp.IconButton attachmentZipDownloadButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel attachmentListFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
