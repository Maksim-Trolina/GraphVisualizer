using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class ConfirmButton : Button
    {
        private InputCountVertexForm inputCountVertexForm;

        private InputCountBox inputCountBox;

        private MatrixGraph matrixGraphCount;

        public ConfirmButton(int width, int height, int positionX, int positionY,InputCountBox inputCountBox,InputCountVertexForm inputCountVertexForm, string buttonText = "OK")
        {
            this.Text = buttonText;
            this.Size = new System.Drawing.Size(width, height);
            this.Location = new System.Drawing.Point(positionX, positionY);
            this.inputCountBox = inputCountBox;
            this.inputCountVertexForm = inputCountVertexForm;
            Click += new EventHandler(ButtonClick);
            matrixGraphCount = new MatrixGraph(this.inputCountVertexForm);
            
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            int inputNumber;
            try
            {
                inputNumber = Int32.Parse(inputCountBox.Text);
            }
            catch
            {
                inputNumber = 0;
            }

            matrixGraphCount.DeleteMatrix();
            
            matrixGraphCount.CreateMatrix(inputNumber);
        }
    }

    public class MatrixGraph
    {
        private InputCountBox[,] matrixGraph;

        private InputCountVertexForm inputCountVertexForm;

        public MatrixGraph(InputCountVertexForm inputCountVertexForm)
        {
            this.inputCountVertexForm = inputCountVertexForm;
        }

        public void DeleteMatrix()
        {
            if (matrixGraph != null)
            {
                for (int i = 0; i < matrixGraph.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrixGraph.GetLength(1); ++j)
                    {
                        inputCountVertexForm.Controls.Remove(matrixGraph[i, j]);
                    }
                }
            }
        }

        public void CreateMatrix(int rows)
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
                    
                    inputCountVertexForm.Controls.Add(matrixGraph[i, j]);
                }
            }
        }
    }
}
