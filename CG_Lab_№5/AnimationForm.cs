using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            w = new World(new SizeF(worldPanel.Width, worldPanel.Height));
            sc = new ScreenConverter(new Size(worldPanel.Width, worldPanel.Height),
                new RectangleF(0, w.Height, w.Width, w.Height));
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startGB.Visible = false;
            updateTimer.Start();
            drawTimer.Start();
            Focus();
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            worldPanel.Invalidate();
        }

        private DateTime last = DateTime.Now;
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            try { w.Update((current - last).Milliseconds * 0.1f); }
            catch
            {
                startGB.Visible = true;
                label1.Text = "Поражение!";
                drawTimer.Enabled = false;
                updateTimer.Enabled = false;
                w = new World(new SizeF(worldPanel.Width, worldPanel.Height));
                worldPanel.Invalidate();
            }
            last = current;
        }

        private void worldPanel_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bmp);
            w.DrawAll(g, sc);
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
            g.Dispose();
        }

        private void AnimationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                w.UFO.Shooting = true;
            }
            if (e.KeyData == Keys.A)
            {
                w.UFO.Speed.X = -3;
                return;
            }
            if (e.KeyData == Keys.D)
            {
                w.UFO.Speed.X = 3;
                return;
            }
            if (e.KeyData == Keys.W)
            {
                w.UFO.Speed.Y = 3;
                return;
            }
            if (e.KeyData == Keys.S)
            {
                w.UFO.Speed.Y = -3;
                return;
            }
        }

        private void AnimationForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                w.UFO.Shooting = false;
            }
            if (e.KeyData == Keys.A || e.KeyData == Keys.D)
            {
                w.UFO.Speed.X = 0;
                return;
            }
            if (e.KeyData == Keys.W || e.KeyData == Keys.S)
            {
                w.UFO.Speed.Y = 0;
                return;
            }
        }
    }
}
