namespace dNothi.Desktop.UI
{
    partial class DefaultPageUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.modulePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // modulePanel
            // 
            this.modulePanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.modulePanel.Controls.Add(this.label1);
            this.modulePanel.Location = new System.Drawing.Point(0, 0);
            this.modulePanel.Name = "modulePanel";
            this.modulePanel.Size = new System.Drawing.Size(788, 162);
            this.modulePanel.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Page Under Construction";
            // 
            // DefaultPageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.modulePanel);
            this.Name = "DefaultPageUserControl";
            this.Size = new System.Drawing.Size(798, 165);
            this.modulePanel.ResumeLayout(false);
            this.modulePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel modulePanel;
        private System.Windows.Forms.Label label1;
    }
}
