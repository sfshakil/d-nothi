using dNothi.Desktop.UI;
using dNothi.Desktop.UI.Dak;
using Nothi.JsonParser.Entity.Dak_List_Inbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            designationSelect2.Hide();
        }

        public Dashboard(List<DakListInboxRecordsDTO> dakLists)
        {
            InitializeComponent();
            List<DakInboxUserControl> dakInboxUserControls = new List<DakInboxUserControl>();
            int i = 0;
            foreach (DakListInboxRecordsDTO dakListInboxRecordsDTO in dakLists)
            {

                DakInboxUserControl dakInboxUserControl = new DakInboxUserControl();
                dakInboxUserControl.date = dakListInboxRecordsDTO.dak_user.last_movement_date;
                dakInboxUserControl.subject = dakListInboxRecordsDTO.dak_user.dak_subject;
                dakInboxUserControl.decision = dakListInboxRecordsDTO.dak_user.dak_decision;
                dakInboxUserControl.source = dakListInboxRecordsDTO.dak_origin.name_bng;
                dakInboxUserControl.sender = dakListInboxRecordsDTO.movement_status.from.officer;
                dakInboxUserControl.receiver = dakListInboxRecordsDTO.movement_status.to[0].officer;
                i = i + 1;
                dakInboxUserControls.Add(dakInboxUserControl);
               
            }

            for (int j = 0; j <= dakInboxUserControls.Count - 1; j++)
            {
                dashBoardBodyPanel.Controls.Add(dakInboxUserControls[j]);
            }






        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.button1.ForeColor = Color.DodgerBlue;
       }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.ForeColor = Color.Black;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.button4.ForeColor = Color.DodgerBlue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.button4.ForeColor = Color.Black;
        }
        private void button16_MouseHover(object sender, EventArgs e)
        {
            this.button16.ForeColor = Color.DodgerBlue;
        }
        private void button16_MouseLeave(object sender, EventArgs e)
        {
            this.button16.ForeColor = Color.Black;
        }
        private void button5_MouseHover(object sender, EventArgs e)
        {
            this.button5.ForeColor = Color.DodgerBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.button5.ForeColor = Color.Black;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.button6.ForeColor = Color.DodgerBlue;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.button6.ForeColor = Color.Black;
        }

        private void button10_MouseHover_1(object sender, EventArgs e)
        {
            this.button10.ForeColor = Color.DodgerBlue;
        }

        private void button10_MouseLeave_1(object sender, EventArgs e)
        {
            this.button10.ForeColor = Color.Black;
        }

        private void button17_MouseHover(object sender, EventArgs e)
        {
            this.button17.ForeColor = Color.DodgerBlue;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            this.button17.ForeColor = Color.Black;
        }

        private void button18_MouseHover(object sender, EventArgs e)
        {
            this.button18.ForeColor = Color.DodgerBlue;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            this.button18.ForeColor = Color.Black;
        }

        private void label1_Resize(object sender, EventArgs e)
        {
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.AutoSize = true;
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            this.label1.Size = new System.Drawing.Size(19, 20);
        }

        private void xTextBox2_MouseHover(object sender, EventArgs e)
        {
            this.xTextBox2.Text = "";
            this.xTextBox2.BackColor = Color.WhiteSmoke;
        }

        private void xTextBox2_MouseLeave(object sender, EventArgs e)
        {
            this.xTextBox2.Text = "খুঁজুন";
            this.xTextBox2.BackColor = Color.Gainsboro;
        }

        private void xTextBox2_MouseEnter(object sender, EventArgs e)
        {
            this.xTextBox2.Text = "";
            this.xTextBox2.BackColor = Color.WhiteSmoke;
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if(designationSelect2.Width==428)
            {
                designationSelect2.Show();
                designationSelect2.Width = 427;
                button15.BackColor = Color.WhiteSmoke;
            }
            else
            {
                designationSelect2.Hide();
                designationSelect2.Width = 428;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Nothi nothi = new Nothi();
            //nothi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
        }
        private bool IsCollasped;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(IsCollasped)
            {
                panelDropDownDakUpload.Height +=10;
                if(panelDropDownDakUpload.Size==panelDropDownDakUpload.MaximumSize)
                {
                    timer1.Stop();
                    IsCollasped = false;
                }
               
            }
            else
            {
                panelDropDownDakUpload.Height -= 10;
                if (panelDropDownDakUpload.Size == panelDropDownDakUpload.MinimumSize)
                {
                    timer1.Stop();
                    IsCollasped = true;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
} 
