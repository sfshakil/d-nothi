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
            this.dashboardRightSideFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // rightSliderHeadLineLabel
            // 
            this.rightSliderHeadLineLabel.AutoSize = true;
            this.rightSliderHeadLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightSliderHeadLineLabel.Location = new System.Drawing.Point(22, 16);
            this.rightSliderHeadLineLabel.Name = "rightSliderHeadLineLabel";
            this.rightSliderHeadLineLabel.Size = new System.Drawing.Size(96, 24);
            this.rightSliderHeadLineLabel.TabIndex = 29;
            this.rightSliderHeadLineLabel.Text = "ডাক গতিবিধি";
            // 
            // sliderCrossButton
            // 
            this.sliderCrossButton.BackColor = System.Drawing.Color.IndianRed;
            this.sliderCrossButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sliderCrossButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sliderCrossButton.Location = new System.Drawing.Point(553, 14);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(21, 21);
            this.sliderCrossButton.TabIndex = 27;
            this.sliderCrossButton.Text = "x";
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            this.sliderCrossButton.Click += new System.EventHandler(this.sliderCrossButton_Click);
            // 
            // dashboardRightSideFlowLayoutPanel
            // 
            this.dashboardRightSideFlowLayoutPanel.AutoScroll = true;
            this.dashboardRightSideFlowLayoutPanel.AutoSize = true;
            this.dashboardRightSideFlowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardRightSideFlowLayoutPanel.Location = new System.Drawing.Point(23, 45);
            this.dashboardRightSideFlowLayoutPanel.MaximumSize = new System.Drawing.Size(551, 700);
            this.dashboardRightSideFlowLayoutPanel.MinimumSize = new System.Drawing.Size(551, 700);
            this.dashboardRightSideFlowLayoutPanel.Name = "dashboardRightSideFlowLayoutPanel";
            this.dashboardRightSideFlowLayoutPanel.Size = new System.Drawing.Size(551, 700);
            this.dashboardRightSideFlowLayoutPanel.TabIndex = 28;
            // 
            // DakMovementDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(599, 780);
            this.Controls.Add(this.rightSliderHeadLineLabel);
            this.Controls.Add(this.sliderCrossButton);
            this.Controls.Add(this.dashboardRightSideFlowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DakMovementDetailsForm";
            this.Text = "DakMovementDetailsForm";
            this.Load += new System.EventHandler(this.DakMovementDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rightSliderHeadLineLabel;
        private System.Windows.Forms.Button sliderCrossButton;
        public System.Windows.Forms.FlowLayoutPanel dashboardRightSideFlowLayoutPanel;
    }
}