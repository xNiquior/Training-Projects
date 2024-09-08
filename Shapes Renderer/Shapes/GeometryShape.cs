using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shape_Renderer;

namespace LB_7.Shapes
{
    public abstract class GeometryShape
    {
        public readonly static Dictionary<string, Color> Colors = new()
        {
            {"Black", Color.Black},
            {"Blue", Color.Blue},
            {"Green", Color.Green},
            {"Brown", Color.Brown},
            {"Coral", Color.Coral},
            {"Cyan", Color.Cyan},
            {"DarkGray", Color.DarkGray},
            {"Gold", Color.Gold},
            {"Lime", Color.Lime},
            {"Navy", Color.Navy},
            {"Orange", Color.Orange},
            {"Pink", Color.Pink},
            {"Purple", Color.Purple},
            {"Red", Color.Red},
            {"Orchid", Color.Orchid},
            {"Salmon", Color.Salmon},
            {"Silver", Color.Silver},
            {"Yellow", Color.Yellow},
            {"Violet", Color.Violet},
            {"Wheat", Color.Wheat},
        };

        public ShapeCentre CentreCoords;
        public string ColorName;
        public int Size;

        protected const float SHAPE_BORDER_WIDTH = 4;


        public GeometryShape(string colorName, int size, (int, int) centreCoords)
        {
            ColorName = colorName;
            Size = size;
            CentreCoords = new(centreCoords);
        }


        public abstract string Name { get; }
        public virtual double Area { get; }


        public virtual string ShowInfo()
            => $"{Name}, {Area}";

        public abstract void Draw(Graphics graphics);

        public abstract bool IsPointInShape(int x, int y);
    }
}
