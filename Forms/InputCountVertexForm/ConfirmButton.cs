using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class ConfirmButton : Button
    {
        public InputCountVertexForm InputCountVertexForm { get; set; }
        public InputCountBox InputCountBox { get; set; }

        public ConfirmButton(int sizeX, int sizeY, int locationX, int locationY, string buttonText = "OK")
        {
            this.Text = buttonText;
            this.Size = new System.Drawing.Size(sizeX, sizeY);
            this.Location = new System.Drawing.Point(locationX, locationY);
            Click += new EventHandler(ButtonClick);
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            uint inputNumber = 0;
            if (UInt32.TryParse(InputCountBox.Text, out inputNumber) && inputNumber > 0 && inputNumber < 6)
            {
                InputCountVertexForm.CreateMatrixGraph(inputNumber);
            }

        }
    }
}
