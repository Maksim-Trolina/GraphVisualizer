using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class UnweightedGraph
    {
        private List<List<int>> graph;

        private List<ColorVertex> colors;

        private List<int> parent;

        private int cycleStart;

        private int cycleEnd;

        public UnweightedGraph(List<List<int>> graph)
        {
            this.graph = graph;
        }

        private void Clear()
        {
            colors.Clear();

            parent.Clear();
        }

        public bool IsAcyclic()
        {
            parent = new List<int>();

            colors = new List<ColorVertex>();

            for(int i = 0; i < graph.Count; i++)
            {
                parent.Add(-1);

                colors.Add(ColorVertex.White);
            }

            cycleStart = -1;

            for(int i = 0; i < graph.Count; i++)
            {
                if (DFS(i))
                {
                    break;
                }
            }

            if(cycleStart == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private bool DFS(int vertex)
        {
            colors[vertex] = ColorVertex.Gray;

            for(int i = 0; i < graph[vertex].Count; i++)
            {
                int to = graph[vertex][i];
                
                if(colors[to] == ColorVertex.White)
                {
                    parent[to] = vertex;

                    if (DFS(to))
                    {
                        return true;
                    }
                }
                else if(colors[to] == ColorVertex.Gray)
                {
                    cycleEnd = vertex;

                    cycleStart = to;

                    return true;
                }
            }

            colors[vertex] = ColorVertex.Black;

            return false;
        }
    }
}
