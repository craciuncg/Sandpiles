using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandpiles
{
    public partial class Form1 : Form
    {

        public Graphics gfx;

        public Sandpile sandpile;
        public int width, height;

        public const int amount = 100000;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            width = pictureBox1.Width;
            height = pictureBox1.Height;

            sandpile = new Sandpile(width, height);
            sandpile.Drop(amount);
            
            sandpile.Topple();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            gfx.Clear(Color.Black);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    switch (sandpile.Data()[i, j])
                    {
                        case 1:
                            {
                                gfx.DrawRectangle(new Pen(Color.White), i, j, 1, 1);
                                break;
                            }
                        case 2:
                            {
                                gfx.DrawRectangle(new Pen(Color.Purple), i, j, 1, 1);
                                break;
                            }
                        case 3:
                            {
                                gfx.DrawRectangle(new Pen(Color.Brown), i, j, 1, 1);
                                break;
                            }

                    }
                    
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static void LogMatrix(int[,] m)
        {

        }
    }
}
