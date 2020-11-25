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

        private List<List<int>> cycles;
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

            cycles = null;
        }

        public void ButtonClick(object sender,EventArgs e)
        {
            if (cycles == null)
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
                cycles = unweightedGraph.GetCycles();

                ChangeColorEdges(BrushColor.Green);
            }
        }

        private void ClearCycle()
        {
            ChangeColorEdges(BrushColor.Black);

            cycles = null;
        }

        private void ChangeColorEdges(BrushColor color)
        {
            for(int i = 0; i < cycles.Count; i++)
            {
                for(int j = 0; j < cycles[i].Count - 1; j++)
                {
                    for(int q = 0; q < edgeDraws.Count; q++)
                    {
                        if(edgeDraws[q].Id == cycles[i][j] && edgeDraws[q].ConnectabelVertex == cycles[i][j + 1])
                        {
                            edgeDraws[q].BrushEdge = color;
                        }
                    }
                }
            }
        }
    }
}
