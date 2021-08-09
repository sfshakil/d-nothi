namespace dNothi.Desktop.UI
{
    partial class SelectOfficerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectOfficerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new FontAwesome.Sharp.IconButton();
            this.sliderCrossButton = new FontAwesome.Sharp.IconButton();
            this.sLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.officerSearchOfficerNameLabel = new System.Windows.Forms.Label();
            this.saveOfficerButton = new FontAwesome.Sharp.IconButton();
            this.label19 = new System.Windows.Forms.Label();
            this.searchOfficerRightButton = new System.Windows.Forms.Button();
            this.searchOfficerRightPanel = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.searchOfficerRightListBox = new System.Windows.Forms.ListBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.searchOfficerRightXTextBox = new dNothi.Desktop.XTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.potraJariTabPage = new System.Windows.Forms.TabPage();
            this.bodyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.perPageRowLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.PreviousIconButton = new FontAwesome.Sharp.IconButton();
            this.nextIconButton = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.potraJariIButton = new FontAwesome.Sharp.IconButton();
            this.listTypeLabel = new System.Windows.Forms.Label();
            this.bodyContentPanel = new System.Windows.Forms.Panel();
            this.newPotrojariPanel = new System.Windows.Forms.Panel();
            this.khosraListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.noKhosraPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.finalSaveButton = new FontAwesome.Sharp.IconButton();
            this.officerListPanel = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.officerEmptyPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.officerListFlowLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.countOfficer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.searchOfficerRightPanel.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.potraJariTabPage.SuspendLayout();
            this.bodyTableLayoutPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.bodyContentPanel.SuspendLayout();
            this.noKhosraPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.officerListPanel.SuspendLayout();
            this.officerEmptyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.sliderCrossButton);
            this.panel1.Controls.Add(this.sLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 70);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.AutoSize = true;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.CloseButton.IconColor = System.Drawing.Color.DimGray;
            this.CloseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CloseButton.IconSize = 20;
            this.CloseButton.Location = new System.Drawing.Point(416, 17);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(28, 31);
            this.CloseButton.TabIndex = 39;
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // sliderCrossButton
            // 
            this.sliderCrossButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sliderCrossButton.BackColor = System.Drawing.Color.White;
            this.sliderCrossButton.FlatAppearance.BorderSize = 0;
            this.sliderCrossButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sliderCrossButton.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.sliderCrossButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sliderCrossButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.sliderCrossButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.sliderCrossButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.sliderCrossButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.sliderCrossButton.IconSize = 18;
            this.sliderCrossButton.Location = new System.Drawing.Point(420, 17);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.MaximumSize = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.TabIndex = 40;
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            this.sliderCrossButton.Click += new System.EventHandler(this.sliderCrossButton_Click);
            // 
            // sLabel
            // 
            this.sLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sLabel.AutoSize = true;
            this.sLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.sLabel.Location = new System.Drawing.Point(0, 23);
            this.sLabel.Name = "sLabel";
            this.sLabel.Size = new System.Drawing.Size(131, 21);
            this.sLabel.TabIndex = 39;
            this.sLabel.Text = "অনুমোদনকারী বাছাই";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 80);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 636);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.potraJariTabPage);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(15, 12);
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 636);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tabPage1.Controls.Add(this.officerSearchOfficerNameLabel);
            this.tabPage1.Controls.Add(this.saveOfficerButton);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.searchOfficerRightButton);
            this.tabPage1.Controls.Add(this.searchOfficerRightPanel);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // officerSearchOfficerNameLabel
            // 
            this.officerSearchOfficerNameLabel.AutoSize = true;
            this.officerSearchOfficerNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.officerSearchOfficerNameLabel.Location = new System.Drawing.Point(34, 57);
            this.officerSearchOfficerNameLabel.MaximumSize = new System.Drawing.Size(320, 18);
            this.officerSearchOfficerNameLabel.MinimumSize = new System.Drawing.Size(320, 18);
            this.officerSearchOfficerNameLabel.Name = "officerSearchOfficerNameLabel";
            this.officerSearchOfficerNameLabel.Size = new System.Drawing.Size(320, 18);
            this.officerSearchOfficerNameLabel.TabIndex = 93;
            this.officerSearchOfficerNameLabel.Text = "নাম/পদবী দিয়ে খুঁজুন";
            this.officerSearchOfficerNameLabel.Click += new System.EventHandler(this.searchOfficerRightButton_Click);
            // 
            // saveOfficerButton
            // 
            this.saveOfficerButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.saveOfficerButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.saveOfficerButton.FlatAppearance.BorderSize = 0;
            this.saveOfficerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveOfficerButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveOfficerButton.ForeColor = System.Drawing.Color.White;
            this.saveOfficerButton.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            this.saveOfficerButton.IconColor = System.Drawing.Color.White;
            this.saveOfficerButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveOfficerButton.IconSize = 32;
            this.saveOfficerButton.Location = new System.Drawing.Point(273, 400);
            this.saveOfficerButton.Name = "saveOfficerButton";
            this.saveOfficerButton.Size = new System.Drawing.Size(115, 50);
            this.saveOfficerButton.TabIndex = 94;
            this.saveOfficerButton.Text = " সংরক্ষণ";
            this.saveOfficerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveOfficerButton.UseVisualStyleBackColor = false;
            this.saveOfficerButton.Visible = false;
            this.saveOfficerButton.Click += new System.EventHandler(this.saveOfficerButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(25, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 18);
            this.label19.TabIndex = 92;
            this.label19.Text = "অফিসার খুঁজুন";
            // 
            // searchOfficerRightButton
            // 
            this.searchOfficerRightButton.BackColor = System.Drawing.Color.Transparent;
            this.searchOfficerRightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchOfficerRightButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(248)))));
            this.searchOfficerRightButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.searchOfficerRightButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.searchOfficerRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchOfficerRightButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchOfficerRightButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchOfficerRightButton.Image = ((System.Drawing.Image)(resources.GetObject("searchOfficerRightButton.Image")));
            this.searchOfficerRightButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchOfficerRightButton.Location = new System.Drawing.Point(25, 46);
            this.searchOfficerRightButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchOfficerRightButton.Name = "searchOfficerRightButton";
            this.searchOfficerRightButton.Size = new System.Drawing.Size(363, 37);
            this.searchOfficerRightButton.TabIndex = 90;
            this.searchOfficerRightButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchOfficerRightButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.searchOfficerRightButton.UseVisualStyleBackColor = false;
            this.searchOfficerRightButton.Click += new System.EventHandler(this.searchOfficerRightButton_Click);
            // 
            // searchOfficerRightPanel
            // 
            this.searchOfficerRightPanel.AutoScroll = true;
            this.searchOfficerRightPanel.Controls.Add(this.panel19);
            this.searchOfficerRightPanel.Controls.Add(this.panel8);
            this.searchOfficerRightPanel.Location = new System.Drawing.Point(25, 83);
            this.searchOfficerRightPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchOfficerRightPanel.Name = "searchOfficerRightPanel";
            this.searchOfficerRightPanel.Size = new System.Drawing.Size(363, 310);
            this.searchOfficerRightPanel.TabIndex = 91;
            this.searchOfficerRightPanel.Visible = false;
            this.searchOfficerRightPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color_Blue);
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.searchOfficerRightListBox);
            this.panel19.Location = new System.Drawing.Point(6, 50);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(351, 242);
            this.panel19.TabIndex = 94;
            this.panel19.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color_Blue);
            // 
            // searchOfficerRightListBox
            // 
            this.searchOfficerRightListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchOfficerRightListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchOfficerRightListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.searchOfficerRightListBox.Font = new System.Drawing.Font("SolaimanLipi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchOfficerRightListBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchOfficerRightListBox.FormattingEnabled = true;
            this.searchOfficerRightListBox.ItemHeight = 50;
            this.searchOfficerRightListBox.Items.AddRange(new object[] {
            "মোহাম্মদ আশরাফ উদ্দিন সিনিয়র সহকারী সচিব, সওব্য-১২ শাখা, জনপ্রশাসন মন্ত্রণালয়",
            "মোহাম্মদ আশরাফুল ইসলাম মোল্লা গোপনীয় সহকারী, শিক্ষা ও আইসিটি, জেলা প্রশাসকের কার্" +
                "যালয়, নরসিংদী",
            "জি.এম. ফয়সাল আহমদ সিস্টেম এনালিস্ট, আইসিটি সেল, নৌ-পরিবহন মন্ত্রণালয়"});
            this.searchOfficerRightListBox.Location = new System.Drawing.Point(0, 0);
            this.searchOfficerRightListBox.Margin = new System.Windows.Forms.Padding(10);
            this.searchOfficerRightListBox.MaximumSize = new System.Drawing.Size(350, 248);
            this.searchOfficerRightListBox.Name = "searchOfficerRightListBox";
            this.searchOfficerRightListBox.Size = new System.Drawing.Size(350, 242);
            this.searchOfficerRightListBox.TabIndex = 35;
            this.searchOfficerRightListBox.Click += new System.EventHandler(this.searchOfficerRightListBox_Click);
            this.searchOfficerRightListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.searchOfficerRightListBox_DrawItem);
            this.searchOfficerRightListBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.searchOfficerRightListBox_MeasureItem);
            this.searchOfficerRightListBox.SelectedIndexChanged += new System.EventHandler(this.searchOfficerRightListBox_SelectedIndexChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(363, 49);
            this.panel8.TabIndex = 34;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.searchOfficerRightXTextBox);
            this.panel12.Location = new System.Drawing.Point(6, 7);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(351, 37);
            this.panel12.TabIndex = 34;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color_Blue);
            // 
            // searchOfficerRightXTextBox
            // 
            this.searchOfficerRightXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchOfficerRightXTextBox.BackColor = System.Drawing.Color.White;
            this.searchOfficerRightXTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchOfficerRightXTextBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchOfficerRightXTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchOfficerRightXTextBox.Location = new System.Drawing.Point(6, 9);
            this.searchOfficerRightXTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchOfficerRightXTextBox.Name = "searchOfficerRightXTextBox";
            this.searchOfficerRightXTextBox.Size = new System.Drawing.Size(342, 19);
            this.searchOfficerRightXTextBox.TabIndex = 33;
            this.searchOfficerRightXTextBox.TextChanged += new System.EventHandler(this.searchOfficerRightXTextBox_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 3;
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // potraJariTabPage
            // 
            this.potraJariTabPage.Controls.Add(this.bodyTableLayoutPanel);
            this.potraJariTabPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.potraJariTabPage.ImageIndex = 5;
            this.potraJariTabPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.potraJariTabPage.Location = new System.Drawing.Point(4, 49);
            this.potraJariTabPage.Name = "potraJariTabPage";
            this.potraJariTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.potraJariTabPage.Size = new System.Drawing.Size(439, 583);
            this.potraJariTabPage.TabIndex = 3;
            this.potraJariTabPage.UseVisualStyleBackColor = true;
            this.potraJariTabPage.Click += new System.EventHandler(this.potraJariTabPage_Click);
            // 
            // bodyTableLayoutPanel
            // 
            this.bodyTableLayoutPanel.ColumnCount = 1;
            this.bodyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayoutPanel.Controls.Add(this.panel5, 0, 2);
            this.bodyTableLayoutPanel.Controls.Add(this.panel3, 0, 0);
            this.bodyTableLayoutPanel.Controls.Add(this.bodyContentPanel, 0, 3);
            this.bodyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.bodyTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bodyTableLayoutPanel.Name = "bodyTableLayoutPanel";
            this.bodyTableLayoutPanel.RowCount = 4;
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayoutPanel.Size = new System.Drawing.Size(433, 577);
            this.bodyTableLayoutPanel.TabIndex = 55;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.perPageRowLabel);
            this.panel5.Controls.Add(this.totalLabel);
            this.panel5.Controls.Add(this.PreviousIconButton);
            this.panel5.Controls.Add(this.nextIconButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 45);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(433, 40);
            this.panel5.TabIndex = 2;
            // 
            // perPageRowLabel
            // 
            this.perPageRowLabel.BackColor = System.Drawing.Color.Transparent;
            this.perPageRowLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.perPageRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perPageRowLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(86)))));
            this.perPageRowLabel.Location = new System.Drawing.Point(39, 0);
            this.perPageRowLabel.Name = "perPageRowLabel";
            this.perPageRowLabel.Size = new System.Drawing.Size(216, 40);
            this.perPageRowLabel.TabIndex = 104;
            this.perPageRowLabel.Text = "১ - ১০";
            this.perPageRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalLabel
            // 
            this.totalLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(86)))));
            this.totalLabel.Location = new System.Drawing.Point(255, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(110, 40);
            this.totalLabel.TabIndex = 107;
            this.totalLabel.Text = "সর্বমোট ৮১ টি";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PreviousIconButton
            // 
            this.PreviousIconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.PreviousIconButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PreviousIconButton.FlatAppearance.BorderSize = 0;
            this.PreviousIconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.PreviousIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousIconButton.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            this.PreviousIconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.PreviousIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PreviousIconButton.IconSize = 24;
            this.PreviousIconButton.Location = new System.Drawing.Point(365, 0);
            this.PreviousIconButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.PreviousIconButton.Name = "PreviousIconButton";
            this.PreviousIconButton.Size = new System.Drawing.Size(34, 40);
            this.PreviousIconButton.TabIndex = 105;
            this.PreviousIconButton.UseVisualStyleBackColor = false;
            this.PreviousIconButton.Click += new System.EventHandler(this.PreviousIconButton_Click);
            // 
            // nextIconButton
            // 
            this.nextIconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.nextIconButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.nextIconButton.FlatAppearance.BorderSize = 0;
            this.nextIconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.nextIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextIconButton.IconChar = FontAwesome.Sharp.IconChar.ChevronRight;
            this.nextIconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.nextIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.nextIconButton.IconSize = 24;
            this.nextIconButton.Location = new System.Drawing.Point(399, 0);
            this.nextIconButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.nextIconButton.Name = "nextIconButton";
            this.nextIconButton.Size = new System.Drawing.Size(34, 40);
            this.nextIconButton.TabIndex = 106;
            this.nextIconButton.UseVisualStyleBackColor = false;
            this.nextIconButton.Click += new System.EventHandler(this.nextIconButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.panel3.Controls.Add(this.potraJariIButton);
            this.panel3.Controls.Add(this.listTypeLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(433, 45);
            this.panel3.TabIndex = 1;
            // 
            // potraJariIButton
            // 
            this.potraJariIButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.potraJariIButton.AutoSize = true;
            this.potraJariIButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.potraJariIButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.potraJariIButton.FlatAppearance.BorderSize = 0;
            this.potraJariIButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.potraJariIButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potraJariIButton.ForeColor = System.Drawing.Color.White;
            this.potraJariIButton.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            this.potraJariIButton.IconColor = System.Drawing.Color.White;
            this.potraJariIButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.potraJariIButton.IconSize = 32;
            this.potraJariIButton.Location = new System.Drawing.Point(318, 0);
            this.potraJariIButton.Name = "potraJariIButton";
            this.potraJariIButton.Size = new System.Drawing.Size(115, 45);
            this.potraJariIButton.TabIndex = 95;
            this.potraJariIButton.Text = " সংরক্ষণ";
            this.potraJariIButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.potraJariIButton.UseVisualStyleBackColor = false;
            this.potraJariIButton.Click += new System.EventHandler(this.potraJariIButton_Click);
            // 
            // listTypeLabel
            // 
            this.listTypeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.listTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(70)))), ((int)(((byte)(117)))));
            this.listTypeLabel.Location = new System.Drawing.Point(0, 0);
            this.listTypeLabel.Name = "listTypeLabel";
            this.listTypeLabel.Size = new System.Drawing.Size(236, 45);
            this.listTypeLabel.TabIndex = 37;
            this.listTypeLabel.Text = "পত্রজারি গ্রুপ তালিকা";
            this.listTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bodyContentPanel
            // 
            this.bodyContentPanel.AutoScroll = true;
            this.bodyContentPanel.AutoSize = true;
            this.bodyContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.bodyContentPanel.Controls.Add(this.newPotrojariPanel);
            this.bodyContentPanel.Controls.Add(this.khosraListTableLayoutPanel);
            this.bodyContentPanel.Controls.Add(this.noKhosraPanel);
            this.bodyContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyContentPanel.Location = new System.Drawing.Point(0, 85);
            this.bodyContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bodyContentPanel.Name = "bodyContentPanel";
            this.bodyContentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.bodyContentPanel.Size = new System.Drawing.Size(433, 492);
            this.bodyContentPanel.TabIndex = 3;
            // 
            // newPotrojariPanel
            // 
            this.newPotrojariPanel.AutoScroll = true;
            this.newPotrojariPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newPotrojariPanel.Location = new System.Drawing.Point(5, 48);
            this.newPotrojariPanel.Margin = new System.Windows.Forms.Padding(0);
            this.newPotrojariPanel.Name = "newPotrojariPanel";
            this.newPotrojariPanel.Size = new System.Drawing.Size(423, 439);
            this.newPotrojariPanel.TabIndex = 3;
            // 
            // khosraListTableLayoutPanel
            // 
            this.khosraListTableLayoutPanel.AutoSize = true;
            this.khosraListTableLayoutPanel.ColumnCount = 1;
            this.khosraListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.khosraListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.khosraListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.khosraListTableLayoutPanel.Location = new System.Drawing.Point(5, 48);
            this.khosraListTableLayoutPanel.Name = "khosraListTableLayoutPanel";
            this.khosraListTableLayoutPanel.RowCount = 1;
            this.khosraListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.khosraListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.khosraListTableLayoutPanel.Size = new System.Drawing.Size(423, 0);
            this.khosraListTableLayoutPanel.TabIndex = 3;
            // 
            // noKhosraPanel
            // 
            this.noKhosraPanel.BackColor = System.Drawing.Color.White;
            this.noKhosraPanel.Controls.Add(this.label2);
            this.noKhosraPanel.Controls.Add(this.iconButton3);
            this.noKhosraPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.noKhosraPanel.Location = new System.Drawing.Point(5, 5);
            this.noKhosraPanel.Margin = new System.Windows.Forms.Padding(0);
            this.noKhosraPanel.Name = "noKhosraPanel";
            this.noKhosraPanel.Size = new System.Drawing.Size(423, 43);
            this.noKhosraPanel.TabIndex = 2;
            this.noKhosraPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(157)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(130, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "কোনো তথ্য পাওয়া যায় নি";
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton3.BackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.iconButton3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(157)))), ((int)(((byte)(255)))));
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 24;
            this.iconButton3.Location = new System.Drawing.Point(77, 6);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(50, 28);
            this.iconButton3.TabIndex = 102;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.finalSaveButton);
            this.tabPage3.Controls.Add(this.officerListPanel);
            this.tabPage3.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.ForeColor = System.Drawing.Color.Maroon;
            this.tabPage3.ImageIndex = 4;
            this.tabPage3.Location = new System.Drawing.Point(4, 49);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(439, 583);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // finalSaveButton
            // 
            this.finalSaveButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.finalSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finalSaveButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.finalSaveButton.FlatAppearance.BorderSize = 0;
            this.finalSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finalSaveButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalSaveButton.ForeColor = System.Drawing.Color.White;
            this.finalSaveButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.finalSaveButton.IconColor = System.Drawing.Color.White;
            this.finalSaveButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.finalSaveButton.IconSize = 32;
            this.finalSaveButton.Location = new System.Drawing.Point(285, 527);
            this.finalSaveButton.Name = "finalSaveButton";
            this.finalSaveButton.Size = new System.Drawing.Size(148, 50);
            this.finalSaveButton.TabIndex = 95;
            this.finalSaveButton.Text = "বাছাই সম্পন্ন করুন";
            this.finalSaveButton.UseVisualStyleBackColor = false;
            this.finalSaveButton.Click += new System.EventHandler(this.finalSaveButton_Click);
            // 
            // officerListPanel
            // 
            this.officerListPanel.AutoSize = true;
            this.officerListPanel.Controls.Add(this.label15);
            this.officerListPanel.Controls.Add(this.officerEmptyPanel);
            this.officerListPanel.Controls.Add(this.officerListFlowLayoutPanel);
            this.officerListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.officerListPanel.Location = new System.Drawing.Point(3, 3);
            this.officerListPanel.Name = "officerListPanel";
            this.officerListPanel.Size = new System.Drawing.Size(433, 29);
            this.officerListPanel.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Silver;
            this.label15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label15.Location = new System.Drawing.Point(0, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(433, 1);
            this.label15.TabIndex = 6;
            // 
            // officerEmptyPanel
            // 
            this.officerEmptyPanel.Controls.Add(this.label14);
            this.officerEmptyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.officerEmptyPanel.Location = new System.Drawing.Point(0, 0);
            this.officerEmptyPanel.Name = "officerEmptyPanel";
            this.officerEmptyPanel.Size = new System.Drawing.Size(433, 28);
            this.officerEmptyPanel.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(204)))));
            this.label14.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(19, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(195, 18);
            this.label14.TabIndex = 1;
            this.label14.Text = "দয়া করে একজন অফিসার বাছাই করুন";
            // 
            // officerListFlowLayoutPanel
            // 
            this.officerListFlowLayoutPanel.AutoSize = true;
            this.officerListFlowLayoutPanel.ColumnCount = 1;
            this.officerListFlowLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.officerListFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.officerListFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.officerListFlowLayoutPanel.Name = "officerListFlowLayoutPanel";
            this.officerListFlowLayoutPanel.RowCount = 1;
            this.officerListFlowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.officerListFlowLayoutPanel.Size = new System.Drawing.Size(433, 0);
            this.officerListFlowLayoutPanel.TabIndex = 41;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-search-32.png");
            this.imageList1.Images.SetKeyName(1, "Repeal-alt-Hover.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search-48.png");
            this.imageList1.Images.SetKeyName(3, "icons8-double-down-50.png");
            this.imageList1.Images.SetKeyName(4, "icons8-list-48.png");
            this.imageList1.Images.SetKeyName(5, "users.png");
            // 
            // countOfficer
            // 
            this.countOfficer.AutoSize = true;
            this.countOfficer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.countOfficer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.countOfficer.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countOfficer.ForeColor = System.Drawing.Color.White;
            this.countOfficer.Location = new System.Drawing.Point(264, 97);
            this.countOfficer.Name = "countOfficer";
            this.countOfficer.Size = new System.Drawing.Size(16, 18);
            this.countOfficer.TabIndex = 41;
            this.countOfficer.Text = "০";
            // 
            // SelectOfficerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 726);
            this.Controls.Add(this.countOfficer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectOfficerForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "SelectOfficerForm";
            this.Load += new System.EventHandler(this.SelectOfficerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.searchOfficerRightPanel.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.potraJariTabPage.ResumeLayout(false);
            this.bodyTableLayoutPanel.ResumeLayout(false);
            this.bodyTableLayoutPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.bodyContentPanel.ResumeLayout(false);
            this.bodyContentPanel.PerformLayout();
            this.noKhosraPanel.ResumeLayout(false);
            this.noKhosraPanel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.officerListPanel.ResumeLayout(false);
            this.officerListPanel.PerformLayout();
            this.officerEmptyPanel.ResumeLayout(false);
            this.officerEmptyPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton sliderCrossButton;
        private System.Windows.Forms.Label sLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label countOfficer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button searchOfficerRightButton;
        private System.Windows.Forms.Panel searchOfficerRightPanel;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.ListBox searchOfficerRightListBox;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel12;
        private XTextBox searchOfficerRightXTextBox;
        private FontAwesome.Sharp.IconButton saveOfficerButton;
        private System.Windows.Forms.Panel officerListPanel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel officerEmptyPanel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label officerSearchOfficerNameLabel;
        private FontAwesome.Sharp.IconButton finalSaveButton;
        private FontAwesome.Sharp.IconButton CloseButton;
        private System.Windows.Forms.TableLayoutPanel officerListFlowLayoutPanel;
        private System.Windows.Forms.TabPage potraJariTabPage;
        private System.Windows.Forms.TableLayoutPanel bodyTableLayoutPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label perPageRowLabel;
        private System.Windows.Forms.Label totalLabel;
        private FontAwesome.Sharp.IconButton PreviousIconButton;
        private FontAwesome.Sharp.IconButton nextIconButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label listTypeLabel;
        private System.Windows.Forms.Panel bodyContentPanel;
        private System.Windows.Forms.Panel newPotrojariPanel;
        private System.Windows.Forms.TableLayoutPanel khosraListTableLayoutPanel;
        private System.Windows.Forms.Panel noKhosraPanel;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton potraJariIButton;
    }
}