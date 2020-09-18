using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class InputCountBox : TextBox
    {
        public InputCountBox(int sizeX, int sizeY, int locationX, int locationY, string initValue = "0")
        {
            this.Text = initValue;
            this.Size = new System.Drawing.Size(sizeX, sizeY);
            this.Location = new System.Drawing.Point(locationX, locationY);
                     
        }
    }
}
