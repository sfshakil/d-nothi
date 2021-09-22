
namespace dNothi.Desktop.UI
{
    partial class RvwDashContentShowInEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RvwDashContentShowInEditor));
            this.tinyMCEPanel = new System.Windows.Forms.Panel();
            this.tinyMceEditor = new CefSharp.WinForms.ChromiumWebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.lbNoteSubject = new System.Windows.Forms.Label();
            this.ShareButton = new FontAwesome.Sharp.IconButton();
            this.onlineToggleButton2 = new dNothi.Desktop.UI.CustomMessageBox.OnlineToggleButton();
            this.profilePanel = new System.Windows.Forms.Panel();
            this.userPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.onlineStatus = new FontAwesome.Sharp.IconButton();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.profileShowArrowButton = new FontAwesome.Sharp.IconButton();
            this.footerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.button30 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.tinyMCEPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.footerTableLayoutPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tinyMCEPanel
            // 
            this.tinyMCEPanel.AutoScroll = true;
            this.tinyMCEPanel.Controls.Add(this.tinyMceEditor);
            this.tinyMCEPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tinyMCEPanel.Location = new System.Drawing.Point(0, 65);
            this.tinyMCEPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tinyMCEPanel.Name = "tinyMCEPanel";
            this.tinyMCEPanel.Size = new System.Drawing.Size(1800, 594);
            this.tinyMCEPanel.TabIndex = 3;
            // 
            // tinyMceEditor
            // 
            this.tinyMceEditor.ActivateBrowserOnCreation = true;
            this.tinyMceEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tinyMceEditor.Location = new System.Drawing.Point(0, 0);
            this.tinyMceEditor.Margin = new System.Windows.Forms.Padding(4);
            this.tinyMceEditor.Name = "tinyMceEditor";
            this.tinyMceEditor.Size = new System.Drawing.Size(1800, 594);
            this.tinyMceEditor.TabIndex = 0;
            this.tinyMceEditor.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.tinyMceEditor_FrameLoadEnd);
            this.tinyMceEditor.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.tinyMceEditor_LoadingStateChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ShareButton);
            this.panel1.Controls.Add(this.onlineToggleButton2);
            this.panel1.Controls.Add(this.profilePanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1800, 65);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lbNoteSubject);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1203, 65);
            this.panel2.TabIndex = 112;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(438, 65);
            this.panel3.TabIndex = 113;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(47, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.label1.Size = new System.Drawing.Size(381, 43);
            this.label1.TabIndex = 113;
            this.label1.Text = "Nothi Shared Editor                       ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSize = true;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 38;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(47, 65);
            this.iconButton1.TabIndex = 112;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // lbNoteSubject
            // 
            this.lbNoteSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNoteSubject.AutoSize = true;
            this.lbNoteSubject.Font = new System.Drawing.Font("SolaimanLipi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoteSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbNoteSubject.Location = new System.Drawing.Point(765, 11);
            this.lbNoteSubject.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoteSubject.Name = "lbNoteSubject";
            this.lbNoteSubject.Size = new System.Drawing.Size(85, 35);
            this.lbNoteSubject.TabIndex = 112;
            this.lbNoteSubject.Text = "বিষয়ঃ ";
            this.lbNoteSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShareButton
            // 
            this.ShareButton.AutoSize = true;
            this.ShareButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShareButton.FlatAppearance.BorderSize = 0;
            this.ShareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShareButton.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.ShareButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ShareButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ShareButton.IconSize = 38;
            this.ShareButton.Location = new System.Drawing.Point(1203, 0);
            this.ShareButton.Margin = new System.Windows.Forms.Padding(0);
            this.ShareButton.Name = "ShareButton";
            this.ShareButton.Size = new System.Drawing.Size(59, 65);
            this.ShareButton.TabIndex = 111;
            this.ShareButton.UseVisualStyleBackColor = true;
            this.ShareButton.Click += new System.EventHandler(this.ShareButton_Click);
            // 
            // onlineToggleButton2
            // 
            this.onlineToggleButton2.AutoSize = true;
            this.onlineToggleButton2.BackColor = System.Drawing.Color.Transparent;
            this.onlineToggleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.onlineToggleButton2.Location = new System.Drawing.Point(1262, 0);
            this.onlineToggleButton2.Margin = new System.Windows.Forms.Padding(0);
            this.onlineToggleButton2.MinimumSize = new System.Drawing.Size(53, 0);
            this.onlineToggleButton2.Name = "onlineToggleButton2";
            this.onlineToggleButton2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.onlineToggleButton2.Size = new System.Drawing.Size(53, 65);
            this.onlineToggleButton2.TabIndex = 109;
            // 
            // profilePanel
            // 
            this.profilePanel.AutoSize = true;
            this.profilePanel.Controls.Add(this.userPictureBox);
            this.profilePanel.Controls.Add(this.onlineStatus);
            this.profilePanel.Controls.Add(this.userNameLabel);
            this.profilePanel.Controls.Add(this.profileShowArrowButton);
            this.profilePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.profilePanel.Location = new System.Drawing.Point(1315, 0);
            this.profilePanel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Padding = new System.Windows.Forms.Padding(4, 6, 13, 6);
            this.profilePanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.profilePanel.Size = new System.Drawing.Size(485, 65);
            this.profilePanel.TabIndex = 31;
            // 
            // userPictureBox
            // 
            this.userPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.userPictureBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.userPictureBox.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.userPictureBox.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.userPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.userPictureBox.IconSize = 52;
            this.userPictureBox.InitialImage = null;
            this.userPictureBox.Location = new System.Drawing.Point(4, 6);
            this.userPictureBox.Margin = new System.Windows.Forms.Padding(9, 15, 5, 5);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.userPictureBox.Size = new System.Drawing.Size(52, 53);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userPictureBox.TabIndex = 29;
            this.userPictureBox.TabStop = false;
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
            this.onlineStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.onlineStatus.Size = new System.Drawing.Size(37, 53);
            this.onlineStatus.TabIndex = 31;
            this.onlineStatus.UseVisualStyleBackColor = false;
            this.onlineStatus.Visible = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(146)))), ((int)(((byte)(197)))));
            this.userNameLabel.Location = new System.Drawing.Point(93, 6);
            this.userNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.userNameLabel.Size = new System.Drawing.Size(356, 35);
            this.userNameLabel.TabIndex = 23;
            this.userNameLabel.Text = "মোঃ হাসানুজ্জামান (সল্যুশন আর্কিটেক্ট, টেকনোলজি) ";
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
            this.profileShowArrowButton.Location = new System.Drawing.Point(449, 6);
            this.profileShowArrowButton.Margin = new System.Windows.Forms.Padding(5);
            this.profileShowArrowButton.Name = "profileShowArrowButton";
            this.profileShowArrowButton.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.profileShowArrowButton.Size = new System.Drawing.Size(23, 53);
            this.profileShowArrowButton.TabIndex = 27;
            this.profileShowArrowButton.UseVisualStyleBackColor = false;
            this.profileShowArrowButton.Visible = false;
            // 
            // footerTableLayoutPanel
            // 
            this.footerTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.footerTableLayoutPanel.ColumnCount = 9;
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.footerTableLayoutPanel.Controls.Add(this.label9, 3, 0);
            this.footerTableLayoutPanel.Controls.Add(this.linkLabel2, 1, 0);
            this.footerTableLayoutPanel.Controls.Add(this.label7, 0, 0);
            this.footerTableLayoutPanel.Controls.Add(this.button30, 4, 0);
            this.footerTableLayoutPanel.Controls.Add(this.button29, 5, 0);
            this.footerTableLayoutPanel.Controls.Add(this.button28, 6, 0);
            this.footerTableLayoutPanel.Controls.Add(this.button27, 7, 0);
            this.footerTableLayoutPanel.Controls.Add(this.button26, 8, 0);
            this.footerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerTableLayoutPanel.Location = new System.Drawing.Point(0, 659);
            this.footerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.footerTableLayoutPanel.Name = "footerTableLayoutPanel";
            this.footerTableLayoutPanel.RowCount = 1;
            this.footerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.footerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.footerTableLayoutPanel.Size = new System.Drawing.Size(1800, 36);
            this.footerTableLayoutPanel.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label9.Location = new System.Drawing.Point(1513, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 36);
            this.label9.TabIndex = 33;
            this.label9.Text = "পার্টনার: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(176, 0);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(125, 36);
            this.linkLabel2.TabIndex = 31;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "এটুআই প্রোগ্রাম";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label7.Location = new System.Drawing.Point(4, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 36);
            this.label7.TabIndex = 30;
            this.label7.Text = "© কপিরাইট ২০২১, ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button30
            // 
            this.button30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button30.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button30.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button30.BackgroundImage")));
            this.button30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button30.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.Location = new System.Drawing.Point(1599, 4);
            this.button30.Margin = new System.Windows.Forms.Padding(4);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(33, 28);
            this.button30.TabIndex = 39;
            this.button30.UseVisualStyleBackColor = false;
            // 
            // button29
            // 
            this.button29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button29.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button29.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button29.BackgroundImage")));
            this.button29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button29.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.Location = new System.Drawing.Point(1640, 4);
            this.button29.Margin = new System.Windows.Forms.Padding(4);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(33, 28);
            this.button29.TabIndex = 40;
            this.button29.UseVisualStyleBackColor = false;
            // 
            // button28
            // 
            this.button28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button28.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button28.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button28.BackgroundImage")));
            this.button28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button28.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button28.Location = new System.Drawing.Point(1681, 4);
            this.button28.Margin = new System.Windows.Forms.Padding(4);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(33, 28);
            this.button28.TabIndex = 41;
            this.button28.UseVisualStyleBackColor = false;
            // 
            // button27
            // 
            this.button27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button27.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button27.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button27.BackgroundImage")));
            this.button27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button27.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Location = new System.Drawing.Point(1722, 4);
            this.button27.Margin = new System.Windows.Forms.Padding(4);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(33, 28);
            this.button27.TabIndex = 42;
            this.button27.UseVisualStyleBackColor = false;
            // 
            // button26
            // 
            this.button26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button26.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button26.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button26.BackgroundImage")));
            this.button26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button26.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(1763, 4);
            this.button26.Margin = new System.Windows.Forms.Padding(4);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(33, 28);
            this.button26.TabIndex = 43;
            this.button26.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 65);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 2, 20, 2);
            this.panel5.Size = new System.Drawing.Size(1800, 46);
            this.panel5.TabIndex = 36;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.Color.White;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1575, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(205, 42);
            this.btnSave.TabIndex = 112;
            this.btnSave.Text = " নথিতে প্রেরন";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // RvwDashContentShowInEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1800, 695);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tinyMCEPanel);
            this.Controls.Add(this.footerTableLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RvwDashContentShowInEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RvwDashContentShowInEditor_Load);
            this.tinyMCEPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.profilePanel.ResumeLayout(false);
            this.profilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.footerTableLayoutPanel.ResumeLayout(false);
            this.footerTableLayoutPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private XTextBox xTextBox1;
        private CircularButton circularButton1;
        private designationSelect designationSelect1;
        private System.Windows.Forms.Panel tinyMCEPanel;
        private CefSharp.WinForms.ChromiumWebBrowser tinyMceEditor;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton ShareButton;
        private CustomMessageBox.OnlineToggleButton onlineToggleButton2;
        private System.Windows.Forms.Panel profilePanel;
        private FontAwesome.Sharp.IconPictureBox userPictureBox;
        private System.Windows.Forms.Label userNameLabel;
        private FontAwesome.Sharp.IconButton profileShowArrowButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbNoteSubject;
        private System.Windows.Forms.TableLayoutPanel footerTableLayoutPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton onlineStatus;
    }
}