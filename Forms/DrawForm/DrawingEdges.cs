using System.Collections.Generic;
using GraphModelDraw;
using System.Windows.Forms;
using VertexSearch;
using GraphRepresentation;
using CraphModel;

namespace Forms.DrawForm
{
    class DrawingEdges
    {

        public void VertexFind(NewEdgeDefinition vertexClick, MouseEventArgs e, List<VertexDraw> vertexDraws,  List<EdgeDraw> edgeDraws, ref int startVertexId, ref int endVertexId,
                               ref AdjacencyList adjacencyList, AdjacencyListPanel adListPanel)
        {

            vertexClick.VertexRemember(ref startVertexId, ref endVertexId
                        , e.X - (int)VertexParameters.Radius, e.Y - (int)VertexParameters.Radius
                        , vertexDraws);


            if ((startVertexId != -1) && (endVertexId != -1) && (startVertexId != endVertexId) && (!IsDuplicate(edgeDraws, startVertexId, endVertexId)))
            {
                EdgeDraw edgeDraw = new EdgeDraw(BrushColor.Black, 0, startVertexId, endVertexId);

                edgeDraws.Add(edgeDraw);

                adjacencyList.AddNode(startVertexId ,endVertexId , 0);

                adListPanel.UpdateNodesPanel(startVertexId, endVertexId);
              
                startVertexId = -1;
                endVertexId = -1;
            }
            else if (IsDuplicate(edgeDraws, startVertexId, endVertexId))
            {

                startVertexId = -1;
                endVertexId = -1;
            }


        }

        private bool IsDuplicate(List<EdgeDraw> edgeDraws, int startVertexId, int endVertexId)
        {
            foreach (var edge in edgeDraws)
            {
                if ((startVertexId == edge.Id) && (endVertexId == edge.ConnectabelVertex))
                {

                    return true;

                }

            }
            return false;

        }



    }
}
