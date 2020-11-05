using CraphModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using Forms.DrawForm;

namespace Forms
{
    public class DrawVertexButton : Button
    {
        private InputCountVertexForm inputCountForm;

        private StartForm.DrawForm drawForm;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private MatrixGraph matrixGraph;

        private InitialGraph initialVertexes;

        private List<List<InputCountBox>> matrix;

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

            initialVertexes = new InitialGraph(vertexDraws, edgeDraws, matrixGraph);

            matrix = new List<List<InputCountBox>>();

            Click += new EventHandler(ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            initialVertexes.CreateVertexes();

            initialVertexes.FillingMatrix(matrix);

            initialVertexes.CreateEdges();

            drawForm = new StartForm.DrawForm(vertexDraws, edgeDraws, matrix);

            inputCountForm.Hide();

            drawForm.ShowDialog();

            inputCountForm.Close();

        }

        
    }

    public class InitialGraph
    {
        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private CollisionVertex collisionVertex;

        private MatrixGraph matrixGraph;

        public InitialGraph(List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws, MatrixGraph matrixGraph)
        {
            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            this.matrixGraph = matrixGraph;

            collisionVertex = new CollisionVertex();
        }

        public void FillingMatrix(List<List<InputCountBox>> matrix)
        {         

            int stepX = 10;
            int stepY = 10;

            int width = 20;
            int height = 20;

            int positionX = 0;
            int positionY = 0;

            int matrixLength = 0;

            if(matrixGraph.Matrix != null)
            {
                matrixLength = matrixGraph.Matrix.GetLength(1);

            }

            

            for (int i = 0; i < matrixLength; i++)
            {
                matrix.Add(new List<InputCountBox>());

                for(int j = 0; j < matrixLength; j++)
                {

                    matrix[i].Add(new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j));

                    matrix[i][j].Text = matrixGraph.Matrix[i, j].Text;


                }              

            }

        }

        public void CreateVertexes()
        {
            int countVertex = 0;

            if (matrixGraph.Matrix != null)
            {
                countVertex = matrixGraph.Matrix.GetLength(0);
            }

            float x = 90f;

            float y = 50f;

            float step = 2 * (float)VertexParameters.Radius + 10;

            for (int i = 0; i < countVertex; ++i)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Red, BrushColor.Red, x + i * step, y, (float)VertexParameters.Width
                    , (float)VertexParameters.Height, "", i);

                if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    vertexDraws.Add(vertexDraw);
                }

            }

        }

        public void CreateEdges()
        {
            int matrixLength = 0;

            if (matrixGraph.Matrix != null)
            {
                matrixLength = matrixGraph.Matrix.GetLength(0);

            }

            for (int i = 0; i < matrixLength; ++i)
            {
                for (int j = 0; j < matrixLength; ++j)
                {
                    int cellValue = Int32.Parse(matrixGraph.Matrix[i, j].Text);

                    if (cellValue != 0)
                    {
                        edgeDraws.Add(new EdgeDraw(BrushColor.Black, cellValue, i, j));
                    }
                }
            }
        }
    }
}
