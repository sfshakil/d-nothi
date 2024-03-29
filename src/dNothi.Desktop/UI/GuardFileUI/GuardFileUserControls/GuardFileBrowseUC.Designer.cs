﻿namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    partial class GuardFileBrowseUC
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dakUploadAttachmentNameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.attachmentDeleteButton = new FontAwesome.Sharp.IconButton();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.attachmentLink = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentLink)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(840, 106);
            this.tableLayoutPanel2.TabIndex = 13;
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel2_CellPaint);
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(339, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(414, 101);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dakUploadAttachmentNameTextBox);
            this.panel3.Location = new System.Drawing.Point(9, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 32);
            this.panel3.TabIndex = 9;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // dakUploadAttachmentNameTextBox
            // 
            this.dakUploadAttachmentNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dakUploadAttachmentNameTextBox.BackColor = System.Drawing.Color.White;
            this.dakUploadAttachmentNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dakUploadAttachmentNameTextBox.Location = new System.Drawing.Point(6, 10);
            this.dakUploadAttachmentNameTextBox.Name = "dakUploadAttachmentNameTextBox";
            this.dakUploadAttachmentNameTextBox.Size = new System.Drawing.Size(382, 13);
            this.dakUploadAttachmentNameTextBox.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.attachmentDeleteButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(759, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 100);
            this.panel1.TabIndex = 7;
            // 
            // attachmentDeleteButton
            // 
            this.attachmentDeleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attachmentDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.attachmentDeleteButton.FlatAppearance.BorderSize = 0;
            this.attachmentDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentDeleteButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.attachmentDeleteButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(149)))), ((int)(((byte)(160)))));
            this.attachmentDeleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.attachmentDeleteButton.IconSize = 24;
            this.attachmentDeleteButton.Location = new System.Drawing.Point(21, 33);
            this.attachmentDeleteButton.Name = "attachmentDeleteButton";
            this.attachmentDeleteButton.Size = new System.Drawing.Size(36, 34);
            this.attachmentDeleteButton.TabIndex = 10;
            this.attachmentDeleteButton.UseVisualStyleBackColor = false;
            this.attachmentDeleteButton.Click += new System.EventHandler(this.attachmentDeleteButton_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.attachmentLink);
            this.panel4.Location = new System.Drawing.Point(166, 8);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(87, 90);
            this.panel4.TabIndex = 13;
            // 
            // attachmentLink
            // 
            this.attachmentLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.attachmentLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentLink.Location = new System.Drawing.Point(0, 0);
            this.attachmentLink.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.attachmentLink.Name = "attachmentLink";
            this.attachmentLink.Padding = new System.Windows.Forms.Padding(5);
            this.attachmentLink.Size = new System.Drawing.Size(87, 90);
            this.attachmentLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.attachmentLink.TabIndex = 7;
            this.attachmentLink.TabStop = false;
            // 
            // GuardFileBrowseUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "GuardFileBrowseUC";
            this.Size = new System.Drawing.Size(840, 108);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attachmentLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox dakUploadAttachmentNameTextBox;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton attachmentDeleteButton;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox attachmentLink;
    }
}
