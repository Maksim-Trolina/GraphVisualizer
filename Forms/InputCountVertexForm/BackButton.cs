using System.Windows.Forms;
using System;

namespace Forms
{
    class BackButton : Button
    {

        public BackButton(string buttonText = "back to menu")
        {

            Text = buttonText;

            Size = new System.Drawing.Size(100, 30);

            Location = new System.Drawing.Point(10, 410);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);

            Click += new EventHandler(ButtonClick);

        }

        public virtual void ButtonClick(object sender, EventArgs e)
        {

        }
    }
}
