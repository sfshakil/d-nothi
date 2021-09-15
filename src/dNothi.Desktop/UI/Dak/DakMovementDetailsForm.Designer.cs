namespace dNothi.Desktop.UI.Dak
{
    partial class DakMovementDetailsForm
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
            this.rightSliderHeadLineLabel = new System.Windows.Forms.Label();
            this.sliderCrossButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dashboardRightSideFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightSliderHeadLineLabel
            // 
            this.rightSliderHeadLineLabel.AutoSize = true;
            this.rightSliderHeadLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightSliderHeadLineLabel.Location = new System.Drawing.Point(26, 14);
            this.rightSliderHeadLineLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rightSliderHeadLineLabel.Name = "rightSliderHeadLineLabel";
            this.rightSliderHeadLineLabel.Size = new System.Drawing.Size(122, 29);
            this.rightSliderHeadLineLabel.TabIndex = 29;
            this.rightSliderHeadLineLabel.Text = "ডাক গতিবিধি";
            // 
            // sliderCrossButton
            // 
            this.sliderCrossButton.AutoSize = true;
            this.sliderCrossButton.BackColor = System.Drawing.Color.Transparent;
            this.sliderCrossButton.FlatAppearance.BorderSize = 0;
            this.sliderCrossButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sliderCrossButton.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sliderCrossButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sliderCrossButton.Location = new System.Drawing.Point(750, 14);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(40, 44);
            this.sliderCrossButton.TabIndex = 27;
            this.sliderCrossButton.Text = "x";
            this.sliderCrossButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            this.sliderCrossButton.Click += new System.EventHandler(this.sliderCrossButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sliderCrossButton);
            this.panel1.Controls.Add(this.rightSliderHeadLineLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 77);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dashboardRightSideFlowLayoutPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panel2.Size = new System.Drawing.Size(799, 883);
            this.panel2.TabIndex = 30;
            // 
            // dashboardRightSideFlowLayoutPanel
            // 
            this.dashboardRightSideFlowLayoutPanel.AutoScroll = true;
            this.dashboardRightSideFlowLayoutPanel.AutoSize = true;
            this.dashboardRightSideFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardRightSideFlowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardRightSideFlowLayoutPanel.Location = new System.Drawing.Point(5, 0);
            this.dashboardRightSideFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dashboardRightSideFlowLayoutPanel.Name = "dashboardRightSideFlowLayoutPanel";
            this.dashboardRightSideFlowLayoutPanel.Size = new System.Drawing.Size(789, 878);
            this.dashboardRightSideFlowLayoutPanel.TabIndex = 29;
            // 
            // DakMovementDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(799, 960);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DakMovementDetailsForm";
            this.Text = "DakMovementDetailsForm";
            this.Load += new System.EventHandler(this.DakMovementDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label rightSliderHeadLineLabel;
        private System.Windows.Forms.Button sliderCrossButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.FlowLayoutPanel dashboardRightSideFlowLayoutPanel;
    }
}