using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_7.Shapes
{
    public class Square : GeometryShape
    {
        public Square(string color, int size, (int, int) centreCoords) : base(color, size, centreCoords) { }


        public override string Name { get => "Square"; }
        public override double Area { get => Size * Size; }


        public override void Draw(Graphics graphics)
            => graphics.DrawRectangle(new Pen(Colors[ColorName], SHAPE_BORDER_WIDTH), CentreCoords.X - Size / 2, CentreCoords.Y - Size / 2, Size, Size);

        public override bool IsPointInShape(int x, int y)
        {
            double R = Size / 2;
            return R >= Math.Abs(CentreCoords.X - x) &&
                   R >= Math.Abs(CentreCoords.Y - y);
        }
    }
}
