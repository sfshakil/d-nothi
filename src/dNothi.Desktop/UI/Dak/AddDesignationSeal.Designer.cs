namespace dNothi.Desktop.UI.Dak
{
    partial class AddDesignationSeal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDesignationSeal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddDesignationCloseButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlLeft = new System.Windows.Forms.TabControl();
            this.ownOfficeTabPageLeft = new System.Windows.Forms.TabPage();
            this.designationStateOwnLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.prapokSearchOwnOfficeTextBox = new PlaceholderTextBox.PlaceholderTextBox();
            this.prapokownOfficeTreeView = new System.Windows.Forms.TreeView();
            this.otherOfficeTabPageLeft = new System.Windows.Forms.TabPage();
            this.searchOfficeListComboBox = new dNothi.Desktop.UI.ManuelUserControl.SearchDropdownList();
            this.panel5 = new System.Windows.Forms.Panel();
            this.otherOfficerSearchTextBox = new PlaceholderTextBox.PlaceholderTextBox();
            this.designationStateOtherLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.otherOfficeTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControlRight = new System.Windows.Forms.TabControl();
            this.ownOfficeTabPageRight = new System.Windows.Forms.TabPage();
            this.ownOfficeRightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.otherOfficeTabPageRight = new System.Windows.Forms.TabPage();
            this.otherOfficeRightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.saveDesignationSealButton = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.tabControlLeft.SuspendLayout();
            this.ownOfficeTabPageLeft.SuspendLayout();
            this.panel4.SuspendLayout();
            this.otherOfficeTabPageLeft.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControlRight.SuspendLayout();
            this.ownOfficeTabPageRight.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.otherOfficeTabPageRight.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddDesignationCloseButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 66);
            this.panel1.TabIndex = 0;
            // 
            // AddDesignationCloseButton
            // 
            this.AddDesignationCloseButton.AutoSize = true;
            this.AddDesignationCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.AddDesignationCloseButton.FlatAppearance.BorderSize = 0;
            this.AddDesignationCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddDesignationCloseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddDesignationCloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.AddDesignationCloseButton.IconColor = System.Drawing.Color.DimGray;
            this.AddDesignationCloseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AddDesignationCloseButton.IconSize = 20;
            this.AddDesignationCloseButton.Location = new System.Drawing.Point(1062, 9);
            this.AddDesignationCloseButton.Name = "AddDesignationCloseButton";
            this.AddDesignationCloseButton.Size = new System.Drawing.Size(28, 31);
            this.AddDesignationCloseButton.TabIndex = 38;
            this.AddDesignationCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddDesignationCloseButton.UseVisualStyleBackColor = false;
            this.AddDesignationCloseButton.Click += new System.EventHandler(this.AddDesignationCloseButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "প্রাপকের তালিকা তৈরি করুন";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label8.Location = new System.Drawing.Point(0, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1100, 1);
            this.label8.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "পদবি নির্বাচন করুন";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "নির্বাচিত পদসমূহ";
            // 
            // tabControlLeft
            // 
            this.tabControlLeft.Controls.Add(this.ownOfficeTabPageLeft);
            this.tabControlLeft.Controls.Add(this.otherOfficeTabPageLeft);
            this.tabControlLeft.ImageList = this.imageList1;
            this.tabControlLeft.Location = new System.Drawing.Point(19, 133);
            this.tabControlLeft.Name = "tabControlLeft";
            this.tabControlLeft.Padding = new System.Drawing.Point(8, 8);
            this.tabControlLeft.SelectedIndex = 0;
            this.tabControlLeft.Size = new System.Drawing.Size(530, 482);
            this.tabControlLeft.TabIndex = 4;
            this.tabControlLeft.SelectedIndexChanged += new System.EventHandler(this.tabControlLeft_SelectedIndexChanged);
            // 
            // ownOfficeTabPageLeft
            // 
            this.ownOfficeTabPageLeft.Controls.Add(this.designationStateOwnLabel);
            this.ownOfficeTabPageLeft.Controls.Add(this.panel4);
            this.ownOfficeTabPageLeft.Controls.Add(this.prapokownOfficeTreeView);
            this.ownOfficeTabPageLeft.ImageIndex = 1;
            this.ownOfficeTabPageLeft.Location = new System.Drawing.Point(4, 40);
            this.ownOfficeTabPageLeft.Name = "ownOfficeTabPageLeft";
            this.ownOfficeTabPageLeft.Padding = new System.Windows.Forms.Padding(3);
            this.ownOfficeTabPageLeft.Size = new System.Drawing.Size(522, 438);
            this.ownOfficeTabPageLeft.TabIndex = 0;
            this.ownOfficeTabPageLeft.Text = "নিজ অফিসের পদসমূহ";
            this.ownOfficeTabPageLeft.UseVisualStyleBackColor = true;
            // 
            // designationStateOwnLabel
            // 
            this.designationStateOwnLabel.AutoSize = true;
            this.designationStateOwnLabel.Location = new System.Drawing.Point(18, 93);
            this.designationStateOwnLabel.Name = "designationStateOwnLabel";
            this.designationStateOwnLabel.Size = new System.Drawing.Size(282, 21);
            this.designationStateOwnLabel.TabIndex = 77;
            this.designationStateOwnLabel.Text = "শাখা ০ টি, পদ ০টি, শুন্যপদ ০টি, কর্মরত ০ জন";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.prapokSearchOwnOfficeTextBox);
            this.panel4.Location = new System.Drawing.Point(18, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(310, 44);
            this.panel4.TabIndex = 76;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderBlueColor);
            // 
            // prapokSearchOwnOfficeTextBox
            // 
            this.prapokSearchOwnOfficeTextBox.BackColor = System.Drawing.Color.White;
            this.prapokSearchOwnOfficeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prapokSearchOwnOfficeTextBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prapokSearchOwnOfficeTextBox.Location = new System.Drawing.Point(10, 13);
            this.prapokSearchOwnOfficeTextBox.Name = "prapokSearchOwnOfficeTextBox";
            this.prapokSearchOwnOfficeTextBox.PlaceholderText = "প্রাপক খুঁজুন";
            this.prapokSearchOwnOfficeTextBox.Size = new System.Drawing.Size(297, 22);
            this.prapokSearchOwnOfficeTextBox.TabIndex = 3;
            this.prapokSearchOwnOfficeTextBox.TextChanged += new System.EventHandler(this.prapokSearchOwnOfficeTextBox_TextChanged);
            // 
            // prapokownOfficeTreeView
            // 
            this.prapokownOfficeTreeView.BackColor = System.Drawing.Color.White;
            this.prapokownOfficeTreeView.CheckBoxes = true;
            this.prapokownOfficeTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.prapokownOfficeTreeView.ForeColor = System.Drawing.Color.Black;
            this.prapokownOfficeTreeView.Location = new System.Drawing.Point(18, 134);
            this.prapokownOfficeTreeView.Name = "prapokownOfficeTreeView";
            this.prapokownOfficeTreeView.Size = new System.Drawing.Size(490, 301);
            this.prapokownOfficeTreeView.TabIndex = 0;
            this.prapokownOfficeTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.prapokownOfficeTreeView_BeforeCheck);
            this.prapokownOfficeTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.prapokownOfficeTreeView_AfterCheck);
            this.prapokownOfficeTreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.prapokotherOfficeTreeView_DrawNode);
            this.prapokownOfficeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.prapokownOfficeTreeView_AfterSelect);
            // 
            // otherOfficeTabPageLeft
            // 
            this.otherOfficeTabPageLeft.AutoScroll = true;
            this.otherOfficeTabPageLeft.Controls.Add(this.searchOfficeListComboBox);
            this.otherOfficeTabPageLeft.Controls.Add(this.panel5);
            this.otherOfficeTabPageLeft.Controls.Add(this.designationStateOtherLabel);
            this.otherOfficeTabPageLeft.Controls.Add(this.label10);
            this.otherOfficeTabPageLeft.Controls.Add(this.otherOfficeTreeView);
            this.otherOfficeTabPageLeft.ImageIndex = 0;
            this.otherOfficeTabPageLeft.Location = new System.Drawing.Point(4, 40);
            this.otherOfficeTabPageLeft.Name = "otherOfficeTabPageLeft";
            this.otherOfficeTabPageLeft.Padding = new System.Windows.Forms.Padding(3);
            this.otherOfficeTabPageLeft.Size = new System.Drawing.Size(522, 438);
            this.otherOfficeTabPageLeft.TabIndex = 1;
            this.otherOfficeTabPageLeft.Text = "অন্য অফিসের পদসমূহ ";
            this.otherOfficeTabPageLeft.UseVisualStyleBackColor = true;
            // 
            // searchOfficeListComboBox
            // 
            this.searchOfficeListComboBox.BackColor = System.Drawing.Color.White;
            this.searchOfficeListComboBox.Font = new System.Drawing.Font("SolaimanLipi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchOfficeListComboBox.height = 0;
            this.searchOfficeListComboBox.isListShown = false;
            this.searchOfficeListComboBox.itemList = null;
            this.searchOfficeListComboBox.Location = new System.Drawing.Point(22, 30);
            this.searchOfficeListComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchOfficeListComboBox.Name = "searchOfficeListComboBox";
            this.searchOfficeListComboBox.searchButtonText = "অফিস বাছাই করুন";
            this.searchOfficeListComboBox.selectedId = 0;
            this.searchOfficeListComboBox.Size = new System.Drawing.Size(477, 48);
            this.searchOfficeListComboBox.TabIndex = 89;
            this.searchOfficeListComboBox.ChangeSelectedIndex += new System.EventHandler(this.searchOfficeListComboBox_ChangeSelectedIndex);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.otherOfficerSearchTextBox);
            this.panel5.Location = new System.Drawing.Point(16, 249);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(310, 35);
            this.panel5.TabIndex = 88;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderBlueColor);
            // 
            // otherOfficerSearchTextBox
            // 
            this.otherOfficerSearchTextBox.BackColor = System.Drawing.Color.White;
            this.otherOfficerSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.otherOfficerSearchTextBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherOfficerSearchTextBox.Location = new System.Drawing.Point(6, 7);
            this.otherOfficerSearchTextBox.Name = "otherOfficerSearchTextBox";
            this.otherOfficerSearchTextBox.PlaceholderText = "প্রাপক খুঁজুন";
            this.otherOfficerSearchTextBox.Size = new System.Drawing.Size(297, 22);
            this.otherOfficerSearchTextBox.TabIndex = 3;
            this.otherOfficerSearchTextBox.TextChanged += new System.EventHandler(this.otherOfficerSearchTextBox_TextChanged);
            // 
            // designationStateOtherLabel
            // 
            this.designationStateOtherLabel.AutoSize = true;
            this.designationStateOtherLabel.Location = new System.Drawing.Point(18, 287);
            this.designationStateOtherLabel.Name = "designationStateOtherLabel";
            this.designationStateOtherLabel.Size = new System.Drawing.Size(282, 21);
            this.designationStateOtherLabel.TabIndex = 79;
            this.designationStateOtherLabel.Text = "শাখা ০ টি, পদ ০টি, শুন্যপদ ০টি, কর্মরত ০ জন";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(18, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 28);
            this.label10.TabIndex = 87;
            this.label10.Text = "অফিস বাছাই করুন";
            // 
            // otherOfficeTreeView
            // 
            this.otherOfficeTreeView.CheckBoxes = true;
            this.otherOfficeTreeView.Location = new System.Drawing.Point(16, 311);
            this.otherOfficeTreeView.Name = "otherOfficeTreeView";
            this.otherOfficeTreeView.Scrollable = false;
            this.otherOfficeTreeView.Size = new System.Drawing.Size(490, 319);
            this.otherOfficeTreeView.TabIndex = 78;
            this.otherOfficeTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.otherOfficeTreeView_BeforeCheck);
            this.otherOfficeTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.otherOfficeTreeView_AfterCheck);
            this.otherOfficeTreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.prapokotherOfficeTreeView_DrawNode);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-building-24.png");
            this.imageList1.Images.SetKeyName(1, "icons8-brandenburg-gate-24.png");
            // 
            // tabControlRight
            // 
            this.tabControlRight.Controls.Add(this.ownOfficeTabPageRight);
            this.tabControlRight.Controls.Add(this.otherOfficeTabPageRight);
            this.tabControlRight.ImageList = this.imageList1;
            this.tabControlRight.Location = new System.Drawing.Point(559, 133);
            this.tabControlRight.Name = "tabControlRight";
            this.tabControlRight.Padding = new System.Drawing.Point(8, 8);
            this.tabControlRight.SelectedIndex = 0;
            this.tabControlRight.Size = new System.Drawing.Size(530, 482);
            this.tabControlRight.TabIndex = 5;
            this.tabControlRight.SelectedIndexChanged += new System.EventHandler(this.tabControlRight_SelectedIndexChanged);
            // 
            // ownOfficeTabPageRight
            // 
            this.ownOfficeTabPageRight.AutoScroll = true;
            this.ownOfficeTabPageRight.Controls.Add(this.ownOfficeRightFlowLayoutPanel);
            this.ownOfficeTabPageRight.Controls.Add(this.tableLayoutPanel1);
            this.ownOfficeTabPageRight.ImageIndex = 1;
            this.ownOfficeTabPageRight.Location = new System.Drawing.Point(4, 40);
            this.ownOfficeTabPageRight.Name = "ownOfficeTabPageRight";
            this.ownOfficeTabPageRight.Padding = new System.Windows.Forms.Padding(3);
            this.ownOfficeTabPageRight.Size = new System.Drawing.Size(522, 438);
            this.ownOfficeTabPageRight.TabIndex = 0;
            this.ownOfficeTabPageRight.Text = "নিজ অফিসের পদসমূহ";
            this.ownOfficeTabPageRight.UseVisualStyleBackColor = true;
            // 
            // ownOfficeRightFlowLayoutPanel
            // 
            this.ownOfficeRightFlowLayoutPanel.AutoSize = true;
            this.ownOfficeRightFlowLayoutPanel.Location = new System.Drawing.Point(6, 46);
            this.ownOfficeRightFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ownOfficeRightFlowLayoutPanel.MaximumSize = new System.Drawing.Size(510, 0);
            this.ownOfficeRightFlowLayoutPanel.Name = "ownOfficeRightFlowLayoutPanel";
            this.ownOfficeRightFlowLayoutPanel.Size = new System.Drawing.Size(510, 0);
            this.ownOfficeRightFlowLayoutPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.27451F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.72549F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderBlueColor);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label5.Size = new System.Drawing.Size(25, 36);
            this.label5.TabIndex = 1;
            this.label5.Text = "#";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(36, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(470, 32);
            this.panel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "কর্মকর্তা";
            // 
            // otherOfficeTabPageRight
            // 
            this.otherOfficeTabPageRight.Controls.Add(this.otherOfficeRightFlowLayoutPanel);
            this.otherOfficeTabPageRight.Controls.Add(this.tableLayoutPanel2);
            this.otherOfficeTabPageRight.ImageIndex = 0;
            this.otherOfficeTabPageRight.Location = new System.Drawing.Point(4, 40);
            this.otherOfficeTabPageRight.Name = "otherOfficeTabPageRight";
            this.otherOfficeTabPageRight.Padding = new System.Windows.Forms.Padding(3);
            this.otherOfficeTabPageRight.Size = new System.Drawing.Size(522, 438);
            this.otherOfficeTabPageRight.TabIndex = 1;
            this.otherOfficeTabPageRight.Text = "অন্য অফিসের পদসমূহ ";
            this.otherOfficeTabPageRight.UseVisualStyleBackColor = true;
            // 
            // otherOfficeRightFlowLayoutPanel
            // 
            this.otherOfficeRightFlowLayoutPanel.AutoSize = true;
            this.otherOfficeRightFlowLayoutPanel.Location = new System.Drawing.Point(6, 47);
            this.otherOfficeRightFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.otherOfficeRightFlowLayoutPanel.MaximumSize = new System.Drawing.Size(510, 0);
            this.otherOfficeRightFlowLayoutPanel.Name = "otherOfficeRightFlowLayoutPanel";
            this.otherOfficeRightFlowLayoutPanel.Size = new System.Drawing.Size(510, 0);
            this.otherOfficeRightFlowLayoutPanel.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.27451F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.72549F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 7);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(510, 40);
            this.tableLayoutPanel2.TabIndex = 2;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderBlueColor);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label6.Size = new System.Drawing.Size(25, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "#";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(36, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 11);
            this.panel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "কর্মকর্তা";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label11.Location = new System.Drawing.Point(-7, 617);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1108, 1);
            this.label11.TabIndex = 35;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Transparent;
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1100, 733);
            this.metroPanel1.TabIndex = 40;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSize = true;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(78)))), ((int)(((byte)(96)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.Location = new System.Drawing.Point(967, 621);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(118, 48);
            this.iconButton1.TabIndex = 37;
            this.iconButton1.Text = "বন্ধ করুন";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.AddDesignationCloseButton_Click);
            // 
            // saveDesignationSealButton
            // 
            this.saveDesignationSealButton.AutoSize = true;
            this.saveDesignationSealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.saveDesignationSealButton.FlatAppearance.BorderSize = 0;
            this.saveDesignationSealButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveDesignationSealButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveDesignationSealButton.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            this.saveDesignationSealButton.IconColor = System.Drawing.Color.White;
            this.saveDesignationSealButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveDesignationSealButton.IconSize = 32;
            this.saveDesignationSealButton.Location = new System.Drawing.Point(847, 621);
            this.saveDesignationSealButton.Name = "saveDesignationSealButton";
            this.saveDesignationSealButton.Size = new System.Drawing.Size(131, 48);
            this.saveDesignationSealButton.TabIndex = 36;
            this.saveDesignationSealButton.Text = "সংরক্ষণ করুন";
            this.saveDesignationSealButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveDesignationSealButton.UseVisualStyleBackColor = false;
            this.saveDesignationSealButton.Click += new System.EventHandler(this.saveDesignationSealButton_Click);
            // 
            // AddDesignationSeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 733);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.saveDesignationSealButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControlRight);
            this.Controls.Add(this.tabControlLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroPanel1);
            this.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddDesignationSeal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDesignationSeal";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlLeft.ResumeLayout(false);
            this.ownOfficeTabPageLeft.ResumeLayout(false);
            this.ownOfficeTabPageLeft.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.otherOfficeTabPageLeft.ResumeLayout(false);
            this.otherOfficeTabPageLeft.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabControlRight.ResumeLayout(false);
            this.ownOfficeTabPageRight.ResumeLayout(false);
            this.ownOfficeTabPageRight.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.otherOfficeTabPageRight.ResumeLayout(false);
            this.otherOfficeTabPageRight.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControlLeft;
        private System.Windows.Forms.TabPage ownOfficeTabPageLeft;
        private System.Windows.Forms.TabPage otherOfficeTabPageLeft;
        private System.Windows.Forms.TabControl tabControlRight;
        private System.Windows.Forms.TabPage ownOfficeTabPageRight;
        private System.Windows.Forms.TabPage otherOfficeTabPageRight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel ownOfficeRightFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel otherOfficeRightFlowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView prapokownOfficeTreeView;
        private System.Windows.Forms.Panel panel4;
        private PlaceholderTextBox.PlaceholderTextBox prapokSearchOwnOfficeTextBox;
        private System.Windows.Forms.Label designationStateOwnLabel;
        private System.Windows.Forms.Label designationStateOtherLabel;
        private System.Windows.Forms.TreeView otherOfficeTreeView;
        private System.Windows.Forms.Label label10;
        private FontAwesome.Sharp.IconButton saveDesignationSealButton;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.ImageList imageList1;
        private FontAwesome.Sharp.IconButton AddDesignationCloseButton;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Panel panel5;
        private PlaceholderTextBox.PlaceholderTextBox otherOfficerSearchTextBox;
        private ManuelUserControl.SearchDropdownList searchOfficeListComboBox;
    }
}