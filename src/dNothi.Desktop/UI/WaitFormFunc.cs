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
        //public WaitFormFunc()
        //{
        //   // wait =new WaitNothiForm();
        //   // loadthread = null;
           
        //}

       public void Show()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcess));
            loadthread.Start();
        }

        public void Show(Form parent)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcess));
           // loadthread.SetApartmentState(ApartmentState.STA);
            loadthread.Start(parent);
        }

        public void Close()
        {
            if (wait != null)
            {
                // loadthread = new Thread(new ThreadStart(LoadingProcess));
                //loadthread.Start();
                //wait.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
                wait.BeginInvoke(new System.Threading.ThreadStart(wait.CloseWaitForm));
                //wait.Hide();
               // wait.BeginInvoke(new Action(() => wait.Close()));
                wait = null;
                loadthread = null;
                
            }
          
        }
        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void LoadingProcess()
        {
            wait = new WaitNothiForm();
            wait.ShowDialog();

        }

        private void LoadingProcess(object parent)
        {
            Form parent1 = parent as Form;
            wait = new WaitNothiForm(parent1);
            Application.Run(wait);
            //wait.ShowDialog();
            CalPopUpWindow(wait);
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();

            hideform.BackColor = Color.Black;
            hideform.Height = Screen.PrimaryScreen.WorkingArea.Height; //{Width = 1382 Height = 744}
            hideform.Width = Screen.PrimaryScreen.WorkingArea.Width; //{Width = 1382 Height = 744}
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
    }
}
