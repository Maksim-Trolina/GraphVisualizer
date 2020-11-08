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

            colors = new List<ColorVertex>();

            parent = new List<int>();
        }

        private void Clear()
        {
            colors.Clear();

            parent.Clear();
        }

        public bool IsAcyclic()
        {
            Clear();

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

        public List<int> GetCycle()
        {
            List<int> cycle = new List<int> { cycleStart };

            for(int i = cycleEnd; i != cycleStart; i = parent[i])
            {
                cycle.Add(i);
            }

            cycle.Add(cycleStart);

            cycle.Reverse();

            return cycle;
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
