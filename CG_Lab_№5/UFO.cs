using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Lab__5
{
    class UFO
    {
        public Vector Position { get; set; }
        public float R { get; set; }
        public Vector Speed { get; set; }
        public bool Shooting { get; set; }
        public UFO(Vector position, float r)
        {
            Position = position;
            Speed = Vector.Zero;
            R = r;
            Shooting = false;
        }
    }
}
