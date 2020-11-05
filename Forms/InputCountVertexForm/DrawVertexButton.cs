﻿using CraphModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using Forms.DrawForm;

namespace Forms
{
    public class DrawVertexButton : Button
    {
        private InputCountVertexForm inputCountForm;

        private StartForm.DrawForm drawForm;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private MatrixGraph matrixGraph;

        private InitialVertexes initialVertexes;

        private List<List<InputCountBox>> matrix;

        public DrawVertexButton(int width, int height, int positionX, int positionY, InputCountVertexForm inputCountForm
            , MatrixGraph matrixGraph, string buttonText = "Create vertexes")
        {
            this.Text = buttonText;

            this.Size = new System.Drawing.Size(width, height);

            this.Location = new System.Drawing.Point(positionX, positionY);

            this.inputCountForm = inputCountForm;

            this.matrixGraph = matrixGraph;

            vertexDraws = new List<VertexDraw>();

            edgeDraws = new List<EdgeDraw>();           

            initialVertexes = new InitialVertexes(vertexDraws, edgeDraws, matrixGraph.Matrix);

            Click += new EventHandler(ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (matrixGraph.Matrix == null)
            {
                initialVertexes.CreateVertexes(0); 
            }
            else
            {
                initialVertexes.CreateVertexes(matrixGraph.Matrix.GetLength(0));
            }

            initialVertexes.FillingMatrix(matrixGraph.Matrix, ref matrix);

            initialVertexes.CreateEdges(matrixGraph.Matrix);

            drawForm = new StartForm.DrawForm(vertexDraws, edgeDraws, matrix);

            inputCountForm.Hide();

            drawForm.ShowDialog();

            inputCountForm.Close();

        }

        
    }

    public class InitialVertexes
    {
        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private CollisionVertex collisionVertex;

        private InputCountBox[,] Matrix;

        public InitialVertexes(List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws, InputCountBox[,] Matrix)
        {
            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            this.Matrix = Matrix;

            collisionVertex = new CollisionVertex();
        }

        public void FillingMatrix(InputCountBox[,] Matrix, ref List<List<InputCountBox>> matrix)
        {

            matrix = new List<List<InputCountBox>>();
          

            int stepX = 10;
            int stepY = 10;

            int width = 20;
            int height = 20;

            int positionX = 0;
            int positionY = 0;

            int matrixLength = 0;

            if(Matrix != null)
            {
                matrixLength = Matrix.GetLength(1);

            }

            

            for (int i = 0; i < matrixLength; i++)
            {
                matrix.Add(new List<InputCountBox>());

                for(int j = 0; j < matrixLength; j++)
                {

                    matrix[i].Add(new InputCountBox(width, height, positionX + (width + stepX) * i, positionY + (height + stepY) * j));

                    matrix[i][j].Text = Matrix[i, j].Text;


                }              

            }

        }

        public void CreateVertexes(int countVertex)
        {
            float x = 90f;

            float y = 50f;

            float step = 2 * (float)VertexParameters.Radius + 10;

            for (int i = 0; i < countVertex; ++i)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Red, BrushColor.Red, x + i * step, y, (float)VertexParameters.Width
                    , (float)VertexParameters.Height, "", i);

                if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    vertexDraws.Add(vertexDraw);
                }

            }

        }

        public void CreateEdges(InputCountBox[,] Matrix)
        {
            int matrixLength = 0;

            if (Matrix != null)
            {
                matrixLength = Matrix.GetLength(0);

            }

            for (int i = 0; i < matrixLength; ++i)
            {
                for (int j = 0; j < matrixLength; ++j)
                {
                    int cellValue = Int32.Parse(Matrix[i, j].Text);

                    if (cellValue != 0)
                    {
                        edgeDraws.Add(new EdgeDraw(BrushColor.Black, cellValue, i, j));
                    }
                }
            }
        }
    }
}
