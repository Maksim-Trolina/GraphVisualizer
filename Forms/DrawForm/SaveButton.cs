using System;
using System.Windows.Forms;
using CraphModel;


namespace Forms.DrawForm
{
    class SaveButton : Button
    {
        public SaveButton()
        {

            Text = "Save that shit";

            Location = new System.Drawing.Point(630, 400);

            Size = new System.Drawing.Size(150, 30);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);

            Graph = new Graph();

        }

        public Graph Graph { get; set; }


        public void ButtonClick(object sender, EventArgs e)
        {
          Graph.SaveGraph();

        }
    }
}
