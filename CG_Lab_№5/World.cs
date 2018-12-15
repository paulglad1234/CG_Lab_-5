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
            Spaceship = null;
            Random r = new Random();
            int n = r.Next(1,15);
            for (int i = 0; i < n; i++)
            {
                Meteorites.Add(new Meteorite(new Vector(r.Next(0, (int)Width), r.Next(0, (int)Height)), 10));
            }
        }
        public void DrawAll(Graphics g, ScreenConverter sc)
        {
            foreach (Meteorite p in Meteorites)
            {
                Point pnt = sc.R2S(p.Position);
                float r = sc.R2S(p.R);
                g.FillEllipse(Brushes.Beige, pnt.X - r, pnt.Y - r, r + r, r + r);
            }
        }
    }
}
