namespace dNothi.Desktop.UI.NothiUI
{
    partial class NothiMasterRegisterReportUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NothiMasterRegisterReportUserControl));
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.dateRangeTextBox = new System.Windows.Forms.Panel();
            this.pageNextButton = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.totalRowlabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTextBox = new PlaceholderTextBox.PlaceholderTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dakPriorityComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.headlineLabel = new System.Windows.Forms.Label();
            this.bodyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fileWebBrowser = new System.Windows.Forms.WebBrowser();
            this.noRowMessageLabel = new System.Windows.Forms.Label();
            this.customDatePicker = new dNothi.Desktop.UI.ManuelUserControl.DakCustomDatePickerUserControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.nothiPrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.perPageRowLabel = new System.Windows.Forms.Label();
            this.dateRangeTextBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.panel7.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.bodyTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton2.IconSize = 24;
            this.iconButton2.Location = new System.Drawing.Point(823, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(45, 41);
            this.iconButton2.TabIndex = 69;
            this.MyToolTip.SetToolTip(this.iconButton2, "এক্সেল");
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(194)))), ((int)(((byte)(187)))));
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton1.IconSize = 24;
            this.iconButton1.Location = new System.Drawing.Point(868, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(45, 41);
            this.iconButton1.TabIndex = 68;
            this.MyToolTip.SetToolTip(this.iconButton1, "পিডিএফ");
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dateRangeTextBox
            // 
            this.dateRangeTextBox.Controls.Add(this.perPageRowLabel);
            this.dateRangeTextBox.Controls.Add(this.pageNextButton);
            this.dateRangeTextBox.Controls.Add(this.iconButton3);
            this.dateRangeTextBox.Controls.Add(this.totalRowlabel);
            this.dateRangeTextBox.Controls.Add(this.panel3);
            this.dateRangeTextBox.Controls.Add(this.panel7);
            this.dateRangeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateRangeTextBox.Location = new System.Drawing.Point(0, 41);
            this.dateRangeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.dateRangeTextBox.Name = "dateRangeTextBox";
            this.dateRangeTextBox.Size = new System.Drawing.Size(913, 55);
            this.dateRangeTextBox.TabIndex = 95;
            // 
            // pageNextButton
            // 
            this.pageNextButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pageNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pageNextButton.FlatAppearance.BorderSize = 0;
            this.pageNextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.pageNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageNextButton.IconChar = FontAwesome.Sharp.IconChar.ChevronRight;
            this.pageNextButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.pageNextButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pageNextButton.IconSize = 24;
            this.pageNextButton.Location = new System.Drawing.Point(875, 9);
            this.pageNextButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pageNextButton.Name = "pageNextButton";
            this.pageNextButton.Size = new System.Drawing.Size(34, 34);
            this.pageNextButton.TabIndex = 99;
            this.pageNextButton.UseVisualStyleBackColor = false;
            this.pageNextButton.Click += new System.EventHandler(this.pageNextButton_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ChevronLeft;
            this.iconButton3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 24;
            this.iconButton3.Location = new System.Drawing.Point(841, 9);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(34, 34);
            this.iconButton3.TabIndex = 98;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // totalRowlabel
            // 
            this.totalRowlabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalRowlabel.AutoSize = true;
            this.totalRowlabel.BackColor = System.Drawing.Color.Transparent;
            this.totalRowlabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRowlabel.Location = new System.Drawing.Point(749, 18);
            this.totalRowlabel.Name = "totalRowlabel";
            this.totalRowlabel.Size = new System.Drawing.Size(79, 18);
            this.totalRowlabel.TabIndex = 97;
            this.totalRowlabel.Text = "সর্বমোট ৮১ টি";
            this.totalRowlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.Controls.Add(this.dateTextBox);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(274, 9);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(269, 35);
            this.panel3.TabIndex = 95;
            this.panel3.Click += new System.EventHandler(this.dateRangePickerShow);
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color_Blue);
            // 
            // dateTextBox
            // 
            this.dateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTextBox.BackColor = System.Drawing.Color.White;
            this.dateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTextBox.Location = new System.Drawing.Point(98, 8);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.PlaceholderText = "সময়সীমা";
            this.dateTextBox.Size = new System.Drawing.Size(165, 19);
            this.dateTextBox.TabIndex = 95;
            this.dateTextBox.Click += new System.EventHandler(this.dateRangePickerShow);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.iconPictureBox2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(93, 33);
            this.panel4.TabIndex = 94;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.Highlight;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 24;
            this.iconPictureBox2.Location = new System.Drawing.Point(67, 0);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(24, 33);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox2.TabIndex = 93;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.dateRangePickerShow);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 33);
            this.label2.TabIndex = 92;
            this.label2.Text = "সময়সীমা";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.dateRangePickerShow);
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel7.Controls.Add(this.dakPriorityComboBox);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(10, 9);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(250, 35);
            this.panel7.TabIndex = 94;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color_Blue);
            // 
            // dakPriorityComboBox
            // 
            this.dakPriorityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dakPriorityComboBox.DropDownHeight = 110;
            this.dakPriorityComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dakPriorityComboBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dakPriorityComboBox.FormattingEnabled = true;
            this.dakPriorityComboBox.IntegralHeight = false;
            this.dakPriorityComboBox.Location = new System.Drawing.Point(72, 4);
            this.dakPriorityComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.dakPriorityComboBox.Name = "dakPriorityComboBox";
            this.dakPriorityComboBox.Size = new System.Drawing.Size(174, 26);
            this.dakPriorityComboBox.TabIndex = 91;
            this.dakPriorityComboBox.SelectedIndexChanged += new System.EventHandler(this.dakPriorityComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 33);
            this.label1.TabIndex = 92;
            this.label1.Text = "শাখা";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            this.headerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(243)))), ((int)(((byte)(253)))));
            this.headerPanel.Controls.Add(this.iconButton2);
            this.headerPanel.Controls.Add(this.iconButton1);
            this.headerPanel.Controls.Add(this.iconPictureBox1);
            this.headerPanel.Controls.Add(this.headlineLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(913, 41);
            this.headerPanel.TabIndex = 1;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(243)))), ((int)(((byte)(253)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(194)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(194)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 30;
            this.iconPictureBox1.Location = new System.Drawing.Point(8, 5);
            this.iconPictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(35, 30);
            this.iconPictureBox1.TabIndex = 67;
            this.iconPictureBox1.TabStop = false;
            // 
            // headlineLabel
            // 
            this.headlineLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.headlineLabel.AutoSize = true;
            this.headlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.headlineLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headlineLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.headlineLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.headlineLabel.Location = new System.Drawing.Point(44, 9);
            this.headlineLabel.Name = "headlineLabel";
            this.headlineLabel.Size = new System.Drawing.Size(86, 21);
            this.headlineLabel.TabIndex = 66;
            this.headlineLabel.Text = "মাস্টার ফাইল";
            this.headlineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bodyTableLayoutPanel
            // 
            this.bodyTableLayoutPanel.AutoSize = true;
            this.bodyTableLayoutPanel.ColumnCount = 1;
            this.bodyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayoutPanel.Controls.Add(this.headerPanel, 0, 0);
            this.bodyTableLayoutPanel.Controls.Add(this.dateRangeTextBox, 0, 1);
            this.bodyTableLayoutPanel.Controls.Add(this.fileWebBrowser, 0, 3);
            this.bodyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyTableLayoutPanel.Name = "bodyTableLayoutPanel";
            this.bodyTableLayoutPanel.RowCount = 4;
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayoutPanel.Size = new System.Drawing.Size(913, 584);
            this.bodyTableLayoutPanel.TabIndex = 0;
            // 
            // fileWebBrowser
            // 
            this.fileWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileWebBrowser.Location = new System.Drawing.Point(10, 96);
            this.fileWebBrowser.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.fileWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.fileWebBrowser.Name = "fileWebBrowser";
            this.fileWebBrowser.Size = new System.Drawing.Size(893, 488);
            this.fileWebBrowser.TabIndex = 97;
            this.fileWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // noRowMessageLabel
            // 
            this.noRowMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noRowMessageLabel.AutoSize = true;
            this.noRowMessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.noRowMessageLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noRowMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.noRowMessageLabel.Location = new System.Drawing.Point(404, 215);
            this.noRowMessageLabel.Name = "noRowMessageLabel";
            this.noRowMessageLabel.Size = new System.Drawing.Size(169, 18);
            this.noRowMessageLabel.TabIndex = 97;
            this.noRowMessageLabel.Text = "দুঃখিত কোন তথ্য পাওয়া যায় নি।";
            this.noRowMessageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customDatePicker
            // 
            this.customDatePicker._date = null;
            this.customDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.customDatePicker.AutoSize = true;
            this.customDatePicker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customDatePicker.BackColor = System.Drawing.Color.White;
            this.customDatePicker.dateFrom = new System.DateTime(((long)(0)));
            this.customDatePicker.dateTo = new System.DateTime(((long)(0)));
            this.customDatePicker.Location = new System.Drawing.Point(372, 82);
            this.customDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.customDatePicker.Name = "customDatePicker";
            this.customDatePicker.Size = new System.Drawing.Size(152, 230);
            this.customDatePicker.TabIndex = 59;
            this.customDatePicker.Visible = false;
            this.customDatePicker.OptionClick += new System.EventHandler(this.customDatePicker_OptionClick);
            // 
            // nothiPrintPreviewDialog
            // 
            this.nothiPrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.nothiPrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.nothiPrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.nothiPrintPreviewDialog.Document = this.printDocument1;
            this.nothiPrintPreviewDialog.Enabled = true;
            this.nothiPrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("nothiPrintPreviewDialog.Icon")));
            this.nothiPrintPreviewDialog.Name = "dakUploadPrintPreviewDialog";
            this.nothiPrintPreviewDialog.Visible = false;
            // 
            // perPageRowLabel
            // 
            this.perPageRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perPageRowLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.perPageRowLabel.Location = new System.Drawing.Point(641, 7);
            this.perPageRowLabel.Name = "perPageRowLabel";
            this.perPageRowLabel.Size = new System.Drawing.Size(100, 39);
            this.perPageRowLabel.TabIndex = 100;
            this.perPageRowLabel.Text = "১ - ১২";
            this.perPageRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NothiMasterRegisterReportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.customDatePicker);
            this.Controls.Add(this.noRowMessageLabel);
            this.Controls.Add(this.bodyTableLayoutPanel);
            this.Name = "NothiMasterRegisterReportUserControl";
            this.Size = new System.Drawing.Size(913, 584);
            this.Load += new System.EventHandler(this.RegisterReportUserControl_Load);
            this.dateRangeTextBox.ResumeLayout(false);
            this.dateRangeTextBox.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.panel7.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.bodyTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip MyToolTip;
        private ManuelUserControl.DakCustomDatePickerUserControl customDatePicker;
        private System.Windows.Forms.Panel dateRangeTextBox;
        private FontAwesome.Sharp.IconButton pageNextButton;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.Label totalRowlabel;
        private System.Windows.Forms.Panel panel3;
        private PlaceholderTextBox.PlaceholderTextBox dateTextBox;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox dakPriorityComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel headerPanel;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label headlineLabel;
        private System.Windows.Forms.TableLayoutPanel bodyTableLayoutPanel;
        private System.Windows.Forms.Label noRowMessageLabel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog nothiPrintPreviewDialog;
        private System.Windows.Forms.WebBrowser fileWebBrowser;
        private System.Windows.Forms.Label perPageRowLabel;
    }
}
