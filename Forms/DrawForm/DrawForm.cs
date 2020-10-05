﻿using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using System.Collections.Generic;
using System.Drawing;
using Forms.DrawForm;

namespace StartForm
{
    public partial class DrawForm : Form
    {
        private List<VertexDraw> vertexDraws;

        private CollisionVertex collisionVertex;

        public DrawForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            vertexDraws = new List<VertexDraw>();

            collisionVertex = new CollisionVertex();

            MouseDown += new MouseEventHandler(MouseClickDrawForm);

            SaveButton saveButton = new SaveButton();

            Controls.Add(saveButton);

        }

        private void MouseClickDrawForm(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Red, BrushColor.Green
                    , e.X - (int)VertexParameters.Radius, e.Y - (int)VertexParameters.Radius
                    , (int)VertexParameters.Width, (int)VertexParameters.Height, "Саси"
                    , vertexDraws.Count);

                if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    vertexDraws.Add(vertexDraw);

                    Refresh();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            Font font = new Font("Times New Roman", 12, FontStyle.Bold);

            Brush brush = new SolidBrush(Color.Black);

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            foreach (var vertex in vertexDraws)
            {
                graphics.FillEllipse(Brushes.Blue, vertex.X, vertex.Y, vertex.Width, vertex.Height);

                graphics.DrawString(vertex.Id.ToString(), font, brush, vertex.X + (int)VertexParameters.Radius, vertex.Y + (int)VertexParameters.Radius);
            }
            
        }
    }
}
