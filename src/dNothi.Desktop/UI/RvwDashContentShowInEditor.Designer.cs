
namespace dNothi.Desktop.UI
{
    partial class RvwDashContentShowInEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RvwDashContentShowInEditor));
            this.RVWBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tinyMCEPanel = new System.Windows.Forms.Panel();
            this.tinyMceEditor = new CefSharp.WinForms.ChromiumWebBrowser();
            this.tinyMCEPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tinyMCEPanel
            // 
            this.tinyMCEPanel.AutoScroll = true;
            this.tinyMCEPanel.Controls.Add(this.tinyMceEditor);
            this.tinyMCEPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tinyMCEPanel.Location = new System.Drawing.Point(0, 0);
            this.tinyMCEPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tinyMCEPanel.Name = "tinyMCEPanel";
            this.tinyMCEPanel.Size = new System.Drawing.Size(1800, 695);
            this.tinyMCEPanel.TabIndex = 3;
            // 
            // tinyMceEditor
            // 
            this.tinyMceEditor.ActivateBrowserOnCreation = true;
            this.tinyMceEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tinyMceEditor.Location = new System.Drawing.Point(0, 0);
            this.tinyMceEditor.Margin = new System.Windows.Forms.Padding(4);
            this.tinyMceEditor.Name = "tinyMceEditor";
            this.tinyMceEditor.Size = new System.Drawing.Size(1800, 695);
            this.tinyMceEditor.TabIndex = 0;
            this.tinyMceEditor.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.tinyMceEditor_FrameLoadEnd);
            this.tinyMceEditor.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.tinyMceEditor_LoadingStateChanged);
            // 
            // RvwDashContentShowInEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1800, 695);
            this.Controls.Add(this.tinyMCEPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RvwDashContentShowInEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RvwDashContentShowInEditor_Load);
            this.tinyMCEPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private XTextBox xTextBox1;
        private CircularButton circularButton1;
        private designationSelect designationSelect1;
        private System.ComponentModel.BackgroundWorker RVWBackgroundWorker;
        private System.Windows.Forms.Panel tinyMCEPanel;
        private CefSharp.WinForms.ChromiumWebBrowser tinyMceEditor;
    }
}