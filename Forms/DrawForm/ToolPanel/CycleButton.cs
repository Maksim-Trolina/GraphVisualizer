using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Algorithms;
using GraphModelDraw;
using GraphRepresentation;
using StartForm;

namespace Forms.DrawForm
{
    public class CycleButton : ToolStripButton
    {
        private Algorithms.Converter converter;

        private AdjacencyList adjacencyList;

        private List<EdgeDraw> edgeDraws;

        private StartForm.DrawForm drawForm;

        private List<int> cycle;
        public CycleButton(int width,int height,AdjacencyList adjacencyList,List<EdgeDraw> edgeDraws,StartForm.DrawForm drawForm)
        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Text = "Show Cycle";

            Click += new EventHandler(ButtonClick);

            converter = new Algorithms.Converter();

            this.adjacencyList = adjacencyList;

            this.edgeDraws = edgeDraws;

            this.drawForm = drawForm;

            cycle = null;
        }

        public void ButtonClick(object sender,EventArgs e)
        {
            if (cycle == null)
            {
                DrawCycle();

                drawForm.Refresh();
            }
            else
            {
                ClearCycle();

                drawForm.Refresh();
            }
        }

        private void DrawCycle()
        {
            List<List<int>> graph = converter.ConvertToSimpleGraph(adjacencyList);

            UnweightedGraph unweightedGraph = new Algorithms.UnweightedGraph(graph);

            if (!unweightedGraph.IsAcyclic())
            {
                cycle = unweightedGraph.GetCycle();

                ChangeColorEdges(BrushColor.Green);
            }
        }

        private void ClearCycle()
        {
            ChangeColorEdges(BrushColor.Black);

            cycle = null;
        }

        private void ChangeColorEdges(BrushColor color)
        {
            for(int i = 0; i < cycle.Count - 1; i++)
            {
                for(int j = 0; j < edgeDraws.Count; j++)
                {
                    if(edgeDraws[j].Id == cycle[i] && edgeDraws[j].ConnectabelVertex == cycle[i + 1])
                    {
                        edgeDraws[j].BrushEdge = color;
                    }
                }
            }
        }
    }
}
