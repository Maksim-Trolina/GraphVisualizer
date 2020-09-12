using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class InfoTextLabel : System.Windows.Forms.Label
    {
        public InfoTextLabel(int sizeX, int sizeY, int locationX, int locationY, string info = "Введите количество вершин в графе:")
        {
            this.Text = info;
            this.Size = new System.Drawing.Size(sizeX, sizeY);
            this.Location = new System.Drawing.Point(locationX, locationY);
        }
    }
}
