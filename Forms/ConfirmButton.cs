using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class ConfirmButton : Button
    {
        public ConfirmButton(int sizeX, int sizeY, int locationX, int locationY, string buttonText = "OK")
        {
            this.Text = buttonText;
            this.Size = new System.Drawing.Size(sizeX, sizeY);
            this.Location = new System.Drawing.Point(locationX, locationY);
        }
    }
}
