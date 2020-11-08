using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GraphModelDraw;
using GraphRepresentation;

namespace Forms.DrawForm
{
    public class CycleButton : ToolStripButton
    {
        private bool isShowCycle;

        private Algorithms.Converter converter;

        private AdjacencyList adjacencyList;

        private List<EdgeDraw> edgeDraws;
        public CycleButton(int width,int height,AdjacencyList adjacencyList,List<EdgeDraw> edgeDraws)
        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Text = "Show Cycle";

            Click += new EventHandler(ButtonClick);

            isShowCycle = false;

            converter = new Algorithms.Converter();

            this.adjacencyList = adjacencyList;

            this.edgeDraws = edgeDraws;
        }

        public void ButtonClick(object sender,EventArgs e)
        {
            isShowCycle = !isShowCycle;

            if (isShowCycle)
            {
                DrawCycle();
            }
            else
            {

            }
        }

        private void DrawCycle()
        {
            List<List<int>> graph = converter.ConvertToSimpleGraph(adjacencyList);

            Algorithms.UnweightedGraph unweightedGraph = new Algorithms.UnweightedGraph(graph);

            if (!unweightedGraph.IsAcyclic())
            {
                List<int> cycle = unweightedGraph.GetCycle();

                for(int i = 0; i < cycle.Count - 1; i++)
                {
                    for(int j = 0; j < edgeDraws.Count; j++)
                    {
                        if(edgeDraws[j].Id == cycle[i] && edgeDraws[j].ConnectabelVertex == cycle[i + 1])
                        {
                            edgeDraws[j].BrushEdge = BrushColor.Green;
                        }
                    }
                }
            }
        }
    }
}
