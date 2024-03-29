﻿using dNothi.Desktop.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Utility
{
    public class WaitFormFunc
    {
        WaitNothiForm wait;
        Thread loadthread;
        public WaitFormFunc()
        {
            wait = new WaitNothiForm();
            loadthread = null;

        }

        public void Show()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcess));
            loadthread.Start();
        }

        public void Show(Form parent)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcess));

            loadthread.Start(parent);
        }

        public void Close()
        {
            if (wait != null)
            {
                wait.BeginInvoke(new System.Threading.ThreadStart(wait.CloseWaitForm));

                wait = null;
                loadthread = null;

            }
        }

        private void LoadingProcess()
        {
            wait = new WaitNothiForm();
            wait.ShowDialog();

        }

        private void LoadingProcess(object parent)
        {
            wait = new WaitNothiForm(parent as Form);

            CalPopUpWindow(wait, parent as Form);
        }
        private void CalPopUpWindow(Form form, Form parent)
        {
            Form hideform = new Form();
            hideform.BackColor = Color.Black;
            hideform.Height = Screen.PrimaryScreen.WorkingArea.Height; //{Width = 1382 Height = 744}
            hideform.Width = Screen.PrimaryScreen.WorkingArea.Width; //{Width = 1382 Height = 744}
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;
            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form, parent); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form, Form parent)
        {
            form.ShowInTaskbar = false;
            form.TopMost = false;
            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
    }
}
