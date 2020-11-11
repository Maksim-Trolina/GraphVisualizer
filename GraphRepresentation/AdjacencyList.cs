using System;
using System.Collections.Generic;
using CraphModel;
using GraphModelDraw;

namespace GraphRepresentation
{
    public class AdjacencyList
    {
        public Dictionary<int, List<Node>> adjacencyList { get; private set; }

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

        public void AddNode(int vertexStartId, int vertexEndId, int weight)
        {

            if (vertexStartId == vertexEndId)
            {
                throw new Exception("The starting vertex coincides with the ending vertex");
            }
            else

            {

                adjacencyList[vertexStartId].Add(new Node() { Connectable = vertexEndId, Weight = weight});

            }
        }
    }
}
