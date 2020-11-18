using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; 

namespace Forms.DrawForm
{
    public class CellBox : TextBox
    {
        public char FirstDigit { get; private set; }

        public CellBox(int width, int height, int positionX, int positionY, int initValue = 0)
        {
            Text = Convert.ToString(initValue);

            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            KeyPress += new KeyPressEventHandler(TextBoxKeyPressed);

            
        }

        public void TextBoxKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (Text.Length == 1)
            {
                FirstDigit = Text[0];
            }

            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b') || (Text.Length == 0 && e.KeyChar == '0'))   // entered a digit or backspace
            {
                e.Handled = true;
            }


        }

        
    }
}
