using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace BabyFunTime
{
    public partial class MainForm : Form
    {
        Random rand = new Random();
        System.Drawing.Graphics graphicsObj;
       


        public MainForm()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            graphicsObj = this.CreateGraphics();
            string basePath = Environment.CurrentDirectory;
            string relativePath = @"\media\background.wav";
            var path = Path.GetFullPath(basePath+relativePath);
            SoundPlayer simpleSound = new SoundPlayer(path);
            simpleSound.PlayLooping();
            pictureBox1.Show();
            timer1.Start();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Font myFont = new System.Drawing.Font("Helvetica", 40, FontStyle.Italic);
            //Brush myBrush = new SolidBrush(System.Drawing.Color.Red);
            //graphicsObj.DrawString(e.KeyChar.ToString(), myFont, myBrush, Random(rand, 0, 1000), Random(rand, 50, 1000));
            DrawRectangle();
            if (e.KeyChar == (char)Keys.Space)
            {
                panMain.Controls.Clear();
                
            }
        }

        private void DrawRectangle()
        {
            //Graphics graphicsObj;

            //graphicsObj = this.CreateGraphics();

            //Pen myPen = new Pen(System.Drawing.Color.Red, 8);

           
            // myRectangle = new Rectangle(20, 20, Random(rand, 0, 500), Random(rand, 50, 500));

            switch (Random(rand,0,4))
            {
                //case 1:
                //    var round = new Rectangle(Random(rand, 0, 1000), Random(rand, 50, 1000), 25, 20);
                //    graphicsObj.DrawRectangle(myPen, round);
                //    break;
                //case 2:
                //    Rectangle myRectangle = new Rectangle(Random(rand, 0, 1000), Random(rand, 50, 1000), 25, 20);
                //    graphicsObj.DrawRectangle(myPen, myRectangle);
                //    break;
                case 3:
                    DrawImage("peppa.gif");
                    break;
                case 4:
                    DrawImage("music.gif");
                    break;
                case 5:
                    DrawImage("jorge.gif");
                   break;
                //case 6:
                //    DrawImage("jorge.png");
                //    break;
                                 
                default:
                    //var dd = new Rectangle(Random(rand, 0, 1000), Random(rand, 50, 1000), 25, 25);
                    //graphicsObj.DrawRectangle(myPen, dd);
                    DrawImage("music.gif");
                    break;
            }
           
        }

        public static int Random(Random rand, int min, int max)
        {
            return rand.Next(min, max);
        }

        private void DrawImage(string imageName)
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = @"\media\"+ imageName;
            var path = Path.GetFullPath(basePath + relativePath);
            PictureBox image2 =new PictureBox();
            image2.ImageLocation =path ;
            image2.Location = new Point(Random(rand, 0, 1000), Random(rand, 0, 1000));
            image2.Size = new Size(300, 300);
            image2.SizeMode = PictureBoxSizeMode.StretchImage;
            // Draw the image.9++
            panMain.Controls.Add(image2);

           //graphicsObj.DrawImage(image2, Random(rand, 0, 1000), Random(rand, 0, 1000));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in panMain.Controls)
            {
                var picturebox =(PictureBox) item;
                int x = picturebox.Location.X;
                int y = picturebox.Location.Y;

                picturebox.Location = new Point(x + 50, y-25);

                if (x > this.Width)
                    timer1.Stop();
            }
            
        }
    }
}
