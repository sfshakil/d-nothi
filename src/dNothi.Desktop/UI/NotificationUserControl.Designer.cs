
namespace dNothi.Desktop.UI
{
    partial class NotificationUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCross = new FontAwesome.Sharp.IconButton();
            this.lbLabelText = new System.Windows.Forms.Label();
            this.decisionViewBodyPanel = new System.Windows.Forms.Panel();
            this.notificationViewFLP = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.decisionViewBodyPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 31);
            this.panel2.TabIndex = 79;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnCross);
            this.panel1.Controls.Add(this.lbLabelText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 91);
            this.panel1.TabIndex = 78;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 90);
            this.panel5.TabIndex = 65;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 90);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(960, 1);
            this.panel6.TabIndex = 64;
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.btnCross.FlatAppearance.BorderSize = 0;
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCross.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCross.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.btnCross.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCross.IconSize = 24;
            this.btnCross.Location = new System.Drawing.Point(901, 18);
            this.btnCross.Margin = new System.Windows.Forms.Padding(0);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(45, 43);
            this.btnCross.TabIndex = 63;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // lbLabelText
            // 
            this.lbLabelText.AutoSize = true;
            this.lbLabelText.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbLabelText.Location = new System.Drawing.Point(13, 31);
            this.lbLabelText.Margin = new System.Windows.Forms.Padding(0);
            this.lbLabelText.Name = "lbLabelText";
            this.lbLabelText.Size = new System.Drawing.Size(152, 30);
            this.lbLabelText.TabIndex = 0;
            this.lbLabelText.Text = "নোটিফিকেশন   ";
            // 
            // decisionViewBodyPanel
            // 
            this.decisionViewBodyPanel.AutoScroll = true;
            this.decisionViewBodyPanel.Controls.Add(this.notificationViewFLP);
            this.decisionViewBodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decisionViewBodyPanel.Location = new System.Drawing.Point(0, 122);
            this.decisionViewBodyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.decisionViewBodyPanel.Name = "decisionViewBodyPanel";
            this.decisionViewBodyPanel.Size = new System.Drawing.Size(960, 728);
            this.decisionViewBodyPanel.TabIndex = 81;
            // 
            // notificationViewFLP
            // 
            this.notificationViewFLP.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.notificationViewFLP.AutoSize = true;
            this.notificationViewFLP.ColumnCount = 1;
            this.notificationViewFLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.notificationViewFLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.notificationViewFLP.Dock = System.Windows.Forms.DockStyle.Top;
            this.notificationViewFLP.Location = new System.Drawing.Point(0, 0);
            this.notificationViewFLP.Margin = new System.Windows.Forms.Padding(0);
            this.notificationViewFLP.Name = "notificationViewFLP";
            this.notificationViewFLP.RowCount = 1;
            this.notificationViewFLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.notificationViewFLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.notificationViewFLP.Size = new System.Drawing.Size(960, 0);
            this.notificationViewFLP.TabIndex = 55;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 850);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 42);
            this.panel3.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(420, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 66;
            this.label1.Text = "Clear All";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 1);
            this.panel4.TabIndex = 65;
            // 
            // NotificationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.decisionViewBodyPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NotificationUserControl";
            this.Size = new System.Drawing.Size(960, 892);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.decisionViewBodyPanel.ResumeLayout(false);
            this.decisionViewBodyPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private FontAwesome.Sharp.IconButton btnCross;
        private System.Windows.Forms.Label lbLabelText;
        private System.Windows.Forms.Panel decisionViewBodyPanel;
        private System.Windows.Forms.TableLayoutPanel notificationViewFLP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
    }
}
