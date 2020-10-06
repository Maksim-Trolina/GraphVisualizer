using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public class InputCountBox : TextBox
    {
        public InputCountBox(int width, int height, int positionX, int positionY, string initValue = "0")
        {
            this.Text = initValue;
            this.Size = new System.Drawing.Size(width, height);
            this.Location = new System.Drawing.Point(positionX, positionY);
            this.KeyPress += new KeyPressEventHandler(TextBoxKeyPressed);
                     
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
