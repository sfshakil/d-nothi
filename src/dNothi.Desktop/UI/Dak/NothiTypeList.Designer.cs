namespace dNothi.Desktop.UI.Dak
{
    partial class NothiTypeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NothiTypeList));
            this.txtSerialNo = new dNothi.Desktop.XTextBox();
            this.txtNothiSubjectType = new dNothi.Desktop.XTextBox();
            this.txtNothiCode = new dNothi.Desktop.XTextBox();
            this.txtNothiNumber = new dNothi.Desktop.XTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BackColor = System.Drawing.Color.White;
            this.txtSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(20, 12);
            this.txtSerialNo.Multiline = true;
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(44, 35);
            this.txtSerialNo.TabIndex = 31;
            // 
            // txtNothiSubjectType
            // 
            this.txtNothiSubjectType.BackColor = System.Drawing.Color.White;
            this.txtNothiSubjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNothiSubjectType.Location = new System.Drawing.Point(81, 12);
            this.txtNothiSubjectType.Multiline = true;
            this.txtNothiSubjectType.Name = "txtNothiSubjectType";
            this.txtNothiSubjectType.Size = new System.Drawing.Size(199, 63);
            this.txtNothiSubjectType.TabIndex = 32;
            // 
            // txtNothiCode
            // 
            this.txtNothiCode.BackColor = System.Drawing.Color.White;
            this.txtNothiCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNothiCode.Location = new System.Drawing.Point(286, 12);
            this.txtNothiCode.Multiline = true;
            this.txtNothiCode.Name = "txtNothiCode";
            this.txtNothiCode.Size = new System.Drawing.Size(44, 35);
            this.txtNothiCode.TabIndex = 33;
            // 
            // txtNothiNumber
            // 
            this.txtNothiNumber.BackColor = System.Drawing.Color.White;
            this.txtNothiNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNothiNumber.Location = new System.Drawing.Point(347, 12);
            this.txtNothiNumber.Multiline = true;
            this.txtNothiNumber.Name = "txtNothiNumber";
            this.txtNothiNumber.Size = new System.Drawing.Size(44, 35);
            this.txtNothiNumber.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(412, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 35);
            this.button1.TabIndex = 45;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Turquoise;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(446, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 35);
            this.button3.TabIndex = 47;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // NothiTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNothiNumber);
            this.Controls.Add(this.txtNothiCode);
            this.Controls.Add(this.txtNothiSubjectType);
            this.Controls.Add(this.txtSerialNo);
            this.Name = "NothiTypeList";
            this.Size = new System.Drawing.Size(556, 103);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XTextBox txtSerialNo;
        private XTextBox txtNothiSubjectType;
        private XTextBox txtNothiCode;
        private XTextBox txtNothiNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}
