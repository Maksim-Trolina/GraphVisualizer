using System;
using System.Collections.Generic;
<<<<<<< HEAD
<<<<<<< HEAD
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;

namespace Forms.DrawForm
{
    class WeightTable : FlowLayoutPanel
    {
        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        //private MatrixWeightPanel matrix;

        private InputCountBox[,] weightMatrix;

        public WeightTable(int width, int height, int positionX, int positionY, List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Right;

            AutoScroll = true;

            BorderStyle = BorderStyle.Fixed3D;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            // matrix = new MatrixWeightPanel(this, vertexDraws, edgeDraws);

            CreateMatrix();
        }

        public void CreateMatrix()
        {
            if (vertexDraws != null)
            {
                weightMatrix = new InputCountBox[vertexDraws.Count, vertexDraws.Count];

                int stepX = 15;
                int stepY = 15;

                int width = 30;
                int height = 20;

                int positionX = 50;
                int positionY = 200;

                for (int i = 0; i < vertexDraws.Count; ++i)
                {
                    for (int j = 0; j < vertexDraws.Count; ++j)
                    {
                        weightMatrix[i, j] = new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j);
                        if (i == j)
                        {
                            weightMatrix[i, j].Enabled = false;
                        }

                        Controls.Add(weightMatrix[i, j]);
                    }
                }
            }
        }       
    }

    //class MatrixWeightPanel
    //{
    //    private WeightTable weightTable;

    //    private List<VertexDraw> vertexDraws;

    //    private List<EdgeDraw> edgeDraws;

    //    private InputCountBox[,] matrix;

    //    public MatrixWeightPanel(WeightTable weightTable, List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws)
    //    {
    //        this.weightTable = weightTable;

    //        this.vertexDraws = vertexDraws;

    //        this.edgeDraws = edgeDraws;

            
    //    }

    //    public void CreateMatrix()
    //    {
           
    //    }
    //}
=======
=======
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
using System.Text;

namespace Forms.DrawForm
{
    class WeightTable
    {
    }
<<<<<<< HEAD
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
=======
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
}
