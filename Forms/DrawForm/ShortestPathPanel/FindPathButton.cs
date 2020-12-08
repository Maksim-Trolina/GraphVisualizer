using StartForm;
using Algorithms;
using GraphModelDraw;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    public class FindPathButton : Button
    {
        private GraphRepresentation.AdjacencyList adList;

        private List<EdgeDraw> edgeDraws;

        private List<int> path;

        private InputCountBox startVertex;

        private InputCountBox endVertex;

        private StartForm.DrawForm drawForm;

        private InfoTextLabel infoText;
       
        public FindPathButton(int width, int height, int positionX, int positionY
            , GraphRepresentation.AdjacencyList adList, List<EdgeDraw> edgeDraws
            , InputCountBox startVertex, InputCountBox endVertex
            , StartForm.DrawForm drawForm, InfoTextLabel infoText)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Text = "Find path";

            Click += new EventHandler(ButtonClick);

            this.adList = adList;

            this.edgeDraws = edgeDraws;

            this.startVertex = startVertex;

            this.endVertex = endVertex;

            this.drawForm = drawForm;

            this.infoText = infoText;

            path = null;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            int start = int.Parse(startVertex.Text);

            int end = int.Parse(endVertex.Text);

            if (adList.adjacencyList.ContainsKey(start) && adList.adjacencyList.ContainsKey(end))
            {
                ClearPath();

                DrawPath(start, end, infoText);
            }
            else
            {
                infoText.Text = "Non-exist vertex";
            }
        }

        private void DrawPath(int start, int end, InfoTextLabel infoText)
        {
            WeightedGraph weightedGraph = new WeightedGraph(adList);

            path = weightedGraph.FindShortestPath(start, end);

            if (SumWeightPath(path) == 0)
            {
                infoText.Text = "Path: is not exist";
            }
            else
            {
                infoText.Text += Convert.ToString(SumWeightPath(path));
            }

            ChangeColorEdges(BrushColor.Yellow);

            drawForm.Refresh();
        }

        public void ClearPath()
        {
            ChangeColorEdges(BrushColor.Black);

            path = null;

            infoText.Text = "Path: ";

            drawForm.Refresh();
        }

        private void ChangeColorEdges(BrushColor color)
        {
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    for (int j = 0; j < edgeDraws.Count; j++)
                    {
                        if (edgeDraws[j].Id == path[i] && edgeDraws[j].ConnectabelVertex == path[i + 1])
                        {
                            edgeDraws[j].BrushEdge = color;
                        }
                    }
                }
            }
        }

        private int SumWeightPath(List<int> path)
        {
            if (path == null)
            {
                return 0; 
            }

            int sum = 0;

            for (int i = 0; i < path.Count - 1; ++i)
            {
                sum += adList.adjacencyList[path[i]][adList.FindNumberInList(path[i], path[i + 1])].Weight;
            }

            return sum;

        }
    }
}
