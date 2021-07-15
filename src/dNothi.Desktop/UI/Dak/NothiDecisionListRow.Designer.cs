
namespace dNothi.Desktop.UI.Dak
{
    partial class NothiDecisionListRow
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
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.lbDecisionText = new System.Windows.Forms.Label();
            this.btnDecisionAdd = new FontAwesome.Sharp.IconButton();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel16.Controls.Add(this.panel34);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(13, 0);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(937, 2);
            this.panel16.TabIndex = 60;
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.panel34.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel34.Location = new System.Drawing.Point(0, 1);
            this.panel34.Margin = new System.Windows.Forms.Padding(0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(937, 1);
            this.panel34.TabIndex = 60;
            // 
            // lbDecisionText
            // 
            this.lbDecisionText.AutoSize = true;
            this.lbDecisionText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDecisionText.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDecisionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.lbDecisionText.Location = new System.Drawing.Point(56, 2);
            this.lbDecisionText.Margin = new System.Windows.Forms.Padding(0);
            this.lbDecisionText.Name = "lbDecisionText";
            this.lbDecisionText.Padding = new System.Windows.Forms.Padding(150, 8, 0, 0);
            this.lbDecisionText.Size = new System.Drawing.Size(204, 34);
            this.lbDecisionText.TabIndex = 82;
            this.lbDecisionText.Text = "খসড়া";
            // 
            // btnDecisionAdd
            // 
            this.btnDecisionAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnDecisionAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDecisionAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDecisionAdd.FlatAppearance.BorderSize = 0;
            this.btnDecisionAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDecisionAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.btnDecisionAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecisionAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecisionAdd.ForeColor = System.Drawing.Color.White;
            this.btnDecisionAdd.IconChar = FontAwesome.Sharp.IconChar.FileMedical;
            this.btnDecisionAdd.IconColor = System.Drawing.Color.White;
            this.btnDecisionAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDecisionAdd.IconSize = 26;
            this.btnDecisionAdd.Location = new System.Drawing.Point(13, 2);
            this.btnDecisionAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnDecisionAdd.Name = "btnDecisionAdd";
            this.btnDecisionAdd.Size = new System.Drawing.Size(43, 60);
            this.btnDecisionAdd.TabIndex = 71;
            this.btnDecisionAdd.UseVisualStyleBackColor = false;
            this.btnDecisionAdd.Click += new System.EventHandler(this.btnDecisionAdd_Click);
            // 
            // NothiDecisionListRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbDecisionText);
            this.Controls.Add(this.btnDecisionAdd);
            this.Controls.Add(this.panel16);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NothiDecisionListRow";
            this.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.Size = new System.Drawing.Size(950, 62);
            this.panel16.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel34;
        private FontAwesome.Sharp.IconButton btnDecisionAdd;
        private System.Windows.Forms.Label lbDecisionText;
    }
}
