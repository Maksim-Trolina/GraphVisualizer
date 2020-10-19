using GraphModelDraw;
using System;
using System.Drawing;

namespace ArrowDraw
{
    public class Arrow
    {
        public Point GetEndArrowPoint(Point start,Point end)
        {
            int X = Math.Abs(start.X - end.X);
            int Y = Math.Abs(start.Y - end.Y);

            int hypotenuse = (int)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y,2));

            int x = (X * (int)VertexParameters.Radius) / hypotenuse;
            int y = (Y * (int)VertexParameters.Radius) / hypotenuse;

            Point result = new Point();

            result.X = end.X;

            result.Y = end.Y;

            if(start.X <= end.X)
            {
                result.X -= x;
            }
            else
            {
                result.X += x;
            }
            if(start.Y <= end.Y)
            {
                result.Y -= y;
            }
            else
            {
                result.Y += y;
            }

            return result;
        }
    }
}
