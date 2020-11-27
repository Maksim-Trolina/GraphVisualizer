using System;
using System.Windows.Forms;
using System.Drawing;


namespace Forms
{
    class StartButton : Button
    {
        private StartForm.StartForm startForm;

        private InputCountVertexForm inputCountVertexForm;

        public StartButton(StartForm.StartForm startForm)
        {
            this.startForm = startForm;

            ForeColor = Color.Black;

            this.BackColor = Color.Orange;

            Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));

            FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            Text = "Matrix";

            Location = new System.Drawing.Point(350, 160);

            Size = new System.Drawing.Size(100, 50);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);            

        }


        public void ButtonClick(object sender, EventArgs e)
        {

            inputCountVertexForm = new InputCountVertexForm(startForm);

            inputCountVertexForm.Show();

            startForm.Hide();
            

        }           
    }
}
