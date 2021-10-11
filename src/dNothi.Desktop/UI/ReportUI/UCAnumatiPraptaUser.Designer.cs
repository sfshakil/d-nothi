namespace dNothi.Desktop.UI.ReportUI
{
    partial class UCAnumatiPraptaUser
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
            this.EditUpdatetableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.userIdlabel = new System.Windows.Forms.Label();
            this.serialLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.decisionDeleteButton = new FontAwesome.Sharp.IconButton();
            this.dateLabel = new System.Windows.Forms.Label();
            this.EditUpdatetableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditUpdatetableLayoutPanel
            // 
            this.EditUpdatetableLayoutPanel.AutoSize = true;
            this.EditUpdatetableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.EditUpdatetableLayoutPanel.ColumnCount = 4;
            this.EditUpdatetableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.30612F));
            this.EditUpdatetableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.EditUpdatetableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.EditUpdatetableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26531F));
            this.EditUpdatetableLayoutPanel.Controls.Add(this.userIdlabel, 0, 0);
            this.EditUpdatetableLayoutPanel.Controls.Add(this.serialLabel, 0, 0);
            this.EditUpdatetableLayoutPanel.Controls.Add(this.panel2, 3, 0);
            this.EditUpdatetableLayoutPanel.Controls.Add(this.dateLabel, 1, 0);
            this.EditUpdatetableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditUpdatetableLayoutPanel.Location = new System.Drawing.Point(3, 0);
            this.EditUpdatetableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.EditUpdatetableLayoutPanel.Name = "EditUpdatetableLayoutPanel";
            this.EditUpdatetableLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.EditUpdatetableLayoutPanel.RowCount = 1;
            this.EditUpdatetableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.EditUpdatetableLayoutPanel.Size = new System.Drawing.Size(620, 44);
            this.EditUpdatetableLayoutPanel.TabIndex = 3;
            this.EditUpdatetableLayoutPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.Cell_Color_Blue);
            // 
            // userIdlabel
            // 
            this.userIdlabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userIdlabel.AutoSize = true;
            this.userIdlabel.Location = new System.Drawing.Point(99, 15);
            this.userIdlabel.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.userIdlabel.Name = "userIdlabel";
            this.userIdlabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.userIdlabel.Size = new System.Drawing.Size(39, 13);
            this.userIdlabel.TabIndex = 86;
            this.userIdlabel.Text = "label";
            this.userIdlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serialLabel
            // 
            this.serialLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serialLabel.AutoSize = true;
            this.serialLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialLabel.Location = new System.Drawing.Point(5, 13);
            this.serialLabel.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.serialLabel.Name = "serialLabel";
            this.serialLabel.Size = new System.Drawing.Size(54, 18);
            this.serialLabel.TabIndex = 0;
            this.serialLabel.Text = "sdsadas";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.decisionDeleteButton);
            this.panel2.Location = new System.Drawing.Point(537, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(77, 38);
            this.panel2.TabIndex = 85;
            // 
            // decisionDeleteButton
            // 
            this.decisionDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.decisionDeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.decisionDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.decisionDeleteButton.FlatAppearance.BorderSize = 0;
            this.decisionDeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.decisionDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decisionDeleteButton.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.decisionDeleteButton.IconColor = System.Drawing.Color.White;
            this.decisionDeleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.decisionDeleteButton.IconSize = 20;
            this.decisionDeleteButton.Location = new System.Drawing.Point(0, 0);
            this.decisionDeleteButton.MaximumSize = new System.Drawing.Size(34, 36);
            this.decisionDeleteButton.MinimumSize = new System.Drawing.Size(34, 36);
            this.decisionDeleteButton.Name = "decisionDeleteButton";
            this.decisionDeleteButton.Size = new System.Drawing.Size(34, 36);
            this.decisionDeleteButton.TabIndex = 88;
            this.decisionDeleteButton.UseVisualStyleBackColor = false;
            this.decisionDeleteButton.Click += new System.EventHandler(this.decisionDeleteButton_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(319, 15);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dateLabel.Size = new System.Drawing.Size(39, 13);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "label";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCAnumatiPraptaUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.EditUpdatetableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "UCAnumatiPraptaUser";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Size = new System.Drawing.Size(626, 44);
            this.EditUpdatetableLayoutPanel.ResumeLayout(false);
            this.EditUpdatetableLayoutPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel EditUpdatetableLayoutPanel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label serialLabel;
        private FontAwesome.Sharp.IconButton decisionDeleteButton;
        private System.Windows.Forms.Label userIdlabel;
    }
}
