
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
            this.components = new System.ComponentModel.Container();
            this.FileTLP = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnWhatsappShare = new FontAwesome.Sharp.IconButton();
            this.btnMailShare = new FontAwesome.Sharp.IconButton();
            this.btnFileDownload = new FontAwesome.Sharp.IconButton();
            this.btnShare = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbFileViewLink = new System.Windows.Forms.Label();
            this.lbFileDownloadLink = new System.Windows.Forms.Label();
            this.lbFileSizeInKb = new System.Windows.Forms.Label();
            this.lbFileName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlusSquare = new FontAwesome.Sharp.IconButton();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.FileTLP.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileTLP
            // 
            this.FileTLP.AutoSize = true;
            this.FileTLP.ColumnCount = 3;
            this.FileTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.031008F));
            this.FileTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.14729F));
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
            this.FileTLP.Size = new System.Drawing.Size(1290, 90);
            this.FileTLP.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnWhatsappShare);
            this.panel3.Controls.Add(this.btnMailShare);
            this.panel3.Controls.Add(this.btnFileDownload);
            this.panel3.Controls.Add(this.btnShare);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1073, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 90);
            this.panel3.TabIndex = 2;
            // 
            // btnWhatsappShare
            // 
            this.btnWhatsappShare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnWhatsappShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhatsappShare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWhatsappShare.FlatAppearance.BorderSize = 0;
            this.btnWhatsappShare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnWhatsappShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnWhatsappShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhatsappShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhatsappShare.ForeColor = System.Drawing.Color.White;
            this.btnWhatsappShare.IconChar = FontAwesome.Sharp.IconChar.Whatsapp;
            this.btnWhatsappShare.IconColor = System.Drawing.Color.White;
            this.btnWhatsappShare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWhatsappShare.IconSize = 26;
            this.btnWhatsappShare.Location = new System.Drawing.Point(156, 48);
            this.btnWhatsappShare.Margin = new System.Windows.Forms.Padding(0);
            this.btnWhatsappShare.Name = "btnWhatsappShare";
            this.btnWhatsappShare.Size = new System.Drawing.Size(36, 37);
            this.btnWhatsappShare.TabIndex = 79;
            this.MyToolTip.SetToolTip(this.btnWhatsappShare, "হোয়াটসঅ্যাপে শেয়ার করুন");
            this.btnWhatsappShare.UseVisualStyleBackColor = false;
            this.btnWhatsappShare.Visible = false;
            this.btnWhatsappShare.Click += new System.EventHandler(this.btnWhatsappShare_Click);
            // 
            // btnMailShare
            // 
            this.btnMailShare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnMailShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMailShare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMailShare.FlatAppearance.BorderSize = 0;
            this.btnMailShare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnMailShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnMailShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMailShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMailShare.ForeColor = System.Drawing.Color.White;
            this.btnMailShare.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.btnMailShare.IconColor = System.Drawing.Color.White;
            this.btnMailShare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMailShare.IconSize = 26;
            this.btnMailShare.Location = new System.Drawing.Point(120, 48);
            this.btnMailShare.Margin = new System.Windows.Forms.Padding(0);
            this.btnMailShare.Name = "btnMailShare";
            this.btnMailShare.Size = new System.Drawing.Size(36, 37);
            this.btnMailShare.TabIndex = 78;
            this.MyToolTip.SetToolTip(this.btnMailShare, "মেইলে শেয়ার করুন");
            this.btnMailShare.UseVisualStyleBackColor = false;
            this.btnMailShare.Visible = false;
            this.btnMailShare.Click += new System.EventHandler(this.btnMailShare_Click);
            // 
            // btnFileDownload
            // 
            this.btnFileDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnFileDownload.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnFileDownload.Location = new System.Drawing.Point(83, 8);
            this.btnFileDownload.Margin = new System.Windows.Forms.Padding(0);
            this.btnFileDownload.Name = "btnFileDownload";
            this.btnFileDownload.Size = new System.Drawing.Size(36, 38);
            this.btnFileDownload.TabIndex = 74;
            this.MyToolTip.SetToolTip(this.btnFileDownload, "ডাউনলোড ");
            this.btnFileDownload.UseVisualStyleBackColor = false;
            this.btnFileDownload.Click += new System.EventHandler(this.btnFileDownload_Click);
            // 
            // btnShare
            // 
            this.btnShare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShare.FlatAppearance.BorderSize = 0;
            this.btnShare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnShare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnShare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShare.ForeColor = System.Drawing.Color.Transparent;
            this.btnShare.IconChar = FontAwesome.Sharp.IconChar.ShareAlt;
            this.btnShare.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.btnShare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShare.IconSize = 28;
            this.btnShare.Location = new System.Drawing.Point(120, 8);
            this.btnShare.Margin = new System.Windows.Forms.Padding(0);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(36, 38);
            this.btnShare.TabIndex = 73;
            this.MyToolTip.SetToolTip(this.btnShare, "শেয়ার");
            this.btnShare.UseVisualStyleBackColor = false;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbFileViewLink);
            this.panel2.Controls.Add(this.lbFileDownloadLink);
            this.panel2.Controls.Add(this.lbFileSizeInKb);
            this.panel2.Controls.Add(this.lbFileName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(52, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 90);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.lbFileName_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPlusSquare);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 90);
            this.panel1.TabIndex = 0;
            // 
            // btnPlusSquare
            // 
            this.btnPlusSquare.BackColor = System.Drawing.Color.Transparent;
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
            this.btnPlusSquare.Location = new System.Drawing.Point(8, 11);
            this.btnPlusSquare.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlusSquare.Name = "btnPlusSquare";
            this.btnPlusSquare.Size = new System.Drawing.Size(36, 43);
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
            this.Size = new System.Drawing.Size(1290, 90);
            this.FileTLP.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        private FontAwesome.Sharp.IconButton btnShare;
        private System.Windows.Forms.Label lbFileSizeInKb;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Label lbFileViewLink;
        private System.Windows.Forms.Label lbFileDownloadLink;
        private FontAwesome.Sharp.IconButton btnWhatsappShare;
        private FontAwesome.Sharp.IconButton btnMailShare;
        private System.Windows.Forms.ToolTip MyToolTip;
    }
}
