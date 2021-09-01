namespace dNothi.Desktop.UI
{
    partial class ModalLoginMenuUserControl
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
            this.modulePanel = new System.Windows.Forms.Panel();
            this.courseStartButton = new System.Windows.Forms.Button();
            this.courseRegisterButton = new System.Windows.Forms.Button();
            this.modulePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // modulePanel
            // 
            this.modulePanel.BackColor = System.Drawing.SystemColors.Control;
            this.modulePanel.Controls.Add(this.courseStartButton);
            this.modulePanel.Controls.Add(this.courseRegisterButton);
            this.modulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulePanel.Location = new System.Drawing.Point(0, 0);
            this.modulePanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.modulePanel.Name = "modulePanel";
            this.modulePanel.Size = new System.Drawing.Size(97, 58);
            this.modulePanel.TabIndex = 107;
            // 
            // courseStartButton
            // 
            this.courseStartButton.AutoSize = true;
            this.courseStartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.courseStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.courseStartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.courseStartButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseStartButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.courseStartButton.FlatAppearance.BorderSize = 0;
            this.courseStartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.courseStartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.courseStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseStartButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseStartButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(99)))), ((int)(((byte)(114)))));
            this.courseStartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.courseStartButton.Location = new System.Drawing.Point(0, 28);
            this.courseStartButton.Name = "courseStartButton";
            this.courseStartButton.Size = new System.Drawing.Size(97, 28);
            this.courseStartButton.TabIndex = 23;
            this.courseStartButton.Text = "কোর্স শুরু করুন";
            this.courseStartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.courseStartButton.UseVisualStyleBackColor = false;
            this.courseStartButton.Click += new System.EventHandler(this.courseStartButton_Click);
            // 
            // courseRegisterButton
            // 
            this.courseRegisterButton.AutoSize = true;
            this.courseRegisterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.courseRegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.courseRegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.courseRegisterButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseRegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.courseRegisterButton.FlatAppearance.BorderSize = 0;
            this.courseRegisterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.courseRegisterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.courseRegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseRegisterButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseRegisterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(99)))), ((int)(((byte)(114)))));
            this.courseRegisterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.courseRegisterButton.Location = new System.Drawing.Point(0, 0);
            this.courseRegisterButton.Name = "courseRegisterButton";
            this.courseRegisterButton.Size = new System.Drawing.Size(97, 28);
            this.courseRegisterButton.TabIndex = 24;
            this.courseRegisterButton.Text = "কোর্সে নিবন্ধন";
            this.courseRegisterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.courseRegisterButton.UseVisualStyleBackColor = false;
            this.courseRegisterButton.Click += new System.EventHandler(this.courseRegisterButton_Click);
            // 
            // ModalLoginMenuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.modulePanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ModalLoginMenuUserControl";
            this.Size = new System.Drawing.Size(97, 58);
            this.modulePanel.ResumeLayout(false);
            this.modulePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel modulePanel;
        private System.Windows.Forms.Button courseRegisterButton;
        private System.Windows.Forms.Button courseStartButton;
    }
}
