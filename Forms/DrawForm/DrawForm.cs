using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CollisionDraw;
using GraphModelDraw;

namespace StartForm
{
    public partial class DrawForm : Form
    {
        private List<VertexDraw> vertexDraws;

        private CollisionVertex collisionVertex;

        public DrawForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            vertexDraws = new List<VertexDraw>();

            collisionVertex = new CollisionVertex();

            MouseDown += new MouseEventHandler(MouseClickDrawForm);

        }

        private void MouseClickDrawForm(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Red, BrushColor.Green
                    , e.X - (int)VertexParameters.Radius, e.Y - (int)VertexParameters.Radius
                    , (int)VertexParameters.Width, (int)VertexParameters.Height, "Саси"
                    , vertexDraws.Count);

                if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    vertexDraws.Add(vertexDraw);

                    Refresh();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            foreach (var vertex in vertexDraws)
            {
                graphics.FillEllipse(Brushes.Blue, vertex.X, vertex.Y, vertex.Width, vertex.Height);
            }
            
        }
    }
}
