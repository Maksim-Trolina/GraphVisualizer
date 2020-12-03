using GraphModelDraw;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    public class DeletePathButton : Button
    {
        private List<int> path;

        private StartForm.DrawForm drawForm;

        private List<EdgeDraw> edgeDraws;

        public DeletePathButton(int width, int height, int positionX, int positionY, List<int> path
            , StartForm.DrawForm drawForm, List<EdgeDraw> edgeDraws)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Text = "Delete path";

            Click += new EventHandler(ButtonClick);

            this.path = path;

            this.drawForm = drawForm;

            this.edgeDraws = edgeDraws;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            ClearPath();
        }

        private void ClearPath()
        {
            ChangeColorEdges(BrushColor.Black, path);

            drawForm.Refresh();

            path = null;
        }

        private void ChangeColorEdges(BrushColor color, List<int> path)
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
    }
}
