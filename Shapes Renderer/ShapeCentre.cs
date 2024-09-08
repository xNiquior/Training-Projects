using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Renderer
{
    public class ShapeCentre
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ShapeCentre((int, int) pair)
        {
            X = pair.Item1;
            Y = pair.Item2;
        }
    }
}
