using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_Lab__5
{
    class World
    {
        public SizeF Size { get; set; }
        public float Width { get { return Size.Width; } }
        public float Height { get { return Size.Height; } }
        public List<Meteorite> Meteorites { get; set; }
        public Spaceship Spaceship { get; private set; }
        public World(SizeF size)
        {
            Size = size;
            Meteorites = new List<Meteorite>();
            Spaceship = new Spaceship(new Vector(Width / 2, 0));
            Random r = new Random();
            int n = r.Next(1,8);
            for (int i = 0; i < n; i++)
            {
                Meteorites.Add(new Meteorite(new Vector(r.Next(0, (int)(Width / 2 - 40)), r.Next(0, (int)Height)), 10));
                Meteorites.Add(new Meteorite(new Vector(r.Next((int)(Width / 2 + 40), (int)Width), r.Next(0, (int)Height)), 10));
            }
        }
        public void DrawAll(Graphics g, ScreenConverter sc)
        {
            DrawSpaceship(g, sc);
            foreach (Meteorite p in Meteorites)
            {
                DrawMeteorite(p, g, sc);
            }
        }
        private void DrawMeteorite(Meteorite p, Graphics g, ScreenConverter sc)
        {
            Point pnt = sc.R2S(p.Position);
            float r = sc.R2S(p.R);
            g.FillEllipse(Brushes.Beige, pnt.X - r, pnt.Y - r, r + r, r + r);
        }
        private void DrawSpaceship(Graphics g, ScreenConverter sc)
        {
            g.FillEllipse(Brushes.Orange, Spaceship.Position.X - 20, Spaceship.Position.Y - 20, 40, 40);
        }
    }
}
