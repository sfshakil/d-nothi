namespace dNothi.Desktop.CustomControl
{
    partial class PlaceHolderTextBox
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
            this.XTextBox = new dNothi.Desktop.XTextBox();
            this.SuspendLayout();
            // 
            // XTextBox
            // 
            this.XTextBox.BackColor = System.Drawing.Color.White;
            this.XTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.XTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.XTextBox.Location = new System.Drawing.Point(0, 0);
            this.XTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.XTextBox.Multiline = true;
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(193, 22);
            this.XTextBox.TabIndex = 34;
            this.XTextBox.Text = "X Text Box";
            // 
            // PlaceHolderTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.XTextBox);
            this.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 4, 3, 4);
            this.Name = "PlaceHolderTextBox";
            this.Size = new System.Drawing.Size(193, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XTextBox XTextBox;
    }
}
