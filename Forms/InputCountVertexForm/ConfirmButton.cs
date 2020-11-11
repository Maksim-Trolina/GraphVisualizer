﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public class ConfirmButton : Button
    {
        private InputCountVertexForm inputCountVertexForm;

        private InputCountBox inputCountBox;

        private MatrixGraph matrixGraph;

        public ConfirmButton(int width, int height, int positionX, int positionY, InputCountBox inputCountBox
            ,InputCountVertexForm inputCountVertexForm, MatrixGraph matrixGraph, string buttonText = "OK")
        {
            this.Text = buttonText;

            this.Size = new System.Drawing.Size(width, height);

            this.Location = new System.Drawing.Point(positionX, positionY);

            this.inputCountBox = inputCountBox;

            this.inputCountVertexForm = inputCountVertexForm;

            Click += new EventHandler(ButtonClick);

            this.matrixGraph = matrixGraph;
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            int rows;

            try
            {
                rows = Int32.Parse(inputCountBox.Text);
            }
            catch
            {
                rows = 0;
            }

            matrixGraph.DeleteMatrix();
            
            matrixGraph.CreateMatrix(rows);

        }
    }

    public class MatrixGraph
    {
        public InputCountBox[,] Matrix { get; private set; }

        private InputCountVertexForm inputCountVertexForm;

        public MatrixGraph(InputCountVertexForm inputCountVertexForm)
        {
            this.inputCountVertexForm = inputCountVertexForm;
        }

        public void DeleteMatrix()
        {
            if (Matrix != null)
            {
                for (int i = 0; i < Matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < Matrix.GetLength(1); ++j)
                    {
                        inputCountVertexForm.Controls.Remove(Matrix[i, j]);
                    }
                }
            }
        }

        public void CreateMatrix(int rows)
        {
            Matrix = new InputCountBox[rows, rows];

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
                    Matrix[i, j] = new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j);
                    if (i == j)
                    {
                        Matrix[i, j].Enabled = false;
                    }
                    
                    inputCountVertexForm.Controls.Add(Matrix[i, j]);
                }
            }
        }
    }
}
