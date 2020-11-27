using System;
using System.Drawing;

namespace Forms
{
    class BackToMenuFromInputButton : BackButton
    {
        private Forms.InputCountVertexForm inputCountVertexForm;

        private MatrixGraph matrixGraph;

        private StartForm.StartForm startForm;

        public BackToMenuFromInputButton(MatrixGraph matrixGraph, StartForm.StartForm startForm, 
            InputCountVertexForm inputCountVertexForm, string buttonText = "Menu") : base(buttonText)
        {
            ForeColor = Color.Black;

            this.BackColor = Color.Orange;

            Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));

            FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            Text = buttonText;

            Location = new System.Drawing.Point(10, 410);

            this.startForm = startForm;

            this.inputCountVertexForm = inputCountVertexForm;

            this.matrixGraph = matrixGraph;

        }


        public override void ButtonClick(object sender, EventArgs e)
        {

            matrixGraph.DeleteMatrix();

            startForm.Show();

            inputCountVertexForm.Close();
           

        }
    }
}
