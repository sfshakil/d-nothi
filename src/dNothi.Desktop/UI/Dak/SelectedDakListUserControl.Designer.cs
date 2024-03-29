﻿namespace dNothi.Desktop.UI.Dak
{
    partial class SelectedDakListUserControl
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
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
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
            this.panel1.Controls.Add(this.selectCheckBox);
            this.panel1.Controls.Add(this.subjectLinkLabel);
            this.panel1.Controls.Add(this.hideButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 33);
            this.panel1.TabIndex = 0;
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.AutoSize = true;
            this.selectCheckBox.Checked = true;
            this.selectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.selectCheckBox.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.selectCheckBox.Location = new System.Drawing.Point(484, 10);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Size = new System.Drawing.Size(15, 14);
            this.selectCheckBox.TabIndex = 87;
            this.selectCheckBox.UseVisualStyleBackColor = true;
            this.selectCheckBox.CheckedChanged += new System.EventHandler(this.selectCheckBox_CheckedChanged);
            // 
            // subjectLinkLabel
            // 
            this.subjectLinkLabel.AutoSize = true;
            this.subjectLinkLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.subjectLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.subjectLinkLabel.Location = new System.Drawing.Point(50, 7);
            this.subjectLinkLabel.MaximumSize = new System.Drawing.Size(420, 0);
            this.subjectLinkLabel.MinimumSize = new System.Drawing.Size(420, 0);
            this.subjectLinkLabel.Name = "subjectLinkLabel";
            this.subjectLinkLabel.Size = new System.Drawing.Size(420, 18);
            this.subjectLinkLabel.TabIndex = 86;
            this.subjectLinkLabel.TabStop = true;
            this.subjectLinkLabel.Text = "দুর্নীতি দমন কমিশনের নিয়োগ এর জন্য অনলাইনে আবেদন।";
            // 
            // hideButton
            // 
            this.hideButton.BackColor = System.Drawing.Color.Transparent;
            this.hideButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.hideButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
            this.hideButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.hideButton.IconSize = 24;
            this.hideButton.Location = new System.Drawing.Point(19, 5);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(25, 25);
            this.hideButton.TabIndex = 85;
            this.hideButton.UseVisualStyleBackColor = false;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(92)))), ((int)(((byte)(107)))));
            this.label1.Location = new System.Drawing.Point(16, 3);
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
            this.prerokLabel.Location = new System.Drawing.Point(55, 3);
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
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 21);
            this.panel2.TabIndex = 88;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(101)))), ((int)(((byte)(116)))));
            this.dateLabel.Location = new System.Drawing.Point(408, 3);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(97, 14);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "১৭/১/২১ ১২:৫০ PM";
            // 
            // SelectedDakListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(520, 0);
            this.MinimumSize = new System.Drawing.Size(515, 50);
            this.Name = "SelectedDakListUserControl";
            this.Size = new System.Drawing.Size(520, 54);
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
        private System.Windows.Forms.CheckBox selectCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label prerokLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
