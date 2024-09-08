using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_7.Shapes
{
    public class Triangle : GeometryShape
    {
        public Triangle(string color, int size, (int, int) centreCoords) : base(color, size, centreCoords) { }


        public override string Name { get => "Triangle"; }
        public override double Area { get => (int)(Math.Pow(Size, 2) / Math.Sqrt(3)); }


        public override void Draw(Graphics graphics)
        {
            Point[] points = new Point[]
            {
                new Point(CentreCoords.X, CentreCoords.Y - 2 * Size / 3),
                new Point((int)(CentreCoords.X - Size / Math.Sqrt(3)), CentreCoords.Y + Size / 3),
                new Point((int)(CentreCoords.X + Size / Math.Sqrt(3)), CentreCoords.Y + Size / 3)
            };

            graphics.DrawPolygon(new Pen(Colors[ColorName], SHAPE_BORDER_WIDTH), points);
        }

        public override bool IsPointInShape(int x, int y)
        {
            return y - CentreCoords.Y >= -(int)Math.Sqrt(3) * (x - CentreCoords.X) - 2 * Size / 3 &&
                   y - CentreCoords.Y >= (int)Math.Sqrt(3) * (x - CentreCoords.X) - 2 * Size / 3 &&
                   y - CentreCoords.Y <= Size / 3;
        }
    }
}
