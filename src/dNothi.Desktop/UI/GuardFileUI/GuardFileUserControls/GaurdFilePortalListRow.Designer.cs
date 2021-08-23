
namespace dNothi.Desktop.UI.Dak
{
    partial class GaurdFilePortalListRow
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
            this.btnGaurdFileAdd = new FontAwesome.Sharp.IconButton();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbname_bng = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbguard_file_category_name_bng = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGaurdFileAdd
            // 
            this.btnGaurdFileAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnGaurdFileAdd.Location = new System.Drawing.Point(24, 1);
            this.btnGaurdFileAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnGaurdFileAdd.Name = "btnGaurdFileAdd";
            this.btnGaurdFileAdd.Size = new System.Drawing.Size(32, 40);
            this.btnGaurdFileAdd.TabIndex = 72;
            this.btnGaurdFileAdd.UseVisualStyleBackColor = false;
            this.btnGaurdFileAdd.Click += new System.EventHandler(this.btnGaurdFileAdd_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.lbname_bng, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lbguard_file_category_name_bng, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(920, 49);
            this.tableLayoutPanel.TabIndex = 2;
            this.tableLayoutPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_CellPaint);
            // 
            // lbname_bng
            // 
            this.lbname_bng.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbname_bng.AutoSize = true;
            this.lbname_bng.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbname_bng.Location = new System.Drawing.Point(99, 14);
            this.lbname_bng.Name = "lbname_bng";
            this.lbname_bng.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbname_bng.Size = new System.Drawing.Size(34, 18);
            this.lbname_bng.TabIndex = 88;
            this.lbname_bng.Text = "ধরন";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnGaurdFileAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(9, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(84, 41);
            this.panel2.TabIndex = 86;
            // 
            // lbguard_file_category_name_bng
            // 
            this.lbguard_file_category_name_bng.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbguard_file_category_name_bng.AutoSize = true;
            this.lbguard_file_category_name_bng.Location = new System.Drawing.Point(462, 17);
            this.lbguard_file_category_name_bng.Margin = new System.Windows.Forms.Padding(3);
            this.lbguard_file_category_name_bng.Name = "lbguard_file_category_name_bng";
            this.lbguard_file_category_name_bng.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbguard_file_category_name_bng.Size = new System.Drawing.Size(36, 13);
            this.lbguard_file_category_name_bng.TabIndex = 87;
            this.lbguard_file_category_name_bng.Text = "নাম";
            this.lbguard_file_category_name_bng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GaurdFilePortalListRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GaurdFilePortalListRow";
            this.Size = new System.Drawing.Size(920, 49);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip MyToolTip;
        private FontAwesome.Sharp.IconButton btnGaurdFileAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lbname_bng;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbguard_file_category_name_bng;
    }
}
