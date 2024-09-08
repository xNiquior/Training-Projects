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

        private void AddSpecificShape(string shape, string colorKey, int size, (int, int) centreCoords)
        {
            switch (shape)
            {
                case "Square":
                    geometryShapes.Add(new Square(colorKey, size, centreCoords));
                    break;
                case "Circle":
                    geometryShapes.Add(new Circle(colorKey, size, centreCoords));
                    break;
                case "Triangle":
                    geometryShapes.Add(new Triangle(colorKey, size, centreCoords));
                    break;
                default:
                    throw new InvalidOperationException("Неправильный тип фигуры!");
            }
            
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

                    AddSpecificShape(elements[0], elements[1], int.Parse(elements[2]), (int.Parse(elements[3]), int.Parse(elements[4])));
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
}