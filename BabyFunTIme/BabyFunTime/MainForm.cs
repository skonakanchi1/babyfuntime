using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            simpleSound.Play();

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
            graphicsObj.DrawString(e.KeyChar.ToString(), myFont, myBrush, Random(rand,0, 1000), Random(rand,50, 1000));
        }

        public static int Random(Random rand, int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
