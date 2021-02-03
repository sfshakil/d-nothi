namespace dNothi.Desktop.UI.Dak
{
    partial class DakMovementStatusListUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DakMovementStatusListUserControl));
            this.userTypeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.userDesignationLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userTypeLabel
            // 
            this.userTypeLabel.AutoSize = true;
            this.userTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userTypeLabel.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTypeLabel.Location = new System.Drawing.Point(0, 0);
            this.userTypeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.userTypeLabel.Name = "userTypeLabel";
            this.userTypeLabel.Size = new System.Drawing.Size(95, 120);
            this.userTypeLabel.TabIndex = 0;
            this.userTypeLabel.Text = "প্রেরক           :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.userTypeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userDesignationLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 120);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // userDesignationLabel
            // 
            this.userDesignationLabel.AutoSize = true;
            this.userDesignationLabel.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userDesignationLabel.Location = new System.Drawing.Point(95, 0);
            this.userDesignationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.userDesignationLabel.MaximumSize = new System.Drawing.Size(320, 0);
            this.userDesignationLabel.Name = "userDesignationLabel";
            this.userDesignationLabel.Size = new System.Drawing.Size(320, 120);
            this.userDesignationLabel.TabIndex = 1;
            this.userDesignationLabel.Text = resources.GetString("userDesignationLabel.Text");
            // 
            // DakMovementStatusListUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.MaximumSize = new System.Drawing.Size(415, 0);
            this.MinimumSize = new System.Drawing.Size(415, 0);
            this.Name = "DakMovementStatusListUserControl";
            this.Size = new System.Drawing.Size(415, 120);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label userTypeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label userDesignationLabel;
    }
}
