using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; 

namespace Forms.DrawForm
{
    public class CellBox : TextBox
    {
        public CellBox(int width, int height, int positionX, int positionY, int initValue = 0)
        {
            Text = Convert.ToString(initValue);

            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            KeyPress += new KeyPressEventHandler(TextBoxKeyPressed);

            if (Text == "0")
            {
                Enabled = false;
            }
        }
        public void TextBoxKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))   // entered a digit or backspace
            {
                e.Handled = true;

            }
        }
    }
}
