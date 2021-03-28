
namespace dNothi.Desktop.UI.Dak
{
    partial class ReviewDashBoardContentShare
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
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.AutoSize = true;
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.RowCount = 1;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(696, 92);
            this.contentTableLayoutPanel.TabIndex = 0;
            // 
            // ReviewDashBoardContentShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReviewDashBoardContentShare";
            this.Size = new System.Drawing.Size(696, 92);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
    }
}
