using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class ConfirmButton : Button
    {
        public InputCountVertexForm InputCountVertexForm { get; set; }
        public InputCountBox InputCountBox { get; set; }
        private InputCountBox[,] matrixGraph;

        public ConfirmButton(int width, int height, int positionX, int positionY, string buttonText = "OK")
        {
            this.Text = buttonText;
            this.Size = new System.Drawing.Size(width, height);
            this.Location = new System.Drawing.Point(positionX, positionY);
            Click += new EventHandler(ButtonClick);
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            int inputNumber;
            try
            {
                inputNumber = Int32.Parse(InputCountBox.Text);
            }
            catch
            {
                inputNumber = 0;
            }

            DeleteMatrixGraph();
            CreateMatrixGraph(inputNumber);
        }

        public void DeleteMatrixGraph()
        {
            if (matrixGraph != null)
            {
                for (int i = 0; i < matrixGraph.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrixGraph.GetLength(1); ++j)
                    {
                        InputCountVertexForm.Controls.Remove(matrixGraph[i, j]);
                    }
                }
            }
        }

        public void CreateMatrixGraph(int rows)
        {
            matrixGraph = new InputCountBox[rows, rows];

            int stepX = 15;
            int stepY = 15;

            int width = 30;
            int height = 20;

            int positionX = 50;
            int positionY = 200;

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < rows; ++j)
                {
                    matrixGraph[i, j] = new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j);
                    if (i == j)
                    {
                        matrixGraph[i, j].Enabled = false;
                    }
                    InputCountVertexForm.Controls.Add(matrixGraph[i, j]);
                }
            }
        }
    }
}
