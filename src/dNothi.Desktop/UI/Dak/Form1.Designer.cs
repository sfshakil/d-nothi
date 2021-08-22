namespace dNothi.Desktop.UI.Dak
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.choosePicButton = new FontAwesome.Sharp.IconButton();
            this.officerEditablePictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerEditablePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(35, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 27);
            this.label8.TabIndex = 62;
            this.label8.Text = "বিস্তারিত খুঁজুন";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel34, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.choosePicButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.officerEditablePictureBox, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1028, 295);
            this.tableLayoutPanel2.TabIndex = 63;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel2.SetColumnSpan(this.panel34, 3);
            this.panel34.Controls.Add(this.iconButton3);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel34.Location = new System.Drawing.Point(0, 0);
            this.panel34.Margin = new System.Windows.Forms.Padding(0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(1028, 45);
            this.panel34.TabIndex = 0;
            // 
            // iconButton3
            // 
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.Black;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iconButton3.IconColor = System.Drawing.Color.Black;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 24;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 0);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(165, 45);
            this.iconButton3.TabIndex = 6;
            this.iconButton3.Text = " পাসওয়ার্ড পরিবর্তন";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = true;
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
            this.choosePicButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.choosePicButton.Location = new System.Drawing.Point(220, 253);
            this.choosePicButton.Name = "choosePicButton";
            this.choosePicButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.choosePicButton.Size = new System.Drawing.Size(157, 39);
            this.choosePicButton.TabIndex = 37;
            this.choosePicButton.Text = " ছবি বাছাই করুন";
            this.choosePicButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.choosePicButton.UseVisualStyleBackColor = false;
            this.choosePicButton.Click += new System.EventHandler(this.choosePicButton_Click);
            // 
            // officerEditablePictureBox
            // 
            this.officerEditablePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.officerEditablePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("officerEditablePictureBox.Image")));
            this.officerEditablePictureBox.Location = new System.Drawing.Point(199, 48);
            this.officerEditablePictureBox.Name = "officerEditablePictureBox";
            this.officerEditablePictureBox.Size = new System.Drawing.Size(200, 195);
            this.officerEditablePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.officerEditablePictureBox.TabIndex = 38;
            this.officerEditablePictureBox.TabStop = false;
            this.officerEditablePictureBox.Click += new System.EventHandler(this.officerEditablePictureBox_Click);
            this.officerEditablePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.officerEditablePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.officerEditablePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label8);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officerEditablePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton choosePicButton;
        private System.Windows.Forms.Panel panel34;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.PictureBox officerEditablePictureBox;
    }
}