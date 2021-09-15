using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    partial class DakTagForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ফোল্ডার");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.HeadingPanel = new System.Windows.Forms.Panel();
            this.sliderCrossButton = new FontAwesome.Sharp.IconButton();
            this.singleDakHeaderLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dakSubLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.bodyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.personalFolderTreeView = new System.Windows.Forms.TreeView();
            this.MyImageList = new System.Windows.Forms.ImageList(this.components);
            this.tagButton = new FontAwesome.Sharp.IconButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.HeadingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.bodyTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeadingPanel
            // 
            this.HeadingPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HeadingPanel.Controls.Add(this.sliderCrossButton);
            this.HeadingPanel.Controls.Add(this.singleDakHeaderLabel);
            this.HeadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeadingPanel.Location = new System.Drawing.Point(20, 0);
            this.HeadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeadingPanel.Name = "HeadingPanel";
            this.HeadingPanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.HeadingPanel.Size = new System.Drawing.Size(510, 69);
            this.HeadingPanel.TabIndex = 38;
            // 
            // sliderCrossButton
            // 
            this.sliderCrossButton.BackColor = System.Drawing.Color.White;
            this.sliderCrossButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.sliderCrossButton.FlatAppearance.BorderSize = 0;
            this.sliderCrossButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sliderCrossButton.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.sliderCrossButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sliderCrossButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.sliderCrossButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.sliderCrossButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.sliderCrossButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.sliderCrossButton.IconSize = 18;
            this.sliderCrossButton.Location = new System.Drawing.Point(486, 25);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.MaximumSize = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(24, 32);
            this.sliderCrossButton.TabIndex = 38;
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            this.sliderCrossButton.Click += new System.EventHandler(this.sliderCrossButton_Click);
            // 
            // singleDakHeaderLabel
            // 
            this.singleDakHeaderLabel.AutoSize = true;
            this.singleDakHeaderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.singleDakHeaderLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleDakHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.singleDakHeaderLabel.Location = new System.Drawing.Point(0, 25);
            this.singleDakHeaderLabel.Name = "singleDakHeaderLabel";
            this.singleDakHeaderLabel.Size = new System.Drawing.Size(203, 30);
            this.singleDakHeaderLabel.TabIndex = 28;
            this.singleDakHeaderLabel.Text = "ব্যক্তিগত ফোল্ডারসমূহ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dakSubLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.searchPanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.HeadingPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bodyTableLayoutPanel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tagButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 50);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 726);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // dakSubLabel
            // 
            this.dakSubLabel.AutoSize = true;
            this.dakSubLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.dakSubLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dakSubLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dakSubLabel.Location = new System.Drawing.Point(23, 69);
            this.dakSubLabel.Name = "dakSubLabel";
            this.dakSubLabel.Size = new System.Drawing.Size(226, 30);
            this.dakSubLabel.TabIndex = 41;
            this.dakSubLabel.Text = "খসড়া অফিস স্মারক চেক";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(167)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(23, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "আপনি মোট (0) টি ফোল্ডার খুজে পেয়েছেন";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchTextBox);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(23, 148);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(504, 40);
            this.searchPanel.TabIndex = 0;
            this.searchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BlueBorder);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(8, 10);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(487, 27);
            this.searchTextBox.TabIndex = 100;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // bodyTableLayoutPanel
            // 
            this.bodyTableLayoutPanel.AutoScroll = true;
            this.bodyTableLayoutPanel.ColumnCount = 1;
            this.bodyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayoutPanel.Controls.Add(this.personalFolderTreeView, 0, 1);
            this.bodyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayoutPanel.Location = new System.Drawing.Point(23, 230);
            this.bodyTableLayoutPanel.Name = "bodyTableLayoutPanel";
            this.bodyTableLayoutPanel.Padding = new System.Windows.Forms.Padding(1);
            this.bodyTableLayoutPanel.RowCount = 2;
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 449F));
            this.bodyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bodyTableLayoutPanel.Size = new System.Drawing.Size(504, 443);
            this.bodyTableLayoutPanel.TabIndex = 40;
            this.bodyTableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BlueBorder);
            // 
            // personalFolderTreeView
            // 
            this.personalFolderTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.personalFolderTreeView.CheckBoxes = true;
            this.personalFolderTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personalFolderTreeView.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalFolderTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(92)))), ((int)(((byte)(110)))));
            this.personalFolderTreeView.ImageIndex = 0;
            this.personalFolderTreeView.ImageList = this.MyImageList;
            this.personalFolderTreeView.Location = new System.Drawing.Point(6, 6);
            this.personalFolderTreeView.Margin = new System.Windows.Forms.Padding(5);
            this.personalFolderTreeView.Name = "personalFolderTreeView";
            treeNode1.Name = "privateNode";
            treeNode1.Tag = "0";
            treeNode1.Text = "ফোল্ডার";
            this.personalFolderTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.personalFolderTreeView.SelectedImageIndex = 0;
            this.personalFolderTreeView.Size = new System.Drawing.Size(482, 439);
            this.personalFolderTreeView.TabIndex = 1;
            this.personalFolderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.personalFolderTreeView_AfterSelect);
            this.personalFolderTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.personalFolderTreeView_NodeMouseClick);
            this.personalFolderTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.personalFolderTreeView_MouseClick);
            // 
            // MyImageList
            // 
            this.MyImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.MyImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.MyImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tagButton
            // 
            this.tagButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(80)))), ((int)(((byte)(252)))));
            this.tagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tagButton.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(80)))), ((int)(((byte)(252)))));
            this.tagButton.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.tagButton.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(80)))), ((int)(((byte)(252)))));
            this.tagButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.tagButton.IconSize = 36;
            this.tagButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tagButton.Location = new System.Drawing.Point(23, 102);
            this.tagButton.Name = "tagButton";
            this.tagButton.Size = new System.Drawing.Size(118, 40);
            this.tagButton.TabIndex = 42;
            this.tagButton.Text = "ট্যাগ করুন";
            this.tagButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tagButton.UseVisualStyleBackColor = true;
            this.tagButton.Click += new System.EventHandler(this.tagButton_Click);
            this.tagButton.MouseLeave += new System.EventHandler(this.tagButton_MouseLeave);
            this.tagButton.MouseHover += new System.EventHandler(this.tagButton_MouseHover);
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewImageColumn1.HeaderText = "+";
            this.dataGridViewImageColumn1.Image = global::dNothi.Desktop.Properties.Resources.delete;
            this.dataGridViewImageColumn1.MinimumWidth = 2;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 27;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewImageColumn2.HeaderText = "+";
            this.dataGridViewImageColumn2.Image = global::dNothi.Desktop.Properties.Resources.delete;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 23;
            // 
            // DakTagForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 726);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DakTagForm";
            this.Load += new System.EventHandler(this.DakFolderForm_Load);
            this.HeadingPanel.ResumeLayout(false);
            this.HeadingPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.bodyTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }





        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.Panel HeadingPanel;
        private System.Windows.Forms.Label singleDakHeaderLabel;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private FontAwesome.Sharp.IconButton sliderCrossButton;
        private DataGridViewRadioButtonElements.DataGridViewRadioButtonColumn mul_prapok;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel bodyTableLayoutPanel;
        private Panel searchPanel;
        private Label label1;
        private TextBox searchTextBox;
        private TreeView personalFolderTreeView;
        private ImageList MyImageList;
        private Label dakSubLabel;
        private FontAwesome.Sharp.IconButton tagButton;
    }
}