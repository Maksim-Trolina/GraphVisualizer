using System.Collections.Generic;
using System;
using GraphModelDraw;

namespace VertexSearch
{
    public class VertexClick
    {

        public int GetNumberOfVertex(float ClickX, float ClickY, List<VertexDraw> vertexDraws,  int VertexRadius)
        {

            foreach (var vertex in vertexDraws)
            {
                int distance = (int)GetDistance(vertex.X, ClickX, vertex.Y, ClickY);

                if (distance <= VertexRadius)
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



        public void VertexRemember(ref int startVertexId, ref int endVertexId, float ClickX, float ClickY, List<VertexDraw> vertexDraws, int VertexRadius)
        {

            if ((startVertexId == -1) && (endVertexId == -1) && (GetNumberOfVertex(ClickX, ClickY, vertexDraws, (int)VertexParameters.Radius) != -1))
            {

                startVertexId = GetNumberOfVertex(ClickX, ClickY, vertexDraws, (int)VertexParameters.Radius);
            }

            else if ((endVertexId == -1) && (GetNumberOfVertex(ClickX, ClickY, vertexDraws, (int)VertexParameters.Radius) != -1))
            {

                endVertexId = GetNumberOfVertex(ClickX, ClickY, vertexDraws, (int)VertexParameters.Radius);

                if (endVertexId == startVertexId)
                    endVertexId = -1;
            }
            else
                return;
        }
 
    }
}
