using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_7.Shapes
{
    public class Circle : GeometryShape
    {
        public Circle(string color, int size, (int, int) centreCoords) : base(color, size, centreCoords) { }


        public override string Name { get => "Circle"; }
        public override double Area { get => (int)(0.25 * Math.PI * Math.Pow(Size, 2)); }
        public double Radius { get => Size / 2; }


        public override void Draw(Graphics graphics)
            => graphics.DrawEllipse(new Pen(Colors[ColorName], SHAPE_BORDER_WIDTH), CentreCoords.X - (int)Radius, CentreCoords.Y - (int)Radius, Size, Size);

        public override bool IsPointInShape(int x, int y)
            => Math.Pow(CentreCoords.X - x, 2) + Math.Pow(CentreCoords.Y - y, 2) <= Math.Pow(Radius, 2);
    }
}
