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
         
       

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = @"\media\background.wav";
            var path = Path.GetFullPath(basePath+relativePath);
            SoundPlayer simpleSound = new SoundPlayer(path);
            simpleSound.PlayLooping();

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());

            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Font myFont = new System.Drawing.Font("Helvetica", 40, FontStyle.Italic);
            Brush myBrush = new SolidBrush(System.Drawing.Color.Red);
            graphicsObj.DrawString(e.KeyChar.ToString(), myFont, myBrush, Random(rand, 0, 1000), Random(rand, 50, 1000));
            DrawRectangle();
        }

        private void DrawRectangle()
        {
            Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();

            Pen myPen = new Pen(System.Drawing.Color.Red, 8);

           
            // myRectangle = new Rectangle(20, 20, Random(rand, 0, 500), Random(rand, 50, 500));

            switch (Random(rand,0,6))
            {
                case 1:
                    var round = new Rectangle(Random(rand, 0, 1000), Random(rand, 50, 1000), 25, 20);
                    graphicsObj.DrawRectangle(myPen, round);
                    break;
                case 2:
                    Rectangle myRectangle = new Rectangle(Random(rand, 0, 1000), Random(rand, 50, 1000), 25, 20);
                    graphicsObj.DrawRectangle(myPen, myRectangle);
                    break;
                case 3:
                    DrawImage("peppa.png");
                    break;
                case 4:
                    DrawImage("Daddy_Pig.png");
                    break;
                case 5:
                    DrawImage("Mummy_Pig.png");
                    break;
                case 6:
                    DrawImage("jorge.png");
                    break;
                default:
                    var dd = new Rectangle(Random(rand, 0, 1000), Random(rand, 50, 1000), 25, 25);
                    graphicsObj.DrawRectangle(myPen, dd);
                    break;
            }
           
           // graphicsObj.DrawPolygon(myPen, myRectangle);
            
        }

        public static int Random(Random rand, int min, int max)
        {
            return rand.Next(min, max);
        }

        private void DrawImage(string imageName)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            string basePath = Environment.CurrentDirectory;
            string relativePath = @"\media\"+ imageName;
            var path = Path.GetFullPath(basePath + relativePath);
            Image image2 = Image.FromFile(path);
            // Draw the image.
            graphicsObj.DrawImage(image2, Random(rand, 0, 1000), Random(rand, 0, 1000));
        }
    }
}
