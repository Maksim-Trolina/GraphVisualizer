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

        private List<BrushColor> colors;
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

            colors = new List<BrushColor> { BrushColor.Green, BrushColor.Red, BrushColor.Yellow };
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

                colors = new List<BrushColor> { BrushColor.Green, BrushColor.Red, BrushColor.Yellow };

                drawForm.Refresh();
            }
        }

        private void DrawCycle()
        {
            List<List<int>> graph = converter.ConvertToSimpleGraph(adjacencyList);

            UnweightedGraph unweightedGraph = new Algorithms.UnweightedGraph(graph);

            cycles = unweightedGraph.GetCycles();

            for(int i = 0; i < cycles.Count; i++)
            {
                ChangeColorEdges(GetColor(),cycles[i]);
            }
        }

        private void ClearCycle()
        {
            for (int i = 0; i < cycles.Count; i++)
            {
                ChangeColorEdges(BrushColor.Black,cycles[i]);
            }

            cycles = null;
        }

        private void ChangeColorEdges(BrushColor color,List<int> cycle)
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

        private BrushColor GetColor()
        {
            BrushColor color;

            color = colors[0];

            if (colors.Count > 1)
            {
                colors.RemoveAt(0);
            }

            return color;
        }
    }
}
