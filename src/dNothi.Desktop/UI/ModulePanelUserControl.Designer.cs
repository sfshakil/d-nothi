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
            this.dashboardButton = new FontAwesome.Sharp.IconButton();
            this.potrojariButton = new FontAwesome.Sharp.IconButton();
            this.guardFileModuleButton = new FontAwesome.Sharp.IconButton();
            this.reviewDashBoardButton = new FontAwesome.Sharp.IconButton();
            this.khosraButton = new FontAwesome.Sharp.IconButton();
            this.khosraPotroButton = new FontAwesome.Sharp.IconButton();
            this.emailButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.modulePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modulePanel
            // 
            this.modulePanel.AutoSize = true;
            this.modulePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.modulePanel.Controls.Add(this.tableLayoutPanel1);
            this.modulePanel.Controls.Add(this.panel1);
            this.modulePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.modulePanel.Location = new System.Drawing.Point(0, 0);
            this.modulePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modulePanel.Name = "modulePanel";
            this.modulePanel.Size = new System.Drawing.Size(623, 633);
            this.modulePanel.TabIndex = 107;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dashboardButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.potrojariButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.guardFileModuleButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.reviewDashBoardButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.khosraButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.khosraPotroButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.emailButton, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 114);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 519);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color_Gray);
            // 
            // dashboardButton
            // 
            this.dashboardButton.AutoSize = true;
            this.dashboardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dashboardButton.IconChar = FontAwesome.Sharp.IconChar.TachometerAlt;
            this.dashboardButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dashboardButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.dashboardButton.IconSize = 35;
            this.dashboardButton.Location = new System.Drawing.Point(316, 271);
            this.dashboardButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.dashboardButton.Size = new System.Drawing.Size(302, 117);
            this.dashboardButton.TabIndex = 5;
            this.dashboardButton.Text = "ড্যাশবোর্ড";
            this.dashboardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // potrojariButton
            // 
            this.potrojariButton.AutoSize = true;
            this.potrojariButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.potrojariButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.potrojariButton.FlatAppearance.BorderSize = 0;
            this.potrojariButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.potrojariButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potrojariButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.potrojariButton.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.potrojariButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.potrojariButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.potrojariButton.IconSize = 35;
            this.potrojariButton.Location = new System.Drawing.Point(5, 271);
            this.potrojariButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.potrojariButton.Name = "potrojariButton";
            this.potrojariButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.potrojariButton.Size = new System.Drawing.Size(302, 117);
            this.potrojariButton.TabIndex = 4;
            this.potrojariButton.Text = "পত্রজারি গ্রুপ";
            this.potrojariButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.potrojariButton.UseVisualStyleBackColor = true;
            this.potrojariButton.Click += new System.EventHandler(this.potrojariButton_Click);
            // 
            // guardFileModuleButton
            // 
            this.guardFileModuleButton.AutoSize = true;
            this.guardFileModuleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guardFileModuleButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.guardFileModuleButton.FlatAppearance.BorderSize = 0;
            this.guardFileModuleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardFileModuleButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardFileModuleButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.guardFileModuleButton.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt;
            this.guardFileModuleButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.guardFileModuleButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.guardFileModuleButton.IconSize = 32;
            this.guardFileModuleButton.Location = new System.Drawing.Point(316, 149);
            this.guardFileModuleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guardFileModuleButton.Name = "guardFileModuleButton";
            this.guardFileModuleButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.guardFileModuleButton.Size = new System.Drawing.Size(302, 113);
            this.guardFileModuleButton.TabIndex = 3;
            this.guardFileModuleButton.Text = "গার্ড ফাইল";
            this.guardFileModuleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.guardFileModuleButton.UseVisualStyleBackColor = true;
            this.guardFileModuleButton.Click += new System.EventHandler(this.guardFileModuleButton_Click);
            // 
            // reviewDashBoardButton
            // 
            this.reviewDashBoardButton.AutoSize = true;
            this.reviewDashBoardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewDashBoardButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.reviewDashBoardButton.FlatAppearance.BorderSize = 0;
            this.reviewDashBoardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewDashBoardButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewDashBoardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.reviewDashBoardButton.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.reviewDashBoardButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.reviewDashBoardButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reviewDashBoardButton.IconSize = 32;
            this.reviewDashBoardButton.Location = new System.Drawing.Point(5, 149);
            this.reviewDashBoardButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reviewDashBoardButton.Name = "reviewDashBoardButton";
            this.reviewDashBoardButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.reviewDashBoardButton.Size = new System.Drawing.Size(302, 113);
            this.reviewDashBoardButton.TabIndex = 2;
            this.reviewDashBoardButton.Text = "রিভিউ ড্যাশবোর্ড";
            this.reviewDashBoardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.reviewDashBoardButton.UseVisualStyleBackColor = true;
            this.reviewDashBoardButton.Click += new System.EventHandler(this.reviewDashBoardButton_Click);
            // 
            // khosraButton
            // 
            this.khosraButton.AutoSize = true;
            this.khosraButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.khosraButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.khosraButton.FlatAppearance.BorderSize = 0;
            this.khosraButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.khosraButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khosraButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraButton.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.khosraButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.khosraButton.IconSize = 32;
            this.khosraButton.Location = new System.Drawing.Point(316, 5);
            this.khosraButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.khosraButton.Name = "khosraButton";
            this.khosraButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.khosraButton.Size = new System.Drawing.Size(302, 135);
            this.khosraButton.TabIndex = 1;
            this.khosraButton.Text = "খসড়া";
            this.khosraButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.khosraButton.UseVisualStyleBackColor = true;
            this.khosraButton.Click += new System.EventHandler(this.khosraButton_Click);
            // 
            // khosraPotroButton
            // 
            this.khosraPotroButton.AutoSize = true;
            this.khosraPotroButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.khosraPotroButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.khosraPotroButton.FlatAppearance.BorderSize = 0;
            this.khosraPotroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.khosraPotroButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khosraPotroButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraPotroButton.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.khosraPotroButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.khosraPotroButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.khosraPotroButton.IconSize = 32;
            this.khosraPotroButton.Location = new System.Drawing.Point(5, 5);
            this.khosraPotroButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.khosraPotroButton.Name = "khosraPotroButton";
            this.khosraPotroButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.khosraPotroButton.Size = new System.Drawing.Size(302, 135);
            this.khosraPotroButton.TabIndex = 0;
            this.khosraPotroButton.Text = "খসড়া-পত্র ড্যাশবোর্ড";
            this.khosraPotroButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.khosraPotroButton.UseVisualStyleBackColor = true;
            this.khosraPotroButton.Click += new System.EventHandler(this.khosraPotroButton_Click);
            // 
            // emailButton
            // 
            this.emailButton.AutoSize = true;
            this.emailButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.emailButton.FlatAppearance.BorderSize = 0;
            this.emailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emailButton.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.emailButton.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.emailButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.emailButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.emailButton.IconSize = 35;
            this.emailButton.Location = new System.Drawing.Point(5, 397);
            this.emailButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailButton.Name = "emailButton";
            this.emailButton.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.emailButton.Size = new System.Drawing.Size(302, 117);
            this.emailButton.TabIndex = 6;
            this.emailButton.Text = "ইমেইল বক্স";
            this.emailButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.emailButton.UseVisualStyleBackColor = true;
            this.emailButton.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::dNothi.Desktop.Properties.Resources.bg_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 114);
            this.panel1.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(209, 39);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 34);
            this.label14.TabIndex = 0;
            this.label14.Text = "অন্যান্য মডিউল";
            // 
            // ModulePanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.modulePanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ModulePanelUserControl";
            this.Size = new System.Drawing.Size(623, 636);
            this.modulePanel.ResumeLayout(false);
            this.modulePanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private FontAwesome.Sharp.IconButton emailButton;
        private FontAwesome.Sharp.IconButton dashboardButton;
    }
}
