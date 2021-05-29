
namespace dNothi.Desktop.UI.Dak
{
    partial class FileUserControl
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
            this.FileTLP = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbFileName = new System.Windows.Forms.Label();
            this.lbFileSizeInKb = new System.Windows.Forms.Label();
            this.lbFileDownloadLink = new System.Windows.Forms.Label();
            this.lbFileViewLink = new System.Windows.Forms.Label();
            this.btnFileDownload = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnPlusSquare = new FontAwesome.Sharp.IconButton();
            this.FileTLP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileTLP
            // 
            this.FileTLP.AutoSize = true;
            this.FileTLP.ColumnCount = 3;
            this.FileTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.875969F));
            this.FileTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.30232F));
            this.FileTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.74419F));
            this.FileTLP.Controls.Add(this.panel3, 2, 0);
            this.FileTLP.Controls.Add(this.panel2, 1, 0);
            this.FileTLP.Controls.Add(this.panel1, 0, 0);
            this.FileTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileTLP.Location = new System.Drawing.Point(0, 0);
            this.FileTLP.Margin = new System.Windows.Forms.Padding(0);
            this.FileTLP.Name = "FileTLP";
            this.FileTLP.RowCount = 1;
            this.FileTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FileTLP.Size = new System.Drawing.Size(1290, 68);
            this.FileTLP.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPlusSquare);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 68);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbFileViewLink);
            this.panel2.Controls.Add(this.lbFileDownloadLink);
            this.panel2.Controls.Add(this.lbFileSizeInKb);
            this.panel2.Controls.Add(this.lbFileName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(50, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1023, 68);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.lbFileName_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnFileDownload);
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1073, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 68);
            this.panel3.TabIndex = 2;
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.BackColor = System.Drawing.Color.Transparent;
            this.lbFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbFileName.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFileName.Location = new System.Drawing.Point(0, 0);
            this.lbFileName.Margin = new System.Windows.Forms.Padding(0);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbFileName.Size = new System.Drawing.Size(90, 29);
            this.lbFileName.TabIndex = 73;
            this.lbFileName.Text = "fileName";
            this.lbFileName.Click += new System.EventHandler(this.lbFileName_Click);
            // 
            // lbFileSizeInKb
            // 
            this.lbFileSizeInKb.AutoSize = true;
            this.lbFileSizeInKb.BackColor = System.Drawing.Color.Transparent;
            this.lbFileSizeInKb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbFileSizeInKb.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbFileSizeInKb.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbFileSizeInKb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.lbFileSizeInKb.Location = new System.Drawing.Point(0, 29);
            this.lbFileSizeInKb.Margin = new System.Windows.Forms.Padding(0);
            this.lbFileSizeInKb.Name = "lbFileSizeInKb";
            this.lbFileSizeInKb.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbFileSizeInKb.Size = new System.Drawing.Size(118, 29);
            this.lbFileSizeInKb.TabIndex = 74;
            this.lbFileSizeInKb.Text = "fileSizeInKB";
            this.lbFileSizeInKb.Click += new System.EventHandler(this.lbFileName_Click);
            // 
            // lbFileDownloadLink
            // 
            this.lbFileDownloadLink.AutoSize = true;
            this.lbFileDownloadLink.BackColor = System.Drawing.Color.Transparent;
            this.lbFileDownloadLink.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbFileDownloadLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.lbFileDownloadLink.Location = new System.Drawing.Point(580, 0);
            this.lbFileDownloadLink.Margin = new System.Windows.Forms.Padding(0);
            this.lbFileDownloadLink.Name = "lbFileDownloadLink";
            this.lbFileDownloadLink.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbFileDownloadLink.Size = new System.Drawing.Size(166, 29);
            this.lbFileDownloadLink.TabIndex = 75;
            this.lbFileDownloadLink.Text = "FileDownloadLink";
            this.lbFileDownloadLink.Visible = false;
            // 
            // lbFileViewLink
            // 
            this.lbFileViewLink.AutoSize = true;
            this.lbFileViewLink.BackColor = System.Drawing.Color.Transparent;
            this.lbFileViewLink.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbFileViewLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.lbFileViewLink.Location = new System.Drawing.Point(580, 29);
            this.lbFileViewLink.Margin = new System.Windows.Forms.Padding(0);
            this.lbFileViewLink.Name = "lbFileViewLink";
            this.lbFileViewLink.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbFileViewLink.Size = new System.Drawing.Size(121, 29);
            this.lbFileViewLink.TabIndex = 76;
            this.lbFileViewLink.Text = "FileViewLink";
            this.lbFileViewLink.Visible = false;
            // 
            // btnFileDownload
            // 
            this.btnFileDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnFileDownload.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFileDownload.FlatAppearance.BorderSize = 0;
            this.btnFileDownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnFileDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnFileDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileDownload.ForeColor = System.Drawing.Color.Transparent;
            this.btnFileDownload.IconChar = FontAwesome.Sharp.IconChar.CloudDownloadAlt;
            this.btnFileDownload.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.btnFileDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFileDownload.IconSize = 32;
            this.btnFileDownload.Location = new System.Drawing.Point(83, 15);
            this.btnFileDownload.Margin = new System.Windows.Forms.Padding(0);
            this.btnFileDownload.Name = "btnFileDownload";
            this.btnFileDownload.Size = new System.Drawing.Size(50, 38);
            this.btnFileDownload.TabIndex = 74;
            this.btnFileDownload.UseVisualStyleBackColor = false;
            this.btnFileDownload.Click += new System.EventHandler(this.btnFileDownload_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Transparent;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ShareAlt;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 28;
            this.iconButton1.Location = new System.Drawing.Point(133, 15);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(50, 38);
            this.iconButton1.TabIndex = 73;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Visible = false;
            // 
            // btnPlusSquare
            // 
            this.btnPlusSquare.BackColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlusSquare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPlusSquare.FlatAppearance.BorderSize = 0;
            this.btnPlusSquare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlusSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlusSquare.ForeColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.btnPlusSquare.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.btnPlusSquare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlusSquare.IconSize = 38;
            this.btnPlusSquare.Location = new System.Drawing.Point(0, 0);
            this.btnPlusSquare.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlusSquare.Name = "btnPlusSquare";
            this.btnPlusSquare.Size = new System.Drawing.Size(50, 68);
            this.btnPlusSquare.TabIndex = 72;
            this.btnPlusSquare.UseVisualStyleBackColor = false;
            // 
            // FileUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileTLP);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FileUserControl";
            this.Size = new System.Drawing.Size(1290, 68);
            this.FileTLP.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel FileTLP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnPlusSquare;
        private FontAwesome.Sharp.IconButton btnFileDownload;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label lbFileSizeInKb;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Label lbFileViewLink;
        private System.Windows.Forms.Label lbFileDownloadLink;
    }
}
