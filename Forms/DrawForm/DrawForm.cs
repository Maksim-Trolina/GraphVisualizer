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

        private DrawingEdges drawingEdges;

        private List<EdgeDraw> edgeDraws;

        private CollisionVertex collisionVertex;

        private Brush vertexBrush;

        private StringFormat vertexStringFormat;

        private Font vertexTextFont;

        private VertexClick vertexClick;

        private int startVertexId = -1;

        private int endVertexId = -1;

        private Pen pen;

        private ToolPanel toolPanel;

        private WeightTable weightTable;

        private MatrixWeightPanel matrixWeightPanel;

        public DrawForm(List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws)

        {
            InitializeComponent();

            DoubleBuffered = true;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            collisionVertex = new CollisionVertex();

            vertexClick = new VertexClick();

            drawingEdges = new DrawingEdges();

            MouseDown += new MouseEventHandler(MouseClickDrawForm);

            SaveButton saveButton = new SaveButton();

            Controls.Add(saveButton);

            vertexBrush = new SolidBrush(Color.Black);

            vertexStringFormat = new StringFormat();

            vertexStringFormat.Alignment = StringAlignment.Center;

            vertexStringFormat.LineAlignment = StringAlignment.Center;

            vertexTextFont = new Font("Times New Roman", 12, FontStyle.Bold);

            pen = new Pen(Brushes.LightCoral, 4);

            weightTable = new WeightTable(200, 200, Size.Width - 200, 0);

            matrixWeightPanel = new MatrixWeightPanel(weightTable);

            Controls.Add(weightTable);

            toolPanel = new ToolPanel(0, 100, weightTable);

            Controls.Add(toolPanel);

            matrixWeightPanel.CreateMatrix(vertexDraws.Count);

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

                    matrixWeightPanel.CreateMatrix(1);

                    Refresh();
                }
                else
                {
                    drawingEdges.VertexFind(vertexClick, e, vertexDraws,  edgeDraws, ref startVertexId, ref endVertexId);

                    Refresh();

                }
            }
        }

        Point startPoint = new Point();
        Point endPoint = new Point();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
           
            foreach (var edge in edgeDraws)
            {
               
                drawingEdges.DefinitionOfEdges(vertexDraws, edge, ref startPoint, ref endPoint);

                graphics.DrawLine(pen, startPoint, endPoint);
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
