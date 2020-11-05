using System.Collections.Generic;



namespace GraphModelDraw
{
    public class VertexDraw
    {
        public BrushColor BrushCircle;

        public readonly BrushColor TextBrush;

        public float X;

        public float Y;

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

        public void VertexMove(List<VertexDraw> vertexDraws, ref int vertexId, float newX, float newY)
        {
            vertexDraws[vertexId].X = newX;
            vertexDraws[vertexId].Y = newY;
            vertexDraws[vertexId].BrushCircle = BrushColor.Red;
            vertexId = -1;

        }
    }
}
