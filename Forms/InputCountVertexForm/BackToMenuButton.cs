using System;
using System.Collections.Generic;
using System.Text;

namespace Forms
{
    class BackToMenuButton : BackButton
    {
        private Forms.InputCountVertexForm inputCountVertexForm;

        private MatrixGraph matrixGraph;

        private StartForm.StartForm startForm;

        public BackToMenuButton(MatrixGraph matrixGraph, StartForm.StartForm startForm, 
            InputCountVertexForm inputCountVertexForm, string buttonText = "back to menu") : base(buttonText)
        {

            Text = buttonText;

            this.startForm = startForm;

            this.inputCountVertexForm = inputCountVertexForm;

            this.matrixGraph = matrixGraph;

        }


        public override void ButtonClick(object sender, EventArgs e)
        {
            //base.ButtonClick(sender, e);

            matrixGraph.DeleteMatrix();

            inputCountVertexForm.Hide();
            startForm.Show();
            //inputCountVertexForm.Close();
        }
    }
}
