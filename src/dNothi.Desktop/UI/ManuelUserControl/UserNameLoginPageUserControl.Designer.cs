﻿namespace dNothi.Desktop.UI.ManuelUserControl
{
    partial class UserNameLoginPageUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserNameLoginPageUserControl));
            this.txtUserNamePassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.txtUserName = new dNothi.Desktop.XTextBox();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserNamePassword
            // 
            this.txtUserNamePassword.Location = new System.Drawing.Point(207, 38);
            this.txtUserNamePassword.MaximumSize = new System.Drawing.Size(187, 33);
            this.txtUserNamePassword.MinimumSize = new System.Drawing.Size(187, 33);
            this.txtUserNamePassword.Multiline = true;
            this.txtUserNamePassword.Name = "txtUserNamePassword";
            this.txtUserNamePassword.PasswordChar = '●';
            this.txtUserNamePassword.Size = new System.Drawing.Size(187, 33);
            this.txtUserNamePassword.TabIndex = 25;
            this.txtUserNamePassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserNamePassword_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(204, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "পাসওয়ার্ড";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "ইউজার নেম";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Moccasin;
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(15, 80);
            this.panel9.MaximumSize = new System.Drawing.Size(265, 45);
            this.panel9.MinimumSize = new System.Drawing.Size(265, 45);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(265, 45);
            this.panel9.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "ইউজার নেম ব্যবহার করে প্রবেশ করুন";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(298, 80);
            this.button9.MaximumSize = new System.Drawing.Size(94, 45);
            this.button9.MinimumSize = new System.Drawing.Size(94, 45);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 45);
            this.button9.TabIndex = 21;
            this.button9.Text = "প্রবেশ";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.DimGray;
            this.txtUserName.Location = new System.Drawing.Point(14, 38);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.MaximumSize = new System.Drawing.Size(187, 33);
            this.txtUserName.MinimumSize = new System.Drawing.Size(187, 33);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(187, 33);
            this.txtUserName.TabIndex = 22;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // UserNameLoginPageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtUserNamePassword);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.panel9);
            this.Name = "UserNameLoginPageUserControl";
            this.Size = new System.Drawing.Size(406, 150);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserNamePassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private XTextBox txtUserName;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label2;
    }
}
