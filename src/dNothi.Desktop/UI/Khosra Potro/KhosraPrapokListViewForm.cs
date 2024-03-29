﻿using dNothi.Services.KasaraPatraDashBoardService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraPrapokListViewForm : Form
    {
        public KhosraPrapokListViewForm()
        {
           // tableLayoutPanel1.Controls.Clear();
            InitializeComponent();
           
        }
        
        public PrapakerTalika _prapakerTalika { get; set; }
        public PrapakerTalika prapakerTalika
        {
            get { return _prapakerTalika; }
            set
            {
                _prapakerTalika = value;
                int count = 0;
                int row = 2;
                foreach (var item in value.data.receiver)
                {

                    KhosraPrapokListRowUserControl prapok = new KhosraPrapokListRowUserControl();
                    if (count < 1)
                    {
                        prapok.UserType = "প্রাপক";
                    }
                    prapok.UserName = item.officer;
                    prapok.UserDesignation = item.designation;
                    prapok.UserOfficeName = item.office;
                    prapok.Dock = DockStyle.Top;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 45f));
                    tableLayoutPanel1.Controls.Add(prapok, 0, row);
                    row = tableLayoutPanel1.RowCount++;
                    count = 1;

                }
                count = 0;
                foreach (var item in value.data.onulipi)
                {
                   
                    KhosraPrapokListRowUserControl anulipi = new KhosraPrapokListRowUserControl();
                    if (count < 1)
                    {
                        anulipi.UserType = "অনুলিপি";
                    }
                    anulipi.UserName = item.officer;
                    anulipi.UserDesignation = item.designation;
                    anulipi.UserOfficeName = item.office;
                    anulipi.Dock = DockStyle.Top;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 45f));

                    tableLayoutPanel1.Controls.Add(anulipi, 0, row);
                    row = tableLayoutPanel1.RowCount++;
                    count = 1;
                }
                count = 0;
                foreach (var item in value.data.approver)
                {
                    KhosraPrapokListRowUserControl approver = new KhosraPrapokListRowUserControl();
                    if (count < 1)
                    {
                        approver.UserType = "অনুমোদনকারী";
                    }
                    approver.UserName = item.officer;
                    approver.UserDesignation = item.designation;
                    approver.UserOfficeName = item.office;
                    approver.Dock = DockStyle.Top;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 45f));

                    tableLayoutPanel1.Controls.Add(approver, 0, row);
                    row = tableLayoutPanel1.RowCount++;
                    count = 1;
                }
                count = 0;
                foreach (var item in value.data.attention)
                {
                    KhosraPrapokListRowUserControl attention = new KhosraPrapokListRowUserControl();
                    if (count < 1)
                    {
                        attention.UserType = "দৃষ্টি আকর্ষণ";
                    }
                    attention.UserName = item.officer;
                    attention.UserDesignation = item.designation;
                    attention.UserOfficeName = item.office;
                    attention.Dock = DockStyle.Top;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 45f));

                    tableLayoutPanel1.Controls.Add(attention, 0, row);
                    row = tableLayoutPanel1.RowCount++;
                    count = 1;
                }
                count = 0;
                foreach (var item in value.data.sender)
                {
                    KhosraPrapokListRowUserControl sender = new KhosraPrapokListRowUserControl();
                    if (count < 1)
                    {
                        sender.UserType = "প্রেরক";
                    }
                    sender.UserName = item.officer;
                    sender.UserDesignation = item.designation;
                    sender.UserOfficeName = item.office;
                    sender.Dock = DockStyle.Top;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 45f));

                    tableLayoutPanel1.Controls.Add(sender, 0, row);
                    row = tableLayoutPanel1.RowCount++;
                    count = 1;

                }
            }
        }
        private void KhosraPrapokListViewForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = this.Width;
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void khosraPrapokListRowUserControl2_Load(object sender, EventArgs e)
        {  //sender
            //var senderListRowUserControl = new KhosraPrapokListRowUserControl();
            //senderListRowUserControl.UserName = prapakerTalika.data.receiver.Select(x => x.officer).FirstOrDefault();
            //senderListRowUserControl.UserDesignation= prapakerTalika.data.receiver.Select(x => x.designation).FirstOrDefault();
            //senderListRowUserControl.UserOfficeName = prapakerTalika.data.receiver.Select(x => x.office).FirstOrDefault();

        }

        private void khosraPrapokListRowUserControl1_Load(object sender, EventArgs e)
        {
            //reciver
            //var reciverListRowUserControl = new KhosraPrapokListRowUserControl();
            //reciverListRowUserControl.UserName = prapakerTalika.data.receiver.Select(x => x.officer).FirstOrDefault();
            //reciverListRowUserControl.UserDesignation = prapakerTalika.data.receiver.Select(x => x.designation).FirstOrDefault();
            //reciverListRowUserControl.UserOfficeName = prapakerTalika.data.receiver.Select(x => x.office).FirstOrDefault();
        }

        private void khosraPrapokListRowUserControl3_Load(object sender, EventArgs e)
        {
            //approver
            //var approverListRowUserControl = new KhosraPrapokListRowUserControl();
            //approverListRowUserControl.UserName = prapakerTalika.data.receiver.Select(x => x.officer).FirstOrDefault();
            //approverListRowUserControl.UserDesignation = prapakerTalika.data.receiver.Select(x => x.designation).FirstOrDefault();
            //approverListRowUserControl.UserOfficeName = prapakerTalika.data.receiver.Select(x => x.office).FirstOrDefault();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
