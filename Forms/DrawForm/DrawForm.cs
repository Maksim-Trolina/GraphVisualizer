﻿using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using System.Collections.Generic;
using System.Drawing;
using Forms.DrawForm;
using VertexSearch;


namespace StartForm
{
    public partial class DrawForm : Form
    {
        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private CollisionVertex collisionVertex;

        private Brush vertexBrush;

        private StringFormat vertexStringFormat;

        private Font vertexTextFont;

        private VertexClick vertexClick;

        private int startVertexId;

        private int endVertexId;

        private Pen pen;


        public DrawForm(List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws)

        {
            InitializeComponent();

            DoubleBuffered = true;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            collisionVertex = new CollisionVertex();

            vertexClick = new VertexClick();

            MouseDown += new MouseEventHandler(MouseClickDrawForm);

            SaveButton saveButton = new SaveButton();

            Controls.Add(saveButton);

            vertexBrush = new SolidBrush(Color.Black);

            vertexStringFormat = new StringFormat();

            vertexStringFormat.Alignment = StringAlignment.Center;

            vertexStringFormat.LineAlignment = StringAlignment.Center;

            vertexTextFont = new Font("Times New Roman", 12, FontStyle.Bold);

            pen = new Pen(Brushes.LightCoral, 4);

            startVertexId = -1;

            endVertexId = -1;

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
                else
                {
                    vertexClick.VertexRemember(ref startVertexId, ref endVertexId
                        , e.X - (int)VertexParameters.Radius, e.Y - (int)VertexParameters.Radius
                        , vertexDraws, (int)VertexParameters.Radius);

                    if ((startVertexId != -1) && (endVertexId != -1) && (startVertexId != endVertexId))
                    {
                        EdgeDraw edgeDraw = new EdgeDraw(BrushColor.Black, 0, startVertexId, endVertexId);

                        edgeDraws.Add(edgeDraw);
                        Refresh();

                        startVertexId = -1;
                        endVertexId = -1;
                    }

                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            float startX, startY, endX, endY;

            foreach (var edge in edgeDraws)
            {
                startX = 0;
                startY = 0;
                endX = 0;
                endY = 0;

                foreach (var vertex in vertexDraws)
                {
                    
                    if (edge.Id == vertex.Id)
                    {
                        startX = vertex.X + (int)VertexParameters.Radius;
                        startY = vertex.Y + (int)VertexParameters.Radius;

                    }
                    else if (edge.ConnectabelVertex == vertex.Id)
                    {
                        endX = vertex.X + (int)VertexParameters.Radius;
                        endY = vertex.Y + (int)VertexParameters.Radius;

                        
                    }
                }
                graphics.DrawLine(pen, startX, startY, endX, endY);
            }


            foreach (var vertex in vertexDraws)
            {
                graphics.FillEllipse(Brushes.Blue, vertex.X, vertex.Y, vertex.Width, vertex.Height);

                graphics.DrawString(vertex.Id.ToString(), vertexTextFont, vertexBrush
                    , vertex.X + (int)VertexParameters.Radius, vertex.Y + (int)VertexParameters.Radius, vertexStringFormat);
              
            }


        }

    }
}
