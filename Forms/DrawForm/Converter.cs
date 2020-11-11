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
                        int weight;

                        try
                        {
                            weight = int.Parse(inputCounts[i][j].Text);
                        }
                        catch
                        {
                            weight = 0;
                        }

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

        public List<List<InputCountBox>> ConvertToListListInputCountBox(Graph graph)
        {
            List<List<InputCountBox>> matrix = new List<List<InputCountBox>>();

            int stepX = 10;
            int stepY = 10;

            int width = 20;
            int height = 20;

            int positionX = 0;
            int positionY = 0;

            
           for(int i = 0; i < graph.Vertexs.Count; i++)
           {
                matrix.Add(new List<InputCountBox>());

                for (int j = 0; j < graph.Vertexs.Count; j++)
                {
                    matrix[i].Add(new InputCountBox(width, height, positionX + (width + stepX) * j, positionY + (height + stepY) * i));
                    

                }

           }
            for (int i = 0; i < graph.Vertexs.Count; i++)
            {
                for(int  j = 0; j < graph.Vertexs[i].Nodes.Count; j++)
                {
                    matrix[i][graph.Vertexs[i].Nodes[j].Connectable].Text = graph.Vertexs[i].Nodes[j].Weight.ToString();
                    
                }

            }

                return matrix;
        }
    }
}
