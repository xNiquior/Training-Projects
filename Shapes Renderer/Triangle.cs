using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_7
{
    public class Triangle : GeometryShape
    {
        public override string Name { get => "Triangle"; }

        public Triangle(string color, int size, (int, int) centreCoords) : base(color, size, centreCoords) { }

        public override double Area()
            => (int)(Math.Pow(Size, 2) / Math.Sqrt(3));
        public override void Draw(Graphics g, Color color)
        {
            Point[] points = new Point[]
            {
                new Point(CentreCoords.X, CentreCoords.Y - 2 * Size / 3),
                new Point((int)(CentreCoords.X - Size / Math.Sqrt(3)), CentreCoords.Y + Size / 3),
                new Point((int)(CentreCoords.X + Size / Math.Sqrt(3)), CentreCoords.Y + Size / 3)
            };
            g.DrawPolygon(new Pen(color, 4), points);
        }
        public override bool IsPointInShape(int x, int y)
        {
            return y - CentreCoords.Y >= -(int)Math.Sqrt(3) * (x - CentreCoords.X) - 2 * Size / 3 &&
                   y - CentreCoords.Y >= (int)Math.Sqrt(3) * (x - CentreCoords.X) - 2 * Size / 3 &&
                   y - CentreCoords.Y <= Size / 3;
        }
        public override void Choose()
        {

        }
    }
}
