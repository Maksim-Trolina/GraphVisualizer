using System.Collections.Generic;
using GraphModelDraw;
using System.Drawing;
using System.Windows.Forms;
using VertexSearch;


namespace Forms.DrawForm
{
    class DrawingEdges
    {

        public void VertexFind(VertexClick vertexClick, MouseEventArgs e, List<VertexDraw> vertexDraws, List<EdgeDraw> edgeDraws, ref int startVertexId, ref int endVertexId)
        {

            vertexClick.VertexRemember(ref startVertexId, ref endVertexId
                        , e.X - (int)VertexParameters.Radius, e.Y - (int)VertexParameters.Radius
                        , vertexDraws, (int)VertexParameters.Radius);


            if ((startVertexId != -1) && (endVertexId != -1) && (startVertexId != endVertexId))
            {
                EdgeDraw edgeDraw = new EdgeDraw(BrushColor.Black, 0, startVertexId, endVertexId);

                edgeDraws.Add(edgeDraw);
              
                startVertexId = -1;
                endVertexId = -1;
            }

        }


        public void DefinitionOfEdges(List<EdgeDraw>edgeDraws, List<VertexDraw> vertexDraws, EdgeDraw edge, ref Point p1, ref Point p2)
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
