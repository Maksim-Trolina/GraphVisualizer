using System;
using System.Collections.Generic;
using System.Text;
using CraphModel;
using GraphRepresentation;

namespace Forms.DrawForm
{
    public class Converter
    {
        public AdjacencyList Convert(List<List<InputCountBox>> inputCounts)
        {
            List<Vertex> vertices = new List<Vertex>();

            if (inputCounts != null)
            {
                for (int i = 0; i < inputCounts.Count; i++)
                {
                    vertices.Add(new Vertex { Id = 0, Nodes = new List<Node>() });

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
    }
}
