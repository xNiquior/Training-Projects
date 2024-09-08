using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_7
{
    public class Circle : GeometryShape
    {
        public override string Name { get => "Circle"; }

        public Circle(string color, int size, (int, int) centreCoords) : base(color, size, centreCoords) { }

        public override double Area()
            => (int)(0.25 * Math.PI * Math.Pow(Size, 2));
        public override void Draw(Graphics g, Color color)
    => g.DrawEllipse(new Pen(color, 4), CentreCoords.X - Size / 2, CentreCoords.Y - Size / 2, Size, Size);
        public override bool IsPointInShape(int x, int y)
        {
            double R = Size / 2;
            return Math.Pow(CentreCoords.X - x, 2) + Math.Pow(CentreCoords.Y - y, 2) <= Math.Pow(R, 2);
        }
        public override void Choose()
        {

        }
    }
}
