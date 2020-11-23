using System.Windows.Forms;
using System;

namespace Forms
{
    class BackButton : Button
    {

        public BackButton(int width, int height, int positionX, int positionY, string buttonText = "back to menu")
        {

            this.Text = buttonText;

            this.Size = new System.Drawing.Size(width, height);

            this.Location = new System.Drawing.Point(positionX, positionY);

            Click += new EventHandler(ButtonClick);

        }

        public void ButtonClick(object sender, EventArgs e)
        {


        }
    }
}
