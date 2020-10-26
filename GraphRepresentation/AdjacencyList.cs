using System;
using System.Collections.Generic;
using CraphModel;
using GraphModelDraw;

namespace GraphRepresentation
{
    public class AdjacencyList
    {
        Dictionary<int, List<Node>> adjacencyList;

        public AdjacencyList(List<Vertex> verticles)
        {
            adjacencyList = new Dictionary<int, List<Node>>();

            foreach (var vertex in verticles)
            {
                AddVertex(vertex);
            }
        }

        public void AddVertex(Vertex vertex)
        {
            if (adjacencyList.ContainsKey(vertex.Id))
            {
                throw new Exception("This vertex is already in the list of adjacencies");
            }
            else
            {
                adjacencyList.Add(vertex.Id, vertex.Nodes);
            }

        }

        public void AddNode(Vertex vertexStart, Vertex vertexEnd, int weight)
        {
            if (vertexStart == vertexEnd)
            {
                throw new Exception("The starting vertex coincides with the ending vertex");
            }
            else
            {
                Node node = new Node();

                node.Connectable = vertexEnd.Id;

                node.Weight = weight;

                adjacencyList[vertexStart.Id].Add(node);
            }
        }
    }
}
