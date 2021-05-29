
namespace dNothi.Desktop.UI.Dak
{
    partial class FileViewWebBrowser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileWebBrowser = new System.Windows.Forms.WebBrowser();
            this.btnCross = new FontAwesome.Sharp.IconButton();
            this.lbFileName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbFileName);
            this.panel1.Controls.Add(this.btnCross);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 2, 5, 2);
            this.panel1.Size = new System.Drawing.Size(1100, 42);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // fileWebBrowser
            // 
            this.fileWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileWebBrowser.Location = new System.Drawing.Point(0, 42);
            this.fileWebBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.fileWebBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.fileWebBrowser.Name = "fileWebBrowser";
            this.fileWebBrowser.Size = new System.Drawing.Size(1100, 691);
            this.fileWebBrowser.TabIndex = 5;
            this.fileWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // btnCross
            // 
            this.btnCross.AutoSize = true;
            this.btnCross.BackColor = System.Drawing.Color.Transparent;
            this.btnCross.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCross.FlatAppearance.BorderSize = 0;
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCross.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCross.IconColor = System.Drawing.Color.DimGray;
            this.btnCross.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCross.IconSize = 20;
            this.btnCross.Location = new System.Drawing.Point(1067, 2);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(28, 38);
            this.btnCross.TabIndex = 38;
            this.btnCross.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.BackColor = System.Drawing.Color.Transparent;
            this.lbFileName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFileName.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFileName.Location = new System.Drawing.Point(3, 2);
            this.lbFileName.Margin = new System.Windows.Forms.Padding(0);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lbFileName.Size = new System.Drawing.Size(93, 29);
            this.lbFileName.TabIndex = 74;
            this.lbFileName.Text = "fileName";
            // 
            // FileViewWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 733);
            this.Controls.Add(this.fileWebBrowser);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileViewWebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileViewWebBrowser";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCross;
        private System.Windows.Forms.WebBrowser fileWebBrowser;
        private System.Windows.Forms.Label lbFileName;
    }
}