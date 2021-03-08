namespace dNothi.Desktop.UI.Dak
{
    partial class NothiOnumodonOfficer
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
            this.cbxControl = new System.Windows.Forms.CheckBox();
            this.lbDesignation = new System.Windows.Forms.Label();
            this.officerNameLabel = new System.Windows.Forms.Label();
            this.deleteButton = new FontAwesome.Sharp.IconButton();
            this.btnUser = new FontAwesome.Sharp.IconButton();
            this.bodyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bottomTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bodyTableLayoutPanel.SuspendLayout();
            this.topTableLayoutPanel.SuspendLayout();
            this.bottomTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxControl
            // 
            this.cbxControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxControl.AutoSize = true;
            this.cbxControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.cbxControl.Location = new System.Drawing.Point(15, 7);
            this.cbxControl.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.cbxControl.Name = "cbxControl";
            this.cbxControl.Size = new System.Drawing.Size(15, 14);
            this.cbxControl.TabIndex = 63;
            this.cbxControl.UseVisualStyleBackColor = true;
            // 
            // lbDesignation
            // 
            this.lbDesignation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbDesignation.AutoSize = true;
            this.lbDesignation.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesignation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbDesignation.Location = new System.Drawing.Point(222, 2);
            this.lbDesignation.Name = "lbDesignation";
            this.lbDesignation.Size = new System.Drawing.Size(186, 28);
            this.lbDesignation.TabIndex = 61;
            this.lbDesignation.Text = "সল্যুশন আর্কিটেক্ট,টেকনোলজি,এসপায়ার টু ইনোভেট (এটুআই) প্রোগ্রাম asdsadsdsadsa";
            // 
            // officerNameLabel
            // 
            this.officerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.officerNameLabel.AutoSize = true;
            this.officerNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.officerNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.officerNameLabel.Location = new System.Drawing.Point(34, 7);
            this.officerNameLabel.Name = "officerNameLabel";
            this.officerNameLabel.Size = new System.Drawing.Size(182, 18);
            this.officerNameLabel.TabIndex = 60;
            this.officerNameLabel.Text = "মোঃ হাসানুজ্জামান fsdfdsfsd dsfds ";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.Color.Transparent;
            this.deleteButton.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.deleteButton.IconColor = System.Drawing.Color.Red;
            this.deleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.deleteButton.IconSize = 18;
            this.deleteButton.Location = new System.Drawing.Point(36, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(25, 23);
            this.deleteButton.TabIndex = 62;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click_1);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.Transparent;
            this.btnUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnUser.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.btnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUser.IconSize = 24;
            this.btnUser.Location = new System.Drawing.Point(3, 3);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(25, 27);
            this.btnUser.TabIndex = 58;
            this.btnUser.UseVisualStyleBackColor = false;
            // 
            // bodyTableLayoutPanel
            // 
            this.bodyTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.bodyTableLayoutPanel.ColumnCount = 1;
            this.bodyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayoutPanel.Controls.Add(this.topTableLayoutPanel, 0, 0);
            this.bodyTableLayoutPanel.Controls.Add(this.bottomTableLayoutPanel, 0, 1);
            this.bodyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bodyTableLayoutPanel.Name = "bodyTableLayoutPanel";
            this.bodyTableLayoutPanel.RowCount = 2;
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.Size = new System.Drawing.Size(432, 62);
            this.bodyTableLayoutPanel.TabIndex = 64;
            // 
            // topTableLayoutPanel
            // 
            this.topTableLayoutPanel.ColumnCount = 3;
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableLayoutPanel.Controls.Add(this.officerNameLabel, 0, 0);
            this.topTableLayoutPanel.Controls.Add(this.btnUser, 0, 0);
            this.topTableLayoutPanel.Controls.Add(this.lbDesignation, 2, 0);
            this.topTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topTableLayoutPanel.Name = "topTableLayoutPanel";
            this.topTableLayoutPanel.RowCount = 1;
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topTableLayoutPanel.Size = new System.Drawing.Size(432, 33);
            this.topTableLayoutPanel.TabIndex = 0;
            // 
            // bottomTableLayoutPanel
            // 
            this.bottomTableLayoutPanel.ColumnCount = 2;
            this.bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomTableLayoutPanel.Controls.Add(this.deleteButton, 1, 0);
            this.bottomTableLayoutPanel.Controls.Add(this.cbxControl, 0, 0);
            this.bottomTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomTableLayoutPanel.Location = new System.Drawing.Point(0, 33);
            this.bottomTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomTableLayoutPanel.Name = "bottomTableLayoutPanel";
            this.bottomTableLayoutPanel.RowCount = 1;
            this.bottomTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomTableLayoutPanel.Size = new System.Drawing.Size(432, 29);
            this.bottomTableLayoutPanel.TabIndex = 1;
            // 
            // NothiOnumodonOfficer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bodyTableLayoutPanel);
            this.Name = "NothiOnumodonOfficer";
            this.Size = new System.Drawing.Size(432, 62);
            this.bodyTableLayoutPanel.ResumeLayout(false);
            this.topTableLayoutPanel.ResumeLayout(false);
            this.topTableLayoutPanel.PerformLayout();
            this.bottomTableLayoutPanel.ResumeLayout(false);
            this.bottomTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cbxControl;
        private FontAwesome.Sharp.IconButton deleteButton;
        private System.Windows.Forms.Label lbDesignation;
        private System.Windows.Forms.Label officerNameLabel;
        private FontAwesome.Sharp.IconButton btnUser;
        private System.Windows.Forms.TableLayoutPanel bodyTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel topTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel bottomTableLayoutPanel;
    }
}
