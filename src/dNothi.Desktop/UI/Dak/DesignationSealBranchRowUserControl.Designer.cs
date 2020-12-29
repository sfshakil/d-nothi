namespace dNothi.Desktop.UI.Dak
{
    partial class DesignationSealBranchRowUserControl
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
            this.branchOfficeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.branchNameLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.branchOfficeFlowLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // branchOfficeFlowLayoutPanel
            // 
            this.branchOfficeFlowLayoutPanel.AutoSize = true;
            this.branchOfficeFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.branchOfficeFlowLayoutPanel.Controls.Add(this.tableLayoutPanel2);
            this.branchOfficeFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.branchOfficeFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.branchOfficeFlowLayoutPanel.MaximumSize = new System.Drawing.Size(510, 0);
            this.branchOfficeFlowLayoutPanel.Name = "branchOfficeFlowLayoutPanel";
            this.branchOfficeFlowLayoutPanel.Size = new System.Drawing.Size(510, 74);
            this.branchOfficeFlowLayoutPanel.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(510, 40);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.branchNameLabel);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(501, 34);
            this.panel3.TabIndex = 0;
            // 
            // branchNameLabel
            // 
            this.branchNameLabel.AutoSize = true;
            this.branchNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchNameLabel.Location = new System.Drawing.Point(44, 8);
            this.branchNameLabel.Name = "branchNameLabel";
            this.branchNameLabel.Size = new System.Drawing.Size(204, 18);
            this.branchNameLabel.TabIndex = 1;
            this.branchNameLabel.Text = "যুগ্ম প্রকল্প পরিচালক (কম্পোনেন্ট-২,৩)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "শাখাঃ";
            // 
            // DesignationSealBranchRowUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.branchOfficeFlowLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(510, 0);
            this.Name = "DesignationSealBranchRowUserControl";
            this.Size = new System.Drawing.Size(510, 74);
            this.branchOfficeFlowLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel branchOfficeFlowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label branchNameLabel;
        private System.Windows.Forms.Label label7;
    }
}
