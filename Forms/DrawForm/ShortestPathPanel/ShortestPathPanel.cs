﻿using GraphModelDraw;
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

        public FindPathButton findPathButton;

        private List<EdgeDraw> edgeDraws;

        private InfoTextLabel infoText;

        private InfoTextLabel startVertexText;

        private InfoTextLabel endVertexText;

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

            infoText = new InfoTextLabel(180, 20, 10, 20,"Path: ");

            Controls.Add(infoText);

            startVertexText = new InfoTextLabel(65, 20, 0, 60, "From:");

            Controls.Add(startVertexText);

            endVertexText = new InfoTextLabel(45, 20, Size.Width - 100, 60, "To:");

            Controls.Add(endVertexText);

            startVertex = new InputCountBox(20, 20, 65, 60);

            Controls.Add(startVertex);

            endVertex = new InputCountBox(20, 20, Size.Width - 55, 60);

            Controls.Add(endVertex);

            findPathButton = new FindPathButton(95, 30, Size.Width / 2 - 45, Size.Height - 60, adList, edgeDraws
                , startVertex, endVertex, drawForm, infoText);

            Controls.Add(findPathButton);
        }
    }
}
