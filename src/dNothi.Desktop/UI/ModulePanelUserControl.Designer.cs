namespace dNothi.Desktop.UI
{
    partial class ModulePanelUserControl
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
            this.modulePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.potrojariButton = new FontAwesome.Sharp.IconButton();
            this.guardFileModuleButton = new FontAwesome.Sharp.IconButton();
            this.reviewDashBoardButton = new FontAwesome.Sharp.IconButton();
            this.khosraButton = new FontAwesome.Sharp.IconButton();
            this.khosraPotroButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.modulePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modulePanel
            // 
            this.modulePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.modulePanel.Controls.Add(this.tableLayoutPanel1);
            this.modulePanel.Controls.Add(this.panel1);
            this.modulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulePanel.Location = new System.Drawing.Point(0, 0);
            this.modulePanel.Name = "modulePanel";
            this.modulePanel.Size = new System.Drawing.Size(334, 364);
            this.modulePanel.TabIndex = 107;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.potrojariButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.guardFileModuleButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.reviewDashBoardButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.khosraButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.khosraPotroButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 91);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 273);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // potrojariButton
            // 
            this.potrojariButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.potrojariButton.FlatAppearance.BorderSize = 0;
            this.potrojariButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.potrojariButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potrojariButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.potrojariButton.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.potrojariButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.potrojariButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.potrojariButton.IconSize = 35;
            this.potrojariButton.Location = new System.Drawing.Point(4, 182);
            this.potrojariButton.Name = "potrojariButton";
            this.potrojariButton.Size = new System.Drawing.Size(159, 87);
            this.potrojariButton.TabIndex = 4;
            this.potrojariButton.Text = "পত্রজারি গ্রুপ";
            this.potrojariButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.potrojariButton.UseVisualStyleBackColor = true;
            this.potrojariButton.Click += new System.EventHandler(this.potrojariButton_Click);
            // 
            // guardFileModuleButton
            // 
            this.guardFileModuleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guardFileModuleButton.FlatAppearance.BorderSize = 0;
            this.guardFileModuleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardFileModuleButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardFileModuleButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.guardFileModuleButton.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt;
            this.guardFileModuleButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.guardFileModuleButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.guardFileModuleButton.IconSize = 32;
            this.guardFileModuleButton.Location = new System.Drawing.Point(170, 93);
            this.guardFileModuleButton.Name = "guardFileModuleButton";
            this.guardFileModuleButton.Size = new System.Drawing.Size(160, 82);
            this.guardFileModuleButton.TabIndex = 3;
            this.guardFileModuleButton.Text = "গার্ড ফাইল";
            this.guardFileModuleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.guardFileModuleButton.UseVisualStyleBackColor = true;
            this.guardFileModuleButton.Click += new System.EventHandler(this.guardFileModuleButton_Click);
            // 
            // reviewDashBoardButton
            // 
            this.reviewDashBoardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewDashBoardButton.Enabled = false;
            this.reviewDashBoardButton.FlatAppearance.BorderSize = 0;
            this.reviewDashBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewDashBoardButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewDashBoardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.reviewDashBoardButton.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.reviewDashBoardButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.reviewDashBoardButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reviewDashBoardButton.IconSize = 32;
            this.reviewDashBoardButton.Location = new System.Drawing.Point(4, 93);
            this.reviewDashBoardButton.Name = "reviewDashBoardButton";
            this.reviewDashBoardButton.Size = new System.Drawing.Size(159, 82);
            this.reviewDashBoardButton.TabIndex = 2;
            this.reviewDashBoardButton.Text = "রিভিউ ড্যাশবোর্ড";
            this.reviewDashBoardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.reviewDashBoardButton.UseVisualStyleBackColor = true;
            this.reviewDashBoardButton.Click += new System.EventHandler(this.reviewDashBoardButton_Click);
            // 
            // khosraButton
            // 
            this.khosraButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.khosraButton.FlatAppearance.BorderSize = 0;
            this.khosraButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.khosraButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khosraButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraButton.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.khosraButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.khosraButton.IconSize = 32;
            this.khosraButton.Location = new System.Drawing.Point(170, 4);
            this.khosraButton.Name = "khosraButton";
            this.khosraButton.Size = new System.Drawing.Size(160, 82);
            this.khosraButton.TabIndex = 1;
            this.khosraButton.Text = "খসড়া";
            this.khosraButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.khosraButton.UseVisualStyleBackColor = true;
            this.khosraButton.Click += new System.EventHandler(this.khosraButton_Click);
            // 
            // khosraPotroButton
            // 
            this.khosraPotroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.khosraPotroButton.FlatAppearance.BorderSize = 0;
            this.khosraPotroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.khosraPotroButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khosraPotroButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraPotroButton.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.khosraPotroButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraPotroButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.khosraPotroButton.IconSize = 32;
            this.khosraPotroButton.Location = new System.Drawing.Point(4, 4);
            this.khosraPotroButton.Name = "khosraPotroButton";
            this.khosraPotroButton.Size = new System.Drawing.Size(159, 82);
            this.khosraPotroButton.TabIndex = 0;
            this.khosraPotroButton.Text = "খসড়া-পত্র ড্যাশবোর্ড";
            this.khosraPotroButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.khosraPotroButton.UseVisualStyleBackColor = true;
            this.khosraPotroButton.Click += new System.EventHandler(this.khosraPotroButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::dNothi.Desktop.Properties.Resources.bg_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 91);
            this.panel1.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(117, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "অন্যান্য মডিউল";
            // 
            // ModulePanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.modulePanel);
            this.Name = "ModulePanelUserControl";
            this.Size = new System.Drawing.Size(334, 364);
            this.modulePanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel modulePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton potrojariButton;
        private FontAwesome.Sharp.IconButton guardFileModuleButton;
        private FontAwesome.Sharp.IconButton reviewDashBoardButton;
        private FontAwesome.Sharp.IconButton khosraButton;
        private FontAwesome.Sharp.IconButton khosraPotroButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
    }
}
