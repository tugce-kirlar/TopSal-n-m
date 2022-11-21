using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopSalınım
{
    public partial class Form1 : Form
    {

        List<PictureBox> eListesi = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
        }

        Timer t;
      

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
            Timer t = new Timer();
            t.Start();
            t.Interval = 10;
            t.Tick += T_Tick;
            Random rnd = new Random();

            foreach(Control item in panel1.Controls)
            {
                if (item.Tag!=null && item.Tag.ToString() == "engel") 
                {
                    PictureBox p = (PictureBox)item;
                    eListesi.Add(p);
                    int r = rnd.Next(256);
                    int g = rnd.Next(256);
                    int b = rnd.Next(256);
                    p.BackColor = Color.FromArgb(r, g, b);

                    //p.Click += (s, ee) =>
                    //{
                        
                    //};
                }
            }

           

        }

        int xHiz = 1;
        int yHiz = 1;

        private void T_Tick(object sender, EventArgs e)
        {
            nesne.Left += xHiz;
            nesne.Top += yHiz;

            if (nesne.Top + nesne.Height > pictureBox1.Top && nesne.Left>pictureBox1.Left&&nesne.Left<pictureBox1.Left+pictureBox1.Width)
            {
                yHiz = -yHiz;
            }
            else if (nesne.Left + nesne.Width > nesne.Parent.Width)
            {
                xHiz = -xHiz;
            }
            else if (nesne.Left < 0)
            {
                xHiz = -xHiz;
            }
            else if (nesne.Top < 0)
            {
                yHiz = -yHiz;
            }

            int x2 = nesne.Left + nesne.Width / 2;
            int y2 = nesne.Top + nesne.Height / 2;

            foreach (PictureBox item in eListesi)
            {
               int x1= item.Left + item.Width / 2;
               int y1 = item.Top + item.Height / 2;

                //distance-uzaklık

                double d = Math.Sqrt((y1 - y2) * (y1 - y2) + (x1 - x2) * (x1 - x2));
                if (d < 30)
                {
                    panel1.Controls.Remove(item);
                    eListesi.Remove(item);

                    break;
                }
            }
        

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                pictureBox1.Left -= 10;
            }
            else if (e.KeyCode==Keys.Right)
            {
               pictureBox1.Left += 10;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
