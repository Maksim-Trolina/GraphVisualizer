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
            int inputNumber = 0;
            Int32.TryParse(InputCountBox.Text, out inputNumber);

            if (matrixGraph != null)
            {
                for (int i = 0; i < Math.Sqrt(matrixGraph.Length); ++i)
                {
                    for (int j = 0; j < Math.Sqrt(matrixGraph.Length); ++j)
                    {
                        InputCountVertexForm.Controls.Remove(matrixGraph[i, j]);

                    }
                }
            }

            matrixGraph = new InputCountBox[inputNumber, inputNumber];

            int stepX = 15;
            int stepY = 15;

            int width = 30;
            int height = 20;

            int positionX = 50;
            int positionY = 200;

            for (int i = 0; i < inputNumber; ++i)
            {
                for (int j = 0; j < inputNumber; ++j)
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
