namespace dNothi.Desktop.UI.Dak
{
    partial class CreateNewNotes
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.newNoteTextBox = new PlaceholderTextBox.PlaceholderTextBox();
            this.saveNewNoteButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1607, 49);
            this.panel2.TabIndex = 82;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1607, 1);
            this.flowLayoutPanel1.TabIndex = 42;
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
            this.closeButton.Location = new System.Drawing.Point(1543, 9);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(37, 32);
            this.closeButton.TabIndex = 40;
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MyToolTip.SetToolTip(this.closeButton, "বন্ধ করুন");
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "নোট এর বিষয়";
            // 
            // newNoteTextBox
            // 
            this.newNoteTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.newNoteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newNoteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newNoteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newNoteTextBox.Location = new System.Drawing.Point(20, 12);
            this.newNoteTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newNoteTextBox.Multiline = true;
            this.newNoteTextBox.Name = "newNoteTextBox";
            this.newNoteTextBox.PlaceholderText = "নতুন নোট এর বিষয়";
            this.newNoteTextBox.Size = new System.Drawing.Size(1400, 32);
            this.newNoteTextBox.TabIndex = 3;
            // 
            // saveNewNoteButton
            // 
            this.saveNewNoteButton.AutoSize = true;
            this.saveNewNoteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.saveNewNoteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.saveNewNoteButton.FlatAppearance.BorderSize = 0;
            this.saveNewNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNewNoteButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveNewNoteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveNewNoteButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.saveNewNoteButton.IconColor = System.Drawing.Color.White;
            this.saveNewNoteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveNewNoteButton.IconSize = 32;
            this.saveNewNoteButton.Location = new System.Drawing.Point(1447, 73);
            this.saveNewNoteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveNewNoteButton.Name = "saveNewNoteButton";
            this.saveNewNoteButton.Size = new System.Drawing.Size(133, 50);
            this.saveNewNoteButton.TabIndex = 85;
            this.saveNewNoteButton.Text = "সংরক্ষণ করুন";
            this.saveNewNoteButton.UseVisualStyleBackColor = false;
            this.saveNewNoteButton.Click += new System.EventHandler(this.saveNewNoteButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newNoteTextBox);
            this.panel1.Location = new System.Drawing.Point(20, 73);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 12, 7, 6);
            this.panel1.Size = new System.Drawing.Size(1427, 50);
            this.panel1.TabIndex = 86;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CreateNewNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(1607, 144);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saveNewNoteButton);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 300);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreateNewNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateNewNotes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton closeButton;
        private System.Windows.Forms.Label label1;
        private PlaceholderTextBox.PlaceholderTextBox newNoteTextBox;
        private FontAwesome.Sharp.IconButton saveNewNoteButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip MyToolTip;
    }
}