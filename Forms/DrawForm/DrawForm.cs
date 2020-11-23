﻿using System.Windows.Forms;
using GraphModelDraw;
using CollisionDraw;
using System.Collections.Generic;
using System.Drawing;
using Forms.DrawForm;
using VertexSearch;
using System.Drawing.Drawing2D;
using ArrowDraw;
using Forms;
using GraphRepresentation;
using System.Runtime.CompilerServices;

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

        private NewEdgeDefinition newEdgeDefinition;

        private int startVertexId = -1;

        private int endVertexId = -1;

        private Pen pen;

        private ToolPanel toolPanel;

        private WeightTable weightTable;

        private AdjacencyListPanel adListPanel;

        private MatrixWeightPanel matrixWeightPanel;

        private Arrow arrow;

        private Brush[] brushes;

        private AdjacencyList adjacencyList;

        private Converter converter;

        private BackToMenuOfDrawButton backToMenuOfDrawButton;

        public DrawForm(List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws, List<List<CellBox>> matrix, StartForm startForm)

        {
            InitializeComponent();

            DoubleBuffered = true;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            collisionVertex = new CollisionVertex();

            newEdgeDefinition = new NewEdgeDefinition();

            drawingEdges = new DrawingEdges();

            MouseDown += new MouseEventHandler(MouseClickDrawForm);          

            vertexBrush = new SolidBrush(Color.Black);

            vertexStringFormat = new StringFormat();

            vertexStringFormat.Alignment = StringAlignment.Center;

            vertexStringFormat.LineAlignment = StringAlignment.Center;

            vertexTextFont = new Font("Times New Roman", 12, FontStyle.Bold);

            pen = new Pen(Brushes.Black, 5);

            weightTable = new WeightTable(200, 200, Size.Width - 200, 0);

            matrixWeightPanel = new MatrixWeightPanel(weightTable, matrix);

            matrixWeightPanel.DrawingMatrix();

            Controls.Add(weightTable);

            converter = new Converter();

            adjacencyList = converter.ConvertToAdjacencyList(matrix);

            adListPanel = new AdjacencyListPanel(200, 200, Size.Width - 200, 0, adjacencyList);

            Controls.Add(adListPanel);

            toolPanel = new ToolPanel(0, 100, weightTable, this.edgeDraws
                , adjacencyList, this, adListPanel, this.vertexDraws, matrix, adListPanel.AdListTable.Cells);

            Controls.Add(toolPanel);

            pen.EndCap = LineCap.ArrowAnchor;

            arrow = new Arrow();

            brushes = new Brush[2];
      
            brushes[(int)BrushColor.Red] = Brushes.Red;

            brushes[(int)BrushColor.Black] = Brushes.Black;

            backToMenuOfDrawButton = new BackToMenuOfDrawButton(adjacencyList, vertexDraws, edgeDraws,
                this, adListPanel, weightTable, matrix, adListPanel.AdListTable.Cells, startForm);

            Controls.Add(backToMenuOfDrawButton);

            this.FormClosed += DrawForm_FormClosed;
        }

        private void DrawForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }


        private void MouseClickDrawForm(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                VertexDraw vertexDraw = new VertexDraw(BrushColor.Red, BrushColor.Green
                    , e.X - (int)VertexParameters.Radius, e.Y - (int)VertexParameters.Radius
                    , (int)VertexParameters.Width, (int)VertexParameters.Height, "Саси"
                    , vertexDraws.Count);


                if ((collisionVertex.IsDrawVertex(vertexDraw, vertexDraws)) && (startVertexId != -1))
                {

                    vertexDraw.VertexMove(vertexDraws, ref startVertexId
                        , e.X - (int)VertexParameters.Radius, e.Y - (int)VertexParameters.Radius);

                    Refresh();

                }
                else if (collisionVertex.IsDrawVertex(vertexDraw, vertexDraws))
                {
                    adjacencyList.AddVertex(new CraphModel.Vertex { Id = vertexDraws.Count ,Nodes = new List<CraphModel.Node>()});

                    adListPanel.UpdateIdPanel();

                    vertexDraws.Add(vertexDraw);

                    matrixWeightPanel.ExpandMatrix(1);

                    Refresh();
                }
                else
                {

                    drawingEdges.VertexFind(newEdgeDefinition, e, vertexDraws,  edgeDraws, ref startVertexId, ref endVertexId, ref adjacencyList, adListPanel, matrixWeightPanel);

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
                if (edge.BrushEdge != BrushColor.Green)
                {
                    newEdgeDefinition.DefinitionOfEdge(vertexDraws, edge, ref startPoint, ref endPoint);

                    pen.Color = GetColor(edge.BrushEdge);

                    graphics.DrawLine(pen, startPoint, arrow.GetEndArrowPoint(startPoint, endPoint));
                }
            }

            pen.Width = 8;
            pen.Color = Color.Green;

            foreach(var edge in edgeDraws)
            {
                if(edge.BrushEdge == BrushColor.Green)
                {
                    newEdgeDefinition.DefinitionOfEdge(vertexDraws, edge, ref startPoint, ref endPoint);

                    graphics.DrawLine(pen, startPoint, arrow.GetEndArrowPoint(startPoint, endPoint));
                }
            }

            pen.Width = 5;

            foreach (var vertex in vertexDraws)
            {         
                               
                graphics.FillEllipse(brushes[(int)vertex.BrushCircle], vertex.X, vertex.Y, vertex.Width, vertex.Height);

                graphics.DrawString(vertex.Id.ToString(), vertexTextFont, vertexBrush
                    , vertex.X + (int)VertexParameters.Radius, vertex.Y + (int)VertexParameters.Radius, vertexStringFormat);
              
            }          
             

        }

        private Color GetColor(BrushColor color)
        {
            switch (color)
            {
                case BrushColor.Black:
                    return Color.Black;
                case BrushColor.Green:
                    return Color.Green;
                case BrushColor.Red:
                    return Color.Red;
                case BrushColor.Yellow:
                    return Color.Yellow;
                default:
                    return Color.White;
            }
        }

    }
}
