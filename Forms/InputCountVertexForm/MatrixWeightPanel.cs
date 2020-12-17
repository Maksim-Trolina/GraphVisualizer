using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public class MatrixWeightTablePanel : Panel
    {
        public MatrixWeightTablePanel(int weight, int height, int positionX, int positionY)
        {
            Size = new System.Drawing.Size(weight, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Anchor = (AnchorStyles.Top | AnchorStyles.Left);

            BorderStyle = BorderStyle.Fixed3D;

            AutoScroll = true;
        }
    }
}
