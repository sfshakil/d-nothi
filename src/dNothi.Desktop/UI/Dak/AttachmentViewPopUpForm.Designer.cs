﻿namespace dNothi.Desktop.UI.Dak
{
    partial class AttachmentViewPopUpForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttachmentViewPopUpForm));
            this.pdfViewerControl = new AxAcroPDFLib.AxAcroPDF();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.imageViewPictureBox = new System.Windows.Forms.PictureBox();
            this.fileMissingLabel = new System.Windows.Forms.Label();
            this.rightArrowButton = new FontAwesome.Sharp.IconButton();
            this.leftArrowButton = new FontAwesome.Sharp.IconButton();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.waitPictureBox = new System.Windows.Forms.PictureBox();
            this.mainAttachmentViewWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.downloadIconButton = new FontAwesome.Sharp.IconButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pdfViewerControl)).BeginInit();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pdfViewerControl
            // 
            this.pdfViewerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pdfViewerControl.Enabled = true;
            this.pdfViewerControl.Location = new System.Drawing.Point(0, 501);
            this.pdfViewerControl.Name = "pdfViewerControl";
            this.pdfViewerControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfViewerControl.OcxState")));
            this.pdfViewerControl.Size = new System.Drawing.Size(767, 650);
            this.pdfViewerControl.TabIndex = 3;
            // 
            // imagePanel
            // 
            this.imagePanel.AutoScroll = true;
            this.imagePanel.AutoSize = true;
            this.imagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.imagePanel.Controls.Add(this.imageViewPictureBox);
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.Location = new System.Drawing.Point(0, 1151);
            this.imagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.imagePanel.MaximumSize = new System.Drawing.Size(867, 620);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(767, 0);
            this.imagePanel.TabIndex = 4;
            this.imagePanel.MouseLeave += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            this.imagePanel.MouseHover += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            // 
            // imageViewPictureBox
            // 
            this.imageViewPictureBox.ErrorImage = global::dNothi.Desktop.Properties.Resources.PDF_File_Icon;
            this.imageViewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.imageViewPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.imageViewPictureBox.Name = "imageViewPictureBox";
            this.imageViewPictureBox.Size = new System.Drawing.Size(101, 503);
            this.imageViewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageViewPictureBox.TabIndex = 2;
            this.imageViewPictureBox.TabStop = false;
            this.imageViewPictureBox.WaitOnLoad = true;
            this.imageViewPictureBox.MouseLeave += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            this.imageViewPictureBox.MouseHover += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            // 
            // fileMissingLabel
            // 
            this.fileMissingLabel.AutoSize = true;
            this.fileMissingLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileMissingLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileMissingLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fileMissingLabel.Location = new System.Drawing.Point(0, 0);
            this.fileMissingLabel.MinimumSize = new System.Drawing.Size(767, 501);
            this.fileMissingLabel.Name = "fileMissingLabel";
            this.fileMissingLabel.Size = new System.Drawing.Size(767, 501);
            this.fileMissingLabel.TabIndex = 5;
            this.fileMissingLabel.Text = "দুঃখিত! ফাইলটি বর্তমান অবস্থানে বিদ্যমান নেই।";
            this.fileMissingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.fileMissingLabel.MouseLeave += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            this.fileMissingLabel.MouseHover += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            // 
            // rightArrowButton
            // 
            this.rightArrowButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rightArrowButton.FlatAppearance.BorderSize = 0;
            this.rightArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightArrowButton.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleRight;
            this.rightArrowButton.IconColor = System.Drawing.Color.Black;
            this.rightArrowButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.rightArrowButton.Location = new System.Drawing.Point(726, 265);
            this.rightArrowButton.Name = "rightArrowButton";
            this.rightArrowButton.Size = new System.Drawing.Size(39, 44);
            this.rightArrowButton.TabIndex = 7;
            this.rightArrowButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rightArrowButton.UseVisualStyleBackColor = true;
            this.rightArrowButton.Click += new System.EventHandler(this.rightArrowButton_Click);
            // 
            // leftArrowButton
            // 
            this.leftArrowButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.leftArrowButton.FlatAppearance.BorderSize = 0;
            this.leftArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftArrowButton.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft;
            this.leftArrowButton.IconColor = System.Drawing.Color.Black;
            this.leftArrowButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.leftArrowButton.Location = new System.Drawing.Point(5, 258);
            this.leftArrowButton.Name = "leftArrowButton";
            this.leftArrowButton.Size = new System.Drawing.Size(39, 44);
            this.leftArrowButton.TabIndex = 6;
            this.leftArrowButton.UseVisualStyleBackColor = true;
            this.leftArrowButton.Click += new System.EventHandler(this.leftArrowButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoEllipsis = true;
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.Black;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.closeButton.IconColor = System.Drawing.Color.Black;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closeButton.IconSize = 32;
            this.closeButton.Location = new System.Drawing.Point(737, 2);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 27);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseLeave += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            this.closeButton.MouseHover += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            // 
            // waitPictureBox
            // 
            this.waitPictureBox.BackColor = System.Drawing.Color.White;
            this.waitPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waitPictureBox.Image = global::dNothi.Desktop.Properties.Resources.Full_snake;
            this.waitPictureBox.Location = new System.Drawing.Point(0, 1151);
            this.waitPictureBox.Name = "waitPictureBox";
            this.waitPictureBox.Size = new System.Drawing.Size(767, 0);
            this.waitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.waitPictureBox.TabIndex = 8;
            this.waitPictureBox.TabStop = false;
            this.waitPictureBox.Visible = false;
            // 
            // mainAttachmentViewWebBrowser
            // 
            this.mainAttachmentViewWebBrowser.ActivateBrowserOnCreation = false;
            this.mainAttachmentViewWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainAttachmentViewWebBrowser.Location = new System.Drawing.Point(0, 1151);
            this.mainAttachmentViewWebBrowser.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.mainAttachmentViewWebBrowser.Name = "mainAttachmentViewWebBrowser";
            this.mainAttachmentViewWebBrowser.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.mainAttachmentViewWebBrowser.Size = new System.Drawing.Size(767, 0);
            this.mainAttachmentViewWebBrowser.TabIndex = 9;
            this.mainAttachmentViewWebBrowser.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.mainAttachmentViewWebBrowser_FrameLoadEnd);
            // 
            // downloadIconButton
            // 
            this.downloadIconButton.AutoEllipsis = true;
            this.downloadIconButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadIconButton.FlatAppearance.BorderSize = 0;
            this.downloadIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadIconButton.ForeColor = System.Drawing.Color.Black;
            this.downloadIconButton.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.downloadIconButton.IconColor = System.Drawing.Color.Black;
            this.downloadIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.downloadIconButton.IconSize = 15;
            this.downloadIconButton.Location = new System.Drawing.Point(692, 2);
            this.downloadIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.downloadIconButton.Name = "downloadIconButton";
            this.downloadIconButton.Size = new System.Drawing.Size(28, 27);
            this.downloadIconButton.TabIndex = 10;
            this.downloadIconButton.UseVisualStyleBackColor = true;
            this.downloadIconButton.Click += new System.EventHandler(this.downloadIconButton_Click);
            // 
            // AttachmentViewPopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(767, 520);
            this.Controls.Add(this.downloadIconButton);
            this.Controls.Add(this.rightArrowButton);
            this.Controls.Add(this.leftArrowButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.waitPictureBox);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.mainAttachmentViewWebBrowser);
            this.Controls.Add(this.pdfViewerControl);
            this.Controls.Add(this.fileMissingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AttachmentViewPopUpForm";
            this.Text = "AttachmentViewPopUpForm";
            this.Load += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            this.MouseLeave += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            this.MouseHover += new System.EventHandler(this.AttachmentViewPopUpForm_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pdfViewerControl)).EndInit();
            this.imagePanel.ResumeLayout(false);
            this.imagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton closeButton;
        private AxAcroPDFLib.AxAcroPDF pdfViewerControl;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.PictureBox imageViewPictureBox;
        private System.Windows.Forms.Label fileMissingLabel;
        private FontAwesome.Sharp.IconButton leftArrowButton;
        private FontAwesome.Sharp.IconButton rightArrowButton;
        private System.Windows.Forms.PictureBox waitPictureBox;
        private CefSharp.WinForms.ChromiumWebBrowser mainAttachmentViewWebBrowser;
        private FontAwesome.Sharp.IconButton downloadIconButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}