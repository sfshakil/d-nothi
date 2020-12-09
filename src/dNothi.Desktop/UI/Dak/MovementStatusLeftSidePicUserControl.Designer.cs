namespace dNothi.Desktop.UI.Dak
{
    partial class MovementStatusLeftSidePicUserControl
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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.HorizontalLine = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.decisionLabel = new System.Windows.Forms.Label();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.movementStatusdetailsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.securityPanel = new System.Windows.Forms.Panel();
            this.dakSecurityIconPanel = new System.Windows.Forms.Panel();
            this.priorityPanel = new System.Windows.Forms.Panel();
            this.prioriyLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.movementStatusSliderPanel1 = new dNothi.Desktop.CustomControl.MovementStatusSliderPanel();
            this.officerCircularPictureBox = new dNothi.Desktop.CircularPictureBox();
            this.LeftPanel.SuspendLayout();
            this.descriptionPanel.SuspendLayout();
            this.securityPanel.SuspendLayout();
            this.priorityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerCircularPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LeftPanel.Controls.Add(this.movementStatusSliderPanel1);
            this.LeftPanel.Controls.Add(this.HorizontalLine);
            this.LeftPanel.Controls.Add(this.officerCircularPictureBox);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(75, 238);
            this.LeftPanel.TabIndex = 2;
            // 
            // HorizontalLine
            // 
            this.HorizontalLine.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HorizontalLine.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.HorizontalLine.Location = new System.Drawing.Point(33, 64);
            this.HorizontalLine.Margin = new System.Windows.Forms.Padding(0);
            this.HorizontalLine.Name = "HorizontalLine";
            this.HorizontalLine.Size = new System.Drawing.Size(1, 300);
            this.HorizontalLine.TabIndex = 0;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dateLabel.Location = new System.Drawing.Point(85, 38);
            this.dateLabel.MaximumSize = new System.Drawing.Size(424, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dateLabel.Size = new System.Drawing.Size(127, 17);
            this.dateLabel.TabIndex = 22;
            this.dateLabel.Text = "৩/১২/২০ ১১:০৩ AM";
            // 
            // decisionLabel
            // 
            this.decisionLabel.AutoSize = true;
            this.decisionLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decisionLabel.Location = new System.Drawing.Point(85, 6);
            this.decisionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.decisionLabel.MaximumSize = new System.Drawing.Size(424, 0);
            this.decisionLabel.Name = "decisionLabel";
            this.decisionLabel.Padding = new System.Windows.Forms.Padding(10, 5, 0, 10);
            this.decisionLabel.Size = new System.Drawing.Size(197, 32);
            this.decisionLabel.TabIndex = 21;
            this.decisionLabel.Text = "সদয় সিদ্ধান্তের জন্যে প্রেরণ করা হলো";
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.AutoSize = true;
            this.descriptionPanel.Controls.Add(this.movementStatusdetailsFlowLayoutPanel);
            this.descriptionPanel.Controls.Add(this.securityPanel);
            this.descriptionPanel.Controls.Add(this.priorityPanel);
            this.descriptionPanel.Location = new System.Drawing.Point(97, 63);
            this.descriptionPanel.Name = "descriptionPanel";
            this.descriptionPanel.Size = new System.Drawing.Size(388, 172);
            this.descriptionPanel.TabIndex = 23;
            // 
            // movementStatusdetailsFlowLayoutPanel
            // 
            this.movementStatusdetailsFlowLayoutPanel.AutoSize = true;
            this.movementStatusdetailsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.movementStatusdetailsFlowLayoutPanel.Location = new System.Drawing.Point(0, 67);
            this.movementStatusdetailsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(400, 0);
            this.movementStatusdetailsFlowLayoutPanel.Name = "movementStatusdetailsFlowLayoutPanel";
            this.movementStatusdetailsFlowLayoutPanel.Size = new System.Drawing.Size(388, 0);
            this.movementStatusdetailsFlowLayoutPanel.TabIndex = 25;
            // 
            // securityPanel
            // 
            this.securityPanel.AutoSize = true;
            this.securityPanel.Controls.Add(this.dakSecurityIconPanel);
            this.securityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.securityPanel.Location = new System.Drawing.Point(0, 34);
            this.securityPanel.Name = "securityPanel";
            this.securityPanel.Size = new System.Drawing.Size(388, 33);
            this.securityPanel.TabIndex = 24;
            // 
            // dakSecurityIconPanel
            // 
            this.dakSecurityIconPanel.BackColor = System.Drawing.Color.Transparent;
            this.dakSecurityIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dakSecurityIconPanel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dakSecurityIconPanel.Location = new System.Drawing.Point(2, 3);
            this.dakSecurityIconPanel.Name = "dakSecurityIconPanel";
            this.dakSecurityIconPanel.Size = new System.Drawing.Size(121, 27);
            this.dakSecurityIconPanel.TabIndex = 21;
            this.dakSecurityIconPanel.Visible = false;
            // 
            // priorityPanel
            // 
            this.priorityPanel.AutoSize = true;
            this.priorityPanel.Controls.Add(this.prioriyLabel);
            this.priorityPanel.Controls.Add(this.panel5);
            this.priorityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.priorityPanel.Location = new System.Drawing.Point(0, 0);
            this.priorityPanel.Name = "priorityPanel";
            this.priorityPanel.Size = new System.Drawing.Size(388, 34);
            this.priorityPanel.TabIndex = 23;
            // 
            // prioriyLabel
            // 
            this.prioriyLabel.BackColor = System.Drawing.Color.Transparent;
            this.prioriyLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prioriyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prioriyLabel.Location = new System.Drawing.Point(36, 4);
            this.prioriyLabel.Name = "prioriyLabel";
            this.prioriyLabel.Size = new System.Drawing.Size(86, 27);
            this.prioriyLabel.TabIndex = 11;
            this.prioriyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::dNothi.Desktop.Properties.Resources.icons8_high_priority_24;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel5.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(2, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(30, 28);
            this.panel5.TabIndex = 12;
            // 
            // movementStatusSliderPanel1
            // 
            this.movementStatusSliderPanel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.movementStatusSliderPanel1.Location = new System.Drawing.Point(58, 1);
            this.movementStatusSliderPanel1.Name = "movementStatusSliderPanel1";
            this.movementStatusSliderPanel1.Size = new System.Drawing.Size(74, 86);
            this.movementStatusSliderPanel1.TabIndex = 0;
            // 
            // officerCircularPictureBox
            // 
            this.officerCircularPictureBox.BackgroundImage = global::dNothi.Desktop.Properties.Resources.DamiProfile;
            this.officerCircularPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.officerCircularPictureBox.Location = new System.Drawing.Point(4, 7);
            this.officerCircularPictureBox.Name = "officerCircularPictureBox";
            this.officerCircularPictureBox.Size = new System.Drawing.Size(59, 56);
            this.officerCircularPictureBox.TabIndex = 0;
            this.officerCircularPictureBox.TabStop = false;
            // 
            // MovementStatusLeftSidePicUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.descriptionPanel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.decisionLabel);
            this.Controls.Add(this.LeftPanel);
            this.MaximumSize = new System.Drawing.Size(515, 0);
            this.Name = "MovementStatusLeftSidePicUserControl";
            this.Size = new System.Drawing.Size(513, 238);
            this.LeftPanel.ResumeLayout(false);
            this.descriptionPanel.ResumeLayout(false);
            this.descriptionPanel.PerformLayout();
            this.securityPanel.ResumeLayout(false);
            this.priorityPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officerCircularPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Label HorizontalLine;
        private CircularPictureBox officerCircularPictureBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label decisionLabel;
        private System.Windows.Forms.Panel descriptionPanel;
        private System.Windows.Forms.FlowLayoutPanel movementStatusdetailsFlowLayoutPanel;
        private System.Windows.Forms.Panel securityPanel;
        private System.Windows.Forms.Panel dakSecurityIconPanel;
        private System.Windows.Forms.Panel priorityPanel;
        private System.Windows.Forms.Label prioriyLabel;
        private System.Windows.Forms.Panel panel5;
        private CustomControl.MovementStatusSliderPanel movementStatusSliderPanel1;
    }
}
