using System;
using System.Windows.Forms;


namespace Forms
{
    class StartButton : Button
    {
        private StartForm.StartForm startForm;

        private InputCountVertexForm inputCountVertexForm;

        public StartButton(StartForm.StartForm startForm)
        {
            this.startForm = startForm;          

            Text = "Matrix";

            Location = new System.Drawing.Point(350, 160);

            Size = new System.Drawing.Size(100, 50);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);            

        }


        public void ButtonClick(object sender, EventArgs e)
        {
            inputCountVertexForm = new InputCountVertexForm(startForm);

            startForm.Hide();
            inputCountVertexForm.Show();
            //startForm.Close();

        }           
    }
}
