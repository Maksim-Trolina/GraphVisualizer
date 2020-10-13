using System;
using System.Windows.Forms;


namespace Forms
{
    class StartButton : Button
    {

        public StartButton()
        {

            Text = "Matrix";

            Location = new System.Drawing.Point(350, 160);

            Size = new System.Drawing.Size(100, 50);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);            

        }

        public InputCountVertexForm NextForm;

        public StartForm.StartForm StartForm;

        public void ButtonClick(object sender, EventArgs e)
        {
            StartForm.Hide();
            NextForm.ShowDialog();
            StartForm.Close();

        }           
    }
}
