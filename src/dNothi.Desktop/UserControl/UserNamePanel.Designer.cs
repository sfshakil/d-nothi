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
            this.xTextBox1 = new dNothi.Desktop.XTextBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // xTextBox1
            // 
            this.xTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.xTextBox1.Location = new System.Drawing.Point(21, 16);
            this.xTextBox1.Multiline = true;
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(161, 31);
            this.xTextBox1.TabIndex = 8;
            this.xTextBox1.Text = "ইউজার নেম";
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metroTextBox1.CustomBackground = true;
            this.metroTextBox1.CustomForeColor = true;
            this.metroTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBox1.Location = new System.Drawing.Point(214, 16);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '●';
            this.metroTextBox1.PromptText = "পাসওয়ার্ড";
            this.metroTextBox1.Size = new System.Drawing.Size(161, 31);
            this.metroTextBox1.TabIndex = 9;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseStyleColors = true;
            this.metroTextBox1.UseSystemPasswordChar = true;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(290, 72);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(85, 45);
            this.button9.TabIndex = 12;
            this.button9.Text = "প্রবেশ";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Moccasin;
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(19, 72);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(265, 45);
            this.panel9.TabIndex = 11;
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
            // UserIDPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.button9);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.xTextBox1);
            this.Name = "UserIDPanel";
            this.Size = new System.Drawing.Size(405, 467);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XTextBox xTextBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label2;
    }
}
