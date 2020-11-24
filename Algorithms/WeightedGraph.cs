using System;
using System.Collections.Generic;
using System.Text;
using CraphModel;
using GraphRepresentation;

namespace Algorithms
{
    public class VertexInfo
    {
        public Vertex Vertex { get; set; }

        public bool IsVisited { get; set; }

        public int SumWeightEdges { get; set; }

        public Vertex PrevVertex { get; set; }

        public VertexInfo(Vertex vertex)
        {
            Vertex = vertex;

            IsVisited = false;

            SumWeightEdges = Int32.MaxValue;

            PrevVertex = null;
        }
    }

    public class WeightedGraph
    {
        private List<VertexInfo> vertexInfos;

        public WeightedGraph(AdjacencyList adList)
        {
            vertexInfos = new List<VertexInfo>();

            for (int i = 0; i < adList.adjacencyList.Keys.Count; ++i)
            {
                vertexInfos.Add(new VertexInfo(new Vertex() { Id = i, Nodes = adList.adjacencyList[i]}));   
            }
        }
        
        public List<Vertex> FindShortestPath(Vertex startVertex, Vertex endVertex)
        {
            List<Vertex> path = new List<Vertex>();

            VertexInfo startVertexInfo = GetVertexInfo(startVertex.Id);

            startVertexInfo.SumWeightEdges = 0;

            VertexInfo currentVertexInfo = null;

            while (true)
            {
                currentVertexInfo = FindMinUnvisitedVertex();

                if (currentVertexInfo == null)
                {
                    break;
                }

                SetSumToNextVertex(currentVertexInfo);
            }

            if (GetVertexInfo(endVertex.Id).SumWeightEdges == Int32.MaxValue)
            {
                return null;
            }

            while (startVertex.Id != endVertex.Id)
            {
                path.Add(endVertex);

                endVertex = GetVertexInfo(endVertex.Id).PrevVertex;
            }

            path.Add(endVertex);

            path.Reverse();

            return path;
        }

        private void SetSumToNextVertex(VertexInfo vertexInfo)
        {
            vertexInfo.IsVisited = true;

            for (int i = 0; i < vertexInfo.Vertex.Nodes.Count; ++i)
            {
                int sum = vertexInfo.SumWeightEdges + vertexInfo.Vertex.Nodes[i].Weight;

                VertexInfo nextVertexInfo = GetVertexInfo(vertexInfo.Vertex.Nodes[i].Connectable);

                if (sum < nextVertexInfo.SumWeightEdges)
                {
                    nextVertexInfo.SumWeightEdges = sum;

                    nextVertexInfo.PrevVertex = vertexInfo.Vertex;
                }
            }
        }

        private VertexInfo FindMinUnvisitedVertex()
        {
            int minSum = Int32.MaxValue;

            VertexInfo minVertexInfo = null;

            foreach(var vertex in vertexInfos)
            {
                if (!vertex.IsVisited && vertex.SumWeightEdges < minSum)
                {
                    minVertexInfo = vertex;

                    minSum = vertex.SumWeightEdges;
                }
            }

            return minVertexInfo;
        }

        private VertexInfo GetVertexInfo(int vertexId)
        {
            for (int i = 0; i < vertexInfos.Count; ++i)
            {
                if (vertexInfos[i].Vertex.Id == vertexId)
                {
                    return vertexInfos[i];
                }
            }

            return null;
        }
    }
}
