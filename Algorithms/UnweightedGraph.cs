using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class UnweightedGraph
    {
        private List<List<int>> graph;

        private List<ColorVertex> colors;

        

        public UnweightedGraph(List<List<int>> graph)
        {
            this.graph = graph;
        }

        private void Clear()
        {
            colors.Clear();

            graph.Clear();
        }

        public bool IsAcyclic()
        {

        }
        
        private bool DFS(int vertex)
        {

        }
    }
}
