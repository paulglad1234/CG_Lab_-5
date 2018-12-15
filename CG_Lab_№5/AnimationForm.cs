using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Lab__5
{
    public partial class AnimationForm : Form
    {
        private World w;
        private ScreenConverter sc;
        public AnimationForm()
        {
            InitializeComponent();
            w = new World(new SizeF(Width, Height));
            sc = new ScreenConverter(new Size(Width, Height),
                new RectangleF(0, w.Height, w.Width, w.Height));
            
        }

        private void AnimationForm_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bmp);
            w.DrawAll(g, sc);
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startGB.Visible = false;
            updateTimer.Start();
            drawTimer.Start();
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private DateTime last = DateTime.Now;
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;

            last = current;
        }
    }
}
