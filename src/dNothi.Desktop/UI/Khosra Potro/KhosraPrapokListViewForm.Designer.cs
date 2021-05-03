using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    partial class KhosraPrapokListViewForm
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
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.HeadingPanel = new System.Windows.Forms.Panel();
            this.sliderCrossButton = new FontAwesome.Sharp.IconButton();
            this.singleDakHeaderLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.attachmentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.aproverListRowUserControl = new dNothi.Desktop.UI.Khosra_Potro.KhosraPrapokListRowUserControl();
            this.senderListRowUserControl = new dNothi.Desktop.UI.Khosra_Potro.KhosraPrapokListRowUserControl();
            this.PrapokListRowUserControl = new dNothi.Desktop.UI.Khosra_Potro.KhosraPrapokListRowUserControl();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.HeadingPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.attachmentTableLayoutPanel.SuspendLayout();
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
            this.sliderCrossButton.Click += new System.EventHandler(this.closeButtonClick);
            // 
            // singleDakHeaderLabel
            // 
            this.singleDakHeaderLabel.AutoSize = true;
            this.singleDakHeaderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.singleDakHeaderLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleDakHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.singleDakHeaderLabel.Location = new System.Drawing.Point(0, 25);
            this.singleDakHeaderLabel.Name = "singleDakHeaderLabel";
            this.singleDakHeaderLabel.Size = new System.Drawing.Size(108, 21);
            this.singleDakHeaderLabel.TabIndex = 28;
            this.singleDakHeaderLabel.Text = "প্রাপকের তালিকা";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.attachmentTableLayoutPanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.HeadingPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 50);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 726);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // attachmentTableLayoutPanel
            // 
            this.attachmentTableLayoutPanel.AutoScroll = true;
            this.attachmentTableLayoutPanel.ColumnCount = 1;
            this.attachmentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.attachmentTableLayoutPanel.Controls.Add(this.aproverListRowUserControl, 0, 4);
            this.attachmentTableLayoutPanel.Controls.Add(this.senderListRowUserControl, 0, 4);
            this.attachmentTableLayoutPanel.Controls.Add(this.PrapokListRowUserControl, 0, 0);
            this.attachmentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentTableLayoutPanel.Location = new System.Drawing.Point(23, 72);
            this.attachmentTableLayoutPanel.Name = "attachmentTableLayoutPanel";
            this.attachmentTableLayoutPanel.RowCount = 5;
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.attachmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.attachmentTableLayoutPanel.Size = new System.Drawing.Size(504, 601);
            this.attachmentTableLayoutPanel.TabIndex = 40;
            // 
            // aproverListRowUserControl
            // 
            this.aproverListRowUserControl._UserDesignation = "সল্যুশন আর্কিটেক্ট,";
            this.aproverListRowUserControl._UserName = "মোঃ হাসানুজ্জামান";
            this.aproverListRowUserControl._UserOfficeName = "টেকনোলজি,এসপায়ার টু ইনোভেট (এটু্আই) প্রোগ্রাম Test";
            this.aproverListRowUserControl._UserType = "অনুমোদনকারী";
            this.aproverListRowUserControl.AutoSize = true;
            this.aproverListRowUserControl.BackColor = System.Drawing.Color.White;
            this.aproverListRowUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aproverListRowUserControl.Location = new System.Drawing.Point(3, 74);
            this.aproverListRowUserControl.Name = "aproverListRowUserControl";
            this.aproverListRowUserControl.Size = new System.Drawing.Size(498, 65);
            this.aproverListRowUserControl.TabIndex = 2;
            this.aproverListRowUserControl.UserDesignation = "সল্যুশন আর্কিটেক্ট,";
            this.aproverListRowUserControl.UserName = "মোঃ হাসানুজ্জামান";
            this.aproverListRowUserControl.UserOfficeName = "টেকনোলজি,এসপায়ার টু ইনোভেট (এটু্আই) প্রোগ্রাম Test";
            this.aproverListRowUserControl.UserType = "অনুমোদনকারী";
            this.aproverListRowUserControl.Load += new System.EventHandler(this.khosraPrapokListRowUserControl3_Load);
            // 
            // senderListRowUserControl
            // 
            this.senderListRowUserControl._UserDesignation = "টেকনিক্যাল সাপোর্ট এক্সপার্ট,";
            this.senderListRowUserControl._UserName = "মোঃ হাসানুজ্জামান";
            this.senderListRowUserControl._UserOfficeName = "টেকনোলজি,এসপায়ার টু ইনোভেট (এটু্আই) প্রোগ্রাম Test";
            this.senderListRowUserControl._UserType = "প্রেরক";
            this.senderListRowUserControl.AutoSize = true;
            this.senderListRowUserControl.BackColor = System.Drawing.Color.White;
            this.senderListRowUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.senderListRowUserControl.Location = new System.Drawing.Point(3, 145);
            this.senderListRowUserControl.Name = "senderListRowUserControl";
            this.senderListRowUserControl.Size = new System.Drawing.Size(498, 453);
            this.senderListRowUserControl.TabIndex = 1;
            this.senderListRowUserControl.UserDesignation = "টেকনিক্যাল সাপোর্ট এক্সপার্ট,";
            this.senderListRowUserControl.UserName = "মোঃ হাসানুজ্জামান";
            this.senderListRowUserControl.UserOfficeName = "টেকনোলজি,এসপায়ার টু ইনোভেট (এটু্আই) প্রোগ্রাম Test";
            this.senderListRowUserControl.UserType = "প্রেরক";
            this.senderListRowUserControl.Load += new System.EventHandler(this.khosraPrapokListRowUserControl2_Load);
            // 
            // PrapokListRowUserControl
            // 
            this.PrapokListRowUserControl._UserDesignation = "টেকনিক্যাল সাপোর্ট এক্সপার্ট,";
            this.PrapokListRowUserControl._UserName = "জাফরিন আহমেদ ";
            this.PrapokListRowUserControl._UserOfficeName = "টেকনোলজি,এসপায়ার টু ইনোভেট (এটু্আই) প্রোগ্রাম Test";
            this.PrapokListRowUserControl._UserType = "প্রাপক";
            this.PrapokListRowUserControl.AutoSize = true;
            this.PrapokListRowUserControl.BackColor = System.Drawing.Color.White;
            this.PrapokListRowUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrapokListRowUserControl.Location = new System.Drawing.Point(3, 3);
            this.PrapokListRowUserControl.Name = "PrapokListRowUserControl";
            this.PrapokListRowUserControl.Size = new System.Drawing.Size(498, 65);
            this.PrapokListRowUserControl.TabIndex = 0;
            this.PrapokListRowUserControl.UserDesignation = "টেকনিক্যাল সাপোর্ট এক্সপার্ট,";
            this.PrapokListRowUserControl.UserName = "জাফরিন আহমেদ ";
            this.PrapokListRowUserControl.UserOfficeName = "টেকনোলজি,এসপায়ার টু ইনোভেট (এটু্আই) প্রোগ্রাম Test";
            this.PrapokListRowUserControl.UserType = "প্রাপক";
            this.PrapokListRowUserControl.Load += new System.EventHandler(this.khosraPrapokListRowUserControl1_Load);
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
            // KhosraPrapokListViewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 726);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(550, 726);
            this.MinimumSize = new System.Drawing.Size(550, 726);
            this.Name = "KhosraPrapokListViewForm";
            this.Load += new System.EventHandler(this.KhosraPrapokListViewForm_Load);
            this.HeadingPanel.ResumeLayout(false);
            this.HeadingPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.attachmentTableLayoutPanel.ResumeLayout(false);
            this.attachmentTableLayoutPanel.PerformLayout();
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
        private TableLayoutPanel attachmentTableLayoutPanel;
        private KhosraPrapokListRowUserControl aproverListRowUserControl;
        private KhosraPrapokListRowUserControl senderListRowUserControl;
        private KhosraPrapokListRowUserControl PrapokListRowUserControl;
    }
}