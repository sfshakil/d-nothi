
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGaurdFileAdd = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbname_bng = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.lbguard_file_category_name_bng = new System.Windows.Forms.Label();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel19.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnGaurdFileAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel19, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 46);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnGaurdFileAdd
            // 
            this.btnGaurdFileAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnGaurdFileAdd.Location = new System.Drawing.Point(30, 4);
            this.btnGaurdFileAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnGaurdFileAdd.Name = "btnGaurdFileAdd";
            this.btnGaurdFileAdd.Size = new System.Drawing.Size(32, 38);
            this.btnGaurdFileAdd.TabIndex = 72;
            this.btnGaurdFileAdd.UseVisualStyleBackColor = false;
            this.btnGaurdFileAdd.Click += new System.EventHandler(this.btnGaurdFileAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbname_bng);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(92, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 46);
            this.panel1.TabIndex = 97;
            // 
            // lbname_bng
            // 
            this.lbname_bng.AutoSize = true;
            this.lbname_bng.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbname_bng.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbname_bng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbname_bng.Location = new System.Drawing.Point(0, 0);
            this.lbname_bng.Margin = new System.Windows.Forms.Padding(0);
            this.lbname_bng.Name = "lbname_bng";
            this.lbname_bng.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbname_bng.Size = new System.Drawing.Size(34, 16);
            this.lbname_bng.TabIndex = 2;
            this.lbname_bng.Text = "নাম";
            this.lbname_bng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.lbguard_file_category_name_bng);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(460, 0);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(460, 46);
            this.panel19.TabIndex = 96;
            // 
            // lbguard_file_category_name_bng
            // 
            this.lbguard_file_category_name_bng.AutoSize = true;
            this.lbguard_file_category_name_bng.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbguard_file_category_name_bng.Font = new System.Drawing.Font("SolaimanLipi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbguard_file_category_name_bng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbguard_file_category_name_bng.Location = new System.Drawing.Point(0, 0);
            this.lbguard_file_category_name_bng.Margin = new System.Windows.Forms.Padding(0);
            this.lbguard_file_category_name_bng.Name = "lbguard_file_category_name_bng";
            this.lbguard_file_category_name_bng.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbguard_file_category_name_bng.Size = new System.Drawing.Size(36, 16);
            this.lbguard_file_category_name_bng.TabIndex = 1;
            this.lbguard_file_category_name_bng.Text = "ধরন";
            this.lbguard_file_category_name_bng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GaurdFilePortalListRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GaurdFilePortalListRow";
            this.Size = new System.Drawing.Size(920, 49);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.Label lbguard_file_category_name_bng;
        private System.Windows.Forms.Label lbname_bng;
        private FontAwesome.Sharp.IconButton btnGaurdFileAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel19;
    }
}
