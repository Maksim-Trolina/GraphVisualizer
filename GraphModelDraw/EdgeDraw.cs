using System;
using System.Collections.Generic;
using System.Text;

namespace GraphModelDraw
{
    public class EdgeDraw
    {
        public readonly BrushColor BrushEdge;

        public readonly int WeightEdge;

        public readonly int Id;

        public readonly int ConnectabelEdge;

        public EdgeDraw(BrushColor brushEdge, int weightEdge, int id, int connectableEdge)
        {

            BrushEdge = brushEdge;

            WeightEdge = weightEdge;

            Id = id;

            ConnectabelEdge = connectableEdge;

        }

    }
}
