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
            this.movementStatusSliderPanel1 = new dNothi.Desktop.CustomControl.MovementStatusSliderPanel();
            this.HorizontalLine = new System.Windows.Forms.Label();
            this.officerCircularPictureBox = new dNothi.Desktop.CircularPictureBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.decisionLabel = new System.Windows.Forms.Label();
            this.descriptionPanel = new System.Windows.Forms.Panel();
            this.movementStatusdetailsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dakMovementStatusListUserControl1 = new dNothi.Desktop.UI.Dak.DakMovementStatusListUserControl();
            this.dakMovementStatusListUserControl3 = new dNothi.Desktop.UI.Dak.DakMovementStatusListUserControl();
            this.dakMovementStatusListUserControl2 = new dNothi.Desktop.UI.Dak.DakMovementStatusListUserControl();
            this.dakMovementStatusListUserControl4 = new dNothi.Desktop.UI.Dak.DakMovementStatusListUserControl();
            this.dakMovementStatusListUserControl5 = new dNothi.Desktop.UI.Dak.DakMovementStatusListUserControl();
            this.securityPanel = new System.Windows.Forms.Panel();
            this.dakSecurityIconPanel = new System.Windows.Forms.Panel();
            this.priorityPanel = new System.Windows.Forms.Panel();
            this.prioriyLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerCircularPictureBox)).BeginInit();
            this.descriptionPanel.SuspendLayout();
            this.movementStatusdetailsFlowLayoutPanel.SuspendLayout();
            this.securityPanel.SuspendLayout();
            this.priorityPanel.SuspendLayout();
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
            this.LeftPanel.Size = new System.Drawing.Size(75, 341);
            this.LeftPanel.TabIndex = 2;
            // 
            // movementStatusSliderPanel1
            // 
            this.movementStatusSliderPanel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.movementStatusSliderPanel1.Location = new System.Drawing.Point(58, 1);
            this.movementStatusSliderPanel1.Name = "movementStatusSliderPanel1";
            this.movementStatusSliderPanel1.Size = new System.Drawing.Size(74, 86);
            this.movementStatusSliderPanel1.TabIndex = 0;
            // 
            // HorizontalLine
            // 
            this.HorizontalLine.BackColor = System.Drawing.Color.LightGray;
            this.HorizontalLine.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.HorizontalLine.Location = new System.Drawing.Point(33, 64);
            this.HorizontalLine.Margin = new System.Windows.Forms.Padding(0);
            this.HorizontalLine.Name = "HorizontalLine";
            this.HorizontalLine.Size = new System.Drawing.Size(1, 300);
            this.HorizontalLine.TabIndex = 0;
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
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dateLabel.Location = new System.Drawing.Point(85, 38);
            this.dateLabel.MaximumSize = new System.Drawing.Size(424, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dateLabel.Size = new System.Drawing.Size(140, 20);
            this.dateLabel.TabIndex = 22;
            this.dateLabel.Text = "৩/১২/২০ ১১:০৩ AM";
            // 
            // decisionLabel
            // 
            this.decisionLabel.AutoSize = true;
            this.decisionLabel.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decisionLabel.Location = new System.Drawing.Point(85, 6);
            this.decisionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.decisionLabel.MaximumSize = new System.Drawing.Size(424, 0);
            this.decisionLabel.Name = "decisionLabel";
            this.decisionLabel.Padding = new System.Windows.Forms.Padding(10, 5, 0, 10);
            this.decisionLabel.Size = new System.Drawing.Size(210, 35);
            this.decisionLabel.TabIndex = 21;
            this.decisionLabel.Text = "সদয় সিদ্ধান্তের জন্যে প্রেরণ করা হলো";
            // 
            // descriptionPanel
            // 
            this.descriptionPanel.AutoSize = true;
            this.descriptionPanel.Controls.Add(this.movementStatusdetailsFlowLayoutPanel);
            this.descriptionPanel.Controls.Add(this.securityPanel);
            this.descriptionPanel.Controls.Add(this.priorityPanel);
            this.descriptionPanel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionPanel.Location = new System.Drawing.Point(97, 63);
            this.descriptionPanel.MaximumSize = new System.Drawing.Size(415, 0);
            this.descriptionPanel.Name = "descriptionPanel";
            this.descriptionPanel.Size = new System.Drawing.Size(415, 275);
            this.descriptionPanel.TabIndex = 23;
            // 
            // movementStatusdetailsFlowLayoutPanel
            // 
            this.movementStatusdetailsFlowLayoutPanel.AutoSize = true;
            this.movementStatusdetailsFlowLayoutPanel.Controls.Add(this.dakMovementStatusListUserControl1);
            this.movementStatusdetailsFlowLayoutPanel.Controls.Add(this.dakMovementStatusListUserControl3);
            this.movementStatusdetailsFlowLayoutPanel.Controls.Add(this.dakMovementStatusListUserControl2);
            this.movementStatusdetailsFlowLayoutPanel.Controls.Add(this.dakMovementStatusListUserControl4);
            this.movementStatusdetailsFlowLayoutPanel.Controls.Add(this.dakMovementStatusListUserControl5);
            this.movementStatusdetailsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.movementStatusdetailsFlowLayoutPanel.Location = new System.Drawing.Point(0, 67);
            this.movementStatusdetailsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.movementStatusdetailsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(415, 0);
            this.movementStatusdetailsFlowLayoutPanel.Name = "movementStatusdetailsFlowLayoutPanel";
            this.movementStatusdetailsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.movementStatusdetailsFlowLayoutPanel.Size = new System.Drawing.Size(415, 208);
            this.movementStatusdetailsFlowLayoutPanel.TabIndex = 25;
            // 
            // dakMovementStatusListUserControl1
            // 
            this.dakMovementStatusListUserControl1.AutoSize = true;
            this.dakMovementStatusListUserControl1.BackColor = System.Drawing.Color.Transparent;
            this.dakMovementStatusListUserControl1.Location = new System.Drawing.Point(3, 0);
            this.dakMovementStatusListUserControl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dakMovementStatusListUserControl1.MaximumSize = new System.Drawing.Size(415, 0);
            this.dakMovementStatusListUserControl1.MinimumSize = new System.Drawing.Size(415, 0);
            this.dakMovementStatusListUserControl1.Name = "dakMovementStatusListUserControl1";
            this.dakMovementStatusListUserControl1.Size = new System.Drawing.Size(415, 54);
            this.dakMovementStatusListUserControl1.TabIndex = 26;
            this.dakMovementStatusListUserControl1.userDesignation = "নিলুফা ইয়াসমিন (ন্যাশনাল কনসালটেন্ট ফর ই-নথি ইমপ্লিমেন্টেশন, এসপায়ার টু ইনোভেট (এ" +
    "টুআই) প্রোগ্রাম, এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্রাম";
            this.dakMovementStatusListUserControl1.userType = "প্রেরক";
            // 
            // dakMovementStatusListUserControl3
            // 
            this.dakMovementStatusListUserControl3.AutoSize = true;
            this.dakMovementStatusListUserControl3.BackColor = System.Drawing.Color.Transparent;
            this.dakMovementStatusListUserControl3.Location = new System.Drawing.Point(3, 54);
            this.dakMovementStatusListUserControl3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dakMovementStatusListUserControl3.MaximumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl3.MinimumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl3.Name = "dakMovementStatusListUserControl3";
            this.dakMovementStatusListUserControl3.Size = new System.Drawing.Size(388, 36);
            this.dakMovementStatusListUserControl3.TabIndex = 27;
            this.dakMovementStatusListUserControl3.userDesignation = "মোঃ হাসানুজ্জামান (সল্যুশন আর্কিটেক্ট, টেকনোলজি, এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্" +
    "রাম";
            this.dakMovementStatusListUserControl3.userType = "অনুলিপি প্রাপক";
            // 
            // dakMovementStatusListUserControl2
            // 
            this.dakMovementStatusListUserControl2.AutoSize = true;
            this.dakMovementStatusListUserControl2.BackColor = System.Drawing.Color.Transparent;
            this.dakMovementStatusListUserControl2.Location = new System.Drawing.Point(3, 90);
            this.dakMovementStatusListUserControl2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dakMovementStatusListUserControl2.MaximumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl2.MinimumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl2.Name = "dakMovementStatusListUserControl2";
            this.dakMovementStatusListUserControl2.Size = new System.Drawing.Size(388, 36);
            this.dakMovementStatusListUserControl2.TabIndex = 30;
            this.dakMovementStatusListUserControl2.userDesignation = "মোঃ হাসানুজ্জামান (সল্যুশন আর্কিটেক্ট, টেকনোলজি, এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্" +
    "রাম";
            this.dakMovementStatusListUserControl2.userType = "অনুলিপি প্রাপক";
            // 
            // dakMovementStatusListUserControl4
            // 
            this.dakMovementStatusListUserControl4.AutoSize = true;
            this.dakMovementStatusListUserControl4.BackColor = System.Drawing.Color.Transparent;
            this.dakMovementStatusListUserControl4.Location = new System.Drawing.Point(3, 126);
            this.dakMovementStatusListUserControl4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dakMovementStatusListUserControl4.MaximumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl4.MinimumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl4.Name = "dakMovementStatusListUserControl4";
            this.dakMovementStatusListUserControl4.Size = new System.Drawing.Size(388, 36);
            this.dakMovementStatusListUserControl4.TabIndex = 28;
            this.dakMovementStatusListUserControl4.userDesignation = "মোঃ হাসানুজ্জামান (সল্যুশন আর্কিটেক্ট, টেকনোলজি, এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্" +
    "রাম";
            this.dakMovementStatusListUserControl4.userType = "";
            // 
            // dakMovementStatusListUserControl5
            // 
            this.dakMovementStatusListUserControl5.AutoSize = true;
            this.dakMovementStatusListUserControl5.BackColor = System.Drawing.Color.Transparent;
            this.dakMovementStatusListUserControl5.Location = new System.Drawing.Point(3, 162);
            this.dakMovementStatusListUserControl5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dakMovementStatusListUserControl5.MaximumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl5.MinimumSize = new System.Drawing.Size(388, 0);
            this.dakMovementStatusListUserControl5.Name = "dakMovementStatusListUserControl5";
            this.dakMovementStatusListUserControl5.Size = new System.Drawing.Size(388, 36);
            this.dakMovementStatusListUserControl5.TabIndex = 29;
            this.dakMovementStatusListUserControl5.userDesignation = "মোঃ হাসানুজ্জামান (সল্যুশন আর্কিটেক্ট, টেকনোলজি, এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্" +
    "রাম";
            this.dakMovementStatusListUserControl5.userType = "";
            // 
            // securityPanel
            // 
            this.securityPanel.AutoSize = true;
            this.securityPanel.Controls.Add(this.dakSecurityIconPanel);
            this.securityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.securityPanel.Location = new System.Drawing.Point(0, 34);
            this.securityPanel.Name = "securityPanel";
            this.securityPanel.Size = new System.Drawing.Size(415, 33);
            this.securityPanel.TabIndex = 24;
            // 
            // dakSecurityIconPanel
            // 
            this.dakSecurityIconPanel.AutoSize = true;
            this.dakSecurityIconPanel.BackColor = System.Drawing.Color.Transparent;
            this.dakSecurityIconPanel.BackgroundImage = global::dNothi.Desktop.Properties.Resources.বিশেষ_গোপনীয়;
            this.dakSecurityIconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dakSecurityIconPanel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dakSecurityIconPanel.Location = new System.Drawing.Point(2, 0);
            this.dakSecurityIconPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dakSecurityIconPanel.Name = "dakSecurityIconPanel";
            this.dakSecurityIconPanel.Size = new System.Drawing.Size(120, 33);
            this.dakSecurityIconPanel.TabIndex = 21;
            // 
            // priorityPanel
            // 
            this.priorityPanel.AutoSize = true;
            this.priorityPanel.Controls.Add(this.prioriyLabel);
            this.priorityPanel.Controls.Add(this.panel5);
            this.priorityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.priorityPanel.Location = new System.Drawing.Point(0, 0);
            this.priorityPanel.Name = "priorityPanel";
            this.priorityPanel.Size = new System.Drawing.Size(415, 34);
            this.priorityPanel.TabIndex = 23;
            // 
            // prioriyLabel
            // 
            this.prioriyLabel.BackColor = System.Drawing.Color.Transparent;
            this.prioriyLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panel5.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(2, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(30, 28);
            this.panel5.TabIndex = 12;
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
            this.Size = new System.Drawing.Size(515, 341);
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officerCircularPictureBox)).EndInit();
            this.descriptionPanel.ResumeLayout(false);
            this.descriptionPanel.PerformLayout();
            this.movementStatusdetailsFlowLayoutPanel.ResumeLayout(false);
            this.movementStatusdetailsFlowLayoutPanel.PerformLayout();
            this.securityPanel.ResumeLayout(false);
            this.securityPanel.PerformLayout();
            this.priorityPanel.ResumeLayout(false);
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
        private DakMovementStatusListUserControl dakMovementStatusListUserControl1;
        private DakMovementStatusListUserControl dakMovementStatusListUserControl3;
        private DakMovementStatusListUserControl dakMovementStatusListUserControl4;
        private DakMovementStatusListUserControl dakMovementStatusListUserControl5;
        private DakMovementStatusListUserControl dakMovementStatusListUserControl2;
    }
}
