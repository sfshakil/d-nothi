
namespace dNothi.Desktop.UI.Dak
{
    partial class NoteViewNotInCurrentDesk
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNoteSubject = new System.Windows.Forms.Label();
            this.lbTotalNothi = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbNoteSubject);
            this.panel2.Controls.Add(this.lbTotalNothi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(684, 24);
            this.panel2.TabIndex = 2;
            // 
            // lbNoteSubject
            // 
            this.lbNoteSubject.AutoSize = true;
            this.lbNoteSubject.BackColor = System.Drawing.Color.Transparent;
            this.lbNoteSubject.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNoteSubject.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbNoteSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbNoteSubject.Location = new System.Drawing.Point(34, 0);
            this.lbNoteSubject.Margin = new System.Windows.Forms.Padding(0);
            this.lbNoteSubject.Name = "lbNoteSubject";
            this.lbNoteSubject.Size = new System.Drawing.Size(67, 21);
            this.lbNoteSubject.TabIndex = 64;
            this.lbNoteSubject.Text = "টেস্ট নোট";
            // 
            // lbTotalNothi
            // 
            this.lbTotalNothi.AutoSize = true;
            this.lbTotalNothi.BackColor = System.Drawing.Color.Azure;
            this.lbTotalNothi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTotalNothi.Font = new System.Drawing.Font("SolaimanLipi", 12F);
            this.lbTotalNothi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbTotalNothi.Location = new System.Drawing.Point(15, 0);
            this.lbTotalNothi.Margin = new System.Windows.Forms.Padding(0);
            this.lbTotalNothi.Name = "lbTotalNothi";
            this.lbTotalNothi.Size = new System.Drawing.Size(19, 21);
            this.lbTotalNothi.TabIndex = 63;
            this.lbTotalNothi.Text = "২";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(684, 1);
            this.panel4.TabIndex = 66;
            // 
            // NoteViewNotInCurrentDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "NoteViewNotInCurrentDesk";
            this.Size = new System.Drawing.Size(684, 26);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbNoteSubject;
        private System.Windows.Forms.Label lbTotalNothi;
        private System.Windows.Forms.Panel panel4;
    }
}
