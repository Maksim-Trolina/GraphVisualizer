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

        private List<List<InputCountBox>> matrix;

        private WeightTable weightTable;
     

        public MatrixWeightPanel(WeightTable weightTable)
        {

            matrix = new List<List<InputCountBox>>();

            this.weightTable = weightTable;

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

                    matrix[i].Add(new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j));

                    if (i == j)
                    {
                        matrix[i][j].Enabled = false;
                    }

                    weightTable.Controls.Add(matrix[i][j]);

                }
                
            }

            for(int i = countCellsBefore; i < countCellsBefore + countOfNewVertexs; i++)
            {
                matrix.Add(new List<InputCountBox>());

                for(int j = 0; j < countOfNewVertexs + countCellsBefore; j++)
                {
                 
                    matrix[i].Add(new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j));

                    if (i == j)
                    {
                        matrix[i][j].Enabled = false;
                    }

                    weightTable.Controls.Add(matrix[i][j]);

                }
                
            }

        }
    }
}



