using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public partial class InputCountVertexForm : Form
    {
        private InputCountBox inputBox;
        private InfoTextLabel infoText;
        private ConfirmButton confirmButton;
        private InputCountBox[,] matrixGraph;

        public InputCountVertexForm()
        {
            InitializeComponent();

            inputBox = new InputCountBox(300, 20, 200, 100);
            Controls.Add(inputBox);

            infoText = new InfoTextLabel(300, 30, 200, 80);
            Controls.Add(infoText);

            confirmButton = new ConfirmButton(100, 30, 500, 100) { InputCountBox = inputBox, InputCountVertexForm = this };

            Controls.Add(confirmButton);
        }

        public void CreateMatrixGraph(uint number)
        {
            matrixGraph = new InputCountBox[number, number];
            int stepX = 30;
            int stepY = 30;
                        
            for (int i = 0; i < number; ++i)
            {
                for (int j = 0; j < number; ++j)
                {
                    matrixGraph[i, j] = new InputCountBox(20, 20, 50 + stepY * i, 200 + stepX * j);
                    if (i == j)
                    {
                        matrixGraph[i, j].Enabled = false;
                    }
                    Controls.Add(matrixGraph[i, j]);
                }
            }
        }
    }


}
