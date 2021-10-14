namespace dNothi.Desktop.UI.CustomMessageBox
{
    partial class UIFormValidationAlertMessageForm
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.checkIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.messageIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.checkIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageIconPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.messageLabel.AutoSize = true;
            this.messageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.messageLabel.Font = new System.Drawing.Font("SolaimanLipi", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.White;
            this.messageLabel.Location = new System.Drawing.Point(96, 39);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(267, 28);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "ন্যাশনাল আইডি শুধুমাত্র ১০, ১৩";
            this.messageLabel.Click += new System.EventHandler(this.messageLabel_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.closeButton.IconColor = System.Drawing.Color.White;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closeButton.IconSize = 20;
            this.closeButton.Location = new System.Drawing.Point(366, 40);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 26);
            this.closeButton.TabIndex = 39;
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // checkIconPictureBox
            // 
            this.checkIconPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.checkIconPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkIconPictureBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.checkIconPictureBox.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.checkIconPictureBox.IconSize = 42;
            this.checkIconPictureBox.Location = new System.Drawing.Point(3, 3);
            this.checkIconPictureBox.Name = "checkIconPictureBox";
            this.checkIconPictureBox.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.checkIconPictureBox.Size = new System.Drawing.Size(42, 100);
            this.checkIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.checkIconPictureBox.TabIndex = 42;
            this.checkIconPictureBox.TabStop = false;
            this.checkIconPictureBox.Visible = false;
            // 
            // messageIconPictureBox
            // 
            this.messageIconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.messageIconPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageIconPictureBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.messageIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.messageIconPictureBox.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.messageIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.messageIconPictureBox.IconSize = 42;
            this.messageIconPictureBox.Location = new System.Drawing.Point(51, 3);
            this.messageIconPictureBox.Name = "messageIconPictureBox";
            this.messageIconPictureBox.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.messageIconPictureBox.Size = new System.Drawing.Size(42, 100);
            this.messageIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.messageIconPictureBox.TabIndex = 0;
            this.messageIconPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.closeButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.messageIconPictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkIconPictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.messageLabel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 106);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(395, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 106);
            this.panel1.TabIndex = 3;
            // 
            // UIFormValidationAlertMessageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(1014, 106);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UIFormValidationAlertMessageForm";
            this.Text = "UIFormValidationAlertMessageForm";
            this.Load += new System.EventHandler(this.UIFormValidationAlertMessageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageIconPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label messageLabel;
        private FontAwesome.Sharp.IconButton closeButton;
        private FontAwesome.Sharp.IconPictureBox checkIconPictureBox;
        private FontAwesome.Sharp.IconPictureBox messageIconPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}