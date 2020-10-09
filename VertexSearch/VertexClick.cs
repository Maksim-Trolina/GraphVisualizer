﻿using System.Collections.Generic;
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
 
    }
}
