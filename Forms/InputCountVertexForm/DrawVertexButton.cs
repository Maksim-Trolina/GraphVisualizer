using CraphModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using StartForm;

namespace Forms
{
    public class DrawVertexButton : Button
    {
        private InputCountVertexForm inputCountForm;

        private StartForm.DrawForm drawForm;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private MatrixGraph matrixGraph;

        private InitialVertexes initialVertexes;

        public DrawVertexButton(int width, int height, int positionX, int positionY, InputCountVertexForm inputCountForm
            , MatrixGraph matrixGraph, string buttonText = "Create vertexes")
        {
            this.Text = buttonText;

            this.Size = new System.Drawing.Size(width, height);

            this.Location = new System.Drawing.Point(positionX, positionY);

            this.inputCountForm = inputCountForm;

            this.matrixGraph = matrixGraph;

            vertexDraws = new List<VertexDraw>();

            edgeDraws = new List<EdgeDraw>();

            drawForm = new StartForm.DrawForm(vertexDraws, edgeDraws);

            initialVertexes = new InitialVertexes(vertexDraws);

            Click += new EventHandler(ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (matrixGraph.Matrix == null)
            {
                initialVertexes.CreateVertexes(0);
            }
            else
            {
                initialVertexes.CreateVertexes(matrixGraph.Matrix.GetLength(0));
            }

            inputCountForm.Hide();

            drawForm.ShowDialog();

            inputCountForm.Close();

        }

        
    }

    public class InitialVertexes
    {
        private List<VertexDraw> vertexDraws;

        private CollisionVertex collisionVertex;

        public InitialVertexes(List<VertexDraw> vertexDraws)
        {
            this.vertexDraws = vertexDraws;

            collisionVertex = new CollisionVertex();
        }

        public void CreateVertexes(int countVertex)
        {
            float x = 30f;

            float y = 30f;

            float step = 2 * (float)VertexParameters.Radius + 10;

            for (int i = 0; i < countVertex; ++i)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Green, BrushColor.Red, x + i * step, y, (float)VertexParameters.Width
                    , (float)VertexParameters.Height, "", i);

                if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    vertexDraws.Add(vertexDraw);
                }

            }

        }

    }
}
