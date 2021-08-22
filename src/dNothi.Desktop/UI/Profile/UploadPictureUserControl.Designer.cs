
namespace dNothi.Desktop.UI.Profile
{
    partial class UploadPictureUserControl
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
            this.panel34 = new System.Windows.Forms.Panel();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.officerEditablePictureBox = new System.Windows.Forms.PictureBox();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.zoomInButton = new FontAwesome.Sharp.IconButton();
            this.zoomOutButton = new FontAwesome.Sharp.IconButton();
            this.rightRotateButton = new FontAwesome.Sharp.IconButton();
            this.leftRotateIconButton = new FontAwesome.Sharp.IconButton();
            this.choosePicButton = new FontAwesome.Sharp.IconButton();
            this.panel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerEditablePictureBox)).BeginInit();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.panel34.Controls.Add(this.closeButton);
            this.panel34.Controls.Add(this.iconButton3);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel34.Location = new System.Drawing.Point(0, 0);
            this.panel34.Margin = new System.Windows.Forms.Padding(0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(372, 50);
            this.panel34.TabIndex = 1;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.AutoSize = true;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.closeButton.IconColor = System.Drawing.Color.Black;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closeButton.IconSize = 32;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeButton.Location = new System.Drawing.Point(334, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(38, 38);
            this.closeButton.TabIndex = 2;
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeButton.UseCompatibleTextRendering = true;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.Black;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton3.IconColor = System.Drawing.Color.Black;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 24;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 0);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(166, 50);
            this.iconButton3.TabIndex = 6;
            this.iconButton3.Text = "ছবি ক্রপ করুন";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = true;
            // 
            // officerEditablePictureBox
            // 
            this.officerEditablePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.officerEditablePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.officerEditablePictureBox.Location = new System.Drawing.Point(-23, -21);
            this.officerEditablePictureBox.Name = "officerEditablePictureBox";
            this.officerEditablePictureBox.Size = new System.Drawing.Size(236, 235);
            this.officerEditablePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.officerEditablePictureBox.TabIndex = 39;
            this.officerEditablePictureBox.TabStop = false;
            this.officerEditablePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.officerEditablePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.officerEditablePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // picturePanel
            // 
            this.picturePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePanel.Controls.Add(this.officerEditablePictureBox);
            this.picturePanel.Location = new System.Drawing.Point(80, 86);
            this.picturePanel.Margin = new System.Windows.Forms.Padding(0);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(200, 200);
            this.picturePanel.TabIndex = 40;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(80, 296);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(200, 45);
            this.trackBar1.TabIndex = 41;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // zoomInButton
            // 
            this.zoomInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomInButton.AutoSize = true;
            this.zoomInButton.FlatAppearance.BorderSize = 0;
            this.zoomInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomInButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.zoomInButton.IconColor = System.Drawing.Color.Black;
            this.zoomInButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.zoomInButton.IconSize = 12;
            this.zoomInButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomInButton.Location = new System.Drawing.Point(276, 294);
            this.zoomInButton.Margin = new System.Windows.Forms.Padding(0);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(18, 25);
            this.zoomInButton.TabIndex = 42;
            this.zoomInButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zoomInButton.UseCompatibleTextRendering = true;
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomOutButton.AutoSize = true;
            this.zoomOutButton.FlatAppearance.BorderSize = 0;
            this.zoomOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomOutButton.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.zoomOutButton.IconColor = System.Drawing.Color.Black;
            this.zoomOutButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.zoomOutButton.IconSize = 12;
            this.zoomOutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zoomOutButton.Location = new System.Drawing.Point(68, 296);
            this.zoomOutButton.Margin = new System.Windows.Forms.Padding(0);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(18, 25);
            this.zoomOutButton.TabIndex = 43;
            this.zoomOutButton.UseCompatibleTextRendering = true;
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // rightRotateButton
            // 
            this.rightRotateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightRotateButton.AutoSize = true;
            this.rightRotateButton.FlatAppearance.BorderSize = 0;
            this.rightRotateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightRotateButton.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.rightRotateButton.IconColor = System.Drawing.Color.Black;
            this.rightRotateButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.rightRotateButton.IconSize = 24;
            this.rightRotateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rightRotateButton.Location = new System.Drawing.Point(314, 318);
            this.rightRotateButton.Margin = new System.Windows.Forms.Padding(0);
            this.rightRotateButton.Name = "rightRotateButton";
            this.rightRotateButton.Size = new System.Drawing.Size(38, 38);
            this.rightRotateButton.TabIndex = 44;
            this.rightRotateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rightRotateButton.UseCompatibleTextRendering = true;
            this.rightRotateButton.UseVisualStyleBackColor = true;
            this.rightRotateButton.Click += new System.EventHandler(this.rightRotateButton_Click);
            // 
            // leftRotateIconButton
            // 
            this.leftRotateIconButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftRotateIconButton.AutoSize = true;
            this.leftRotateIconButton.FlatAppearance.BorderSize = 0;
            this.leftRotateIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftRotateIconButton.IconChar = FontAwesome.Sharp.IconChar.Undo;
            this.leftRotateIconButton.IconColor = System.Drawing.Color.Black;
            this.leftRotateIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.leftRotateIconButton.IconSize = 24;
            this.leftRotateIconButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.leftRotateIconButton.Location = new System.Drawing.Point(39, 318);
            this.leftRotateIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.leftRotateIconButton.Name = "leftRotateIconButton";
            this.leftRotateIconButton.Size = new System.Drawing.Size(38, 38);
            this.leftRotateIconButton.TabIndex = 45;
            this.leftRotateIconButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.leftRotateIconButton.UseCompatibleTextRendering = true;
            this.leftRotateIconButton.UseVisualStyleBackColor = true;
            this.leftRotateIconButton.Click += new System.EventHandler(this.leftRotateIconButton_Click);
            // 
            // choosePicButton
            // 
            this.choosePicButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.choosePicButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(187)))), ((int)(((byte)(135)))));
            this.choosePicButton.FlatAppearance.BorderSize = 0;
            this.choosePicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choosePicButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosePicButton.ForeColor = System.Drawing.Color.White;
            this.choosePicButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.choosePicButton.IconColor = System.Drawing.Color.White;
            this.choosePicButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.choosePicButton.IconSize = 24;
            this.choosePicButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.choosePicButton.Location = new System.Drawing.Point(80, 359);
            this.choosePicButton.Name = "choosePicButton";
            this.choosePicButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.choosePicButton.Size = new System.Drawing.Size(200, 39);
            this.choosePicButton.TabIndex = 46;
            this.choosePicButton.Text = "সংরক্ষণ";
            this.choosePicButton.UseVisualStyleBackColor = false;
            this.choosePicButton.Click += new System.EventHandler(this.choosePicButton_Click);
            // 
            // UploadPictureUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(372, 399);
            this.Controls.Add(this.choosePicButton);
            this.Controls.Add(this.leftRotateIconButton);
            this.Controls.Add(this.rightRotateButton);
            this.Controls.Add(this.zoomOutButton);
            this.Controls.Add(this.zoomInButton);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.panel34);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UploadPictureUserControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerEditablePictureBox)).EndInit();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel34;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton closeButton;
        private System.Windows.Forms.PictureBox officerEditablePictureBox;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.TrackBar trackBar1;
        private FontAwesome.Sharp.IconButton zoomInButton;
        private FontAwesome.Sharp.IconButton zoomOutButton;
        private FontAwesome.Sharp.IconButton rightRotateButton;
        private FontAwesome.Sharp.IconButton leftRotateIconButton;
        private FontAwesome.Sharp.IconButton choosePicButton;
    }
}
