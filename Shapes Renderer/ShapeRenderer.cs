using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LB_7.Shapes;

namespace Shape_Renderer
{
    public class ShapeRenderer
    {
        public static List<GeometryShape> GeometryShapes = new List<GeometryShape>();

        private static readonly Random random = new Random();
        

        public static void AddSpecificShape(string shape, string colorName, int size, (int, int) centreCoords)
        {
            switch (shape)
            {
                case "Square":
                    GeometryShapes.Add(new Square(colorName, size, centreCoords));
                    break;
                case "Circle":
                    GeometryShapes.Add(new Circle(colorName, size, centreCoords));
                    break;
                case "Triangle":
                    GeometryShapes.Add(new Triangle(colorName, size, centreCoords));
                    break;
                default:
                    throw new InvalidOperationException("Incorrect shape format!");
            }

        }
        public static void AddNewRandomShape()
        {
            string colorKey = GeometryShape.Colors.ElementAt(random.Next(0, GeometryShape.Colors.Count)).Key;
            int size = random.Next(20, 250);
            (int, int) centreCoords = (random.Next(100, 1500), random.Next(100, 1000));

            switch (random.Next(0, 3))
            {
                case 0:
                    GeometryShapes.Add(new Square(colorKey, size, centreCoords));
                    break;
                case 1:
                    GeometryShapes.Add(new Circle(colorKey, size, centreCoords));
                    break;
                case 2:
                    GeometryShapes.Add(new Triangle(colorKey, size, centreCoords));
                    break;
                default:
                    throw new InvalidOperationException("Incorrect shape format!");
            }
        }
        public static void Render(Graphics graphics)
        {
            foreach (var shape in GeometryShapes)
            {
                shape.Draw(graphics);
            }
        }
    }
}
