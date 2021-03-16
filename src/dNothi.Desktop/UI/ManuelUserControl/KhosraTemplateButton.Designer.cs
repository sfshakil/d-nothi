namespace dNothi.Desktop.UI.ManuelUserControl
{
    partial class KhosraTemplateButton
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
            this.TemplateNameText = new System.Windows.Forms.Button();
            this.khosraTemplatePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.khosraTemplatePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TemplateNameText
            // 
            this.TemplateNameText.AutoSize = true;
            this.TemplateNameText.BackColor = System.Drawing.Color.Transparent;
            this.TemplateNameText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TemplateNameText.FlatAppearance.BorderSize = 0;
            this.TemplateNameText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TemplateNameText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TemplateNameText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TemplateNameText.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemplateNameText.Location = new System.Drawing.Point(0, 113);
            this.TemplateNameText.Name = "TemplateNameText";
            this.TemplateNameText.Size = new System.Drawing.Size(143, 56);
            this.TemplateNameText.TabIndex = 1;
            this.TemplateNameText.Text = "{Template Name}  sadfdfdsa ";
            this.TemplateNameText.UseVisualStyleBackColor = false;
            this.TemplateNameText.Click += new System.EventHandler(this.khosraTemplatePictureBox_Click);
            this.TemplateNameText.MouseLeave += new System.EventHandler(this.KhosraTemplateButton_MouseLeave);
            this.TemplateNameText.MouseHover += new System.EventHandler(this.KhosraTemplateButton_MouseHover);
            // 
            // khosraTemplatePictureBox
            // 
            this.khosraTemplatePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.khosraTemplatePictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.khosraTemplatePictureBox.Image = global::dNothi.Desktop.Properties.Resources.khoshra_1;
            this.khosraTemplatePictureBox.Location = new System.Drawing.Point(0, 0);
            this.khosraTemplatePictureBox.Name = "khosraTemplatePictureBox";
            this.khosraTemplatePictureBox.Size = new System.Drawing.Size(143, 113);
            this.khosraTemplatePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.khosraTemplatePictureBox.TabIndex = 0;
            this.khosraTemplatePictureBox.TabStop = false;
            this.khosraTemplatePictureBox.Click += new System.EventHandler(this.khosraTemplatePictureBox_Click);
            this.khosraTemplatePictureBox.MouseLeave += new System.EventHandler(this.KhosraTemplateButton_MouseLeave);
            this.khosraTemplatePictureBox.MouseHover += new System.EventHandler(this.KhosraTemplateButton_MouseHover);
            // 
            // KhosraTemplateButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.TemplateNameText);
            this.Controls.Add(this.khosraTemplatePictureBox);
            this.Name = "KhosraTemplateButton";
            this.Size = new System.Drawing.Size(143, 169);
            this.Click += new System.EventHandler(this.khosraTemplatePictureBox_Click);
            this.MouseLeave += new System.EventHandler(this.KhosraTemplateButton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.KhosraTemplateButton_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.khosraTemplatePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox khosraTemplatePictureBox;
        private System.Windows.Forms.Button TemplateNameText;
    }
}
