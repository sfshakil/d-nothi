namespace dNothi.Desktop.UI
{
    partial class OfficerRowUserControl
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
            this.deleteButton = new FontAwesome.Sharp.IconButton();
            this.officerNameLabel = new System.Windows.Forms.TextBox();
            this.upDownPanel = new System.Windows.Forms.Panel();
            this.downButton = new FontAwesome.Sharp.IconButton();
            this.upButton = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.upDownPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.officerNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.upDownPanel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 39);
            this.tableLayoutPanel1.TabIndex = 87;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.deleteButton.IconColor = System.Drawing.Color.Red;
            this.deleteButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.deleteButton.IconSize = 32;
            this.deleteButton.Location = new System.Drawing.Point(200, 8);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 23);
            this.deleteButton.TabIndex = 86;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // officerNameLabel
            // 
            this.officerNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.officerNameLabel.BackColor = System.Drawing.Color.White;
            this.officerNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.officerNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.officerNameLabel.Location = new System.Drawing.Point(3, 10);
            this.officerNameLabel.Name = "officerNameLabel";
            this.officerNameLabel.Size = new System.Drawing.Size(185, 19);
            this.officerNameLabel.TabIndex = 87;
            this.officerNameLabel.Text = "হাসানুজ্জামান্ম , কজাহদাস, আজখঞ্জদফা , আকজন্দফকজলাস";
            // 
            // upDownPanel
            // 
            this.upDownPanel.Controls.Add(this.downButton);
            this.upDownPanel.Controls.Add(this.upButton);
            this.upDownPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.upDownPanel.Location = new System.Drawing.Point(233, 0);
            this.upDownPanel.Margin = new System.Windows.Forms.Padding(0);
            this.upDownPanel.MinimumSize = new System.Drawing.Size(24, 0);
            this.upDownPanel.Name = "upDownPanel";
            this.upDownPanel.Size = new System.Drawing.Size(24, 39);
            this.upDownPanel.TabIndex = 88;
            // 
            // downButton
            // 
            this.downButton.AutoSize = true;
            this.downButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.downButton.FlatAppearance.BorderSize = 0;
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.downButton.IconColor = System.Drawing.Color.Silver;
            this.downButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.downButton.IconSize = 15;
            this.downButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.downButton.Location = new System.Drawing.Point(0, 18);
            this.downButton.Margin = new System.Windows.Forms.Padding(0);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(24, 21);
            this.downButton.TabIndex = 65;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.AutoSize = true;
            this.upButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.upButton.FlatAppearance.BorderSize = 0;
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.upButton.IconColor = System.Drawing.Color.Silver;
            this.upButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.upButton.IconSize = 15;
            this.upButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.upButton.Location = new System.Drawing.Point(0, 0);
            this.upButton.Margin = new System.Windows.Forms.Padding(0);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(24, 21);
            this.upButton.TabIndex = 0;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // OfficerRowUserControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OfficerRowUserControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(259, 41);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OfficerRowUserControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OfficerRowUserControl_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OfficerRowUserControl_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.upDownPanel.ResumeLayout(false);
            this.upDownPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton deleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox officerNameLabel;
        private System.Windows.Forms.Panel upDownPanel;
        private FontAwesome.Sharp.IconButton downButton;
        private FontAwesome.Sharp.IconButton upButton;
    }
}
