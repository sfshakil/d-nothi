namespace dNothi.Desktop.UI.CustomMessageBox
{
    partial class OnlineToggleButton
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
            this.onlineButton = new FontAwesome.Sharp.IconButton();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // onlineButton
            // 
            this.onlineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onlineButton.FlatAppearance.BorderSize = 0;
            this.onlineButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.onlineButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.onlineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onlineButton.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
            this.onlineButton.IconColor = System.Drawing.Color.Green;
            this.onlineButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.onlineButton.Location = new System.Drawing.Point(0, 5);
            this.onlineButton.Margin = new System.Windows.Forms.Padding(0);
            this.onlineButton.Name = "onlineButton";
            this.onlineButton.Size = new System.Drawing.Size(63, 37);
            this.onlineButton.TabIndex = 0;
            this.onlineButton.UseVisualStyleBackColor = true;
            this.onlineButton.Click += new System.EventHandler(this.onlineButton_Click);
            // 
            // OnlineToggleButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.onlineButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OnlineToggleButton";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Size = new System.Drawing.Size(63, 42);
            this.Load += new System.EventHandler(this.OnlineToggleButton_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton onlineButton;
        private System.Windows.Forms.ToolTip MyToolTip;
    }
}
