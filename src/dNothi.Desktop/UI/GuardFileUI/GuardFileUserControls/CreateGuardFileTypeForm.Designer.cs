namespace dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls
{
    partial class CreateGuardFileTypeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.saveEditButton = new FontAwesome.Sharp.IconButton();
            this.HeadingPanel = new System.Windows.Forms.Panel();
            this.AddDesignationCloseButton = new FontAwesome.Sharp.IconButton();
            this.sliderCrossButton = new FontAwesome.Sharp.IconButton();
            this.singleDakHeaderLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Subjectlabel = new System.Windows.Forms.Label();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.placeholderTextBox1 = new PlaceholderTextBox.PlaceholderTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.HeadingPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.HeadingPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 50);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(608, 680);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchPanel);
            this.panel2.Controls.Add(this.saveEditButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(23, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 41);
            this.panel2.TabIndex = 40;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.placeholderTextBox1);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(528, 41);
            this.searchPanel.TabIndex = 1;
            this.searchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Color_Blue);
            // 
            // saveEditButton
            // 
            this.saveEditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.saveEditButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveEditButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(197)))), ((int)(((byte)(189)))));
            this.saveEditButton.FlatAppearance.BorderSize = 0;
            this.saveEditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.saveEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveEditButton.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            this.saveEditButton.IconColor = System.Drawing.Color.White;
            this.saveEditButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveEditButton.IconSize = 24;
            this.saveEditButton.Location = new System.Drawing.Point(528, 0);
            this.saveEditButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveEditButton.Name = "saveEditButton";
            this.saveEditButton.Size = new System.Drawing.Size(34, 41);
            this.saveEditButton.TabIndex = 89;
            this.saveEditButton.UseVisualStyleBackColor = false;
            // 
            // HeadingPanel
            // 
            this.HeadingPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HeadingPanel.Controls.Add(this.AddDesignationCloseButton);
            this.HeadingPanel.Controls.Add(this.sliderCrossButton);
            this.HeadingPanel.Controls.Add(this.singleDakHeaderLabel);
            this.HeadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeadingPanel.Location = new System.Drawing.Point(20, 0);
            this.HeadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeadingPanel.Name = "HeadingPanel";
            this.HeadingPanel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.HeadingPanel.Size = new System.Drawing.Size(568, 69);
            this.HeadingPanel.TabIndex = 38;
            // 
            // AddDesignationCloseButton
            // 
            this.AddDesignationCloseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddDesignationCloseButton.AutoSize = true;
            this.AddDesignationCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.AddDesignationCloseButton.FlatAppearance.BorderSize = 0;
            this.AddDesignationCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddDesignationCloseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddDesignationCloseButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.AddDesignationCloseButton.IconColor = System.Drawing.Color.DimGray;
            this.AddDesignationCloseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AddDesignationCloseButton.IconSize = 20;
            this.AddDesignationCloseButton.Location = new System.Drawing.Point(537, 21);
            this.AddDesignationCloseButton.Name = "AddDesignationCloseButton";
            this.AddDesignationCloseButton.Size = new System.Drawing.Size(28, 31);
            this.AddDesignationCloseButton.TabIndex = 41;
            this.AddDesignationCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddDesignationCloseButton.UseVisualStyleBackColor = false;
            this.AddDesignationCloseButton.Click += new System.EventHandler(this.AddDesignationCloseButton_Click);
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
            this.sliderCrossButton.Location = new System.Drawing.Point(568, 25);
            this.sliderCrossButton.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCrossButton.MaximumSize = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.Name = "sliderCrossButton";
            this.sliderCrossButton.Size = new System.Drawing.Size(0, 32);
            this.sliderCrossButton.TabIndex = 38;
            this.sliderCrossButton.UseVisualStyleBackColor = false;
            // 
            // singleDakHeaderLabel
            // 
            this.singleDakHeaderLabel.AutoSize = true;
            this.singleDakHeaderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.singleDakHeaderLabel.Font = new System.Drawing.Font("SolaimanLipi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleDakHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(86)))));
            this.singleDakHeaderLabel.Location = new System.Drawing.Point(0, 25);
            this.singleDakHeaderLabel.Name = "singleDakHeaderLabel";
            this.singleDakHeaderLabel.Size = new System.Drawing.Size(117, 21);
            this.singleDakHeaderLabel.TabIndex = 28;
            this.singleDakHeaderLabel.Text = "গার্ড ফাইলের ধরন";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Subjectlabel);
            this.panel1.Location = new System.Drawing.Point(23, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 25);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("SolaimanLipi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(33, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(11, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Subjectlabel
            // 
            this.Subjectlabel.AutoSize = true;
            this.Subjectlabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Subjectlabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subjectlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(68)))), ((int)(((byte)(86)))));
            this.Subjectlabel.Location = new System.Drawing.Point(0, 0);
            this.Subjectlabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.Subjectlabel.Name = "Subjectlabel";
            this.Subjectlabel.Size = new System.Drawing.Size(33, 18);
            this.Subjectlabel.TabIndex = 1;
            this.Subjectlabel.Text = "ধরন:";
            this.Subjectlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewImageColumn1.HeaderText = "+";
            this.dataGridViewImageColumn1.Image = global::dNothi.Desktop.Properties.Resources.delete;
            this.dataGridViewImageColumn1.MinimumWidth = 2;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 27;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewImageColumn2.HeaderText = "+";
            this.dataGridViewImageColumn2.Image = global::dNothi.Desktop.Properties.Resources.delete;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 23;
            // 
            // placeholderTextBox1
            // 
            this.placeholderTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.placeholderTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.placeholderTextBox1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderTextBox1.Location = new System.Drawing.Point(6, 11);
            this.placeholderTextBox1.Name = "placeholderTextBox1";
            this.placeholderTextBox1.PlaceholderText = "ধরন";
            this.placeholderTextBox1.Size = new System.Drawing.Size(515, 19);
            this.placeholderTextBox1.TabIndex = 0;
            // 
            // CreateGuardFileTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateGuardFileTypeForm";
            this.Text = "CreateGuardFileTypeForm";
            this.Load += new System.EventHandler(this.CreateGuardFileTypeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.HeadingPanel.ResumeLayout(false);
            this.HeadingPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel HeadingPanel;
        private FontAwesome.Sharp.IconButton sliderCrossButton;
        private System.Windows.Forms.Label singleDakHeaderLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Subjectlabel;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Panel searchPanel;
        private FontAwesome.Sharp.IconButton saveEditButton;
        private FontAwesome.Sharp.IconButton AddDesignationCloseButton;
        private PlaceholderTextBox.PlaceholderTextBox placeholderTextBox1;
    }
}