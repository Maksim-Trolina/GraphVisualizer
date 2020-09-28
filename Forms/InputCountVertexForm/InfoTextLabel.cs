using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class InfoTextLabel : System.Windows.Forms.Label
    {
        public InfoTextLabel(int width, int height, int positionX, int positionY, string info = "Введите количество вершин в графе:")
        {
            this.Text = info;
            this.Size = new System.Drawing.Size(width, height);
            this.Location = new System.Drawing.Point(positionX, positionY);
        }
    }
}
