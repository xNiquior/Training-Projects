using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_7
{
    public abstract class GeometryShape
    {
        public abstract string Name { get; }
        public virtual ShapeCentre CentreCoords { get; set; } = new((0, 0));
        public virtual string Color { get; set; }
        public virtual int Size { get; set; }

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

        public GeometryShape(string color, int size, (int, int) centreCoords)
        {
            Color = color;
            Size = size;

            CentreCoords.X = new ShapeCentre(centreCoords).X;
            CentreCoords.Y = new ShapeCentre(centreCoords).Y;

        }

        public virtual string Output()
            => $"{Name}, {Area()}";
        public abstract double Area();
        public abstract void Draw(Graphics g, Color color);
        public abstract bool IsPointInShape(int x, int y);
        public abstract void Choose();
    }
}
