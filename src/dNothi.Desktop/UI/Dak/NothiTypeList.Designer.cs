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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbNothiSubjectType = new System.Windows.Forms.Label();
            this.lbNothiCode = new System.Windows.Forms.Label();
            this.lbNothiNumber = new System.Windows.Forms.Label();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(410, 12);
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
            this.button3.Location = new System.Drawing.Point(444, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 35);
            this.button3.TabIndex = 47;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // lbNothiSubjectType
            // 
            this.lbNothiSubjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNothiSubjectType.Location = new System.Drawing.Point(81, 12);
            this.lbNothiSubjectType.Name = "lbNothiSubjectType";
            this.lbNothiSubjectType.Size = new System.Drawing.Size(199, 68);
            this.lbNothiSubjectType.TabIndex = 50;
            this.lbNothiSubjectType.Text = "NothiSubjectType";
            // 
            // lbNothiCode
            // 
            this.lbNothiCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNothiCode.Location = new System.Drawing.Point(284, 12);
            this.lbNothiCode.Name = "lbNothiCode";
            this.lbNothiCode.Size = new System.Drawing.Size(44, 35);
            this.lbNothiCode.TabIndex = 51;
            this.lbNothiCode.Text = "NothiCode";
            this.lbNothiCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNothiNumber
            // 
            this.lbNothiNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNothiNumber.Location = new System.Drawing.Point(345, 12);
            this.lbNothiNumber.Name = "lbNothiNumber";
            this.lbNothiNumber.Size = new System.Drawing.Size(44, 35);
            this.lbNothiNumber.TabIndex = 52;
            this.lbNothiNumber.Text = "NothiCode";
            this.lbNothiNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNo.Location = new System.Drawing.Point(20, 12);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(44, 35);
            this.lblSerialNo.TabIndex = 53;
            this.lblSerialNo.Text = "SerialNo";
            this.lblSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NothiTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSerialNo);
            this.Controls.Add(this.lbNothiNumber);
            this.Controls.Add(this.lbNothiCode);
            this.Controls.Add(this.lbNothiSubjectType);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "NothiTypeList";
            this.Size = new System.Drawing.Size(541, 103);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbNothiSubjectType;
        private System.Windows.Forms.Label lbNothiCode;
        private System.Windows.Forms.Label lbNothiNumber;
        private System.Windows.Forms.Label lblSerialNo;
    }
}
