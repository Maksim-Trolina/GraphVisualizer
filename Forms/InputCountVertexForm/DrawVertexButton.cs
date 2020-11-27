using CraphModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using Forms.DrawForm;
using GraphRepresentation;

namespace Forms
{
    public class DrawVertexButton : Button
    {
        private InputCountVertexForm inputCountForm;

        private StartForm.DrawForm drawForm;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private MatrixGraph matrixGraph;

        private InitialGraph initialGraph;

        private List<List<CellBox>> matrix;

        private StartForm.StartForm startForm;


        public DrawVertexButton(int width, int height, int positionX, int positionY, InputCountVertexForm inputCountForm
            , MatrixGraph matrixGraph, StartForm.StartForm startForm, string buttonText = "Create vertexes")
        {
            this.Text = buttonText;

            this.Size = new System.Drawing.Size(width, height);

            this.Location = new System.Drawing.Point(positionX, positionY);

            this.inputCountForm = inputCountForm;

            this.matrixGraph = matrixGraph;

            vertexDraws = new List<VertexDraw>();

            edgeDraws = new List<EdgeDraw>();           

            initialGraph = new InitialGraph(vertexDraws, edgeDraws, matrixGraph);

            matrix = new List<List<CellBox>>();

            Click += new EventHandler(ButtonClick);

            this.startForm = startForm;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            vertexDraws.Clear();

            edgeDraws.Clear();

            initialGraph.CreateVertexes();

            initialGraph.FillingMatrix(matrix);

            initialGraph.CreateEdges();

            drawForm = new StartForm.DrawForm(vertexDraws, edgeDraws, matrix, startForm, inputCountForm, matrixGraph, initialGraph.UpdateAdjacencyList(matrix));

            drawForm.Show();

            inputCountForm.Close();

        }
       
    }

    public class InitialGraph
    {
        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private CollisionVertex collisionVertex;

        private MatrixGraph matrixGraph;

        private Converter converter;

        private AdjacencyList adjacencyList;

        public InitialGraph(List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws, MatrixGraph matrixGraph)
        {
            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            this.matrixGraph = matrixGraph;

            collisionVertex = new CollisionVertex();

            converter = new Converter();

        }

        public void FillingMatrix(List<List<CellBox>> matrix)
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
                matrix.Add(new List<CellBox>());

                for(int j = 0; j < matrixLength; j++)
                {

                    matrix[i].Add(new CellBox(width, height, positionX + (width + stepX) * j, positionY + (height + stepY) * i));
                    
                    if (matrixGraph.Matrix[j, i].Text == "")
                    {
                        matrix[i][j].Text = "0";
                    }
                    else
                    {
                        matrix[i][j].Text = matrixGraph.Matrix[j, i].Text;
                    }
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
                    int cellValue;

                    try
                    {
                        cellValue = Int32.Parse(matrixGraph.Matrix[i, j].Text);
                    }
                    catch
                    {
                        cellValue = 0;
                    }

                    if (cellValue != 0)
                    {
                        edgeDraws.Add(new EdgeDraw(BrushColor.Black, cellValue, j, i));
                    }
                }
            }
        }

        public AdjacencyList UpdateAdjacencyList(List<List<CellBox>> matrix)
        {
            return adjacencyList = converter.ConvertToAdjacencyList(matrix);

        }
    }
}
