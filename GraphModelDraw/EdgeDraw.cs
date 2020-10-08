using System;
using System.Collections.Generic;
using System.Text;

namespace GraphModelDraw
{
    public class EdgeDraw
    {
        public readonly BrushColor BrushEdge;

        public readonly BrushColor TextBrush;

        public readonly int WeightEdge;

        public readonly int ConnectabelEdge;

        public EdgeDraw(BrushColor brushEdge, BrushColor textBrush, int weightEdge, int connectableEdge)
        {

            BrushEdge = brushEdge;

            TextBrush = textBrush;

            WeightEdge = weightEdge;

            ConnectabelEdge = connectableEdge;

        }

    }
}
