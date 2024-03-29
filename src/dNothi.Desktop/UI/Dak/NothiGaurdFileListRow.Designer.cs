﻿
namespace dNothi.Desktop.UI.Dak
{
    partial class NothiGaurdFileListRow
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
            this.panel11 = new System.Windows.Forms.Panel();
            this.lbname_bng = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnShow = new FontAwesome.Sharp.IconButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnGaurdFileAdd = new FontAwesome.Sharp.IconButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbguard_file_category_name_bng = new System.Windows.Forms.Label();
            this.countPanel = new System.Windows.Forms.Panel();
            this.countLabel = new System.Windows.Forms.Label();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.countPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.panel11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.countPanel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 63);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lbname_bng);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(414, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.panel11.Size = new System.Drawing.Size(368, 41);
            this.panel11.TabIndex = 83;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // lbname_bng
            // 
            this.lbname_bng.AutoSize = true;
            this.lbname_bng.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbname_bng.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbname_bng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbname_bng.Location = new System.Drawing.Point(3, 6);
            this.lbname_bng.Margin = new System.Windows.Forms.Padding(0);
            this.lbname_bng.Name = "lbname_bng";
            this.lbname_bng.Size = new System.Drawing.Size(24, 16);
            this.lbname_bng.TabIndex = 2;
            this.lbname_bng.Text = "নাম";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnDelete);
            this.panel10.Controls.Add(this.btnShow);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(782, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(138, 41);
            this.panel10.TabIndex = 82;
            this.panel10.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelete.IconColor = System.Drawing.Color.White;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 26;
            this.btnDelete.Location = new System.Drawing.Point(45, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 37);
            this.btnDelete.TabIndex = 74;
            this.MyToolTip.SetToolTip(this.btnDelete, "মুছে ফেলুন");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShow.IconColor = System.Drawing.Color.White;
            this.btnShow.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShow.IconSize = 26;
            this.btnShow.Location = new System.Drawing.Point(8, 3);
            this.btnShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(32, 35);
            this.btnShow.TabIndex = 73;
            this.MyToolTip.SetToolTip(this.btnShow, "দেখুন");
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnGaurdFileAdd);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(15, 4, 8, 4);
            this.panel9.Size = new System.Drawing.Size(138, 41);
            this.panel9.TabIndex = 81;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // btnGaurdFileAdd
            // 
            this.btnGaurdFileAdd.AutoSize = true;
            this.btnGaurdFileAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnGaurdFileAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGaurdFileAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGaurdFileAdd.FlatAppearance.BorderSize = 0;
            this.btnGaurdFileAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnGaurdFileAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnGaurdFileAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaurdFileAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaurdFileAdd.ForeColor = System.Drawing.Color.White;
            this.btnGaurdFileAdd.IconChar = FontAwesome.Sharp.IconChar.FileMedical;
            this.btnGaurdFileAdd.IconColor = System.Drawing.Color.White;
            this.btnGaurdFileAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGaurdFileAdd.IconSize = 26;
            this.btnGaurdFileAdd.Location = new System.Drawing.Point(47, 4);
            this.btnGaurdFileAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnGaurdFileAdd.Name = "btnGaurdFileAdd";
            this.btnGaurdFileAdd.Size = new System.Drawing.Size(32, 33);
            this.btnGaurdFileAdd.TabIndex = 72;
            this.MyToolTip.SetToolTip(this.btnGaurdFileAdd, "অনুচ্ছেদে সংযুক্ত করুন");
            this.btnGaurdFileAdd.UseVisualStyleBackColor = false;
            this.btnGaurdFileAdd.Click += new System.EventHandler(this.btnGaurdFileAdd_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lbguard_file_category_name_bng);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(138, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.panel8.Size = new System.Drawing.Size(276, 41);
            this.panel8.TabIndex = 80;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // lbguard_file_category_name_bng
            // 
            this.lbguard_file_category_name_bng.AutoSize = true;
            this.lbguard_file_category_name_bng.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbguard_file_category_name_bng.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbguard_file_category_name_bng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbguard_file_category_name_bng.Location = new System.Drawing.Point(3, 6);
            this.lbguard_file_category_name_bng.Margin = new System.Windows.Forms.Padding(0);
            this.lbguard_file_category_name_bng.Name = "lbguard_file_category_name_bng";
            this.lbguard_file_category_name_bng.Size = new System.Drawing.Size(26, 16);
            this.lbguard_file_category_name_bng.TabIndex = 1;
            this.lbguard_file_category_name_bng.Text = "ধরন";
            // 
            // countPanel
            // 
            this.countPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.countPanel, 2);
            this.countPanel.Controls.Add(this.countLabel);
            this.countPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.countPanel.Location = new System.Drawing.Point(138, 41);
            this.countPanel.Margin = new System.Windows.Forms.Padding(0);
            this.countPanel.Name = "countPanel";
            this.countPanel.Padding = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.countPanel.Size = new System.Drawing.Size(644, 22);
            this.countPanel.TabIndex = 84;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countLabel.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.countLabel.Location = new System.Drawing.Point(3, 6);
            this.countLabel.Margin = new System.Windows.Forms.Padding(0);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(199, 16);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "গার্ড ফাইলটি মোট যুক্ত করা হয়েছে (১) বার";
            // 
            // NothiGaurdFileListRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NothiGaurdFileListRow";
            this.Size = new System.Drawing.Size(920, 66);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.countPanel.ResumeLayout(false);
            this.countPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lbname_bng;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbguard_file_category_name_bng;
        private FontAwesome.Sharp.IconButton btnGaurdFileAdd;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.ToolTip MyToolTip;
        private FontAwesome.Sharp.IconButton btnShow;
        private System.Windows.Forms.Panel countPanel;
        private System.Windows.Forms.Label countLabel;
    }
}
