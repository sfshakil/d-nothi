namespace dNothi.Desktop.UI.OtherModule.GuardFileUserControls
{
    partial class UCGuardFileTypes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCGuardFileTypes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guardFileTypeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.guardFileTypeTableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 43);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(748, 38);
            this.tableLayoutPanel1.TabIndex = 87;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.Table_Cell_Color_Blue);
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Table_Border_Color);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(629, 1);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label11.Size = new System.Drawing.Size(115, 36);
            this.label11.TabIndex = 3;
            this.label11.Text = "কার্যক্রম";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(520, 1);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label10.Size = new System.Drawing.Size(102, 36);
            this.label10.TabIndex = 2;
            this.label10.Text = "ধরন সংখ্যা";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 1);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label8.Size = new System.Drawing.Size(80, 36);
            this.label8.TabIndex = 0;
            this.label8.Text = "ক্রমিক নং";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(91, 1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label9.Size = new System.Drawing.Size(422, 36);
            this.label9.TabIndex = 1;
            this.label9.Text = "ধরন";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guardFileTypeTableLayoutPanel
            // 
            this.guardFileTypeTableLayoutPanel.AutoSize = true;
            this.guardFileTypeTableLayoutPanel.ColumnCount = 1;
            this.guardFileTypeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.guardFileTypeTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.guardFileTypeTableLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this.guardFileTypeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guardFileTypeTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.guardFileTypeTableLayoutPanel.Name = "guardFileTypeTableLayoutPanel";
            this.guardFileTypeTableLayoutPanel.RowCount = 3;
            this.guardFileTypeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.guardFileTypeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.guardFileTypeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.guardFileTypeTableLayoutPanel.Size = new System.Drawing.Size(756, 82);
            this.guardFileTypeTableLayoutPanel.TabIndex = 88;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Controls.Add(this.iconButton4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 39);
            this.panel1.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(614, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 39);
            this.label6.TabIndex = 33;
            this.label6.Text = " সর্বমোট: ১২";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            this.iconButton3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 24;
            this.iconButton3.Location = new System.Drawing.Point(688, 0);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(34, 39);
            this.iconButton3.TabIndex = 34;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.ChevronRight;
            this.iconButton4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 24;
            this.iconButton4.Location = new System.Drawing.Point(722, 0);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(34, 39);
            this.iconButton4.TabIndex = 35;
            this.iconButton4.UseVisualStyleBackColor = false;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewImageColumn1.HeaderText = "+";
            this.dataGridViewImageColumn1.Image = global::dNothi.Desktop.Properties.Resources.delete;
            this.dataGridViewImageColumn1.MinimumWidth = 2;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 37;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewImageColumn2.HeaderText = "+";
            this.dataGridViewImageColumn2.Image = global::dNothi.Desktop.Properties.Resources.delete;
            this.dataGridViewImageColumn2.MinimumWidth = 2;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 39;
            // 
            // UCGuardFileTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.guardFileTypeTableLayoutPanel);
            this.Name = "UCGuardFileTypes";
            this.Size = new System.Drawing.Size(756, 82);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.guardFileTypeTableLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel guardFileTypeTableLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
    }
}
