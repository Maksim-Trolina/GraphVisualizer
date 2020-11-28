using System;
using System.Windows.Forms;
using CraphModel;
using Serializing;
using System.Collections.Generic;
using GraphModelDraw;
using CollisionDraw;
using Forms.DrawForm;
using GraphRepresentation;
using System.Drawing;



namespace Forms
{
    class LoadFileButton : Button
    {

        private DeserializeGraph deserializeGraph;

        private Graph loadGraph;

        private StartForm.StartForm startForm;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private StartForm.DrawForm drawForm;

        private List<List<CellBox>> matrix;

        private DrawForm.Converter converter;

        private OpenFileDialog ofd;

        private CollisionVertex collisionVertex;

        private InputCountVertexForm inputCountVertexForm;

        private MatrixGraph matrixGraph;

        private AdjacencyList adjacencyList;

        private int left;


        public LoadFileButton(StartForm.StartForm startForm)
        {
            Text = "Load file";

            this.left = left;

            FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            ForeColor = Color.Black;

            this.BackColor = Color.Orange;

            Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));

            Location = new System.Drawing.Point(350, 220);

            Size = new System.Drawing.Size(100, 50);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            vertexDraws = new List<VertexDraw>();

            this.startForm = startForm;

            edgeDraws = new List<EdgeDraw>();          

            Click += new EventHandler(ButtonClick);

            deserializeGraph = new DeserializeGraph();

            converter = new DrawForm.Converter();

            ofd = new OpenFileDialog();

            ofd.Filter = "Json files (*.json)|*.json";

            ofd.CheckFileExists = true;

            collisionVertex = new CollisionVertex();

        }
       

        public void ButtonClick(object sender, EventArgs e)
        {          

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                loadGraph = deserializeGraph.LoadGraph(ofd.FileName);

                matrix = converter.ConvertToListListCellBox(loadGraph);

                adjacencyList = converter.ConvertToAdjacencyList(matrix);

                DrawingLoadedEdges(matrix);
                DrawingLoadedVertexs(matrix);

                inputCountVertexForm = new InputCountVertexForm(startForm);

                drawForm = new StartForm.DrawForm(vertexDraws, edgeDraws, matrix, startForm, inputCountVertexForm, matrixGraph, adjacencyList);

                drawForm.Show();

            }


        }

        private void DrawingLoadedVertexs(List<List<CellBox>> matrix)
        {
            int countVertex = matrix.Count;

            float x = 90f;

            float y = 50f;

            float step = 2 * (float)VertexParameters.Radius + 10;

            for (int i = 0; i < countVertex; ++i)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Orange, BrushColor.Orange, x + i * step, y, (float)VertexParameters.Width
                    , (float)VertexParameters.Height, "", i);

                if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    vertexDraws.Add(vertexDraw);
                }

            }

        }

        private void DrawingLoadedEdges(List<List<CellBox>> matrix)
        {
            int matrixLength = matrix.Count;


            for (int i = 0; i < matrixLength; ++i)
            {
                for (int j = 0; j < matrixLength; ++j)
                {
                    int cellValue;

                    try
                    {
                        cellValue = Int32.Parse(matrix[i][j].Text);
                    }
                    catch
                    {
                        cellValue = 0;
                    }

                    if (cellValue != 0)
                    {
                        edgeDraws.Add(new EdgeDraw(BrushColor.Black, cellValue, i, j));
                    }
                }
            }

        }



    }
}
