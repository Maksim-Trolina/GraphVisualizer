using System.Collections.Generic;
using System;
using GraphModelDraw;

namespace VertexSearch
{
    public class VertexClick
    {

        public int GetNumberOfVertex(float ClickX, float ClickY, List<VertexDraw> vertexDraws, int VertexRadius)
        {

            foreach (var vertex in vertexDraws)
            {
                if ((int)GetDistance(vertex.X, vertex.Y, ClickX, ClickY) >= VertexRadius)
                {
                    return vertex.Id;
                }


            }
            return -1;
        }

        private double GetDistance(float x1, float x2, float y1, float y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }


        public int FoundVertexs(int startVertex, int endVertex)
        {

            if ((startVertex != -1) && (endVertex != -1))
            {
                return (int)FoundPoints.TwoVertexFound;
            }
            if (startVertex != -1)
            {
                return (int)FoundPoints.OneVertexFound;
            }

            return (int)FoundPoints.NooneFertexsFound;

        }

    }
}
