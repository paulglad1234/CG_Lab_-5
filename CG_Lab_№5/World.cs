using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace CG_Lab__5
{
    class World
    {
        public SizeF Size { get; set; }
        public float Width { get { return Size.Width; } }
        public float Height { get { return Size.Height; } }
        private List<Meteorite> Meteorites { get; set; }
        private Vector Met_Speed { get; set; }
        private Vector Met_Velocity { get; set; }
        public UFO UFO { get; set; }
        public World(SizeF size)
        {
            Size = size;
            Meteorites = new List<Meteorite>();
            UFO = new UFO(new Vector(Width * 0.5f, 30), 30);
            Random rnd = new Random();
            int n = rnd.Next(1, 8);
            for (int i = 0; i < n; i++)
            {
                int r = rnd.Next(10, 30);
                Meteorites.Add(new Meteorite(new Vector(rnd.Next(0, (int)(Width / 2 - UFO.R - r)), rnd.Next(0, (int)Height)), r));
                r = rnd.Next(50);
                Meteorites.Add(new Meteorite(new Vector(rnd.Next((int)(Width / 2 + UFO.R + r), (int)Width), rnd.Next(0, (int)Height)), r));
            }
            Met_Speed = new Vector(0, -1);
            Met_Velocity = new Vector(0, -0.0001f);
        }
        public void DrawAll(Graphics g, ScreenConverter sc)
        {
            /*Thread t1 = new Thread(() =>
            {
                foreach (Meteorite m in Meteorites)
                {
                    DrawMeteorite(m, g, sc);
                }
            });
            t1.Start();*/
            foreach (Meteorite m in Meteorites)
            {
                DrawMeteorite(m, g, sc);
            }
            
            DrawUFO(g, sc);
            if (UFO.Shooting)
                DrawLaser(g, sc);
        }
        private void DrawMeteorite(Meteorite p, Graphics g, ScreenConverter sc)
        {
            Point pnt = sc.R2S(p.Position);
            float r = sc.R2S(p.R);
            g.FillEllipse(Brushes.Beige, pnt.X - r, pnt.Y - r, r + r, r + r);
            g.DrawEllipse(new Pen(Brushes.DarkGray, 2), pnt.X - r * 0.75f, pnt.Y - r * 0.25f, r, r);
        }
        private void DrawUFO(Graphics g, ScreenConverter sc)
        {
            Point pnt = sc.R2S(UFO.Position);
            float r = sc.R2S(UFO.R);
            g.FillEllipse(Brushes.LightSteelBlue, pnt.X - r, pnt.Y - r, r + r, r + r);
            g.FillEllipse(Brushes.SteelBlue, pnt.X - r* 0.75f, pnt.Y - r * 0.75f, r * 1.5f, r * 1.5f);
        }
        public void Update(float dt)
        {
            UpdateSpaceship(dt);
            for (int i = 0; i < Meteorites.Count; i++)
            {
                UpdateMeteorite(Meteorites[i], dt, ref i);
            }
            Met_Speed += Met_Velocity * dt;
            GenerateNewMeteorite();
        }
        private void GenerateNewMeteorite()
        {
            Random rnd = new Random();
            int n = rnd.Next(0, 10);
            if (n == 1)
            {
                int r = rnd.Next(10, 30);
                Meteorites.Add(new Meteorite(new Vector(rnd.Next(0, (int)Width), Height + r), r));
            }
        }
        private void UpdateMeteorite(Meteorite m, float t, ref int i)
        {
            m.Position += Met_Speed * t + Met_Velocity * t * t * 0.5f;
            if (m.Position.DistanceTo(UFO.Position) <= m.R + UFO.R)
            {
                throw new Exception();
            }
            if (m.Position.Y < -m.R || Check(m))
            {
                Meteorites.RemoveAt(i);
                i--;
            }
        }
        private void UpdateSpaceship(float t)
        {
            Vector pos = UFO.Position + UFO.Speed * t;
            if (pos.X > 0 && pos.X < Width && pos.Y > 0 && pos.Y < Height)
                UFO.Position = pos;
        }
        private void DrawLaser(Graphics g, ScreenConverter sc)
        {
            Point p = sc.R2S(UFO.Position);
            float r = sc.R2S(UFO.R);
            g.FillEllipse(Brushes.Blue, p.X - 10, p.Y - 10, 20, 20);
            g.FillRectangle(Brushes.Black, p.X - 3, p.Y - 20, 6, 20);
            g.FillRectangle(Brushes.Red, p.X - 3, 0, 6, p.Y - 20);
        }
        private bool Check(Meteorite m)
        {
            if (UFO.Shooting)
            {
                Vector l = new Vector(UFO.Position.X - 3, m.Position.Y);
                if (m.Position.DistanceTo(l) <= m.R)
                    return true;
                l.X += 6;
                return m.Position.DistanceTo(l) <= m.R;
            }
            return false;
        }
    }
}
