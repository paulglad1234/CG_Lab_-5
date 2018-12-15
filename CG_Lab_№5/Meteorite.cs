using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Lab__5
{
    class Meteorite
    {
        public Vector Position { get; set; }
        public float R { get; set; }
        public Meteorite(Vector position, float r)
        {
            Position = position;
            R = r;
        }
    }
}