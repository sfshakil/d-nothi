namespace dNothi.Desktop.UI.Dak
{
    partial class CreateNewNothiType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewNothiType));
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNothiType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xTextBox1 = new dNothi.Desktop.XTextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGuidelines = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "বিষয়ের ধরন";
            // 
            // cbxNothiType
            // 
            this.cbxNothiType.BackColor = System.Drawing.Color.White;
            this.cbxNothiType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNothiType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbxNothiType.FormattingEnabled = true;
            this.cbxNothiType.IntegralHeight = false;
            this.cbxNothiType.ItemHeight = 20;
            this.cbxNothiType.Location = new System.Drawing.Point(26, 38);
            this.cbxNothiType.MaxDropDownItems = 100;
            this.cbxNothiType.Name = "cbxNothiType";
            this.cbxNothiType.Size = new System.Drawing.Size(369, 28);
            this.cbxNothiType.TabIndex = 47;
            this.cbxNothiType.Text = "বিষয়ের ধরন";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "২ ডিজিটের ধরন কোড";
            // 
            // xTextBox1
            // 
            this.xTextBox1.BackColor = System.Drawing.Color.White;
            this.xTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xTextBox1.Location = new System.Drawing.Point(422, 38);
            this.xTextBox1.Multiline = true;
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(122, 28);
            this.xTextBox1.TabIndex = 49;
            this.xTextBox1.Text = "২ ডিজিটের ধরন কোড";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.Location = new System.Drawing.Point(362, 83);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(92, 43);
            this.button11.TabIndex = 50;
            this.button11.Text = "সংরক্ষণ করুন";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DeepPink;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(452, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 43);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "বাতিল করুন";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGuidelines
            // 
            this.btnGuidelines.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnGuidelines.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuidelines.BackgroundImage")));
            this.btnGuidelines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuidelines.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuidelines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuidelines.Location = new System.Drawing.Point(26, 83);
            this.btnGuidelines.Name = "btnGuidelines";
            this.btnGuidelines.Size = new System.Drawing.Size(25, 23);
            this.btnGuidelines.TabIndex = 52;
            this.btnGuidelines.UseVisualStyleBackColor = false;
            this.btnGuidelines.Click += new System.EventHandler(this.btnGuidelines_Click);
            // 
            // CreateNewNothiType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGuidelines);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.xTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxNothiType);
            this.Controls.Add(this.label2);
            this.Name = "CreateNewNothiType";
            this.Size = new System.Drawing.Size(554, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNothiType;
        private System.Windows.Forms.Label label1;
        private XTextBox xTextBox1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGuidelines;
    }
}
