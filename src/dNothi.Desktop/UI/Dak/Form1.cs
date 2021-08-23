using dNothi.Desktop.UI.Profile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void choosePicButton_Click(object sender, EventArgs e)
        {
            UploadPictureUserControl uploadPictureUserControl = new UploadPictureUserControl();
            uploadPictureUserControl.ChooseImage();
            UIDesignCommonMethod.CalPopUpWindow(uploadPictureUserControl, this);
        }

        private PictureBox picBox = new PictureBox();
        



        private bool Dragging;
        private int xPos;
        private int yPos;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) { Dragging = false; }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Dragging = true;
                xPos = e.X;
                yPos = e.Y;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (Dragging && c != null)
            {
                c.Top = e.Y + c.Top - yPos;
                c.Left = e.X + c.Left - xPos;
            }
        }

        private void officerEditablePictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
