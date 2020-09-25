using GraphModelDraw;
using System;
using System.Collections.Generic;

namespace CollisionDraw
{
    public class CollisionVertex
    {
        public bool IsDrawVertex(VertexDraw vertexDraw, List<VertexDraw> vertexDraws)
        {
            return !IsCollision(vertexDraw, vertexDraws);
        }

        private bool IsCollision(VertexDraw vertexDraw,List<VertexDraw> vertexDraws)
        {
            foreach(var vertex in vertexDraws)
            {
                int distance = (int)GetDistance(vertex.X, vertexDraw.X, vertex.Y, vertexDraw.Y);

                if (distance < 2 * (int)VertexParameters.Radius)
                {
                    return true;
                }
            }

            return false;
        }

        private double GetDistance(float x1, float x2, float y1, float y2)
        {
            return Math.Sqrt((x1 - x2)*(x1-x2) + (y1-y2)*(y1-y2));
        }
    }
}
