using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    class StartButton : Button
    {
      
        public void ButtonInitialization(Form StartForm, string buttonName, int buttonX, int buttonY, int buttonWidth, int buttonHeight)
        {
            Button buttonPattern = new Button();

            buttonPattern.Text = buttonName;

            buttonPattern.Location = new System.Drawing.Point(buttonX, buttonY); 

            buttonPattern.Size = new System.Drawing.Size(buttonWidth, buttonHeight);

            buttonPattern.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            StartForm.Controls.Add(buttonPattern); // mapping an item to a form

        }
    }
}
