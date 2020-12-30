namespace dNothi.Desktop.UI.Dak
{
    partial class DesignationSealListOfficerRowUserControl
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
            this.officerNameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pandksand = new System.Windows.Forms.Panel();
            this.officerNameLabel = new System.Windows.Forms.Label();
            this.deleteButton = new FontAwesome.Sharp.IconButton();
            this.officerNameTableLayoutPanel.SuspendLayout();
            this.pandksand.SuspendLayout();
            this.SuspendLayout();
            // 
            // officerNameTableLayoutPanel
            // 
            this.officerNameTableLayoutPanel.AutoSize = true;
            this.officerNameTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.officerNameTableLayoutPanel.ColumnCount = 2;
            this.officerNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.27451F));
            this.officerNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.72549F));
            this.officerNameTableLayoutPanel.Controls.Add(this.deleteButton, 0, 0);
            this.officerNameTableLayoutPanel.Controls.Add(this.pandksand, 1, 0);
            this.officerNameTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.officerNameTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.officerNameTableLayoutPanel.MaximumSize = new System.Drawing.Size(510, 0);
            this.officerNameTableLayoutPanel.Name = "officerNameTableLayoutPanel";
            this.officerNameTableLayoutPanel.RowCount = 1;
            this.officerNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.officerNameTableLayoutPanel.Size = new System.Drawing.Size(510, 31);
            this.officerNameTableLayoutPanel.TabIndex = 3;
            // 
            // pandksand
            // 
            this.pandksand.AutoSize = true;
            this.pandksand.Controls.Add(this.officerNameLabel);
            this.pandksand.Location = new System.Drawing.Point(33, 4);
            this.pandksand.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pandksand.MaximumSize = new System.Drawing.Size(472, 0);
            this.pandksand.Name = "pandksand";
            this.pandksand.Size = new System.Drawing.Size(389, 24);
            this.pandksand.TabIndex = 0;
            // 
            // officerNameLabel
            // 
            this.officerNameLabel.AutoSize = true;
            this.officerNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.officerNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.officerNameLabel.Location = new System.Drawing.Point(0, 0);
            this.officerNameLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.officerNameLabel.Name = "officerNameLabel";
            this.officerNameLabel.Padding = new System.Windows.Forms.Padding(3);
            this.officerNameLabel.Size = new System.Drawing.Size(389, 24);
            this.officerNameLabel.TabIndex = 0;
            this.officerNameLabel.Text = "সেলিনাfপরিচালক (কম্পোনেন্ট-২,৩),এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্রাম";
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.Color.Transparent;
            this.deleteButton.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.deleteButton.IconColor = System.Drawing.Color.Red;
            this.deleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.deleteButton.IconSize = 18;
            this.deleteButton.Location = new System.Drawing.Point(4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(25, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Visible = false;
            // 
            // DesignationSealListOfficerRowUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.officerNameTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(510, 0);
            this.Name = "DesignationSealListOfficerRowUserControl";
            this.Size = new System.Drawing.Size(510, 31);
            this.officerNameTableLayoutPanel.ResumeLayout(false);
            this.officerNameTableLayoutPanel.PerformLayout();
            this.pandksand.ResumeLayout(false);
            this.pandksand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel officerNameTableLayoutPanel;
        private System.Windows.Forms.Panel pandksand;
        private System.Windows.Forms.Label officerNameLabel;
        private FontAwesome.Sharp.IconButton deleteButton;
    }
}
