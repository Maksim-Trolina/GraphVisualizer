using System;
using System.Collections.Generic;
using System.Text;
using CraphModel;
using GraphRepresentation;

namespace Forms.DrawForm
{
    public class Converter
    {
        public AdjacencyList ConvertToAdjacencyList(List<List<InputCountBox>> inputCounts)
        {
            List<Vertex> vertices = new List<Vertex>();

            if (inputCounts != null)
            {
                for (int i = 0; i < inputCounts.Count; i++)
                {
                    vertices.Add(new Vertex { Id = i, Nodes = new List<Node>() });

                    for (int j = 0; j < inputCounts[i].Count; j++)
                    {
                        int weight = int.Parse(inputCounts[i][j].Text);

                        if (weight != 0)
                        {
                            vertices[i].Nodes.Add(new Node { Connectable = j, Weight = weight });
                        }
                    }
                }
            }

            return new AdjacencyList(vertices);
        }

        public Graph ConvertToGraph(AdjacencyList adjacencyList)
        {
            Graph graph = new Graph();
            Vertex vertex = new Vertex();

            graph.Vertexs = new List<Vertex>(adjacencyList.adjacencyList.Count);

            for (int i = 0; i < adjacencyList.adjacencyList.Count; i++)
            {
                vertex.Nodes = new List<Node>(adjacencyList.adjacencyList[i].Count);

                for (int j = 0; j < adjacencyList.adjacencyList[i].Count; j++)
                {

                    vertex.Nodes.Add(new Node() { Weight = adjacencyList.adjacencyList[i][j].Weight, Connectable = adjacencyList.adjacencyList[i][j].Connectable });

                }

                graph.Vertexs.Add(new Vertex() { Nodes = vertex.Nodes, Id = i });

            }

            return graph;
        }

        public AdjacencyList ConvertToAdjacencyList(Graph graph)
        {
            List<Vertex> vertices = new List<Vertex>();



            return new AdjacencyList(vertices);
        }
    }
}
