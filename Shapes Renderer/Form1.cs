using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using LB_7.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Shape_Renderer
{
    public partial class Form1 : Form
    {
        private List<GeometryShape> shapes = ShapeRenderer.GeometryShapes;


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            ShapeRenderer.Render(graphics);
        }

        private void Create_Click(object sender, EventArgs e)
        {
            int formerLenght = shapes.Count;
            ShapeRenderer.AddNewRandomShape();

            if (formerLenght != shapes.Count)
                Check.Text = $"Succesful: {formerLenght} -> {shapes.Count}! {shapes[shapes.Count - 1].Name}";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Log.txt", null);

            if (shapes.Count > 0)
            {
                foreach (GeometryShape shape in shapes)
                {
                    File.AppendAllText("Log.txt", $"{shape.Name}#{shape.ColorName}#{shape.Size}#{shape.CentreCoords.X}#{shape.CentreCoords.Y}" + Environment.NewLine);
                }
                Check.Text = $"Successfully saved: {shapes.Count}!";
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            shapes.Clear();

            if (File.ReadAllLines("Log.txt") != null)
            {
                string[]? log = File.ReadAllLines("Log.txt");
                foreach (string line in log)
                {
                    string[] elements = line.Split('#');
                    ShapeRenderer.AddSpecificShape(elements[0], elements[1], int.Parse(elements[2]), (int.Parse(elements[3]), int.Parse(elements[4])));
                }

                Check.Text = $"Successfully downloaded: {shapes.Count}!";
            }

            Refresh();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs clickCoords)
        {
            Check.Text = $"{clickCoords.X}, {clickCoords.Y}\n";
            Check.Text += "Object(s): ";

            foreach (GeometryShape shape in shapes)
            {
                if (shape.IsPointInShape(clickCoords.X, clickCoords.Y))
                {
                    Check.Text += shape.ShowInfo() + "\n";
                }
            }

            if (shapes.Count == 1)
            {
                Check.Text += $"\n\n{clickCoords.X - shapes[0].CentreCoords.X}" +
                              $"\n{clickCoords.Y - shapes[0].CentreCoords.Y}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ClearLogs_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Log.txt", String.Empty);
            shapes.Clear();
            Refresh();

            Check.Text = $"Successfully cleared: {shapes.Count}!";
        }
    }
}