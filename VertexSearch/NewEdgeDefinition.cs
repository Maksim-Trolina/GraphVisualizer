using System.Collections.Generic;
using System;
using GraphModelDraw;
using System.Drawing;


namespace VertexSearch
{
    public class NewEdgeDefinition
    {

        public int GetNumberOfVertex(float ClickX, float ClickY, List<VertexDraw> vertexDraws)
        {
            int distance = 0;
            

            foreach (var vertex in vertexDraws)
            {
                distance = (int)GetDistance(vertex.X, ClickX, vertex.Y, ClickY);

                if (distance <= (int)VertexParameters.Radius)
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



        public void VertexRemember(ref int startVertexId, ref int endVertexId, float ClickX, float ClickY, List<VertexDraw> vertexDraws)
        {

            if ((startVertexId == -1) && (endVertexId == -1) && (GetNumberOfVertex(ClickX, ClickY, vertexDraws) != -1))
            {

                startVertexId = GetNumberOfVertex(ClickX, ClickY, vertexDraws);

                vertexDraws[startVertexId].BrushCircle = BrushColor.Black;


            }

            else if ((endVertexId == -1) && (GetNumberOfVertex(ClickX, ClickY, vertexDraws) != -1))
            {

                endVertexId = GetNumberOfVertex(ClickX, ClickY, vertexDraws);

                if (endVertexId == startVertexId)
                {
                    vertexDraws[startVertexId].BrushCircle = BrushColor.Red;
                    endVertexId = -1;
                    startVertexId = -1;
                    
                }
                    

                if (endVertexId != -1)
                {
                    vertexDraws[startVertexId].BrushCircle = BrushColor.Red;

                }

            }
            else
                return;
        }

        public void DefinitionOfEdge(List<VertexDraw> vertexDraws, EdgeDraw edge, ref Point p1, ref Point p2)
        {

            p1.X = 0;
            p1.Y = 0;

            p2.X = 0;
            p2.Y = 0;

            foreach (var vertex in vertexDraws)
            {

                if (edge.Id == vertex.Id)
                {
                    p1.X = (int)vertex.X + (int)VertexParameters.Radius;
                    p1.Y = (int)vertex.Y + (int)VertexParameters.Radius;

                }
                else if (edge.ConnectabelVertex == vertex.Id)
                {
                    p2.X = (int)vertex.X + (int)VertexParameters.Radius;
                    p2.Y = (int)vertex.Y + (int)VertexParameters.Radius;


                }
            }

        }

    }
}
