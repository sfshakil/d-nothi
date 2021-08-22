using System;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    partial class UserProfileForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Subjectlabel = new System.Windows.Forms.Label();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.HeadingPanel = new System.Windows.Forms.Panel();
            this.sliderCrossButton = new FontAwesome.Sharp.IconButton();
            this.singleDakHeaderLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.attachmentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.designationListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.joiningDateLabel = new System.Windows.Forms.Label();
            this.mobileLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.birthCertificate = new System.Windows.Forms.Label();
            this.nationalIdLabel = new System.Windows.Forms.Label();
            this.dateofBirthLabel = new System.Windows.Forms.Label();
            this.motherNameLabel = new System.Windows.Forms.Label();
            this.fatherNameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.signatureIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.profileUpdateButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userImageBox = new FontAwesome.Sharp.IconPictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.HeadingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.attachmentTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signatureIconPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Subjectlabel
            // 
            this.Subjectlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Subjectlabel.AutoSize = true;
            this.Subjectlabel.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subjectlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(210)))));
            this.Subjectlabel.Location = new System.Drawing.Point(3, 6);
            this.Subjectlabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.Subjectlabel.Name = "Subjectlabel";
            this.Subjectlabel.Size = new System.Drawing.Size(149, 27);
            this.Subjectlabel.TabIndex = 0;
            this.Subjectlabel.Text = "User লগইন তথ্য";
            this.Subjectlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.HeadingPanel.Size = new System.Drawing.Size(579, 61);
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
            this.sliderCrossButton.Location = new System.Drawing.Point(555, 25);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.MaximumSize = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(24, 32);
            this.sliderCrossButton.TabIndex = 38;
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            this.sliderCrossButton.Click += new System.EventHandler(this.closeButtonClick);
            // 
            // singleDakHeaderLabel
            // 
            this.singleDakHeaderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.singleDakHeaderLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleDakHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.singleDakHeaderLabel.Location = new System.Drawing.Point(0, 25);
            this.singleDakHeaderLabel.Name = "singleDakHeaderLabel";
            this.singleDakHeaderLabel.Size = new System.Drawing.Size(161, 36);
            this.singleDakHeaderLabel.TabIndex = 28;
            this.singleDakHeaderLabel.Text = "ব্যবহারকারীর প্রোফাইল";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.HeadingPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.attachmentTableLayoutPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 50);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.90909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(619, 726);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // attachmentTableLayoutPanel
            // 
            this.attachmentTableLayoutPanel.AutoScroll = true;
            this.attachmentTableLayoutPanel.AutoSize = true;
            this.attachmentTableLayoutPanel.ColumnCount = 1;
            this.attachmentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.attachmentTableLayoutPanel.Controls.Add(this.tableLayoutPanel6, 0, 5);
            this.attachmentTableLayoutPanel.Controls.Add(this.tableLayoutPanel4, 0, 4);
            this.attachmentTableLayoutPanel.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.attachmentTableLayoutPanel.Controls.Add(this.panel2, 0, 1);
            this.attachmentTableLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this.attachmentTableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.attachmentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.attachmentTableLayoutPanel.Location = new System.Drawing.Point(23, 64);
            this.attachmentTableLayoutPanel.Name = "attachmentTableLayoutPanel";
            this.attachmentTableLayoutPanel.RowCount = 6;
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.attachmentTableLayoutPanel.Size = new System.Drawing.Size(573, 609);
            this.attachmentTableLayoutPanel.TabIndex = 40;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.designationListBox, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 660);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.87671F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.12329F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(573, 88);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(573, 28);
            this.panel6.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "প্রোফাইল (ব্যক্তিগত তথ্য)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label14.Location = new System.Drawing.Point(0, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(573, 1);
            this.label14.TabIndex = 39;
            // 
            // designationListBox
            // 
            this.designationListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.designationListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.designationListBox.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designationListBox.FormattingEnabled = true;
            this.designationListBox.ItemHeight = 21;
            this.designationListBox.Location = new System.Drawing.Point(10, 31);
            this.designationListBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.designationListBox.Name = "designationListBox";
            this.designationListBox.Size = new System.Drawing.Size(560, 42);
            this.designationListBox.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 410);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.47111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.52889F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(573, 250);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.Location = new System.Drawing.Point(3, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(567, 2);
            this.label9.TabIndex = 40;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(573, 28);
            this.panel5.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "প্রোফাইল (ব্যক্তিগত তথ্য)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(0, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(573, 1);
            this.label11.TabIndex = 39;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.joiningDateLabel, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.mobileLabel, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.emailLabel, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.birthCertificate, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.nationalIdLabel, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.dateofBirthLabel, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.motherNameLabel, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.fatherNameLabel, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanel5.RowCount = 10;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(573, 219);
            this.tableLayoutPanel5.TabIndex = 41;
            // 
            // joiningDateLabel
            // 
            this.joiningDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.joiningDateLabel.AutoSize = true;
            this.joiningDateLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joiningDateLabel.Location = new System.Drawing.Point(13, 168);
            this.joiningDateLabel.Name = "joiningDateLabel";
            this.joiningDateLabel.Size = new System.Drawing.Size(175, 21);
            this.joiningDateLabel.TabIndex = 8;
            this.joiningDateLabel.Text = "কর্মক্ষেত্রে যোগদানের তারিখ:";
            // 
            // mobileLabel
            // 
            this.mobileLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mobileLabel.AutoSize = true;
            this.mobileLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileLabel.Location = new System.Drawing.Point(13, 147);
            this.mobileLabel.Name = "mobileLabel";
            this.mobileLabel.Size = new System.Drawing.Size(64, 21);
            this.mobileLabel.TabIndex = 7;
            this.mobileLabel.Text = "মোবাইল:";
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(13, 126);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(61, 21);
            this.emailLabel.TabIndex = 6;
            this.emailLabel.Text = "ইমেইল: ";
            // 
            // birthCertificate
            // 
            this.birthCertificate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.birthCertificate.AutoSize = true;
            this.birthCertificate.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthCertificate.Location = new System.Drawing.Point(13, 105);
            this.birthCertificate.Name = "birthCertificate";
            this.birthCertificate.Size = new System.Drawing.Size(69, 21);
            this.birthCertificate.TabIndex = 5;
            this.birthCertificate.Text = "জন্ম সনদ:";
            // 
            // nationalIdLabel
            // 
            this.nationalIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nationalIdLabel.AutoSize = true;
            this.nationalIdLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nationalIdLabel.Location = new System.Drawing.Point(13, 84);
            this.nationalIdLabel.Name = "nationalIdLabel";
            this.nationalIdLabel.Size = new System.Drawing.Size(107, 21);
            this.nationalIdLabel.TabIndex = 4;
            this.nationalIdLabel.Text = "ন্যাশনাল আইডি:";
            // 
            // dateofBirthLabel
            // 
            this.dateofBirthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateofBirthLabel.AutoSize = true;
            this.dateofBirthLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateofBirthLabel.Location = new System.Drawing.Point(13, 63);
            this.dateofBirthLabel.Name = "dateofBirthLabel";
            this.dateofBirthLabel.Size = new System.Drawing.Size(81, 21);
            this.dateofBirthLabel.TabIndex = 3;
            this.dateofBirthLabel.Text = "জন্ম তারিখ: ";
            // 
            // motherNameLabel
            // 
            this.motherNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.motherNameLabel.AutoSize = true;
            this.motherNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motherNameLabel.Location = new System.Drawing.Point(13, 42);
            this.motherNameLabel.Name = "motherNameLabel";
            this.motherNameLabel.Size = new System.Drawing.Size(76, 21);
            this.motherNameLabel.TabIndex = 2;
            this.motherNameLabel.Text = "মায়ের নাম:";
            // 
            // fatherNameLabel
            // 
            this.fatherNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fatherNameLabel.AutoSize = true;
            this.fatherNameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fatherNameLabel.Location = new System.Drawing.Point(13, 21);
            this.fatherNameLabel.Name = "fatherNameLabel";
            this.fatherNameLabel.Size = new System.Drawing.Size(78, 21);
            this.fatherNameLabel.TabIndex = 1;
            this.fatherNameLabel.Text = "বাবার নাম: ";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(13, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(36, 21);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "নাম:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.signatureIconPictureBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 250);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.38095F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.61905F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(573, 160);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Location = new System.Drawing.Point(3, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(567, 2);
            this.label8.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(573, 43);
            this.panel4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "স্বাক্ষর";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(0, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(573, 1);
            this.label6.TabIndex = 39;
            // 
            // signatureIconPictureBox
            // 
            this.signatureIconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.signatureIconPictureBox.BackColor = System.Drawing.Color.White;
            this.signatureIconPictureBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.signatureIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Signature;
            this.signatureIconPictureBox.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.signatureIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.signatureIconPictureBox.IconSize = 114;
            this.signatureIconPictureBox.Location = new System.Drawing.Point(10, 43);
            this.signatureIconPictureBox.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.signatureIconPictureBox.Name = "signatureIconPictureBox";
            this.signatureIconPictureBox.Size = new System.Drawing.Size(203, 114);
            this.signatureIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.signatureIconPictureBox.TabIndex = 3;
            this.signatureIconPictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.userIdLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 35);
            this.panel2.TabIndex = 1;
            // 
            // userIdLabel
            // 
            this.userIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.userIdLabel.Location = new System.Drawing.Point(3, 7);
            this.userIdLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(118, 21);
            this.userIdLabel.TabIndex = 0;
            this.userIdLabel.Text = "200000002962";
            this.userIdLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(573, 2);
            this.label3.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.profileUpdateButton);
            this.panel1.Controls.Add(this.Subjectlabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 35);
            this.panel1.TabIndex = 0;
            // 
            // profileUpdateButton
            // 
            this.profileUpdateButton.AutoSize = true;
            this.profileUpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.profileUpdateButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.profileUpdateButton.FlatAppearance.BorderSize = 0;
            this.profileUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileUpdateButton.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.profileUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileUpdateButton.ForeColor = System.Drawing.Color.White;
            this.profileUpdateButton.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.profileUpdateButton.IconColor = System.Drawing.Color.White;
            this.profileUpdateButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.profileUpdateButton.IconSize = 18;
            this.profileUpdateButton.Location = new System.Drawing.Point(365, 0);
            this.profileUpdateButton.Margin = new System.Windows.Forms.Padding(0);
            this.profileUpdateButton.Name = "profileUpdateButton";
            this.profileUpdateButton.Size = new System.Drawing.Size(208, 34);
            this.profileUpdateButton.TabIndex = 40;
            this.profileUpdateButton.Text = "প্রোফাইল সংশোধন";
            this.profileUpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.profileUpdateButton.UseVisualStyleBackColor = false;
            this.profileUpdateButton.Click += new System.EventHandler(this.profileUpdateButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 1);
            this.label1.TabIndex = 39;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.userImageBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.73094F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.26906F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(573, 180);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(3, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(567, 2);
            this.label7.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 35);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "প্রোফাইল ছবি";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(0, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(573, 1);
            this.label4.TabIndex = 39;
            // 
            // userImageBox
            // 
            this.userImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userImageBox.BackColor = System.Drawing.Color.White;
            this.userImageBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.userImageBox.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.userImageBox.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.userImageBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.userImageBox.IconSize = 142;
            this.userImageBox.Location = new System.Drawing.Point(10, 35);
            this.userImageBox.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.userImageBox.Name = "userImageBox";
            this.userImageBox.Size = new System.Drawing.Size(203, 142);
            this.userImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userImageBox.TabIndex = 3;
            this.userImageBox.TabStop = false;
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
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 23;
            // 
            // UserProfileForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 726);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(550, 726);
            this.Name = "UserProfileForm";
            this.Load += new System.EventHandler(this.UserProfileForm_Load);
            this.HeadingPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.attachmentTableLayoutPanel.ResumeLayout(false);
            this.attachmentTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signatureIconPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImageBox)).EndInit();
            this.ResumeLayout(false);

        }

       


        #endregion

        private System.Windows.Forms.Label Subjectlabel;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.Panel HeadingPanel;
        private System.Windows.Forms.Label singleDakHeaderLabel;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private FontAwesome.Sharp.IconButton sliderCrossButton;
        private DataGridViewRadioButtonElements.DataGridViewRadioButtonColumn mul_prapok;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel attachmentTableLayoutPanel;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton profileUpdateButton;
        private Panel panel2;
        private Label userIdLabel;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private Label label2;
        private Label label4;
        private FontAwesome.Sharp.IconPictureBox userImageBox;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel4;
        private Label label5;
        private Label label6;
        private FontAwesome.Sharp.IconPictureBox signatureIconPictureBox;
        private Label label8;
        private Label label7;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label9;
        private Panel panel5;
        private Label label10;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel5;
        private Label nameLabel;
        private Label joiningDateLabel;
        private Label mobileLabel;
        private Label emailLabel;
        private Label birthCertificate;
        private Label nationalIdLabel;
        private Label dateofBirthLabel;
        private Label motherNameLabel;
        private Label fatherNameLabel;
        private TableLayoutPanel tableLayoutPanel6;
        private Panel panel6;
        private Label label13;
        private Label label14;
        private ListBox designationListBox;
    }
}