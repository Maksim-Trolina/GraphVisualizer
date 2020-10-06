using CraphModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using StartForm;

namespace Forms
{
    public class DrawVertexButton : Button
    {
        private InputCountVertexForm inputCountForm;

        private StartForm.DrawForm drawForm;

        private ConfirmButton confirmButton;

        private List<VertexDraw> vertexDraws;

        private CollisionVertex collisionVertex;

        public DrawVertexButton(int width, int height, int positionX, int positionY, InputCountVertexForm inputCountForm, StartForm.DrawForm drawForm,
          ConfirmButton confirmButton, List<VertexDraw> vertexDraws, string buttonText = "Create vertexes")
        {
            this.Text = buttonText;

            this.Size = new System.Drawing.Size(width, height);

            this.Location = new System.Drawing.Point(positionX, positionY);

            this.inputCountForm = inputCountForm;

            this.drawForm = drawForm;

            this.vertexDraws = vertexDraws;

            this.confirmButton = confirmButton;

            collisionVertex = new CollisionVertex();

            Click += new EventHandler(ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        { 

            CreateVertexes(confirmButton.Rows);

            inputCountForm.Hide();

            drawForm.Paint += new PaintEventHandler(PaintVertexes);

            drawForm.ShowDialog();

            inputCountForm.Close();

        }

        private void PaintVertexes(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            foreach (var vertex in vertexDraws)
            {
                graphics.FillEllipse(Brushes.Blue, vertex.X, vertex.Y, vertex.Width, vertex.Height);
            }
        }

        private void CreateVertexes(int countVertex)
        {
            
            float x = 30f;

            float y = 30f;

            float step = 2 * (float)VertexParameters.Radius + 10;

            for (int i = 0; i < countVertex; ++i)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Green, BrushColor.Red, x + i * step, y, (float)VertexParameters.Width
                    , (float)VertexParameters.Height, "", i);

                if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    vertexDraws.Add(vertexDraw);                   
                }
               
            }

        }

    }

}
