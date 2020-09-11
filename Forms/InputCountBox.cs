using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class InputCountBox : TextBox
    {
        public InputCountBox()
        {
            this.Text = "0";
        }
        
        public bool CorrectInput()
        {
            return true;
        }
    }
}
