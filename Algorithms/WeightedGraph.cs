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
        
        public List<int> FindShortestPath(int startVertexId, int endVertexId)
        {
            VertexInfo startVertexInfo = GetVertexInfo(startVertexId);

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

            return GetPath(startVertexId, endVertexId);
        }

        private void SetSumToNextVertex(VertexInfo vertexInfo)
        {
            vertexInfo.IsVisited = true;

            for (int i = 0; i < vertexInfo.Vertex.Nodes.Count; ++i)
            {
                long sum = vertexInfo.SumWeightEdges + vertexInfo.Vertex.Nodes[i].Weight;

                VertexInfo nextVertexInfo = GetVertexInfo(vertexInfo.Vertex.Nodes[i].Connectable);

                if (sum < nextVertexInfo.SumWeightEdges)
                {
                    nextVertexInfo.SumWeightEdges = Convert.ToInt32(sum);

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

        private List<int> GetPath(int startVertexId, int endVertexId)
        {
            List<int> path = new List<int>();

            if (GetVertexInfo(endVertexId).SumWeightEdges == Int32.MaxValue)
            {
                return null;
            }

            Vertex vertex = new Vertex() { Id = endVertexId };

            while (startVertexId != vertex.Id)
            {
                path.Add(vertex.Id);

                vertex = GetVertexInfo(vertex.Id).PrevVertex;
            }

            path.Add(startVertexId);

            path.Reverse();

            return path;
        }
    }
}
