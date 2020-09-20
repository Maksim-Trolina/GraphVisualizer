using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;

namespace StartForm
{
    public partial class DrawForm : Form
    {
        private List<VertexDraw> vertexDraws;
        public DrawForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            vertexDraws = new List<VertexDraw>();

            MouseDown += new MouseEventHandler(MouseClickDrawForm);

        }

        private void MouseClickDrawForm(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                vertexDraws.Add(new VertexDraw(BrushColor.Red, BrushColor.Green
                    ,e.X-(int)VertexParameters.Radius, e.Y-(int)VertexParameters.Radius
                    ,(int)VertexParameters.Width, (int)VertexParameters.Height,"Саси"
                    ,vertexDraws.Count));

                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            foreach (var vertex in vertexDraws)
            {
                graphics.FillEllipse(Brushes.Blue, vertex.X, vertex.Y, vertex.Width, vertex.Height);
            }
            
        }
    }
}
