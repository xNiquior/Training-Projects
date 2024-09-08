using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace LB_7
{
    public partial class Form1 : Form
    {
        private static readonly Random rnd = new Random();
        private readonly Dictionary<string, Color> Colors = new Dictionary<string, Color>()
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
        private static List<GeometryShape> geometryShapes = new List<GeometryShape>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddNewRandomShape()
        {
            string colorKey = Colors.ElementAt(rnd.Next(0, Colors.Count)).Key;
            int size = rnd.Next(20, 250);
            (int, int) centreCoords = (rnd.Next(100, 1500), rnd.Next(100, 1000));

            switch (rnd.Next(0, 3))
            {
                case 0:
                    geometryShapes.Add(new Square(colorKey, size, centreCoords));
                    break;
                case 1:
                    geometryShapes.Add(new Circle(colorKey, size, centreCoords));
                    break;
                case 2:
                    geometryShapes.Add(new Triangle(colorKey, size, centreCoords));
                    break;
                default:
                    throw new InvalidOperationException("Неправильный тип фигуры!");
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (GeometryShape shape in geometryShapes)
            {
                shape.Draw(g, Colors.GetValueOrDefault(shape.Color));
            }
        }
        private void Create_Click(object sender, EventArgs e)
        {
            int beforeLenght = geometryShapes.Count;
            AddNewRandomShape();

            if (beforeLenght != geometryShapes.Count)
                Check.Text = $"Succesful: {beforeLenght} -> {geometryShapes.Count}! {geometryShapes[geometryShapes.Count - 1].Name}";
        }
        private void Save_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Log.txt", null);
            if (geometryShapes.Count > 0)
            {
                foreach (GeometryShape gs in geometryShapes)
                {
                    File.AppendAllText("Log.txt", $"{gs.Name}#{gs.Color}#{gs.Size}#{gs.CentreCoords.X}#{gs.CentreCoords.Y}" + Environment.NewLine);
                }
                Check.Text = $"Successfully saved: {geometryShapes.Count}!";
            }
        }
        private void Download_Click(object sender, EventArgs e)
        {
            geometryShapes.Clear();
            if (File.ReadAllLines("Log.txt") != null)
            {
                string[]? log = File.ReadAllLines("Log.txt");
                foreach (string line in log)
                {
                    string[] elements = line.Split('#');
                    switch (elements[0])
                    {
                        case "Square":
                            geometryShapes.Add(new Square(elements[1],
                                                               int.Parse(elements[2]),
                                                               (int.Parse(elements[3]), int.Parse(elements[4]))
                                                               ));
                            break;
                        case "Circle":
                            geometryShapes.Add(new Circle(elements[1],
                                                               int.Parse(elements[2]),
                                                               (int.Parse(elements[3]), int.Parse(elements[4]))
                                                               ));
                            break;
                        case "Triangle":
                            geometryShapes.Add(new Triangle(elements[1],
                                                                 int.Parse(elements[2]),
                                                                 (int.Parse(elements[3]), int.Parse(elements[4]))
                                                                 ));
                            break;
                    }
                }
                Check.Text = $"Successfully downloaded: {geometryShapes.Count}!";
            }
            Refresh();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs clickCoords)
        {
            Check.Text = $"{clickCoords.X}, {clickCoords.Y}\n";
            Check.Text += "Object(s): ";
            foreach (GeometryShape shape in geometryShapes)
            {
                if (shape.IsPointInShape(clickCoords.X, clickCoords.Y))
                {
                    Check.Text += shape.Output() + "\n";
                }
            }
            if (geometryShapes.Count == 1)
            {
                Check.Text += $"\n\n{clickCoords.X - geometryShapes[0].CentreCoords.X}" +
                                  $"\n{clickCoords.Y - geometryShapes[0].CentreCoords.Y}";

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


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

    public class Square : GeometryShape
    {
        public override string Name { get => "Square"; }

        public Square(string color, int size, (int, int) centreCoords) : base(color, size, centreCoords) { }

        public override double Area()
            => Size * Size;
        public override void Draw(Graphics g, Color color)
            => g.DrawRectangle(new Pen(color, 4), CentreCoords.X - Size / 2, CentreCoords.Y - Size / 2, Size, Size);
        public override bool IsPointInShape(int x, int y)
        {
            double R = Size / 2;
            return R >= Math.Abs(CentreCoords.X - x) &&
                   R >= Math.Abs(CentreCoords.Y - y);
        }
        public override void Choose()
        {

        }

    }

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