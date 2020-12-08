using System.Windows.Forms;
using System;

namespace Forms
{
    public class BackButton : Button
    {

        public BackButton(string buttonText = "back to menu")
        {

            Text = buttonText;

            Size = new System.Drawing.Size(100, 30);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);

            Click += new EventHandler(ButtonClick);

        }

        public virtual void ButtonClick(object sender, EventArgs e)
        {

        }
    }
}