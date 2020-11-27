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

            cycleStart = -1;

            cycleEnd = -1;
        }

        public bool IsAcyclic()
        {
            Clear();

            for(int i = 0; i < graph.Count; i++)
            {
                parent.Add(-1);

                colors.Add(ColorVertex.White);
            }

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

        private void DeletingEdges(List<int> cycle)
        {
            for(int i = 0; i < cycle.Count - 1; i++)
            {
                int index = cycle[i];

                for(int j = 0; j < graph[index].Count; j++)
                {
                    if(graph[index][j] == cycle[i + 1])
                    {
                        graph[index].RemoveAt(j);
                        break;
                    }
                }
            }
        }

        public List<List<int>> GetCycles()
        {
            List<List<int>> cycles = new List<List<int>>();

            while (!IsAcyclic())
            {
                List<int> cycle = GetCycle();
                cycles.Add(cycle);
                DeletingEdges(cycle);
            }

            return cycles;
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

            if(cycleStart == -1 || cycleEnd == -1)
            {
                return new List<int>();
            }

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
