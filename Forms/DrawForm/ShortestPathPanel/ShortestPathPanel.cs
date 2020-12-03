using GraphModelDraw;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    public class ShortestPathPanel : Panel
    {
        private GraphRepresentation.AdjacencyList adList;

        private InputCountBox startVertex;

        private InputCountBox endVertex;

        private FindPathButton findPathButton;

        private DeletePathButton deletePathButton;

        private List<EdgeDraw> edgeDraws;

        private List<int> path;

        public ShortestPathPanel(int width, int height, int positionX, int positionY
            , GraphRepresentation.AdjacencyList adList, List<EdgeDraw> edgeDraws
            , StartForm.DrawForm drawForm)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            BorderStyle = BorderStyle.Fixed3D;

            Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            Visible = false;

            this.adList = adList;

            this.edgeDraws = edgeDraws;

            //path = null;

            startVertex= new InputCountBox(20, 20, 40, 60);

            Controls.Add(startVertex);

            endVertex = new InputCountBox(20, 20, Size.Width - 60, 60);

            Controls.Add(endVertex);

            findPathButton = new FindPathButton(95, 30, 5, Size.Height - 60, adList, edgeDraws
                , startVertex, endVertex, path, drawForm);

            Controls.Add(findPathButton);

            deletePathButton = new DeletePathButton(95, 30, Size.Width - 100, Size.Height - 60, path, drawForm, edgeDraws);

            Controls.Add(deletePathButton);
        }
    }
}
