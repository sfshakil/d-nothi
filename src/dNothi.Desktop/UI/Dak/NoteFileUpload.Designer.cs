namespace dNothi.Desktop.UI.Dak
{
    partial class NoteFileUpload
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.attachmentNameTextBox = new System.Windows.Forms.TextBox();
            this.lbByte = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.attachmentPicturebox = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentPicturebox)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 87);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelete.IconColor = System.Drawing.Color.White;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 24;
            this.btnDelete.Location = new System.Drawing.Point(795, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(42, 47);
            this.btnDelete.TabIndex = 63;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.attachmentNameTextBox);
            this.panel10.Controls.Add(this.lbByte);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(257, 1);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(503, 85);
            this.panel10.TabIndex = 62;
            // 
            // attachmentNameTextBox
            // 
            this.attachmentNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.attachmentNameTextBox.Location = new System.Drawing.Point(26, 14);
            this.attachmentNameTextBox.Multiline = true;
            this.attachmentNameTextBox.Name = "attachmentNameTextBox";
            this.attachmentNameTextBox.Size = new System.Drawing.Size(441, 36);
            this.attachmentNameTextBox.TabIndex = 0;
            // 
            // lbByte
            // 
            this.lbByte.AutoSize = true;
            this.lbByte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbByte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbByte.Location = new System.Drawing.Point(29, 56);
            this.lbByte.Name = "lbByte";
            this.lbByte.Size = new System.Drawing.Size(68, 16);
            this.lbByte.TabIndex = 71;
            this.lbByte.Text = "byteLabel";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(502, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1, 85);
            this.panel11.TabIndex = 59;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.attachmentPicturebox);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(55, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(202, 85);
            this.panel8.TabIndex = 61;
            // 
            // attachmentPicturebox
            // 
            this.attachmentPicturebox.Location = new System.Drawing.Point(44, 14);
            this.attachmentPicturebox.Name = "attachmentPicturebox";
            this.attachmentPicturebox.Size = new System.Drawing.Size(100, 50);
            this.attachmentPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.attachmentPicturebox.TabIndex = 60;
            this.attachmentPicturebox.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(201, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1, 85);
            this.panel9.TabIndex = 59;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(54, 85);
            this.panel6.TabIndex = 60;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(53, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1, 85);
            this.panel7.TabIndex = 59;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(867, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 85);
            this.panel5.TabIndex = 59;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 85);
            this.panel4.TabIndex = 58;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 1);
            this.panel2.TabIndex = 57;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(868, 1);
            this.panel3.TabIndex = 56;
            // 
            // NoteFileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "NoteFileUpload";
            this.Size = new System.Drawing.Size(868, 87);
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attachmentPicturebox)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbByte;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.PictureBox attachmentPicturebox;
        private System.Windows.Forms.TextBox attachmentNameTextBox;
    }
}
