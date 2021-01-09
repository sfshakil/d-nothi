namespace dNothi.Desktop.UI.Dak
{
    partial class DakNothiteUposthapitoNewNoteAddUserControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.newNoteTextBox = new PlaceholderTextBox.PlaceholderTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.saveNewNoteButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 40);
            this.panel2.TabIndex = 3;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.closeButton.IconColor = System.Drawing.Color.DimGray;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closeButton.IconSize = 20;
            this.closeButton.Location = new System.Drawing.Point(796, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 26);
            this.closeButton.TabIndex = 40;
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "নোট এর বিষয়";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(0, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(825, 1);
            this.label11.TabIndex = 41;
            // 
            // newNoteTextBox
            // 
            this.newNoteTextBox.BackColor = System.Drawing.Color.White;
            this.newNoteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newNoteTextBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newNoteTextBox.Location = new System.Drawing.Point(10, 11);
            this.newNoteTextBox.Multiline = true;
            this.newNoteTextBox.Name = "newNoteTextBox";
            this.newNoteTextBox.PlaceholderText = "নতুন নোট এর বিষয়";
            this.newNoteTextBox.Size = new System.Drawing.Size(644, 20);
            this.newNoteTextBox.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.newNoteTextBox);
            this.panel4.Location = new System.Drawing.Point(13, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(678, 41);
            this.panel4.TabIndex = 77;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSize = true;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.Location = new System.Drawing.Point(690, 144);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(124, 38);
            this.iconButton1.TabIndex = 79;
            this.iconButton1.Text = "বন্ধ করুন";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveNewNoteButton
            // 
            this.saveNewNoteButton.AutoSize = true;
            this.saveNewNoteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.saveNewNoteButton.FlatAppearance.BorderSize = 0;
            this.saveNewNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNewNoteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveNewNoteButton.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            this.saveNewNoteButton.IconColor = System.Drawing.Color.White;
            this.saveNewNoteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveNewNoteButton.IconSize = 32;
            this.saveNewNoteButton.Location = new System.Drawing.Point(690, 46);
            this.saveNewNoteButton.Name = "saveNewNoteButton";
            this.saveNewNoteButton.Size = new System.Drawing.Size(124, 42);
            this.saveNewNoteButton.TabIndex = 78;
            this.saveNewNoteButton.Text = "সংরক্ষণ করুন";
            this.saveNewNoteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveNewNoteButton.UseVisualStyleBackColor = false;
            this.saveNewNoteButton.Click += new System.EventHandler(this.saveNewNoteButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.saveNewNoteButton);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 186);
            this.panel1.TabIndex = 80;
            // 
            // DakNothiteUposthapitoNewNoteAddUserControl
            // 
            this.AcceptButton = this.saveNewNoteButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(827, 186);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DakNothiteUposthapitoNewNoteAddUserControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private PlaceholderTextBox.PlaceholderTextBox newNoteTextBox;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton saveNewNoteButton;
        private System.Windows.Forms.Panel panel1;
    }
}
