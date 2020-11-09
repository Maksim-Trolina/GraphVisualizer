using System;
using System.Collections.Generic;
using System.Text;

namespace GraphModelDraw
{
    public class EdgeDraw
    {
        public BrushColor BrushEdge { get; set; }

        public readonly int Id;

        public readonly int ConnectabelVertex;

        public EdgeDraw(BrushColor brushEdge, int weightEdge, int id, int connectableVertex)
        {

            BrushEdge = brushEdge;

            Id = id;

            ConnectabelVertex = connectableVertex;

        }

    }
}
