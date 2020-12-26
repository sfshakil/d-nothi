namespace dNothi.Desktop
{
    partial class UserNamePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserNamePanel));
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtUserNamePassword = new PlaceholderTextBox.PlaceholderTextBox();
            this.userIdPanel = new System.Windows.Forms.Panel();
            this.txtUserName = new PlaceholderTextBox.PlaceholderTextBox();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.userIdPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Moccasin;
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(15, 75);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(277, 45);
            this.panel9.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "ইউজার নেম ব্যবহার করে প্রবেশ করুন";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(299, 75);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 45);
            this.button9.TabIndex = 12;
            this.button9.Text = "প্রবেশ";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.txtUserNamePassword);
            this.panel3.Location = new System.Drawing.Point(208, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 39);
            this.panel3.TabIndex = 82;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.userIdPanel_Paint);
            // 
            // txtUserNamePassword
            // 
            this.txtUserNamePassword.BackColor = System.Drawing.Color.White;
            this.txtUserNamePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserNamePassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNamePassword.Location = new System.Drawing.Point(4, 10);
            this.txtUserNamePassword.Name = "txtUserNamePassword";
            this.txtUserNamePassword.PlaceholderText = "পাসওয়ার্ড";
            this.txtUserNamePassword.Size = new System.Drawing.Size(177, 19);
            this.txtUserNamePassword.TabIndex = 3;
            this.txtUserNamePassword.TextChanged += new System.EventHandler(this.txtUserNamePassword_TextChanged);
            this.txtUserNamePassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserNamePassword_KeyPress);
            // 
            // userIdPanel
            // 
            this.userIdPanel.BackColor = System.Drawing.Color.Transparent;
            this.userIdPanel.Controls.Add(this.txtUserName);
            this.userIdPanel.Location = new System.Drawing.Point(15, 27);
            this.userIdPanel.Name = "userIdPanel";
            this.userIdPanel.Size = new System.Drawing.Size(187, 39);
            this.userIdPanel.TabIndex = 81;
            this.userIdPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userIdPanel_Paint);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(4, 10);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "ইউজার আইডি";
            this.txtUserName.Size = new System.Drawing.Size(177, 19);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // UserNamePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.userIdPanel);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.panel9);
            this.MaximumSize = new System.Drawing.Size(406, 150);
            this.MinimumSize = new System.Drawing.Size(406, 150);
            this.Name = "UserNamePanel";
            this.Size = new System.Drawing.Size(406, 150);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.userIdPanel.ResumeLayout(false);
            this.userIdPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private PlaceholderTextBox.PlaceholderTextBox txtUserNamePassword;
        private System.Windows.Forms.Panel userIdPanel;
        private PlaceholderTextBox.PlaceholderTextBox txtUserName;
    }
}
