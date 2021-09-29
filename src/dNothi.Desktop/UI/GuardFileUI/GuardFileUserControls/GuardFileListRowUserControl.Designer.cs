namespace dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls
{
    partial class GuardFileListRowUserControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.typeNameLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.decisionDeleteButton = new FontAwesome.Sharp.IconButton();
            this.attachmentShowButton = new FontAwesome.Sharp.IconButton();
            this.typeLabel = new System.Windows.Forms.Label();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.typeNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.typeLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(892, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.Cell_Color_Blue);
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color);
            // 
            // typeNameLabel
            // 
            this.typeNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.typeNameLabel.AutoSize = true;
            this.typeNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeNameLabel.Location = new System.Drawing.Point(9, 14);
            this.typeNameLabel.Name = "typeNameLabel";
            this.typeNameLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.typeNameLabel.Size = new System.Drawing.Size(61, 18);
            this.typeNameLabel.TabIndex = 88;
            this.typeNameLabel.Text = "বাংলাদেশ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.decisionDeleteButton);
            this.panel2.Controls.Add(this.attachmentShowButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(713, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 41);
            this.panel2.TabIndex = 86;
            // 
            // decisionDeleteButton
            // 
            this.decisionDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.decisionDeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.decisionDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.decisionDeleteButton.FlatAppearance.BorderSize = 0;
            this.decisionDeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.decisionDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decisionDeleteButton.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.decisionDeleteButton.IconColor = System.Drawing.Color.White;
            this.decisionDeleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.decisionDeleteButton.IconSize = 20;
            this.decisionDeleteButton.Location = new System.Drawing.Point(34, 0);
            this.decisionDeleteButton.MaximumSize = new System.Drawing.Size(34, 36);
            this.decisionDeleteButton.MinimumSize = new System.Drawing.Size(34, 36);
            this.decisionDeleteButton.Name = "decisionDeleteButton";
            this.decisionDeleteButton.Size = new System.Drawing.Size(34, 36);
            this.decisionDeleteButton.TabIndex = 88;
            this.decisionDeleteButton.UseVisualStyleBackColor = false;
            this.decisionDeleteButton.Click += new System.EventHandler(this.guardFileTableUserControl_deleteButtonClick);
            // 
            // attachmentShowButton
            // 
            this.attachmentShowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.attachmentShowButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.attachmentShowButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.attachmentShowButton.FlatAppearance.BorderSize = 0;
            this.attachmentShowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.attachmentShowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachmentShowButton.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.attachmentShowButton.IconColor = System.Drawing.Color.White;
            this.attachmentShowButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.attachmentShowButton.IconSize = 24;
            this.attachmentShowButton.Location = new System.Drawing.Point(0, 0);
            this.attachmentShowButton.MaximumSize = new System.Drawing.Size(34, 36);
            this.attachmentShowButton.MinimumSize = new System.Drawing.Size(34, 36);
            this.attachmentShowButton.Name = "attachmentShowButton";
            this.attachmentShowButton.Size = new System.Drawing.Size(34, 36);
            this.attachmentShowButton.TabIndex = 87;
            this.attachmentShowButton.UseVisualStyleBackColor = false;
            this.attachmentShowButton.Click += new System.EventHandler(this.guardFileTableUserControl_viewButtonClick);
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(361, 17);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.typeLabel.Size = new System.Drawing.Size(72, 13);
            this.typeLabel.TabIndex = 87;
            this.typeLabel.Text = "ছুটির আইন";
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "অনলাইনে আপলোড  হচ্ছে";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // GuardFileListRowUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GuardFileListRowUserControl";
            this.Size = new System.Drawing.Size(892, 47);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton decisionDeleteButton;
        private FontAwesome.Sharp.IconButton attachmentShowButton;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label typeNameLabel;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.Label label1;
    }
}
