using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;

namespace Forms.DrawForm
{
    class WeightTable : Panel
    {
        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private MatrixWeightPanel matrix;

        public WeightTable(int width, int height, int positionX, int positionY, List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Right;

            AutoScroll = true;

            BorderStyle = BorderStyle.Fixed3D;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            matrix = new MatrixWeightPanel(this, vertexDraws, edgeDraws);

            matrix.CreateMatrix();
        }

        //public void CreateMatrix()
        //{
        //    if (vertexDraws != null)
        //    {
        //        weightMatrix = new InputCountBox[vertexDraws.Count, vertexDraws.Count];

        //        int stepX = 15;
        //        int stepY = 15;

        //        int width = 30;
        //        int height = 20;

        //        int positionX = 50;
        //        int positionY = 200;

        //        for (int i = 0; i < vertexDraws.Count; ++i)
        //        {
        //            for (int j = 0; j < vertexDraws.Count; ++j)
        //            {
        //                weightMatrix[i, j] = new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j);
        //                if (i == j)
        //                {
        //                    weightMatrix[i, j].Enabled = false;
        //                }

        //                Controls.Add(weightMatrix[i, j]);
        //            }
        //        }
        //    }
        //}
    }
    class MatrixWeightPanel
    {
        private WeightTable weightTable;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private InputCountBox[,] matrix;

        public MatrixWeightPanel(WeightTable weightTable, List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws)
        {
            this.weightTable = weightTable;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            matrix = new InputCountBox[8, 8];
        }

        public void CreateMatrix()
        {
            int stepX = 10;
            int stepY = 10;

            int width = 20;
            int height = 20;

            int positionX = 0;
            int positionY = 0;

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    matrix[i,j] = new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j);

                    if (i == j)
                    {
                        matrix[i, j].Enabled = false;
                    }

                    weightTable.Controls.Add(matrix[i, j]);
                }
            }
        }
    }
}



