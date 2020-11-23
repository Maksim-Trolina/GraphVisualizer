using System;
using System.Collections.Generic;
using System.Text;

namespace Forms
{
    class BackToMenuOfInputButton : BackButton
    {
        private Forms.InputCountVertexForm inputCountVertexForm;

        private MatrixGraph matrixGraph;

        private StartForm.StartForm startForm;

        public BackToMenuOfInputButton(MatrixGraph matrixGraph, StartForm.StartForm startForm, 
            InputCountVertexForm inputCountVertexForm, string buttonText = "back to menu") : base(buttonText)
        {

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

            inputCountVertexForm.Hide();
           

        }
    }
}
