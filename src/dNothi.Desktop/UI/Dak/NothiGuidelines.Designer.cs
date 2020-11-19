namespace dNothi.Desktop.UI.Dak
{
    partial class NothiGuidelines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NothiGuidelines));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpNothiGuidelines = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCross = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flpNothiGuidelines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCross);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 60);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "সচিবালয়ের নির্দেশমালা";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 66);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // flpNothiGuidelines
            // 
            this.flpNothiGuidelines.AutoScroll = true;
            this.flpNothiGuidelines.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpNothiGuidelines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flpNothiGuidelines.Controls.Add(this.pictureBox2);
            this.flpNothiGuidelines.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNothiGuidelines.Location = new System.Drawing.Point(3, 66);
            this.flpNothiGuidelines.Name = "flpNothiGuidelines";
            this.flpNothiGuidelines.Size = new System.Drawing.Size(1115, 1110);
            this.flpNothiGuidelines.TabIndex = 4;
            this.flpNothiGuidelines.WrapContents = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1115, 1800);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.Red;
            this.btnCross.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCross.BackgroundImage")));
            this.btnCross.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCross.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Location = new System.Drawing.Point(1075, 19);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(25, 23);
            this.btnCross.TabIndex = 39;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // NothiGuidelines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.flpNothiGuidelines);
            this.Controls.Add(this.panel1);
            this.Name = "NothiGuidelines";
            this.Size = new System.Drawing.Size(1121, 1330);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flpNothiGuidelines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpNothiGuidelines;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
