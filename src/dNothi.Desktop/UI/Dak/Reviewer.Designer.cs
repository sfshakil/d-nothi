
namespace dNothi.Desktop.UI.Dak
{
    partial class Reviewer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbOfficerName = new System.Windows.Forms.Label();
            this.lbOfficerDesignation = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.lbOfficerDesignation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbOfficerName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbOfficerName
            // 
            this.lbOfficerName.AutoSize = true;
            this.lbOfficerName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbOfficerName.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOfficerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbOfficerName.Location = new System.Drawing.Point(0, 0);
            this.lbOfficerName.Margin = new System.Windows.Forms.Padding(0);
            this.lbOfficerName.Name = "lbOfficerName";
            this.lbOfficerName.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbOfficerName.Size = new System.Drawing.Size(152, 28);
            this.lbOfficerName.TabIndex = 6;
            this.lbOfficerName.Text = "জাফরিন আহমেদ";
            // 
            // lbOfficerDesignation
            // 
            this.lbOfficerDesignation.AutoSize = true;
            this.lbOfficerDesignation.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbOfficerDesignation.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOfficerDesignation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbOfficerDesignation.Location = new System.Drawing.Point(152, 0);
            this.lbOfficerDesignation.Margin = new System.Windows.Forms.Padding(0);
            this.lbOfficerDesignation.Name = "lbOfficerDesignation";
            this.lbOfficerDesignation.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbOfficerDesignation.Size = new System.Drawing.Size(547, 28);
            this.lbOfficerDesignation.TabIndex = 7;
            this.lbOfficerDesignation.Text = "সফটওয়্যার ইঞ্জিনিয়ার,ই-সার্ভিস,এসপায়ার টু ইনোভেট (এটু্আই) প্রোগ্রাম";
            // 
            // Reviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Reviewer";
            this.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.Size = new System.Drawing.Size(826, 38);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbOfficerDesignation;
        private System.Windows.Forms.Label lbOfficerName;
    }
}
