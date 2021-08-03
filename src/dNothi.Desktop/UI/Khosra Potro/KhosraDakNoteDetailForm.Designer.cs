using dNothi.Desktop.UI.Dak;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    partial class KhosraDakNoteDetailForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.NoteFullPanel = new System.Windows.Forms.Panel();
            this.CollapseExpandPanel = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.noteHeaderPanel = new System.Windows.Forms.Panel();
            this.onuchhedPnl = new System.Windows.Forms.Panel();
            this.panel59 = new System.Windows.Forms.Panel();
            this.onuchhedFLP = new System.Windows.Forms.TableLayoutPanel();
            this.noteSubjectPanel = new System.Windows.Forms.Panel();
            this.lbNothiLastDate = new System.Windows.Forms.Label();
            this.lbNoteSubject = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.noteTabpanel = new System.Windows.Forms.Panel();
            this.tabButtonPanel = new System.Windows.Forms.Panel();
            this.panel55 = new System.Windows.Forms.Panel();
            this.iconButton9 = new FontAwesome.Sharp.IconButton();
            this.iconButton8 = new FontAwesome.Sharp.IconButton();
            this.lbNoteTotl1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel38 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.pnl.SuspendLayout();
            this.NoteFullPanel.SuspendLayout();
            this.CollapseExpandPanel.SuspendLayout();
            this.noteHeaderPanel.SuspendLayout();
            this.onuchhedPnl.SuspendLayout();
            this.panel59.SuspendLayout();
            this.noteSubjectPanel.SuspendLayout();
            this.noteTabpanel.SuspendLayout();
            this.tabButtonPanel.SuspendLayout();
            this.panel55.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 43);
            this.panel2.TabIndex = 2;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.closeButton.IconColor = System.Drawing.Color.DimGray;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closeButton.IconSize = 20;
            this.closeButton.Location = new System.Drawing.Point(537, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 31);
            this.closeButton.TabIndex = 40;
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(2, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "নোটের বিস্তারিত";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.SystemColors.Window;
            this.pnl.Controls.Add(this.panel2);
            this.pnl.Controls.Add(this.NoteFullPanel);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(600, 634);
            this.pnl.TabIndex = 18;
            // 
            // NoteFullPanel
            // 
            this.NoteFullPanel.Controls.Add(this.CollapseExpandPanel);
            this.NoteFullPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteFullPanel.Location = new System.Drawing.Point(0, 0);
            this.NoteFullPanel.Name = "NoteFullPanel";
            this.NoteFullPanel.Padding = new System.Windows.Forms.Padding(10);
            this.NoteFullPanel.Size = new System.Drawing.Size(600, 634);
            this.NoteFullPanel.TabIndex = 65;
            // 
            // CollapseExpandPanel
            // 
            this.CollapseExpandPanel.AutoScroll = true;
            this.CollapseExpandPanel.BackColor = System.Drawing.SystemColors.Window;
            this.CollapseExpandPanel.Controls.Add(this.splitter3);
            this.CollapseExpandPanel.Controls.Add(this.noteHeaderPanel);
            this.CollapseExpandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CollapseExpandPanel.Location = new System.Drawing.Point(10, 10);
            this.CollapseExpandPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CollapseExpandPanel.Name = "CollapseExpandPanel";
            this.CollapseExpandPanel.Size = new System.Drawing.Size(580, 614);
            this.CollapseExpandPanel.TabIndex = 6;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 157);
            this.splitter3.Margin = new System.Windows.Forms.Padding(0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(580, 5);
            this.splitter3.TabIndex = 2;
            this.splitter3.TabStop = false;
            // 
            // noteHeaderPanel
            // 
            this.noteHeaderPanel.AutoScroll = true;
            this.noteHeaderPanel.Controls.Add(this.onuchhedPnl);
            this.noteHeaderPanel.Controls.Add(this.noteSubjectPanel);
            this.noteHeaderPanel.Controls.Add(this.noteTabpanel);
            this.noteHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.noteHeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.noteHeaderPanel.Name = "noteHeaderPanel";
            this.noteHeaderPanel.Size = new System.Drawing.Size(580, 157);
            this.noteHeaderPanel.TabIndex = 1;
            // 
            // onuchhedPnl
            // 
            this.onuchhedPnl.AutoScroll = true;
            this.onuchhedPnl.Controls.Add(this.panel59);
            this.onuchhedPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onuchhedPnl.Location = new System.Drawing.Point(0, 81);
            this.onuchhedPnl.Margin = new System.Windows.Forms.Padding(0);
            this.onuchhedPnl.Name = "onuchhedPnl";
            this.onuchhedPnl.Size = new System.Drawing.Size(580, 76);
            this.onuchhedPnl.TabIndex = 65;
            // 
            // panel59
            // 
            this.panel59.AutoScroll = true;
            this.panel59.Controls.Add(this.onuchhedFLP);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel59.Location = new System.Drawing.Point(0, 0);
            this.panel59.Margin = new System.Windows.Forms.Padding(0);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(580, 76);
            this.panel59.TabIndex = 71;
            // 
            // onuchhedFLP
            // 
            this.onuchhedFLP.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.onuchhedFLP.AutoSize = true;
            this.onuchhedFLP.ColumnCount = 1;
            this.onuchhedFLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.onuchhedFLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.onuchhedFLP.Dock = System.Windows.Forms.DockStyle.Top;
            this.onuchhedFLP.Location = new System.Drawing.Point(0, 0);
            this.onuchhedFLP.Margin = new System.Windows.Forms.Padding(0);
            this.onuchhedFLP.Name = "onuchhedFLP";
            this.onuchhedFLP.RowCount = 1;
            this.onuchhedFLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.onuchhedFLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.onuchhedFLP.Size = new System.Drawing.Size(580, 0);
            this.onuchhedFLP.TabIndex = 55;
            // 
            // noteSubjectPanel
            // 
            this.noteSubjectPanel.BackColor = System.Drawing.Color.White;
            this.noteSubjectPanel.Controls.Add(this.lbNothiLastDate);
            this.noteSubjectPanel.Controls.Add(this.lbNoteSubject);
            this.noteSubjectPanel.Controls.Add(this.panel37);
            this.noteSubjectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteSubjectPanel.Location = new System.Drawing.Point(0, 41);
            this.noteSubjectPanel.Margin = new System.Windows.Forms.Padding(0);
            this.noteSubjectPanel.Name = "noteSubjectPanel";
            this.noteSubjectPanel.Size = new System.Drawing.Size(580, 40);
            this.noteSubjectPanel.TabIndex = 64;
            // 
            // lbNothiLastDate
            // 
            this.lbNothiLastDate.AutoSize = true;
            this.lbNothiLastDate.BackColor = System.Drawing.Color.White;
            this.lbNothiLastDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNothiLastDate.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNothiLastDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(51)))), ((int)(((byte)(146)))));
            this.lbNothiLastDate.Location = new System.Drawing.Point(101, 0);
            this.lbNothiLastDate.Margin = new System.Windows.Forms.Padding(0);
            this.lbNothiLastDate.Name = "lbNothiLastDate";
            this.lbNothiLastDate.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lbNothiLastDate.Size = new System.Drawing.Size(114, 23);
            this.lbNothiLastDate.TabIndex = 71;
            this.lbNothiLastDate.Text = "৭/১/২১ ৬:১৫ PM";
            this.lbNothiLastDate.Visible = false;
            // 
            // lbNoteSubject
            // 
            this.lbNoteSubject.AutoSize = true;
            this.lbNoteSubject.BackColor = System.Drawing.Color.White;
            this.lbNoteSubject.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNoteSubject.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoteSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbNoteSubject.Location = new System.Drawing.Point(0, 0);
            this.lbNoteSubject.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoteSubject.Name = "lbNoteSubject";
            this.lbNoteSubject.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.lbNoteSubject.Size = new System.Drawing.Size(101, 23);
            this.lbNoteSubject.TabIndex = 70;
            this.lbNoteSubject.Text = "lbNoteSubject";
            // 
            // panel37
            // 
            this.panel37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel37.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel37.Location = new System.Drawing.Point(0, 39);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(580, 1);
            this.panel37.TabIndex = 60;
            // 
            // noteTabpanel
            // 
            this.noteTabpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.noteTabpanel.Controls.Add(this.tabButtonPanel);
            this.noteTabpanel.Controls.Add(this.panel38);
            this.noteTabpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteTabpanel.Location = new System.Drawing.Point(0, 0);
            this.noteTabpanel.Margin = new System.Windows.Forms.Padding(0);
            this.noteTabpanel.Name = "noteTabpanel";
            this.noteTabpanel.Size = new System.Drawing.Size(580, 41);
            this.noteTabpanel.TabIndex = 62;
            // 
            // tabButtonPanel
            // 
            this.tabButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabButtonPanel.Controls.Add(this.panel55);
            this.tabButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.tabButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tabButtonPanel.Name = "tabButtonPanel";
            this.tabButtonPanel.Size = new System.Drawing.Size(136, 40);
            this.tabButtonPanel.TabIndex = 72;
            // 
            // panel55
            // 
            this.panel55.Controls.Add(this.iconButton9);
            this.panel55.Controls.Add(this.iconButton8);
            this.panel55.Controls.Add(this.lbNoteTotl1);
            this.panel55.Controls.Add(this.iconButton1);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel55.Location = new System.Drawing.Point(0, 8);
            this.panel55.Margin = new System.Windows.Forms.Padding(0);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(136, 32);
            this.panel55.TabIndex = 0;
            // 
            // iconButton9
            // 
            this.iconButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.iconButton9.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.iconButton9.FlatAppearance.BorderSize = 0;
            this.iconButton9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton9.ForeColor = System.Drawing.Color.White;
            this.iconButton9.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButton9.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton9.IconSize = 15;
            this.iconButton9.Location = new System.Drawing.Point(93, 0);
            this.iconButton9.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton9.Name = "iconButton9";
            this.iconButton9.Size = new System.Drawing.Size(19, 32);
            this.iconButton9.TabIndex = 70;
            this.iconButton9.UseVisualStyleBackColor = false;
            // 
            // iconButton8
            // 
            this.iconButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.iconButton8.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton8.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.iconButton8.FlatAppearance.BorderSize = 0;
            this.iconButton8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton8.ForeColor = System.Drawing.Color.White;
            this.iconButton8.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.iconButton8.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.iconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton8.IconSize = 15;
            this.iconButton8.Location = new System.Drawing.Point(76, 0);
            this.iconButton8.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton8.Name = "iconButton8";
            this.iconButton8.Size = new System.Drawing.Size(17, 32);
            this.iconButton8.TabIndex = 71;
            this.iconButton8.UseVisualStyleBackColor = false;
            // 
            // lbNoteTotl1
            // 
            this.lbNoteTotl1.AutoSize = true;
            this.lbNoteTotl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lbNoteTotl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNoteTotl1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoteTotl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lbNoteTotl1.Location = new System.Drawing.Point(30, 0);
            this.lbNoteTotl1.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoteTotl1.Name = "lbNoteTotl1";
            this.lbNoteTotl1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lbNoteTotl1.Size = new System.Drawing.Size(46, 23);
            this.lbNoteTotl1.TabIndex = 72;
            this.lbNoteTotl1.Text = "নোটঃ ০";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(30, 32);
            this.iconButton1.TabIndex = 73;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // panel38
            // 
            this.panel38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel38.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel38.Location = new System.Drawing.Point(0, 40);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(580, 1);
            this.panel38.TabIndex = 60;
            // 
            // KhosraDakNoteDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(600, 634);
            this.Controls.Add(this.pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KhosraDakNoteDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DakNothiteUposthapitoForm";
            this.Load += new System.EventHandler(this.DakNothiteUposthapitoForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.NoteFullPanel.ResumeLayout(false);
            this.CollapseExpandPanel.ResumeLayout(false);
            this.noteHeaderPanel.ResumeLayout(false);
            this.onuchhedPnl.ResumeLayout(false);
            this.panel59.ResumeLayout(false);
            this.panel59.PerformLayout();
            this.noteSubjectPanel.ResumeLayout(false);
            this.noteSubjectPanel.PerformLayout();
            this.noteTabpanel.ResumeLayout(false);
            this.tabButtonPanel.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            this.panel55.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Panel NoteFullPanel;
        private System.Windows.Forms.Panel CollapseExpandPanel;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel noteHeaderPanel;
        private System.Windows.Forms.Panel onuchhedPnl;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.TableLayoutPanel onuchhedFLP;
        private System.Windows.Forms.Panel noteSubjectPanel;
        private System.Windows.Forms.Label lbNothiLastDate;
        private System.Windows.Forms.Label lbNoteSubject;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.Panel noteTabpanel;
        private System.Windows.Forms.Panel tabButtonPanel;
        private System.Windows.Forms.Panel panel55;
        private FontAwesome.Sharp.IconButton iconButton9;
        private FontAwesome.Sharp.IconButton iconButton8;
        private System.Windows.Forms.Label lbNoteTotl1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel38;
    }
}