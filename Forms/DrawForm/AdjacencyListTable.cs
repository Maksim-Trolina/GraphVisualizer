using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class AdjacencyListTable : Panel
    {
        public AdjacencyListTable(int width, int height, int positionX, int positionY)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Right;

            AutoScroll = true;

            BorderStyle = BorderStyle.Fixed3D;

        }
    }
}
