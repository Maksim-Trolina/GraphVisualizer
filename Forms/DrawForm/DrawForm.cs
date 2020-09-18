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

            vertexDraws = new List<VertexDraw>();

            MouseDown += new MouseEventHandler(MouseClick);

            

            //Paint += new PaintEventHandler(Paint1);

            //this.

        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                vertexDraws.Add(new VertexDraw(BrushColor.Red, BrushColor.Green, e.X, e.Y, 100, 100,"Саси",vertexDraws.Count));

                //MessageBox.Show("Left tButton");
            }
        }

        private void Paint1(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.FillEllipse(Brushes.Black, 40, 40, 100, 100);

            for(int i = 0; i < vertexDraws.Count; i++)
            {
                graphics.FillEllipse(Brushes.Blue, vertexDraws[i].X, vertexDraws[i].Y, vertexDraws[i].Width, vertexDraws[i].Height);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
