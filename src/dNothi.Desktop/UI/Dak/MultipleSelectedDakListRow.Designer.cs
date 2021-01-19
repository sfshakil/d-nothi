namespace dNothi.Desktop.UI.Dak
{
    partial class MultipleSelectedDakListRow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.subjectLinkLabel = new System.Windows.Forms.LinkLabel();
            this.hideButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.prerokLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.subjectLinkLabel);
            this.panel1.Controls.Add(this.hideButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 30);
            this.panel1.TabIndex = 0;
            // 
            // subjectLinkLabel
            // 
            this.subjectLinkLabel.AutoSize = true;
            this.subjectLinkLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.subjectLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.subjectLinkLabel.Location = new System.Drawing.Point(46, 9);
            this.subjectLinkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.subjectLinkLabel.MaximumSize = new System.Drawing.Size(720, 0);
            this.subjectLinkLabel.MinimumSize = new System.Drawing.Size(720, 0);
            this.subjectLinkLabel.Name = "subjectLinkLabel";
            this.subjectLinkLabel.Size = new System.Drawing.Size(720, 18);
            this.subjectLinkLabel.TabIndex = 86;
            this.subjectLinkLabel.TabStop = true;
            this.subjectLinkLabel.Text = "দুর্নীতি দমন কমিশনের নিয়োগ এর জন্য অনলাইনে আবেদন।";
            // 
            // hideButton
            // 
            this.hideButton.BackColor = System.Drawing.Color.Transparent;
            this.hideButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.hideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.hideButton.IconColor = System.Drawing.Color.Red;
            this.hideButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.hideButton.IconSize = 24;
            this.hideButton.Location = new System.Drawing.Point(19, 6);
            this.hideButton.Margin = new System.Windows.Forms.Padding(0);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(25, 24);
            this.hideButton.TabIndex = 85;
            this.hideButton.UseVisualStyleBackColor = false;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(92)))), ((int)(((byte)(107)))));
            this.label1.Location = new System.Drawing.Point(16, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "প্রেরক:";
            // 
            // prerokLabel
            // 
            this.prerokLabel.AutoSize = true;
            this.prerokLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prerokLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(92)))), ((int)(((byte)(107)))));
            this.prerokLabel.Location = new System.Drawing.Point(55, 2);
            this.prerokLabel.Name = "prerokLabel";
            this.prerokLabel.Size = new System.Drawing.Size(78, 18);
            this.prerokLabel.TabIndex = 2;
            this.prerokLabel.Text = "বোরহান উদ্দিন";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.dateLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.prerokLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 20);
            this.panel2.TabIndex = 88;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(92)))), ((int)(((byte)(107)))));
            this.dateLabel.Location = new System.Drawing.Point(702, 3);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(97, 14);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "১৭/১/২১ ১২:৫০ PM";
            // 
            // MultipleSelectedDakListRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(802, 0);
            this.MinimumSize = new System.Drawing.Size(802, 50);
            this.Name = "MultipleSelectedDakListRow";
            this.Size = new System.Drawing.Size(802, 54);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton hideButton;
        private System.Windows.Forms.LinkLabel subjectLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label prerokLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
