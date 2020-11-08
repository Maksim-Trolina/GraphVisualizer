using System;
using System.Collections.Generic;
using System.Text;
using GraphRepresentation;

namespace Algorithms
{
    public class Converter
    {
        public List<List<int>> ConvertToSimpleGraph(AdjacencyList adjacencyList)
        {
            List<List<int>> graph = new List<List<int>>();

            for(int i = 0; i < adjacencyList.adjacencyList.Count; i++)
            {
                graph.Add(new List<int>());

                for(int j = 0; j < adjacencyList.adjacencyList[i].Count; j++)
                {
                    graph[i].Add(adjacencyList.adjacencyList[i][j].Connectable);
                }
            }

            return graph;
        }
    }
}
