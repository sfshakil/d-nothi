
namespace dNothi.Desktop.UI.Dak
{
    partial class SeparateOnuchhed
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
            this.topPnl = new System.Windows.Forms.Panel();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.lbCreateDate = new System.Windows.Forms.Label();
            this.middlePnl = new System.Windows.Forms.Panel();
            this.lbonucchedId = new System.Windows.Forms.Label();
            this.lbOnucchedNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SubjectBrowser = new System.Windows.Forms.WebBrowser();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SignatureViewBodyPanel = new System.Windows.Forms.Panel();
            this.SignatureFLP = new System.Windows.Forms.TableLayoutPanel();
            this.onuchhedheaderPnl = new dNothi.Desktop.AdvancedPanel();
            this.btnSchedule = new FontAwesome.Sharp.IconButton();
            this.lbOffice = new System.Windows.Forms.Label();
            this.lbNoteNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPlusSquare = new FontAwesome.Sharp.IconButton();
            this.topPnl.SuspendLayout();
            this.middlePnl.SuspendLayout();
            this.SignatureViewBodyPanel.SuspendLayout();
            this.onuchhedheaderPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPnl
            // 
            this.topPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.topPnl.Controls.Add(this.btnDelete);
            this.topPnl.Controls.Add(this.lbCreateDate);
            this.topPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPnl.Location = new System.Drawing.Point(0, 43);
            this.topPnl.Margin = new System.Windows.Forms.Padding(0);
            this.topPnl.Name = "topPnl";
            this.topPnl.Size = new System.Drawing.Size(1297, 30);
            this.topPnl.TabIndex = 2;
            this.topPnl.MouseLeave += new System.EventHandler(this.onuchhedheaderPnl_MouseLeave);
            this.topPnl.MouseHover += new System.EventHandler(this.onuchhedheaderPnl_MouseHover);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelete.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 18;
            this.btnDelete.Location = new System.Drawing.Point(1254, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(43, 30);
            this.btnDelete.TabIndex = 72;
            this.MyToolTip.SetToolTip(this.btnDelete, "মুছে ফেলুন");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            this.btnDelete.MouseHover += new System.EventHandler(this.btnDelete_MouseHover);
            // 
            // lbCreateDate
            // 
            this.lbCreateDate.AutoSize = true;
            this.lbCreateDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lbCreateDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCreateDate.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreateDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbCreateDate.Location = new System.Drawing.Point(0, 0);
            this.lbCreateDate.Margin = new System.Windows.Forms.Padding(0);
            this.lbCreateDate.Name = "lbCreateDate";
            this.lbCreateDate.Size = new System.Drawing.Size(168, 26);
            this.lbCreateDate.TabIndex = 65;
            this.lbCreateDate.Text = " ১১/১/২১ ৪:০১ PM";
            // 
            // middlePnl
            // 
            this.middlePnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.middlePnl.Controls.Add(this.lbonucchedId);
            this.middlePnl.Controls.Add(this.lbOnucchedNo);
            this.middlePnl.Controls.Add(this.label5);
            this.middlePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.middlePnl.Location = new System.Drawing.Point(0, 73);
            this.middlePnl.Margin = new System.Windows.Forms.Padding(0);
            this.middlePnl.Name = "middlePnl";
            this.middlePnl.Size = new System.Drawing.Size(1297, 30);
            this.middlePnl.TabIndex = 3;
            this.middlePnl.MouseLeave += new System.EventHandler(this.onuchhedheaderPnl_MouseLeave);
            this.middlePnl.MouseHover += new System.EventHandler(this.onuchhedheaderPnl_MouseHover);
            // 
            // lbonucchedId
            // 
            this.lbonucchedId.AutoSize = true;
            this.lbonucchedId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lbonucchedId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbonucchedId.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbonucchedId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbonucchedId.Location = new System.Drawing.Point(121, 0);
            this.lbonucchedId.Margin = new System.Windows.Forms.Padding(0);
            this.lbonucchedId.Name = "lbonucchedId";
            this.lbonucchedId.Size = new System.Drawing.Size(24, 26);
            this.lbonucchedId.TabIndex = 68;
            this.lbonucchedId.Text = "0";
            this.lbonucchedId.Visible = false;
            // 
            // lbOnucchedNo
            // 
            this.lbOnucchedNo.AutoSize = true;
            this.lbOnucchedNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lbOnucchedNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbOnucchedNo.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOnucchedNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbOnucchedNo.Location = new System.Drawing.Point(76, 0);
            this.lbOnucchedNo.Margin = new System.Windows.Forms.Padding(0);
            this.lbOnucchedNo.Name = "lbOnucchedNo";
            this.lbOnucchedNo.Size = new System.Drawing.Size(45, 26);
            this.lbOnucchedNo.TabIndex = 67;
            this.lbOnucchedNo.Text = "০.০";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 26);
            this.label5.TabIndex = 66;
            this.label5.Text = "অনুচ্ছেদ";
            // 
            // SubjectBrowser
            // 
            this.SubjectBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubjectBrowser.Location = new System.Drawing.Point(0, 103);
            this.SubjectBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.SubjectBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.SubjectBrowser.Name = "SubjectBrowser";
            this.SubjectBrowser.Size = new System.Drawing.Size(1297, 110);
            this.SubjectBrowser.TabIndex = 4;
            this.SubjectBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // SignatureViewBodyPanel
            // 
            this.SignatureViewBodyPanel.AutoScroll = true;
            this.SignatureViewBodyPanel.Controls.Add(this.SignatureFLP);
            this.SignatureViewBodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignatureViewBodyPanel.Location = new System.Drawing.Point(0, 213);
            this.SignatureViewBodyPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SignatureViewBodyPanel.Name = "SignatureViewBodyPanel";
            this.SignatureViewBodyPanel.Size = new System.Drawing.Size(1297, 0);
            this.SignatureViewBodyPanel.TabIndex = 71;
            // 
            // SignatureFLP
            // 
            this.SignatureFLP.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.SignatureFLP.AutoSize = true;
            this.SignatureFLP.ColumnCount = 1;
            this.SignatureFLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SignatureFLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.SignatureFLP.Dock = System.Windows.Forms.DockStyle.Top;
            this.SignatureFLP.Location = new System.Drawing.Point(0, 0);
            this.SignatureFLP.Margin = new System.Windows.Forms.Padding(0);
            this.SignatureFLP.Name = "SignatureFLP";
            this.SignatureFLP.RowCount = 1;
            this.SignatureFLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SignatureFLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.SignatureFLP.Size = new System.Drawing.Size(1297, 0);
            this.SignatureFLP.TabIndex = 55;
            // 
            // onuchhedheaderPnl
            // 
            this.onuchhedheaderPnl.BackColor = System.Drawing.Color.Transparent;
            this.onuchhedheaderPnl.BackgroundGradientMode = dNothi.Desktop.AdvancedPanel.PanelGradientMode.Vertical;
            this.onuchhedheaderPnl.Controls.Add(this.btnSchedule);
            this.onuchhedheaderPnl.Controls.Add(this.lbOffice);
            this.onuchhedheaderPnl.Controls.Add(this.lbNoteNo);
            this.onuchhedheaderPnl.Controls.Add(this.label6);
            this.onuchhedheaderPnl.Controls.Add(this.btnPlusSquare);
            this.onuchhedheaderPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.onuchhedheaderPnl.EdgeWidth = 0;
            this.onuchhedheaderPnl.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.onuchhedheaderPnl.FlatBorderColor = System.Drawing.Color.Transparent;
            this.onuchhedheaderPnl.Location = new System.Drawing.Point(0, 0);
            this.onuchhedheaderPnl.Margin = new System.Windows.Forms.Padding(0);
            this.onuchhedheaderPnl.Name = "onuchhedheaderPnl";
            this.onuchhedheaderPnl.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.onuchhedheaderPnl.RectRadius = 0;
            this.onuchhedheaderPnl.ShadowColor = System.Drawing.Color.Transparent;
            this.onuchhedheaderPnl.ShadowShift = 0;
            this.onuchhedheaderPnl.ShadowStyle = dNothi.Desktop.AdvancedPanel.ShadowMode.ForwardDiagonal;
            this.onuchhedheaderPnl.Size = new System.Drawing.Size(1297, 43);
            this.onuchhedheaderPnl.StartColor = System.Drawing.Color.White;
            this.onuchhedheaderPnl.Style = dNothi.Desktop.AdvancedPanel.BevelStyle.Flat;
            this.onuchhedheaderPnl.TabIndex = 6;
            this.onuchhedheaderPnl.MouseLeave += new System.EventHandler(this.onuchhedheaderPnl_MouseLeave);
            this.onuchhedheaderPnl.MouseHover += new System.EventHandler(this.onuchhedheaderPnl_MouseHover);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSchedule.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            this.btnSchedule.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnSchedule.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSchedule.IconSize = 28;
            this.btnSchedule.Location = new System.Drawing.Point(1254, 0);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(33, 43);
            this.btnSchedule.TabIndex = 120;
            this.MyToolTip.SetToolTip(this.btnSchedule, "আপলোড হচ্ছে");
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Visible = false;
            // 
            // lbOffice
            // 
            this.lbOffice.AutoSize = true;
            this.lbOffice.BackColor = System.Drawing.Color.Transparent;
            this.lbOffice.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbOffice.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbOffice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbOffice.Location = new System.Drawing.Point(151, 0);
            this.lbOffice.Margin = new System.Windows.Forms.Padding(0);
            this.lbOffice.Name = "lbOffice";
            this.lbOffice.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lbOffice.Size = new System.Drawing.Size(313, 32);
            this.lbOffice.TabIndex = 76;
            this.lbOffice.Text = "(মোঃ হাসানুজ্জামান ১১/১/২১ ৪:০১ PM)";
            // 
            // lbNoteNo
            // 
            this.lbNoteNo.AutoSize = true;
            this.lbNoteNo.BackColor = System.Drawing.Color.Transparent;
            this.lbNoteNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNoteNo.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbNoteNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbNoteNo.Location = new System.Drawing.Point(109, 0);
            this.lbNoteNo.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoteNo.Name = "lbNoteNo";
            this.lbNoteNo.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lbNoteNo.Size = new System.Drawing.Size(42, 32);
            this.lbNoteNo.TabIndex = 73;
            this.lbNoteNo.Text = "০.০";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label6.Location = new System.Drawing.Point(33, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 6, 0, 0);
            this.label6.Size = new System.Drawing.Size(76, 32);
            this.label6.TabIndex = 72;
            this.label6.Text = "অনুচ্ছেদ";
            // 
            // btnPlusSquare
            // 
            this.btnPlusSquare.BackColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlusSquare.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPlusSquare.FlatAppearance.BorderSize = 0;
            this.btnPlusSquare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlusSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlusSquare.ForeColor = System.Drawing.Color.Transparent;
            this.btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.btnPlusSquare.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(154)))));
            this.btnPlusSquare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlusSquare.IconSize = 24;
            this.btnPlusSquare.Location = new System.Drawing.Point(0, 0);
            this.btnPlusSquare.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlusSquare.Name = "btnPlusSquare";
            this.btnPlusSquare.Size = new System.Drawing.Size(33, 43);
            this.btnPlusSquare.TabIndex = 71;
            this.btnPlusSquare.UseVisualStyleBackColor = false;
            this.btnPlusSquare.Click += new System.EventHandler(this.btnPlusSquare_Click);
            // 
            // SeparateOnuchhed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.SignatureViewBodyPanel);
            this.Controls.Add(this.SubjectBrowser);
            this.Controls.Add(this.middlePnl);
            this.Controls.Add(this.topPnl);
            this.Controls.Add(this.onuchhedheaderPnl);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SeparateOnuchhed";
            this.Size = new System.Drawing.Size(1297, 43);
            this.topPnl.ResumeLayout(false);
            this.topPnl.PerformLayout();
            this.middlePnl.ResumeLayout(false);
            this.middlePnl.PerformLayout();
            this.SignatureViewBodyPanel.ResumeLayout(false);
            this.SignatureViewBodyPanel.PerformLayout();
            this.onuchhedheaderPnl.ResumeLayout(false);
            this.onuchhedheaderPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel topPnl;
        private System.Windows.Forms.Label lbCreateDate;
        private System.Windows.Forms.Panel middlePnl;
        private System.Windows.Forms.Label lbOnucchedNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.WebBrowser SubjectBrowser;
        private AdvancedPanel onuchhedheaderPnl;
        private System.Windows.Forms.Label lbOffice;
        private System.Windows.Forms.Label lbNoteNo;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnPlusSquare;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.Label lbonucchedId;
        private System.Windows.Forms.ToolTip MyToolTip;
        private FontAwesome.Sharp.IconButton btnSchedule;
        private System.Windows.Forms.Panel SignatureViewBodyPanel;
        private System.Windows.Forms.TableLayoutPanel SignatureFLP;
    }
}
