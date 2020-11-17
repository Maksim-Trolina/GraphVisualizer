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

        public WeightTable(int width, int height, int positionX, int positionY)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Right;

            AutoScroll = true;

            BorderStyle = BorderStyle.Fixed3D;

        }
  
    }


     class MatrixWeightPanel
     {

        private WeightTable weightTable;

        private List<List<CellBox>> matrix;

        public MatrixWeightPanel(WeightTable weightTable, List<List<CellBox>> matrix)
        {

            this.weightTable = weightTable;
            this.matrix = matrix;

        }

        public void DrawingMatrix()
        {

            for (int i = 0; i < matrix.Count; i++)
            {

                for (int j = 0; j < matrix.Count; j++)
                {
                    weightTable.Controls.Add(matrix[i][j]);
                }

            }

        }

        public void ExpandMatrix(int countOfNewVertexs)
        {

            int stepX = 10;
            int stepY = 10;

            int width = 20;
            int height = 20;

            int positionX = 0;
            int positionY = 0;


            int countCellsBefore = matrix.Count;


            for (int i = 0; i < countCellsBefore; i++)
            {
                for (int j = countCellsBefore; j < countCellsBefore + countOfNewVertexs; j++)
                {

                    matrix[i].Add(new CellBox(width, height, positionX + (width + stepX) * i - weightTable.HorizontalScroll.Value
                        , positionY + (height + stepY) * j - weightTable.VerticalScroll.Value));

                    matrix[i][j].Enabled = false;

                    weightTable.Controls.Add(matrix[i][j]);

                }
                
            }

            for(int i = countCellsBefore; i < countCellsBefore + countOfNewVertexs; i++)
            {
                matrix.Add(new List<CellBox>());

                for(int j = 0; j < countOfNewVertexs + countCellsBefore; j++)
                {

                    matrix[i].Add(new CellBox(width, height, positionX + (width + stepX) * i - weightTable.HorizontalScroll.Value
                         , positionY + (height + stepY) * j - weightTable.VerticalScroll.Value));

                    weightTable.Controls.Add(matrix[i][j]);

                }
                
            }

        }

        public void UpdateNodes(int startId, int endId)
        {
            matrix[endId][startId].Text = "1";
            matrix[endId][startId].Enabled = true;
        }
     }
}



