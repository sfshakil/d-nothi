
namespace dNothi.Desktop.UI.ManuelUserControl
{
    partial class HeaderUserControl
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
            this.nothiModulePanel = new System.Windows.Forms.TableLayoutPanel();
            this.moduleNothiCountLabel = new System.Windows.Forms.Label();
            this.nothiModuleNameLabel = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.dakModulePanel = new System.Windows.Forms.TableLayoutPanel();
            this.moduleDakCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.profilePanel = new System.Windows.Forms.Panel();
            this.userPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.onlineStatus = new FontAwesome.Sharp.IconButton();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.profileShowArrowButton = new FontAwesome.Sharp.IconButton();
            this.onlineToggleButton2 = new dNothi.Desktop.UI.CustomMessageBox.OnlineToggleButton();
            this.moduleButton = new FontAwesome.Sharp.IconButton();
            this.SettingsButton = new FontAwesome.Sharp.IconButton();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NotificationBellButton = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.nothiModulePanel.SuspendLayout();
            this.dakModulePanel.SuspendLayout();
            this.profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.nothiModulePanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dakModulePanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.profilePanel, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.onlineToggleButton2, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.moduleButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.SettingsButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.NotificationBellButton, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1060, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nothiModulePanel
            // 
            this.nothiModulePanel.AutoSize = true;
            this.nothiModulePanel.ColumnCount = 3;
            this.nothiModulePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.nothiModulePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.nothiModulePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.nothiModulePanel.Controls.Add(this.moduleNothiCountLabel, 2, 0);
            this.nothiModulePanel.Controls.Add(this.nothiModuleNameLabel, 1, 0);
            this.nothiModulePanel.Controls.Add(this.iconButton2, 0, 0);
            this.nothiModulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nothiModulePanel.Location = new System.Drawing.Point(4, 4);
            this.nothiModulePanel.Margin = new System.Windows.Forms.Padding(4);
            this.nothiModulePanel.Name = "nothiModulePanel";
            this.nothiModulePanel.RowCount = 1;
            this.nothiModulePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.nothiModulePanel.Size = new System.Drawing.Size(161, 55);
            this.nothiModulePanel.TabIndex = 104;
            this.nothiModulePanel.Click += new System.EventHandler(this.nothiModulePanel_Click);
            this.nothiModulePanel.MouseLeave += new System.EventHandler(this.nothiModulePanel_MouseLeave);
            this.nothiModulePanel.MouseHover += new System.EventHandler(this.nothiModulePanel_MouseHover);
            // 
            // moduleNothiCountLabel
            // 
            this.moduleNothiCountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moduleNothiCountLabel.AutoEllipsis = true;
            this.moduleNothiCountLabel.AutoSize = true;
            this.moduleNothiCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.moduleNothiCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleNothiCountLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moduleNothiCountLabel.Location = new System.Drawing.Point(114, 15);
            this.moduleNothiCountLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.moduleNothiCountLabel.Name = "moduleNothiCountLabel";
            this.moduleNothiCountLabel.Size = new System.Drawing.Size(40, 25);
            this.moduleNothiCountLabel.TabIndex = 18;
            this.moduleNothiCountLabel.Text = "১২২";
            this.moduleNothiCountLabel.Click += new System.EventHandler(this.nothiModulePanel_Click);
            this.moduleNothiCountLabel.MouseLeave += new System.EventHandler(this.nothiModulePanel_MouseLeave);
            this.moduleNothiCountLabel.MouseHover += new System.EventHandler(this.nothiModulePanel_MouseHover);
            // 
            // nothiModuleNameLabel
            // 
            this.nothiModuleNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nothiModuleNameLabel.AutoSize = true;
            this.nothiModuleNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nothiModuleNameLabel.ForeColor = System.Drawing.Color.Black;
            this.nothiModuleNameLabel.Location = new System.Drawing.Point(60, 13);
            this.nothiModuleNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nothiModuleNameLabel.Name = "nothiModuleNameLabel";
            this.nothiModuleNameLabel.Size = new System.Drawing.Size(43, 29);
            this.nothiModuleNameLabel.TabIndex = 19;
            this.nothiModuleNameLabel.Text = "নথি";
            this.nothiModuleNameLabel.Click += new System.EventHandler(this.nothiModulePanel_Click);
            this.nothiModuleNameLabel.MouseLeave += new System.EventHandler(this.nothiModulePanel_MouseLeave);
            this.nothiModuleNameLabel.MouseHover += new System.EventHandler(this.nothiModulePanel_MouseHover);
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton2.AutoSize = true;
            this.iconButton2.BackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 24;
            this.iconButton2.Location = new System.Drawing.Point(4, 9);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(48, 37);
            this.iconButton2.TabIndex = 4;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.nothiModulePanel_Click);
            this.iconButton2.MouseLeave += new System.EventHandler(this.nothiModulePanel_MouseLeave);
            this.iconButton2.MouseHover += new System.EventHandler(this.nothiModulePanel_MouseHover);
            // 
            // dakModulePanel
            // 
            this.dakModulePanel.AutoSize = true;
            this.dakModulePanel.ColumnCount = 3;
            this.dakModulePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dakModulePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dakModulePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dakModulePanel.Controls.Add(this.moduleDakCountLabel, 2, 0);
            this.dakModulePanel.Controls.Add(this.label1, 1, 0);
            this.dakModulePanel.Controls.Add(this.iconButton1, 0, 0);
            this.dakModulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dakModulePanel.Location = new System.Drawing.Point(173, 4);
            this.dakModulePanel.Margin = new System.Windows.Forms.Padding(4);
            this.dakModulePanel.Name = "dakModulePanel";
            this.dakModulePanel.RowCount = 1;
            this.dakModulePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dakModulePanel.Size = new System.Drawing.Size(158, 55);
            this.dakModulePanel.TabIndex = 103;
            this.dakModulePanel.Click += new System.EventHandler(this.dakModulePanel_Click);
            this.dakModulePanel.MouseLeave += new System.EventHandler(this.dakModulePanel_MouseLeave);
            this.dakModulePanel.MouseHover += new System.EventHandler(this.dakModulePanel_MouseHover);
            // 
            // moduleDakCountLabel
            // 
            this.moduleDakCountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moduleDakCountLabel.AutoEllipsis = true;
            this.moduleDakCountLabel.AutoSize = true;
            this.moduleDakCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.moduleDakCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleDakCountLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moduleDakCountLabel.Location = new System.Drawing.Point(121, 15);
            this.moduleDakCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 7, 0);
            this.moduleDakCountLabel.Name = "moduleDakCountLabel";
            this.moduleDakCountLabel.Size = new System.Drawing.Size(30, 25);
            this.moduleDakCountLabel.TabIndex = 18;
            this.moduleDakCountLabel.Text = "১২";
            this.moduleDakCountLabel.Click += new System.EventHandler(this.dakModulePanel_Click);
            this.moduleDakCountLabel.MouseHover += new System.EventHandler(this.dakModulePanel_MouseHover);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(63, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "ডাক";
            this.label1.Click += new System.EventHandler(this.dakModulePanel_Click);
            this.label1.MouseHover += new System.EventHandler(this.dakModulePanel_MouseHover);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton1.AutoSize = true;
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Inbox;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.Location = new System.Drawing.Point(4, 4);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(51, 47);
            this.iconButton1.TabIndex = 4;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.dakModulePanel_Click);
            this.iconButton1.MouseHover += new System.EventHandler(this.dakModulePanel_MouseHover);
            // 
            // profilePanel
            // 
            this.profilePanel.AutoSize = true;
            this.profilePanel.Controls.Add(this.userPictureBox);
            this.profilePanel.Controls.Add(this.onlineStatus);
            this.profilePanel.Controls.Add(this.userNameLabel);
            this.profilePanel.Controls.Add(this.profileShowArrowButton);
            this.profilePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.profilePanel.Location = new System.Drawing.Point(586, 6);
            this.profilePanel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Padding = new System.Windows.Forms.Padding(4, 6, 13, 6);
            this.profilePanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.profilePanel.Size = new System.Drawing.Size(470, 51);
            this.profilePanel.TabIndex = 115;
            this.profilePanel.Click += new System.EventHandler(this.profilePanel_Click);
            // 
            // userPictureBox
            // 
            this.userPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.userPictureBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.userPictureBox.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.userPictureBox.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.userPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.userPictureBox.IconSize = 39;
            this.userPictureBox.InitialImage = null;
            this.userPictureBox.Location = new System.Drawing.Point(4, 6);
            this.userPictureBox.Margin = new System.Windows.Forms.Padding(7, 12, 4, 4);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.userPictureBox.Size = new System.Drawing.Size(52, 39);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userPictureBox.TabIndex = 29;
            this.userPictureBox.TabStop = false;
            this.userPictureBox.Click += new System.EventHandler(this.profilePanel_Click);
            // 
            // onlineStatus
            // 
            this.onlineStatus.AutoSize = true;
            this.onlineStatus.BackColor = System.Drawing.Color.Transparent;
            this.onlineStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.onlineStatus.FlatAppearance.BorderSize = 0;
            this.onlineStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.onlineStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.onlineStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onlineStatus.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.onlineStatus.IconColor = System.Drawing.Color.Silver;
            this.onlineStatus.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.onlineStatus.IconSize = 15;
            this.onlineStatus.Location = new System.Drawing.Point(56, 6);
            this.onlineStatus.Margin = new System.Windows.Forms.Padding(0);
            this.onlineStatus.Name = "onlineStatus";
            this.onlineStatus.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.onlineStatus.Size = new System.Drawing.Size(28, 39);
            this.onlineStatus.TabIndex = 30;
            this.onlineStatus.UseVisualStyleBackColor = false;
            this.onlineStatus.Click += new System.EventHandler(this.profilePanel_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(146)))), ((int)(((byte)(197)))));
            this.userNameLabel.Location = new System.Drawing.Point(84, 6);
            this.userNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.userNameLabel.Size = new System.Drawing.Size(356, 31);
            this.userNameLabel.TabIndex = 23;
            this.userNameLabel.Text = "মোঃ হাসানুজ্জামান (সল্যুশন আর্কিটেক্ট, টেকনোলজি) ";
            this.userNameLabel.Click += new System.EventHandler(this.profilePanel_Click);
            // 
            // profileShowArrowButton
            // 
            this.profileShowArrowButton.BackColor = System.Drawing.Color.Transparent;
            this.profileShowArrowButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.profileShowArrowButton.FlatAppearance.BorderSize = 0;
            this.profileShowArrowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.profileShowArrowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.profileShowArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileShowArrowButton.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            this.profileShowArrowButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.profileShowArrowButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.profileShowArrowButton.IconSize = 20;
            this.profileShowArrowButton.Location = new System.Drawing.Point(440, 6);
            this.profileShowArrowButton.Margin = new System.Windows.Forms.Padding(4);
            this.profileShowArrowButton.Name = "profileShowArrowButton";
            this.profileShowArrowButton.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.profileShowArrowButton.Size = new System.Drawing.Size(17, 39);
            this.profileShowArrowButton.TabIndex = 27;
            this.profileShowArrowButton.UseVisualStyleBackColor = false;
            this.profileShowArrowButton.Click += new System.EventHandler(this.profilePanel_Click);
            // 
            // onlineToggleButton2
            // 
            this.onlineToggleButton2.AutoSize = true;
            this.onlineToggleButton2.BackColor = System.Drawing.Color.Transparent;
            this.onlineToggleButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onlineToggleButton2.Location = new System.Drawing.Point(529, 0);
            this.onlineToggleButton2.Margin = new System.Windows.Forms.Padding(0);
            this.onlineToggleButton2.MinimumSize = new System.Drawing.Size(53, 0);
            this.onlineToggleButton2.Name = "onlineToggleButton2";
            this.onlineToggleButton2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.onlineToggleButton2.Size = new System.Drawing.Size(53, 63);
            this.onlineToggleButton2.TabIndex = 114;
            // 
            // moduleButton
            // 
            this.moduleButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.moduleButton.FlatAppearance.BorderSize = 0;
            this.moduleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moduleButton.IconChar = FontAwesome.Sharp.IconChar.ThLarge;
            this.moduleButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.moduleButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.moduleButton.IconSize = 32;
            this.moduleButton.Location = new System.Drawing.Point(339, 4);
            this.moduleButton.Margin = new System.Windows.Forms.Padding(4);
            this.moduleButton.Name = "moduleButton";
            this.moduleButton.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.moduleButton.Size = new System.Drawing.Size(53, 55);
            this.moduleButton.TabIndex = 107;
            this.moduleButton.UseVisualStyleBackColor = true;
            this.moduleButton.Click += new System.EventHandler(this.moduleButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.AutoSize = true;
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.SettingsButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.SettingsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SettingsButton.IconSize = 32;
            this.SettingsButton.Location = new System.Drawing.Point(418, 4);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.SettingsButton.Size = new System.Drawing.Size(51, 55);
            this.SettingsButton.TabIndex = 113;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // NotificationBellButton
            // 
            this.NotificationBellButton.AutoSize = true;
            this.NotificationBellButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationBellButton.FlatAppearance.BorderSize = 0;
            this.NotificationBellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NotificationBellButton.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.NotificationBellButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.NotificationBellButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.NotificationBellButton.IconSize = 32;
            this.NotificationBellButton.Location = new System.Drawing.Point(477, 4);
            this.NotificationBellButton.Margin = new System.Windows.Forms.Padding(4);
            this.NotificationBellButton.Name = "NotificationBellButton";
            this.NotificationBellButton.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.NotificationBellButton.Size = new System.Drawing.Size(48, 55);
            this.NotificationBellButton.TabIndex = 117;
            this.NotificationBellButton.UseVisualStyleBackColor = true;
            this.NotificationBellButton.Click += new System.EventHandler(this.NotificationBellButton_Click);
            // 
            // HeaderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HeaderUserControl";
            this.Size = new System.Drawing.Size(1060, 63);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.nothiModulePanel.ResumeLayout(false);
            this.nothiModulePanel.PerformLayout();
            this.dakModulePanel.ResumeLayout(false);
            this.dakModulePanel.PerformLayout();
            this.profilePanel.ResumeLayout(false);
            this.profilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label nothiModuleNameLabel;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label moduleNothiCountLabel;
        private FontAwesome.Sharp.IconButton moduleButton;
        private FontAwesome.Sharp.IconButton SettingsButton;
        private CustomMessageBox.OnlineToggleButton onlineToggleButton2;
        private System.Windows.Forms.Panel profilePanel;
        private FontAwesome.Sharp.IconPictureBox userPictureBox;
        private FontAwesome.Sharp.IconButton onlineStatus;
        private System.Windows.Forms.Label userNameLabel;
        private FontAwesome.Sharp.IconButton profileShowArrowButton;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label moduleDakCountLabel;
        private System.Windows.Forms.TableLayoutPanel dakModulePanel;
        private System.Windows.Forms.TableLayoutPanel nothiModulePanel;
        private System.Windows.Forms.ToolTip MyToolTip;
        private FontAwesome.Sharp.IconButton NotificationBellButton;
    }
}
