using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Profile
{
    public partial class UploadPictureUserControl : Form
    {
        public UploadPictureUserControl()
        {
            InitializeComponent();
            

        }

        public Image Image;
        public string Extension;
        public Image _PictureBoxImage;
        public string _PictureBoxImagePath;
        public bool ChooseImage()
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.png; *.jpeg; *.bmp";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {

                
                officerEditablePictureBox.Image = Image = new Bitmap(new Bitmap(opnfd.FileName), 235, 235);
                Extension= Path.GetExtension(opnfd.FileName).ToLower();
                return true;
            }
            return false;
        }

       
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int imgHeight = Convert.ToInt32(Image.Height * trackBar1.Value);
            int imgWidth = Convert.ToInt32(Image.Width * trackBar1.Value);


            Bitmap bitmap = new Bitmap(Image, imgWidth, imgHeight);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            officerEditablePictureBox.Image = bitmap;
        }


        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void rightRotateButton_Click(object sender, EventArgs e)
        {
            officerEditablePictureBox.Image = RotateImage(officerEditablePictureBox.Image, 90);
        }

        private void leftRotateIconButton_Click(object sender, EventArgs e)
        {
            officerEditablePictureBox.Image = RotateImage(officerEditablePictureBox.Image, -90);
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value != trackBar1.Maximum)
            {
                trackBar1.Value += 1;
                trackBar1_Scroll(new object(), new EventArgs());
            }
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if(trackBar1.Value!=trackBar1.Minimum)
            {
                trackBar1.Value = trackBar1.Value-1;
                trackBar1_Scroll(new object(), new EventArgs());
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public EventHandler SaveImageButton;
        private void choosePicButton_Click(object sender, EventArgs e)
        {

            int width = picturePanel.Size.Width;
            int height = picturePanel.Size.Height;

            Bitmap bm = new Bitmap(width, height);
            picturePanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            _PictureBoxImage = bm;

         


            
            if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png")
            {
             string  UploadFileName = "orig_" + Guid.NewGuid().ToString() + Extension.ToUpper();
                _PictureBoxImagePath = Directory.GetCurrentDirectory()+"\\"+ UploadFileName;
                try
                {
                    bm.Save(_PictureBoxImagePath);
                }
                catch(Exception E)
                {

                }
                
            }

            // Bitmap bmp = new Bitmap(officerEditablePictureBox.Image);

            //  int pX =-officerEditablePictureBox.Location.X;
            //  int pY =-officerEditablePictureBox.Location.Y;

            //  _PictureBoxImage = bmp.Clone(
            // new Rectangle { X = pX, Y = pY, Width = picturePanel.Width, Height = picturePanel.Height },
            // bmp.PixelFormat);
            this.Hide();

            if (this.SaveImageButton != null)
                this.SaveImageButton(sender, e);

           
        }
    }
}
