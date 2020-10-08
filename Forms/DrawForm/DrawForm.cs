﻿﻿using System.Windows.Forms;
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

        private int startVertexID;

        private int endVertexID;

        private Pen pen;


        public DrawForm(List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws)

        {
            InitializeComponent();

            DoubleBuffered = true;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            collisionVertex = new CollisionVertex();

            MouseDown += new MouseEventHandler(MouseClickDrawForm);

            SaveButton saveButton = new SaveButton();

            Controls.Add(saveButton);

            vertexBrush = new SolidBrush(Color.Black);

            vertexStringFormat = new StringFormat();

            vertexStringFormat.Alignment = StringAlignment.Center;

            vertexStringFormat.LineAlignment = StringAlignment.Center;

            vertexTextFont = new Font("Times New Roman", 12, FontStyle.Bold);

            pen = new Pen(Brushes.LightCoral, 4);

            startVertexID = -1;

            endVertexID = -1;

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

               switch(vertexClick.FoundVertexs(startVertexID, endVertexID))
                {

                    case (int)FoundPoints.OneVertexFound:

                        endVertexID = vertexClick.GetNumberOfVertex(e.X - (int)VertexParameters.Radius, 
                            e.Y - (int)VertexParameters.Radius, vertexDraws, (int)VertexParameters.Radius);

                        break;

                    case (int)FoundPoints.TwoVertexFound:



                        break;

                    default:

                        startVertexID = vertexClick.GetNumberOfVertex();

                        break;


                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;


  
            foreach (var vertex in vertexDraws)
            {
                graphics.FillEllipse(Brushes.Blue, vertex.X, vertex.Y, vertex.Width, vertex.Height);

                graphics.DrawString(vertex.Id.ToString(), vertexTextFont, vertexBrush, vertex.X + (int)VertexParameters.Radius, vertex.Y + (int)VertexParameters.Radius, vertexStringFormat);

            }

            foreach (var edge in edgeDraws )
            
        }
    }
}
