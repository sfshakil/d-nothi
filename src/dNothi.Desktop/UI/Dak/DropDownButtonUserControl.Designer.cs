namespace dNothi.Desktop.UI.Dak
{
    partial class DropDownButtonUserControl
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
            this.daptorikDakUploadButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // daptorikDakUploadButton
            // 
            this.daptorikDakUploadButton.AutoSize = true;
            this.daptorikDakUploadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daptorikDakUploadButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daptorikDakUploadButton.Location = new System.Drawing.Point(0, 0);
            this.daptorikDakUploadButton.MaximumSize = new System.Drawing.Size(212, 0);
            this.daptorikDakUploadButton.Name = "daptorikDakUploadButton";
            this.daptorikDakUploadButton.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
            this.daptorikDakUploadButton.Size = new System.Drawing.Size(25, 28);
            this.daptorikDakUploadButton.TabIndex = 0;
            this.daptorikDakUploadButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DropDownButtonUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.daptorikDakUploadButton);
            this.MaximumSize = new System.Drawing.Size(212, 0);
            this.Name = "DropDownButtonUserControl";
            this.Size = new System.Drawing.Size(212, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label daptorikDakUploadButton;
    }
}
