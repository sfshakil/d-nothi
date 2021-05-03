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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCGuardFileTypes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guardFileTypeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.perPageRowLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.PreviousIconButton = new FontAwesome.Sharp.IconButton();
            this.nextIconButton = new FontAwesome.Sharp.IconButton();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.label11.Location = new System.Drawing.Point(630, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label11.Size = new System.Drawing.Size(115, 38);
            this.label11.TabIndex = 3;
            this.label11.Text = "কার্যক্রম";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(522, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label10.Size = new System.Drawing.Size(102, 38);
            this.label10.TabIndex = 2;
            this.label10.Text = "ধরন সংখ্যা";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label8.Size = new System.Drawing.Size(80, 38);
            this.label8.TabIndex = 0;
            this.label8.Text = "ক্রমিক নং";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(89, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label9.Size = new System.Drawing.Size(427, 38);
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
            this.guardFileTypeTableLayoutPanel.Size = new System.Drawing.Size(756, 85);
            this.guardFileTypeTableLayoutPanel.TabIndex = 88;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.perPageRowLabel);
            this.panel1.Controls.Add(this.totalLabel);
            this.panel1.Controls.Add(this.PreviousIconButton);
            this.panel1.Controls.Add(this.nextIconButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 39);
            this.panel1.TabIndex = 88;
            // 
            // perPageRowLabel
            // 
            this.perPageRowLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.perPageRowLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perPageRowLabel.Location = new System.Drawing.Point(571, 0);
            this.perPageRowLabel.Name = "perPageRowLabel";
            this.perPageRowLabel.Size = new System.Drawing.Size(43, 39);
            this.perPageRowLabel.TabIndex = 36;
            this.perPageRowLabel.Text = "১ - ১০";
            this.perPageRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalLabel
            // 
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.totalLabel.Location = new System.Drawing.Point(614, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(74, 39);
            this.totalLabel.TabIndex = 33;
            this.totalLabel.Text = " সর্বমোট: ১২";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviousIconButton
            // 
            this.PreviousIconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.PreviousIconButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PreviousIconButton.FlatAppearance.BorderSize = 0;
            this.PreviousIconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.PreviousIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousIconButton.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            this.PreviousIconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.PreviousIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PreviousIconButton.IconSize = 24;
            this.PreviousIconButton.Location = new System.Drawing.Point(688, 0);
            this.PreviousIconButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.PreviousIconButton.Name = "PreviousIconButton";
            this.PreviousIconButton.Size = new System.Drawing.Size(34, 39);
            this.PreviousIconButton.TabIndex = 34;
            this.PreviousIconButton.UseVisualStyleBackColor = false;
            this.PreviousIconButton.Click += new System.EventHandler(this.PreviousIconButton_Click);
            // 
            // nextIconButton
            // 
            this.nextIconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.nextIconButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.nextIconButton.FlatAppearance.BorderSize = 0;
            this.nextIconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.nextIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextIconButton.IconChar = FontAwesome.Sharp.IconChar.ChevronRight;
            this.nextIconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.nextIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.nextIconButton.IconSize = 24;
            this.nextIconButton.Location = new System.Drawing.Point(722, 0);
            this.nextIconButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.nextIconButton.Name = "nextIconButton";
            this.nextIconButton.Size = new System.Drawing.Size(34, 39);
            this.nextIconButton.TabIndex = 35;
            this.nextIconButton.UseVisualStyleBackColor = false;
            this.nextIconButton.Click += new System.EventHandler(this.nextIconButton_Click);
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle9.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewImageColumn1.HeaderText = "+";
            this.dataGridViewImageColumn1.Image = global::dNothi.Desktop.Properties.Resources.delete;
            this.dataGridViewImageColumn1.MinimumWidth = 2;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 37;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle10.NullValue")));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle10;
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
            this.Size = new System.Drawing.Size(756, 85);
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
        private System.Windows.Forms.Label totalLabel;
        private FontAwesome.Sharp.IconButton PreviousIconButton;
        private FontAwesome.Sharp.IconButton nextIconButton;
        private System.Windows.Forms.Label perPageRowLabel;
    }
}
