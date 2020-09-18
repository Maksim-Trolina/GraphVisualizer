using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Forms;


namespace Forms
{
    class StartButton : Button
    {

        private int buttonWidth = 100;
        private int buttonHeight = 50;
        private string buttonName = "Matrix";

        public StartButton()
        {

            this.Text = buttonName;

            this.Location = new System.Drawing.Point(350, 180); 

            this.Size = new System.Drawing.Size(buttonWidth, buttonHeight);

            this.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            this.Click += new EventHandler(ButtonClick);

        }

        public InputCountVertexForm nextForm;
        public StartForm startForm;

        public void ButtonClick(object sender, EventArgs e)
        {

            startForm.Hide();
            nextForm.ShowDialog();
            this.Show();

            MessageBox.Show("Fuck you!");

        }
    }
}
