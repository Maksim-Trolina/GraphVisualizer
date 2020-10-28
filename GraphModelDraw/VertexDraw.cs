using System.Drawing.Drawing2D;
using System.Drawing;


namespace GraphModelDraw
{
    public class VertexDraw
    {
        public BrushColor BrushCircle;

        public readonly BrushColor TextBrush;

        public readonly float X;

        public readonly float Y;

        public readonly float Width;

        public readonly float Height;

        public readonly string Text;

        public readonly int Id;

        public VertexDraw(BrushColor brushCircle,BrushColor textBrush,float x,float y,float width,float height,string text,int id)
        {
            BrushCircle = brushCircle;

            TextBrush = textBrush;

            X = x;

            Y = y;

            Width = width;

            Height = height;

            Text = text;

            Id = id;
        }
    }
}
