using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class StartButton : Button
    {
      
        public void ButtonInitialization(Form StartForm, string buttonName, int buttonX, int buttonY, int buttonWidth, int buttonHeight, EventHandler ev)
        {

            this.Text = buttonName;

            this.Location = new System.Drawing.Point(buttonX, buttonY); 

            this.Size = new System.Drawing.Size(buttonWidth, buttonHeight);

            this.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            StartForm.Controls.Add(this); // mapping an item to a form

        }
    }
}
