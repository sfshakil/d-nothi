namespace dNothi.Desktop.UI.ReportUI
{
    partial class UCAnumatiPraptaUserLis
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
            this.guardFileListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listTypeLabel = new System.Windows.Forms.Label();
            this.iconButton = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.searchHeaderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.searchBoxPanel = new System.Windows.Forms.Panel();
            this.dakSearchSubTextBox = new PlaceholderTextBox.PlaceholderTextBox();
            this.recycleIconButton = new FontAwesome.Sharp.IconButton();
            this.dakSearchUsingTextButton = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.perPageRowLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.PreviousIconButton = new FontAwesome.Sharp.IconButton();
            this.nextIconButton = new FontAwesome.Sharp.IconButton();
            this.guardFileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.typesearchComboBox = new dNothi.Desktop.UI.ManuelUserControl.SearchComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guardFileListTableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.searchHeaderTableLayoutPanel.SuspendLayout();
            this.searchBoxPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.guardFileTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // guardFileListTableLayoutPanel
            // 
            this.guardFileListTableLayoutPanel.AutoSize = true;
            this.guardFileListTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.guardFileListTableLayoutPanel.ColumnCount = 1;
            this.guardFileListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.guardFileListTableLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this.guardFileListTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.guardFileListTableLayoutPanel.Controls.Add(this.guardFileTableLayoutPanel, 0, 2);
            this.guardFileListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guardFileListTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.guardFileListTableLayoutPanel.Name = "guardFileListTableLayoutPanel";
            this.guardFileListTableLayoutPanel.RowCount = 3;
            this.guardFileListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.guardFileListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.guardFileListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.guardFileListTableLayoutPanel.Size = new System.Drawing.Size(907, 146);
            this.guardFileListTableLayoutPanel.TabIndex = 89;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.listTypeLabel);
            this.panel1.Controls.Add(this.iconButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 51);
            this.panel1.TabIndex = 88;
            // 
            // listTypeLabel
            // 
            this.listTypeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.listTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(70)))), ((int)(((byte)(117)))));
            this.listTypeLabel.Location = new System.Drawing.Point(42, 0);
            this.listTypeLabel.Name = "listTypeLabel";
            this.listTypeLabel.Size = new System.Drawing.Size(415, 51);
            this.listTypeLabel.TabIndex = 37;
            this.listTypeLabel.Text = "রিপোর্ট মডুলে অনুমতিপ্রাপ্তদের তালিকা";
            this.listTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconButton
            // 
            this.iconButton.BackColor = System.Drawing.Color.Transparent;
            this.iconButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton.FlatAppearance.BorderSize = 0;
            this.iconButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.iconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.iconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(78)))), ((int)(((byte)(126)))));
            this.iconButton.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(195)))));
            this.iconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton.IconSize = 24;
            this.iconButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton.Location = new System.Drawing.Point(0, 0);
            this.iconButton.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton.Name = "iconButton";
            this.iconButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.iconButton.Size = new System.Drawing.Size(42, 51);
            this.iconButton.TabIndex = 36;
            this.iconButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.searchHeaderTableLayoutPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 49);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // searchHeaderTableLayoutPanel
            // 
            this.searchHeaderTableLayoutPanel.ColumnCount = 3;
            this.searchHeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchHeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchHeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchHeaderTableLayoutPanel.Controls.Add(this.searchBoxPanel, 0, 0);
            this.searchHeaderTableLayoutPanel.Controls.Add(this.recycleIconButton, 2, 0);
            this.searchHeaderTableLayoutPanel.Controls.Add(this.dakSearchUsingTextButton, 1, 0);
            this.searchHeaderTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchHeaderTableLayoutPanel.Location = new System.Drawing.Point(360, 0);
            this.searchHeaderTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.searchHeaderTableLayoutPanel.Name = "searchHeaderTableLayoutPanel";
            this.searchHeaderTableLayoutPanel.RowCount = 1;
            this.searchHeaderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchHeaderTableLayoutPanel.Size = new System.Drawing.Size(270, 49);
            this.searchHeaderTableLayoutPanel.TabIndex = 112;
            // 
            // searchBoxPanel
            // 
            this.searchBoxPanel.AutoSize = true;
            this.searchBoxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.searchBoxPanel.Controls.Add(this.dakSearchSubTextBox);
            this.searchBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.searchBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.searchBoxPanel.Name = "searchBoxPanel";
            this.searchBoxPanel.Size = new System.Drawing.Size(201, 49);
            this.searchBoxPanel.TabIndex = 4;
            this.searchBoxPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.searchBoxPanel_Paint);
            // 
            // dakSearchSubTextBox
            // 
            this.dakSearchSubTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dakSearchSubTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.dakSearchSubTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dakSearchSubTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dakSearchSubTextBox.Location = new System.Drawing.Point(19, 11);
            this.dakSearchSubTextBox.Name = "dakSearchSubTextBox";
            this.dakSearchSubTextBox.PlaceholderText = "নাম দিয়ে খুঁজুন";
            this.dakSearchSubTextBox.Size = new System.Drawing.Size(133, 19);
            this.dakSearchSubTextBox.TabIndex = 3;
            // 
            // recycleIconButton
            // 
            this.recycleIconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.recycleIconButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.recycleIconButton.FlatAppearance.BorderSize = 0;
            this.recycleIconButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.recycleIconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.recycleIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recycleIconButton.IconChar = FontAwesome.Sharp.IconChar.Recycle;
            this.recycleIconButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.recycleIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.recycleIconButton.IconSize = 24;
            this.recycleIconButton.Location = new System.Drawing.Point(235, 0);
            this.recycleIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.recycleIconButton.Name = "recycleIconButton";
            this.recycleIconButton.Size = new System.Drawing.Size(35, 49);
            this.recycleIconButton.TabIndex = 29;
            this.recycleIconButton.UseVisualStyleBackColor = false;
            this.recycleIconButton.Click += new System.EventHandler(this.recycleIconButton_Click);
            // 
            // dakSearchUsingTextButton
            // 
            this.dakSearchUsingTextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.dakSearchUsingTextButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dakSearchUsingTextButton.FlatAppearance.BorderSize = 0;
            this.dakSearchUsingTextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(204)))), ((int)(((byte)(198)))));
            this.dakSearchUsingTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dakSearchUsingTextButton.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.dakSearchUsingTextButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
            this.dakSearchUsingTextButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dakSearchUsingTextButton.IconSize = 32;
            this.dakSearchUsingTextButton.Location = new System.Drawing.Point(201, 0);
            this.dakSearchUsingTextButton.Margin = new System.Windows.Forms.Padding(0);
            this.dakSearchUsingTextButton.Name = "dakSearchUsingTextButton";
            this.dakSearchUsingTextButton.Size = new System.Drawing.Size(34, 49);
            this.dakSearchUsingTextButton.TabIndex = 30;
            this.dakSearchUsingTextButton.UseVisualStyleBackColor = false;
            this.dakSearchUsingTextButton.Click += new System.EventHandler(this.dakSearchUsingTextButton_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel2.Size = new System.Drawing.Size(360, 49);
            this.panel2.TabIndex = 89;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.perPageRowLabel);
            this.panel3.Controls.Add(this.totalLabel);
            this.panel3.Controls.Add(this.PreviousIconButton);
            this.panel3.Controls.Add(this.nextIconButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(630, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel3.Size = new System.Drawing.Size(271, 49);
            this.panel3.TabIndex = 88;
            // 
            // perPageRowLabel
            // 
            this.perPageRowLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.perPageRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perPageRowLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.perPageRowLabel.Location = new System.Drawing.Point(23, 0);
            this.perPageRowLabel.Name = "perPageRowLabel";
            this.perPageRowLabel.Size = new System.Drawing.Size(100, 49);
            this.perPageRowLabel.TabIndex = 37;
            this.perPageRowLabel.Text = "১ - ১২";
            this.perPageRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalLabel
            // 
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.totalLabel.Location = new System.Drawing.Point(123, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(75, 49);
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
            this.PreviousIconButton.Location = new System.Drawing.Point(198, 0);
            this.PreviousIconButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.PreviousIconButton.Name = "PreviousIconButton";
            this.PreviousIconButton.Size = new System.Drawing.Size(34, 49);
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
            this.nextIconButton.Location = new System.Drawing.Point(232, 0);
            this.nextIconButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.nextIconButton.Name = "nextIconButton";
            this.nextIconButton.Size = new System.Drawing.Size(34, 49);
            this.nextIconButton.TabIndex = 35;
            this.nextIconButton.UseVisualStyleBackColor = false;
            this.nextIconButton.Click += new System.EventHandler(this.nextIconButton_Click);
            // 
            // guardFileTableLayoutPanel
            // 
            this.guardFileTableLayoutPanel.AutoSize = true;
            this.guardFileTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.guardFileTableLayoutPanel.ColumnCount = 3;
            this.guardFileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.guardFileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.guardFileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.guardFileTableLayoutPanel.Controls.Add(this.label11, 2, 0);
            this.guardFileTableLayoutPanel.Controls.Add(this.label10, 1, 0);
            this.guardFileTableLayoutPanel.Controls.Add(this.label9, 0, 0);
            this.guardFileTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guardFileTableLayoutPanel.Location = new System.Drawing.Point(3, 109);
            this.guardFileTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.guardFileTableLayoutPanel.Name = "guardFileTableLayoutPanel";
            this.guardFileTableLayoutPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.guardFileTableLayoutPanel.RowCount = 1;
            this.guardFileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.guardFileTableLayoutPanel.Size = new System.Drawing.Size(901, 37);
            this.guardFileTableLayoutPanel.TabIndex = 87;
            this.guardFileTableLayoutPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.Table_Border_Cell_Color_Blue);
            this.guardFileTableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Table_Border_Color_Blue);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(720, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(1);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label11.Size = new System.Drawing.Size(177, 46);
            this.label11.TabIndex = 3;
            this.label11.Text = "কার্যক্রম";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(362, 1);
            this.label10.Margin = new System.Windows.Forms.Padding(1);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label10.Size = new System.Drawing.Size(356, 46);
            this.label10.TabIndex = 2;
            this.label10.Text = "নাম";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 1);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label9.Size = new System.Drawing.Size(356, 46);
            this.label9.TabIndex = 1;
            this.label9.Text = "ধরণ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typesearchComboBox
            // 
            this.typesearchComboBox.AutoSize = true;
            this.typesearchComboBox.BackColor = System.Drawing.Color.White;
            this.typesearchComboBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typesearchComboBox.isListShown = false;
            this.typesearchComboBox.itemList = null;
            this.typesearchComboBox.Location = new System.Drawing.Point(11, 56);
            this.typesearchComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typesearchComboBox.MinimumSize = new System.Drawing.Size(120, 0);
            this.typesearchComboBox.Name = "typesearchComboBox";
            this.typesearchComboBox.searchButtonText = "ধরণ বাছাই করুন";
            this.typesearchComboBox.selectedId = 0;
            this.typesearchComboBox.Size = new System.Drawing.Size(307, 44);
            this.typesearchComboBox.TabIndex = 1;
            this.typesearchComboBox.ChangeSelectedIndex += new System.EventHandler(this.typesearchComboBox_ChangeSelectedIndex);
            this.typesearchComboBox.Load += new System.EventHandler(this.typesearchComboBox_Load);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "type";
            this.dataGridViewTextBoxColumn1.HeaderText = "ধরন";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "typeNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "নাম";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // UCAnumatiPraptaUserLis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.typesearchComboBox);
            this.Controls.Add(this.guardFileListTableLayoutPanel);
            this.Name = "UCAnumatiPraptaUserLis";
            this.Size = new System.Drawing.Size(907, 146);
            this.Load += new System.EventHandler(this.UCGuardFileList_Load);
            this.guardFileListTableLayoutPanel.ResumeLayout(false);
            this.guardFileListTableLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.searchHeaderTableLayoutPanel.ResumeLayout(false);
            this.searchHeaderTableLayoutPanel.PerformLayout();
            this.searchBoxPanel.ResumeLayout(false);
            this.searchBoxPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.guardFileTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TableLayoutPanel guardFileListTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel guardFileTableLayoutPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label totalLabel;
        private FontAwesome.Sharp.IconButton PreviousIconButton;
        private FontAwesome.Sharp.IconButton nextIconButton;
        private System.Windows.Forms.Label perPageRowLabel;
        private ManuelUserControl.SearchComboBox typesearchComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel searchHeaderTableLayoutPanel;
        private System.Windows.Forms.Panel searchBoxPanel;
        private PlaceholderTextBox.PlaceholderTextBox dakSearchSubTextBox;
        private FontAwesome.Sharp.IconButton recycleIconButton;
        private FontAwesome.Sharp.IconButton dakSearchUsingTextButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label listTypeLabel;
        private FontAwesome.Sharp.IconButton iconButton;
    }
}
